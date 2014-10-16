﻿Imports FFXIMemory
Imports FFXIMemory.MobData
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports System.Xml.Serialization
Imports System.Windows.Forms
Imports DataLibrary
Imports DataLibrary.ApRadarDataSet
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class AlphaRadarRenderer
    Inherits Component

#Region " MEMBER VARIABLES "
    Private ReadOnly syncObj As New Object()

    
    Private _myLinkMobs As List(Of Contracts.Shared.MobData)

    Private _isInitialized As Boolean
    '    Private _lastMap As Byte = 0
    Private _lastMapFile As String = ""
    Private _trackMob As MobData
    Private _filterPassed As Boolean
   Private _isMobCamped As Boolean

    'Paint variables
    Private _headerString As String
    Private _mobInfo As String
    Private _mobPoint As PointF
    Private _rangePoint As PointF
    Private _displayText As String
    Private _posString As String
    Private _thisMobCamped As Boolean
    Private _mobIDList As List(Of Integer)

    Private _mapCheckWarningShown As Boolean

    Private WithEvents _watcher As Watcher
    Private _mapHeight, _mapWidth As Single
    Private _targetMob As MobData
    Private _vnmLocation As PointF
    Private _lastVNMDistance As Integer
    Private _lastVNMDirection As Direction
    Private _trackRadius As Integer
    Private _vnmRealLoc As PointF
    Private _pedoStart As PointF
    Private _pedoDistX, _pedoDistY As Single
    Private _pedoAngle As Single
    Private _lampMin, _lampMax As Integer
#End Region

#Region " ENUMERATIONS "
    Public Enum RadarTypes
        Mapped
        Overlay
    End Enum

    Public Enum ScanType
        Memory
        Hook
    End Enum
#End Region

#Region " DELEGATES "
    Public Delegate Sub NewMobListEventHandler(ByVal mobs As Contracts.Shared.MobData())
#End Region

#Region " EVENTS "
    Public Event SettingsChanged()

    Public Event NewMobList As NewMobListEventHandler

#End Region

#Region " PROPERTIES "
#Region " -- POL PROCESS INFO "
    'Private _ffxi As FFXI
    '<Browsable(False)> _
    'Public Property FFXI() As FFXI
    '    Get
    '        If _ffxi Is Nothing Then
    '            _ffxi = New FFXI()
    '        End If
    '        Return _ffxi
    '    End Get
    '    Set(ByVal value As FFXI)
    '        _ffxi = value
    '    End Set
    'End Property
    Private Property ParentForm As LayeredForm
#End Region

#Region " -- RADAR PROPERTIES "
    Private WithEvents _settings As RadarSettings
    <Category("Radar Settings")> _
    Public Property Settings() As RadarSettings
        Get
            If _settings Is Nothing Then
                _settings = New RadarSettings
            End If
            Return _settings
        End Get
        Set(ByVal value As RadarSettings)
            _settings = value
        End Set
    End Property

    Private _corePaintData As RadarPaintData
    <Browsable(False)> _
    Private ReadOnly Property CorePaintData() As RadarPaintData
        Get
            If _corePaintData Is Nothing Then
                _corePaintData = New RadarPaintData
            End If
            Return _corePaintData
        End Get
    End Property


    Private Property MyData() As MobData
    Private Property TargetData As MobData

    Private _mobs As List(Of MobData)
    Private ReadOnly Property Mobs() As List(Of MobData)
        Get
            If _mobs Is Nothing Then
                _mobs = New List(Of MobData)()
            End If
            Return _mobs
        End Get
    End Property

    Private _zones As FFXIMemory.Zones
    Private ReadOnly Property Zones() As FFXIMemory.Zones
        Get
            If _zones Is Nothing Then
                _zones = New FFXIMemory.Zones
            End If
            Return _zones
        End Get
    End Property
    <Category("Radar Settings"), _
     Description("Selects the radar type to use.  Mapped Radar or Overlay Radar"), _
     DefaultValue(GetType(RadarTypes), "Mapped")> _
    Public Property RadarType() As RadarTypes = RadarTypes.Mapped

    Private _mapController As MapHandler
    <Browsable(False)> _
    Public ReadOnly Property MapController() As MapHandler
        Get
            If _mapController Is Nothing Then
                _mapController = New MapHandler()
            End If
            Return _mapController
        End Get
    End Property

    <Browsable(False)> _
    Public Property CurrentMapEntry() As MapData

    <Browsable(False)> _
    Public Property MapData As FFXIImageMap

    Private _hooktype As ScanType = ScanType.Memory
    <Category("Radar Settings"), _
     Description("Selects the scanning method to use when searching for mobs"), _
     DefaultValue(GetType(ScanType), "Memory")> _
    Public Property ScanningMethod() As ScanType
        Get
            Return _hooktype
        End Get
        Set(ByVal value As ScanType)
            _hooktype = ScanType.Memory

        End Set
    End Property

    Private WithEvents _settingsForm As SettingsForm
    <Browsable(False)> _
    Public ReadOnly Property SettingsForm() As SettingsForm
        Get
            If _settingsForm Is Nothing OrElse _settingsForm.IsDisposed Then
                _settingsForm = New SettingsForm(Settings)
                AddHandler _settingsForm.propGrid.PropertyValueChanged, AddressOf Setting_Changed
            End If
            Return _settingsForm
        End Get
    End Property

    Private WithEvents _mobTracker As MobTrackerForm
    Private ReadOnly Property MobTracker() As MobTrackerForm
        Get
            If _mobTracker Is Nothing OrElse _mobTracker.IsDisposed Then
                _mobTracker = New MobTrackerForm(Zones)
            End If
            _mobTracker.ZoneID = Settings.CurrentMap
            Return _mobTracker
        End Get
    End Property

    Public Property ProEnabled() As Boolean

    Private _nmList As List(Of String)
    Public Property NMList() As List(Of String)
        Get
            If _nmList Is Nothing Then
                _nmList = New List(Of String)
            End If
            Return _nmList
        End Get
        Set(ByVal value As List(Of String))
            _nmList = value
        End Set
    End Property

    Private Property NMData As DataLibrary.NMList.NotoriousMonstersDataTable
    Public Property TextRendering() As TextRenderingHint = TextRenderingHint.SystemDefault
    Public Property SmoothingMode() As SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
    Public Property CompositingQuality() As CompositingQuality = Drawing2D.CompositingQuality.HighSpeed

    Private Property PartyMembers() As String()

    Private _mapPath As String = My.Settings.MapsLocation
    Public Property MapPath() As String
        Get
            If _mapPath = "/Maps" Then
                My.Settings.MapsLocation = String.Format("{0}/Maps", Application.StartupPath)
                My.Settings.Save()
                _mapPath = My.Settings.MapsLocation
            End If
            Return _mapPath
        End Get
        Set(ByVal value As String)
            If value = "Default" Then
                value = My.Settings.MapsLocation
            End If
            MapController.MapsPath = value
        End Set
    End Property

    Public Property LinkServerRunning() As Boolean

    Private _font As Font = New Font("Lucid Sans Unicode", 11)
    Public Property Font As Font
        Get
            Return _font
        End Get
        Set(ByVal value As Font)
            _font = value
            Settings.Font = FontConverter.ToBase64String(value)
        End Set
    End Property

    Private Property MapAttributes As ImageAttributes
    Public Property MapMatrix As ColorMatrix

    Private _mapZoomedSize As Size = Size.Empty
    Public Property MapZoomedSize As Size
        Get
            Return _mapZoomedSize
        End Get
        Private Set(ByVal value As Size)
            _mapZoomedSize = value
        End Set
    End Property

    Public Property NMforZone As List(Of NM)
    Public Property VNMDirection As Direction
    Private _VNMDistance As Integer
    Public Property VNMDistance As Integer
        Get
            Return _VNMDistance
        End Get
        Set(ByVal value As Integer)
            If value <> _VNMDistance Then
                If MyData IsNot Nothing AndAlso value > 0 AndAlso value <= 300 Then
                    _pedoStart = New PointF(MyData.X, MyData.Y)
                End If
            End If
            _VNMDistance = value
        End Set
    End Property
#End Region
#End Region

#Region " PRIVATE PAINT METHODS "
#Region " MAPPED RADAR PAINT METHODS "
    ''' <summary>
    ''' Paint method for the mapped radar
    ''' </summary>
    ''' <param name="g">The graphics object to use for painting</param>
    ''' <remarks></remarks>
    Private Sub PaintMappedRadar(ByVal g As Graphics)
        Try
            'Check to see if the CurrentMapEntry exists
            If MyData IsNot Nothing Then
                If CurrentMapEntry IsNot Nothing Then
                    PaintWithMap(g)
                End If

                If Settings.ShowPOS Then
                    PaintMyPOS(g)
                End If

            End If

        Catch
        End Try
    End Sub

    Private Sub PaintNoMap(ByVal g As Graphics)
        'There is not entry found so we are goint to use the center of the map
        CorePaintData.XScale = ParentForm.Width / 50
        CorePaintData.YScale = ParentForm.Height / 50
        CorePaintData.CenterPoint = New PointF(ParentForm.Width / 2, ParentForm.Height / 2)
        CorePaintData.MyScaledPosition = CorePaintData.CenterPoint

        PaintMap(g)
        _mobIDList.Clear()
        SyncLock (syncObj)
            For Each Mob In Mobs
                If Not Mob.Filters.MapFiltered Then
                    'Get the mobs distance from my position
                    Mob.XDistance = (Mob.X - MyData.X) * CorePaintData.XScale / 2
                    Mob.YDistance = -(Mob.Y - MyData.Y) * CorePaintData.YScale / 2
                    'Get the radius of the mobs distance path
                    Mob.Radius = Math.Sqrt(Mob.XDistance ^ 2 + Mob.YDistance ^ 2)
                    'Calculate the angle from 0 of the mob

                    If Mob.YDistance <= 0 Then
                        Mob.Degrees = -Math.Acos(Mob.XDistance / Mob.Radius)
                    Else
                        Mob.Degrees = Math.Acos(Mob.XDistance / Mob.Radius)
                    End If

                    Mob.Degrees *= (180 / Math.PI)
                    'Calculate my angle
                    MyData.Degrees = MyData.Direction * (180 / Math.PI)
                    If MyData.Degrees < 0 Then
                        MyData.Degrees += 360
                    End If

                    'Fix the mobs degrees in relation to mine
                    Mob.Degrees -= MyData.Degrees
                    If Mob.Degrees < 0 Then
                        Mob.Degrees += 360
                    End If
                    'Convert the degrees to radians
                    Mob.Degrees *= (Math.PI / 180)

                    'Calculate the x and y coordinates for the radar
                    Mob.MapX = CorePaintData.CenterPoint.X + (Mob.Radius * Math.Cos(Mob.Degrees + CorePaintData.NinetyDegrees))
                    Mob.MapY = CorePaintData.CenterPoint.Y + (Mob.Radius * Math.Sin(Mob.Degrees + CorePaintData.NinetyDegrees))

                    If Mob.MobType = MobTypes.PC Then
                        If Settings.ShowPC OrElse Settings.ShowPartyMembers Then
                            PaintMob(g, Mob)
                        End If
                    Else
                        If Settings.ShowNPC OrElse Settings.ShowMobs OrElse Settings.ShowCampedMobs Then
                            PaintMob(g, Mob)
                        End If
                    End If


                End If

            Next

            'Paint my pointer
            If Settings.ShowMyPointer Then
                PaintMyPointer(g)
            End If
        End SyncLock


    End Sub

    Private Sub PaintWithMap(ByVal g As Graphics)
        'We have an entry so lets use it
        'Set myposition on the map
        CorePaintData.MyPosition = CurrentMapEntry.ConvertPosTo2D(MyData.X, MyData.Y)
        MyData.MapX = CorePaintData.MyPosition.X
        MyData.MapY = CorePaintData.MyPosition.Y
        'Save my scaled position for the map scaled at 0
        CorePaintData.MyScaledPosition = New PointF(CorePaintData.MyPosition.X * CorePaintData.MapScaleX * 2.0F, _
                                                    CorePaintData.MyPosition.Y * CorePaintData.MapScaleY * 2.0F)
        CorePaintData.MapW = ((CorePaintData.MyScaledPosition.X - CorePaintData.CenterPoint.X) / (CorePaintData.MapScaleX)) + CorePaintData.XShift
        CorePaintData.MapH = ((CorePaintData.MyScaledPosition.Y - CorePaintData.CenterPoint.Y) / (CorePaintData.MapScaleY)) + CorePaintData.YShift
        'Paint the map on the background
        PaintMap(g)

        'Paint the ranges
        'Paint the spell casting range
        If Settings.ShowSpell Then
            PaintRange(g, 25, Pens.WhiteSmoke)
        End If
        'Paint the Job Ability range
        If Settings.ShowJobAbility Then
            PaintRange(g, 20, Pens.Yellow)
        End If
        'Paint the aggro range
        If Settings.ShowAggro Then
            PaintRange(g, 15, Pens.Tomato)
        End If
        'Paint the max visible range
        If Settings.ShowVisibleRange Then
            PaintRange(g, 50, Pens.LimeGreen)
        End If

        'Paint the custom ranges
        If Not Settings.CustomRanges Is Nothing Then
            For Each entry In Settings.CustomRanges
                PaintRange(g, entry.Size, New Pen(entry.RangeColor))
            Next
        End If

        If ProEnabled AndAlso Settings.TrackVNM AndAlso VNMDistance > 0 Then
            PaintVnmTracker(g)
        End If

        'Paint my pointer
        If Settings.ShowMyPointer Then
            PaintMyPointer(g)
        End If

        'Paint all the mobs
        SyncLock (syncObj)
            _mobIDList.Clear()
            For Each mob In Mobs
                If Not mob.Filters.MapFiltered OrElse (Settings.AlwaysShowTarget AndAlso Not TargetData Is Nothing AndAlso TargetData.ID <> MyData.ID AndAlso TargetData.ID = mob.ID) Then
                    'Get the mobs relative position on the map
                    _mobPoint = CurrentMapEntry.ConvertPosTo2D(mob.X, mob.Y)
                    If Settings.Zoom = 1.0 Then
                        mob.MapX = _mobPoint.X * CorePaintData.MapScaleX * 2.0F
                        mob.MapY = _mobPoint.Y * CorePaintData.MapScaleY * 2.0F
                    Else

                        mob.MapX = CorePaintData.CenterPoint.X + ((_mobPoint.X * 2.0F / CorePaintData.MapScaleX - CorePaintData.MyPosition.X * 2.0F / CorePaintData.MapScaleX) * _
                            Settings.Zoom) * (CorePaintData.MapScaleX)
                        mob.MapY = CorePaintData.CenterPoint.Y + ((_mobPoint.Y * 2.0F / CorePaintData.MapScaleY - CorePaintData.MyPosition.Y * 2.0F / CorePaintData.MapScaleY) * _
                            Settings.Zoom) * (CorePaintData.MapScaleY)
                    End If

                    If Not TargetData Is Nothing AndAlso TargetData.ID = mob.ID Then
                        _targetMob = mob
                    Else
                        'Paint the mob
                        If mob.MobType = MobTypes.PC Then
                            If Settings.ShowPC OrElse Settings.ShowPartyMembers Then
                                PaintMob(g, mob)
                            End If
                        Else
                            If Settings.ShowNPC OrElse Settings.ShowMobs OrElse Settings.ShowCampedMobs Then
                                PaintMob(g, mob)
                            End If
                        End If
                    End If


                End If
            Next

            'Handle any link mobs
            If LinkServerRunning Then
                ProcessLinkMobs(g)
                _myLinkMobs.Clear()
            End If

            'Paint your current target
            If Not _targetMob Is Nothing Then
                PaintMob(g, _targetMob, True)
                _targetMob = Nothing
            End If
        End SyncLock


    End Sub

    Private Sub ProcessLinkMobs(ByVal g As Graphics)
        For Each MobList As Contracts.Shared.MobData() In LinkMobs.Values
            For Each mob In MobList
                If Not _mobIDList.Contains(mob.ID) Then
                    _mobIDList.Add(mob.ID)
                    'If Settings.NPCFilterType <> RadarSettings.FilterType.None Then
                    Dim filters As String() = Settings.NPCFilter.Split(",")
                    If mob.IsPC OrElse CheckFilter(Settings.NPCFilterType, mob.Name, mob.ID, filters) Then
                        _mobPoint = CurrentMapEntry.ConvertPosTo2D(mob.Pos.X, mob.Pos.Y)
                        If Settings.Zoom = 1.0 Then
                            mob.Pos.MapX = _mobPoint.X * CorePaintData.MapScaleX * 2.0F
                            mob.Pos.MapY = _mobPoint.Y * CorePaintData.MapScaleY * 2.0F
                        Else
                            mob.Pos.MapX = CorePaintData.CenterPoint.X + ((_mobPoint.X * 2.0F / CorePaintData.MapScaleX - CorePaintData.MyPosition.X * 2.0F / CorePaintData.MapScaleX) * _
                            Settings.Zoom) * (CorePaintData.MapScaleX)
                            mob.Pos.MapY = CorePaintData.CenterPoint.Y + ((_mobPoint.Y * 2.0F / CorePaintData.MapScaleY - CorePaintData.MyPosition.Y * 2.0F / CorePaintData.MapScaleY) * _
                                Settings.Zoom) * (CorePaintData.MapScaleY)

                        End If
                        PaintLinkMob(g, mob)
                    End If
                End If
            Next
        Next


    End Sub

    Public Function CalcClientCoordX(ByVal X As Single, ByVal ratio As Single) As Single
        Return (ParentForm.Width / 2) + ((X - MyData.X) * ratio)
    End Function

    Public Function CalcClientCoordY(ByVal Y As Single, ByVal ratio As Single) As Single
        Return (ParentForm.Height / 2) - ((Y - MyData.Y) * ratio)
    End Function


    ''' <summary>
    ''' Paints the map on the background of the control
    ''' </summary>
    ''' <param name="g">The graphics object used for painting</param>
    ''' <remarks></remarks>
    Private Sub PaintMap(ByVal g As Graphics)
        If Not Me.MapData Is Nothing AndAlso Not MapData.Image Is Nothing Then
            If Settings.Zoom = 1 Then
                'Me.BackgroundImage = MapImage
                Me.MapZoomedSize = Size.Empty
                g.DrawImage(MapData.Image, _
                            ParentForm.ClientRectangle, _
                            0.0F, 0.0F, MapData.Image.Width, MapData.Image.Height, _
                            GraphicsUnit.Pixel, Settings.MapAttributes)
            Else
                'Dim mapBounds = Me.MapData.CheckedBounds
                'Dim clientBounds = Me.ParentForm.ClientRectangle

                'Dim xRatio As Single = clientBounds.Width / mapBounds.Width
                'Dim yRatio As Single = clientBounds.Height / mapBounds.Height

                'Dim ratio As Single
                'If xRatio < yRatio Then
                '    ratio = xRatio / Settings.Zoom
                'Else
                '    ratio = yRatio / Settings.Zoom
                'End If


                'Original Values
                'Dim xZoom As Single = MapData.Image.Width / Settings.Zoom
                'Dim yZoom As Single = MapData.Image.Height / Settings.Zoom
                'Dim xShift As Single = (MapData.Image.Width - xZoom) / 2.0F
                'Dim yShift As Single = (MapData.Image.Height - yZoom) / 2.0F

                Dim xZoom As Single = ParentForm.Width / Settings.Zoom
                Dim yZoom As Single = ParentForm.Height / Settings.Zoom
                Dim xShift As Single = (MapData.Image.Width - xZoom) / 2.0F
                Dim yShift As Single = (MapData.Image.Height - yZoom) / 2.0F

                ' Dim img As New Bitmap(Me.Width, Me.Height)
                'Dim ig As Graphics = Graphics.FromImage(img)

                ' Dim img As New Bitmap(Me.Width, Me.Height)
                'Dim ig As Graphics = Graphics.FromImage(img)

                Me.MapZoomedSize = New Size((MapData.Image.Width * Settings.Zoom) - (xShift + CorePaintData.MapW), (MapData.Image.Height * Settings.Zoom) - (yShift + CorePaintData.MapH))

                g.DrawImage(MapData.Image, _
                            New Rectangle(0, 0, ParentForm.Width, ParentForm.Height), _
                            xShift + CorePaintData.MapW, yShift + CorePaintData.MapH, xZoom, yZoom, _
                            GraphicsUnit.Pixel, Settings.MapAttributes)

                'Dim dest As RectangleF = RectangleF.FromLTRB(
                '    CalcClientCoordX(MapData.Bounds.Left, ratio),
                '    CalcClientCoordY(MapData.Bounds.Top, ratio),
                '    CalcClientCoordX(MapData.Bounds.Right, ratio),
                '    CalcClientCoordY(MapData.Bounds.Bottom, ratio)
                ')

                'g.DrawImage(mapImage, _
                '            Rectangle.Round(dest), _
                '            0, 0, mapImage.Width, mapImage.Height, _
                '            GraphicsUnit.Pixel, Settings.MapAttributes)
                'Me.BackgroundImageLayout = ImageLayout.Stretch
                'Me.BackgroundImage = img
                'This is not currently implemented as I can't seem to get it looking
                'the way that I want it to.
                'PaintMiniMap(g, shift + CorePaintData.MapW, shift + CorePaintData.MapH, zoomSize)
            End If
        End If


    End Sub

    Private Sub PaintMyPOS(ByVal g As Graphics)
        _posString = String.Format("({0})", CurrentMapEntry.ConvertPosToRelative(MyData.X, MyData.Y))
        g.DrawString(_posString, New Font(Font, FontStyle.Bold), Brushes.Red, 10, 10)
    End Sub

    Private Sub PaintVnmTracker(ByVal g As Graphics)
        If VNMDistance < 300 Then
            If (_lastVNMDirection <> VNMDirection OrElse _lastVNMDistance <> VNMDistance) Then
                _vnmRealLoc = New PointF(_MyData.X, _MyData.Y)
                Dim shift As Double = VNMDistance / Math.Sqrt(2)
                Select Case VNMDirection
                    Case FFXIMemory.Direction.East
                        _vnmRealLoc.X += VNMDistance
                    Case FFXIMemory.Direction.SouthEast
                        _vnmRealLoc.X += shift
                        _vnmRealLoc.Y -= shift
                    Case FFXIMemory.Direction.South
                        _vnmRealLoc.Y -= VNMDistance
                    Case FFXIMemory.Direction.SouthWest
                        _vnmRealLoc.X -= shift
                        _vnmRealLoc.Y -= shift
                    Case FFXIMemory.Direction.West
                        _vnmRealLoc.X -= VNMDistance
                    Case FFXIMemory.Direction.NorthWest
                        _vnmRealLoc.X -= shift
                        _vnmRealLoc.Y += shift
                    Case FFXIMemory.Direction.North
                        _vnmRealLoc.Y += VNMDistance
                    Case FFXIMemory.Direction.NorthEast
                        _vnmRealLoc.X += shift
                        _vnmRealLoc.Y += shift
                End Select

                'Convert the position to map coordinates
                _vnmRealLoc = CurrentMapEntry.ConvertPosTo2D(_vnmRealLoc.X, _vnmRealLoc.Y)

                Dim distance As Double = Math.Abs(Math.Sqrt((_vnmRealLoc.X - _MyData.MapX) ^ 2 + (_vnmRealLoc.Y - _MyData.MapY) ^ 2))
                'get the radius of the area to paint
                _trackRadius = distance * Math.PI / 4
            End If
            _lastVNMDirection = VNMDirection
            _lastVNMDistance = VNMDistance
        End If

        If Settings.Zoom = 1 Then
            _vnmLocation.X = _vnmRealLoc.X * CorePaintData.MapScaleX * 2.0F
            _vnmLocation.Y = _vnmRealLoc.Y * CorePaintData.MapScaleY * 2.0F
        Else
            _vnmLocation.X = CorePaintData.CenterPoint.X + ((_vnmRealLoc.X * 2.0F / CorePaintData.MapScaleX - CorePaintData.MyPosition.X * 2.0F / CorePaintData.MapScaleX) * _
                Settings.Zoom) * (CorePaintData.MapScaleX)
            _vnmLocation.Y = CorePaintData.CenterPoint.Y + ((_vnmRealLoc.Y * 2.0F / CorePaintData.MapScaleY - CorePaintData.MyPosition.Y * 2.0F / CorePaintData.MapScaleY) * _
                Settings.Zoom) * (CorePaintData.MapScaleY)
        End If


        Using Brush = New SolidBrush(Color.FromArgb(128, Settings.NMColor))
            g.FillEllipse(Brush, _vnmLocation.X - _trackRadius * Settings.Zoom, _vnmLocation.Y - _trackRadius * Settings.Zoom, _trackRadius * Settings.Zoom * 2, _trackRadius * Settings.Zoom * 2)
        End Using

        'TODO: Need to clear this after zoning
        If Settings.ShowPedometer AndAlso _pedoStart.X <> 0 AndAlso _pedoStart.Y <> 0 Then
            _pedoDistX = MyData.X - _pedoStart.X
            _pedoDistY = MyData.Y - _pedoStart.Y
            _pedoAngle = -Math.Atan2(_pedoDistY, _pedoDistX)
            Dim s As String = String.Format("{0:0.0} {1:0}° {2}", Math.Sqrt(_pedoDistX ^ 2 + _pedoDistY ^ 2), RadiansToDegrees(_pedoAngle), GetHeading(_pedoAngle))
            Dim sSize = g.MeasureString(s, New Font(Font, FontStyle.Bold))
            g.DrawString(s,
                         New Font(Font, FontStyle.Bold), Brushes.Red, New Point(Me.ParentForm.Width - (sSize.Width + 10), 10))
            sSize = Nothing
            s = Nothing
        End If

    End Sub
#End Region

#Region " OVERLAY RADAR PAINT METHODS "
    ''' <summary>
    ''' Paint method for painting the overlay radar
    ''' </summary>
    ''' <param name="g">The graphics object to use for painting</param>
    ''' <remarks></remarks>
    Private Sub PaintOverlayRadar(ByVal g As Graphics)

        Try
            'Clear the background
            'Paint my character pointer
            If Settings.ShowMyPointer Then
                PaintMyPointer(g)
            End If
            'Paint the ranges 
            'Paint the spell casting range
            If Settings.ShowSpell Then
                PaintRange(g, 25, Pens.WhiteSmoke)
            End If
            'Paint the Job Ability range
            If Settings.ShowJobAbility Then
                PaintRange(g, 20, Pens.Yellow)
            End If
            'Paint the aggro range
            If Settings.ShowAggro Then
                PaintRange(g, 15, Pens.Tomato)
            End If
            'Paint the max visible range
            If Settings.ShowVisibleRange Then
                PaintRange(g, 50, Pens.LimeGreen)
            End If

            'Paint the custom ranges
            If Not Settings.CustomRanges Is Nothing Then
                For Each entry In Settings.CustomRanges
                    PaintRange(g, entry.Size, New Pen(entry.RangeColor))
                Next
            End If
            'Paint all the mobs
            'Ensure that the collection can not be modified by another thread
            SyncLock (syncObj)
                For Each Mob In Mobs
                    If Not Mob.Filters.OverlayFiltered OrElse (Settings.AlwaysShowTarget AndAlso Not TargetData Is Nothing AndAlso TargetData.ID <> MyData.ID AndAlso TargetData.ID = Mob.ID) Then
                        'Get the mobs distance from my position
                        Mob.XDistance = (Mob.X - MyData.X) * CorePaintData.YScale / 2
                        Mob.YDistance = -(Mob.Y - MyData.Y) * CorePaintData.YScale / 2
                        Mob.ZDistance = (Mob.Z - MyData.Z) * CorePaintData.YScale / 2
                        'Get the radius of the mobs distance path
                        'Since we ar dealing with a 3 dimensional plane, we need to handle all 3 distances
                        Mob.Radius = Math.Sqrt(Mob.XDistance ^ 2 + Mob.YDistance ^ 2 + Mob.ZDistance ^ 2) 'Mob.Distance * CorePaintData.YScale / 2 '
                        'Calculate the angle from 0 of the mob
                        If Mob.YDistance <= 0 Then
                            Mob.Degrees = -Math.Acos(Mob.XDistance / Mob.Radius)
                        Else
                            Mob.Degrees = Math.Acos(Mob.XDistance / Mob.Radius)
                        End If


                        Mob.Degrees *= (180 / Math.PI)
                        'Calculate my angle
                        MyData.Degrees = MyData.Direction * (180 / Math.PI)
                        If MyData.Degrees < 0 Then
                            MyData.Degrees += 360
                        End If
                        'Fix the mobs degrees in relation to mine
                        Mob.Degrees -= MyData.Degrees
                        If Mob.Degrees < 0 Then
                            Mob.Degrees += 360
                        End If
                        'Convert the degrees to radians
                        Mob.Degrees *= (Math.PI / 180)
                        'Calculate the x and y coordinates for the radar
                        Mob.MapX = CorePaintData.CenterPoint.X + (Mob.Radius * Math.Cos(Mob.Degrees + CorePaintData.NinetyDegrees))
                        Mob.MapY = CorePaintData.CenterPoint.Y + (Mob.Radius * Math.Sin(Mob.Degrees + CorePaintData.NinetyDegrees))

                        If Not TargetData Is Nothing AndAlso TargetData.ID = Mob.ID Then
                            _targetMob = Mob
                        Else
                            'Paint the mob
                            If Mob.MobType = MobTypes.PC Then
                                If Settings.ShowPC OrElse Settings.ShowPartyMembers Then
                                    PaintMob(g, Mob)
                                End If
                            Else
                                If Settings.ShowNPC OrElse Settings.ShowMobs OrElse Settings.ShowCampedMobs Then
                                    PaintMob(g, Mob)
                                End If
                            End If
                        End If


                    End If
                Next

                'Paint your current target
                If Not _targetMob Is Nothing Then
                    PaintMob(g, _targetMob, True)
                    _targetMob = Nothing
                End If

            End SyncLock
            'Paint the header info
            If Settings.ShowHeaderText Then
                PaintHeaderInfo(g)
            End If

            If Settings.ShowCompass Then
                PaintCompass(g)
            End If

            If Not TargetData Is Nothing Then
                If Settings.ShowTargetInfo Then
                    'Don't paint it if in combat
                    If Settings.HideInfoInCombat Then
                        If MyData.Status <> 1 Then
                            PaintMobData(g, TargetData, TargetData.ClaimedBy, Me.Settings.CurrentMap)
                        End If
                    Else

                        PaintMobData(g, TargetData, TargetData.ClaimedBy, Me.Settings.CurrentMap)
                    End If
                End If
            End If

            'Paint the mob tracker
            If Settings.ShowTracker AndAlso Not _trackMob Is Nothing Then
                PaintMobTracker(g)
            End If


        Catch ex As Exception
            'Debug.Print(Ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Paints the current zone information on the radar
    ''' </summary>
    ''' <param name="g">The graphics object to use for painting</param>
    ''' <remarks></remarks>
    Private Sub PaintHeaderInfo(ByVal g As Graphics)
        If Not TargetData Is Nothing Then
            _headerString = String.Format("Current Zone: [{0}] {1} • Position: X: {2} Y: {3} Z: {4} • Target: [{5}] {6}", _
                                          Settings.CurrentMap.ToString("X2"), _
                                          Zones.GetZoneName(Settings.CurrentMap), _
                                          MyData.X, _
                                          MyData.Y, _
                                          MyData.Z, _
                                          TargetData.ID.ToString("X"), _
                                          TargetData.Name)
        Else
            _headerString = String.Format("Current Zone: [{0}] {1} • Position: X: {2} Y: {3} Z: {4}", _
                                          Settings.CurrentMap.ToString("X2"), _
                                          Zones.GetZoneName(Settings.CurrentMap), _
                                          MyData.X, _
                                          MyData.Y, _
                                          MyData.Z)
        End If
        g.DrawString(_headerString, Settings.DataFont, Settings.ShadowBrush, 128, 8)
        g.DrawString(_headerString, Settings.DataFont, Brushes.Yellow, 127, 7)
    End Sub

    ''' <summary>
    ''' Paints the mob data pane on the window
    ''' </summary>
    ''' <param name="g">the graphics object used for painting</param>
    ''' <param name="Target">The mob Name</param>
    ''' <remarks></remarks>
    Private Sub PaintMobData(ByVal g As Graphics, ByVal Target As MobData, ByVal ClaimedBy As Integer, ByVal Zone As Short)
        Dim name As String = Target.Name
        Try
            Dim mob As MobsRow = (From c In DataAccess.MobData.Mobs Where _
                                  c.MobName = name And c.Zone = Zone).FirstOrDefault
            If Not mob Is Nothing Then
                If ClaimedBy > 0 Then
                    _mobInfo = BuildMobInfo(mob, GetClaimedBy(ClaimedBy))
                Else
                    _mobInfo = BuildMobInfo(mob)
                End If
                Dim size = g.MeasureString(_mobInfo, Settings.DataFont)
                size.Width += 10
                size.Height += 30
                g.FillRectangle(New SolidBrush(Color.FromArgb(80, 43, 56, 63)), New Rectangle(New Point(25, 390), size.ToSize))
                size.Width += 1
                size.Height += 1
                g.DrawRectangle(New Pen(Color.FromArgb(80, Color.Gray), 2), New Rectangle(New Point(25, 390), size.ToSize))
                Dim width As Single = size.Width - 12
                If width > 0 Then
                    Dim hpBar As New RectangleF(30, 390 + size.Height - 20, width * Target.HP / 100, 10)
                    g.FillRectangle(New LinearGradientBrush(hpBar, Color.LimeGreen, Color.Green, LinearGradientMode.Vertical), hpBar)
                    g.DrawRectangle(Pens.White, New Rectangle(30, 390 + size.Height - 20, width, 10))
                    g.DrawString(_mobInfo, Settings.DataFont, Brushes.White, 29, 394)
                End If
            Else
                Dim pc As PCRow = (From c In DataAccess.MobData.PC Where c.ServerID = Target.ServerID).FirstOrDefault
                If Not pc Is Nothing Then
                    If Not pc.IsNotesNull Then
                        _mobInfo = String.Format("{0} : {3}{1}Distance: {2}{1}Notes:{1}{4}", pc.PCName, Environment.NewLine, Target.Distance.ToString("0.0"), pc.ServerID, WordWrap(pc.Notes))
                    Else
                        _mobInfo = String.Format("{0} : {4}{1}Distance: {2}{1}Notes: {3}", pc.PCName, Environment.NewLine, Target.Distance.ToString("0.0"), "", pc.ServerID)
                    End If
                    Dim size = g.MeasureString(_mobInfo, Settings.DataFont)
                    size.Width += 10
                    size.Height += 30
                    g.FillRectangle(New SolidBrush(Color.FromArgb(80, 43, 56, 63)), New Rectangle(New Point(25, 390), size.ToSize))
                    size.Width += 1
                    size.Height += 1
                    g.DrawRectangle(New Pen(Color.FromArgb(80, Color.Gray), 2), New Rectangle(New Point(25, 390), size.ToSize))
                    Dim width As Single = size.Width - 12
                    If width > 0 Then
                        Dim hpBar As New RectangleF(30, 390 + size.Height - 20, width * Target.HP / 100, 10)
                        g.FillRectangle(New LinearGradientBrush(hpBar, Color.LimeGreen, Color.Green, LinearGradientMode.Vertical), hpBar)
                        g.DrawRectangle(Pens.White, New Rectangle(30, 390 + size.Height - 20, width, 10))
                        g.DrawString(_mobInfo, Settings.DataFont, Brushes.White, 29, 394)
                    End If
                End If
            End If
        Catch ex As Exception
            'Debug.Print(Ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Paints the compass on the radar
    ''' </summary>
    ''' <param name="g">The graphics object used for painting</param>
    ''' <remarks></remarks>
    Private Sub PaintCompass(ByVal g As Graphics)
        Dim dirFixed As Single
        Dim CompassPoint As New Point
        For i = 1 To 4
            Select Case i
                Case 1 'DRAW NORTH
                    'GET THE NEW ANGLE FOR THE MOB
                    dirFixed = -90 - MyData.Degrees
                Case 2 'DRAW WEST
                    dirFixed = 180 - MyData.Degrees
                Case 3 'DRAW SOUTH
                    dirFixed = 90 - MyData.Degrees
                Case 4 'DRAW EAST
                    dirFixed = 0 - MyData.Degrees
                Case Else

            End Select

            If dirFixed < -360 Then
                dirFixed = (dirFixed + 360)
            End If

            'GET THE ANGLE IN RADIANS
            dirFixed = dirFixed * (Math.PI / 180)

            'PLOT THE POSITION CHANGING 90 DEGREES TO THE 0 POINT
            CompassPoint.Y = CorePaintData.CenterPoint.Y + ((23.5 * CorePaintData.YScale) * Math.Sin(dirFixed + CorePaintData.NinetyDegrees))
            CompassPoint.X = CorePaintData.CenterPoint.X + ((23.5 * CorePaintData.XScale) * Math.Cos(dirFixed + CorePaintData.NinetyDegrees))

            Select Case i
                Case 1 'DRAW NORTH
                    g.DrawString("N", Font, Brushes.White, CompassPoint)
                Case 2 'DRAW WEST
                    g.DrawString("W", Font, Brushes.White, CompassPoint)
                Case 3 'DRAW SOUTH
                    g.DrawString("S", Font, Brushes.White, CompassPoint)
                Case 4 'DRAW EAST
                    g.DrawString("E", Font, Brushes.White, CompassPoint)
                Case Else

            End Select
        Next
    End Sub

    Private Sub PaintMobTracker(ByVal g As Graphics)
        If Not _trackMob Is Nothing Then
            Dim myDirection As Double = -(MyData.Direction * (180 / Math.PI) - 90)
            Dim direction As Double = Math.Atan2(MyData.Y - _trackMob.Y, MyData.X - _trackMob.X) * (180 / Math.PI)
            Dim centerPoint As New PointF(ParentForm.Width / 2, 150)
            g.TranslateTransform(centerPoint.X, centerPoint.Y, MatrixOrder.Prepend)
            g.RotateTransform(myDirection - direction)
            DrawArrow(g)
            g.ResetTransform()
            Dim name As String = String.Format("{0} {1}", _trackMob.Name, Math.Round(Math.Sqrt((MyData.X - _trackMob.X) ^ 2 + (MyData.Y - _trackMob.Y) ^ 2), 1))
            Dim s = g.MeasureString(name, Font)
            g.DrawString(name, Font, Brushes.Lime, centerPoint.X - (s.Width / 2), 180)

        End If
    End Sub

    Private Sub DrawArrow(ByVal g As Graphics)
        Dim pts As Point() = { _
            New Point(-20, -10), _
            New Point(0, -10), _
            New Point(0, -20), _
            New Point(20, 0), _
            New Point(0, 20), _
            New Point(0, 10), _
            New Point(-20, 10) _
        }
        g.FillPolygon(Brushes.LimeGreen, pts)
        g.DrawPolygon(New Pen(Color.Red, 2), pts)
    End Sub
#End Region

#Region " SHARED PAINT METHODS "

    Public Sub PaintRadar(ByVal g As Graphics, ByVal MobList As MobList)
        Try

            ProcessMobList(MobList)

            g.SmoothingMode = SmoothingMode.HighQuality
            'g.SmoothingMode = SmoothingMode
            'g.TextRenderingHint = TextRendering
            'g.CompositingQuality = CompositingQuality

            'Set the center point of the control for painting later
            CorePaintData.CenterPoint = New PointF(CSng(ParentForm.Width) / 2.0F, CSng(ParentForm.Height) / 2.0F)

            'Set the current map
            Settings.CurrentMap = MemoryScanner.Scanner.CurrentMap

            'Set the scale
            If RadarType = RadarTypes.Mapped Then
                'Get the x and y scale

                'Dim size As New SizeF(512.0F, 512.0F)
                If Not Me.MapData Is Nothing AndAlso Not Me.MapData.Image Is Nothing Then
                    _mapHeight = MapData.Image.Height
                    _mapWidth = MapData.Image.Width
                Else
                    _mapHeight = 512.0F
                    _mapWidth = 512.0F
                End If
                'Dim xZoom As Single = MapData.Image.Width / Settings.Zoom
                'Dim yZoom As Single = MapData.Image.Height / Settings.Zoom
                'Dim xShift As Single = (MapData.Image.Width - xZoom) / 2.0F
                'Dim yShift As Single = (MapData.Image.Height - yZoom) / 2.0F
                CorePaintData.XScale = CSng(ParentForm.Width) / _mapWidth * Settings.Zoom
                CorePaintData.YScale = CSng(ParentForm.Height) / _mapHeight * Settings.Zoom
                'Get the map scale values
                CorePaintData.MapScaleX = CSng(ParentForm.Width) / _mapWidth
                CorePaintData.MapScaleY = CSng(ParentForm.Height) / _mapHeight
                PaintMappedRadar(g)
            Else
                CorePaintData.XScale = CSng(ParentForm.Width) / 50.0F
                CorePaintData.YScale = CSng(ParentForm.Height) / 50.0F
                PaintOverlayRadar(g)
            End If
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Paints the triangle for player position in the center of the radar
    ''' </summary>
    ''' <param name="g">The graphics object used for painting</param>
    ''' <remarks></remarks>
    Private Sub PaintMyPointer(ByVal g As Graphics)
        If RadarType = RadarTypes.Mapped Then
            Dim path As New GraphicsPath()


            'rotate it 90° clockwise using the center of the object
            '_pointerEnd.Y = (Math.Sin(MyData.Direction) * 10.0F)
            '_pointerEnd.X = (_pointerEnd.Y / Math.Tan(MyData.Direction))
            Using rot As New Matrix()
                Dim degrees As Single = MyData.Direction * 180 / Math.PI
                If Settings.Zoom = 1 Then
                    path.AddPolygon(New Point() {New Point(CorePaintData.MyScaledPosition.X, CorePaintData.MyScaledPosition.Y + 2), New Point(CorePaintData.MyScaledPosition.X - 6, CorePaintData.MyScaledPosition.Y + 6), New Point(CorePaintData.MyScaledPosition.X, CorePaintData.MyScaledPosition.Y - 10), New Point(CorePaintData.MyScaledPosition.X + 6, CorePaintData.MyScaledPosition.Y + 6)})
                    rot.RotateAt(degrees + 90, CorePaintData.MyScaledPosition)
                    'g.FillEllipse(Brushes.Green, CorePaintData.MyScaledPosition.X - 3.0F, CorePaintData.MyScaledPosition.Y - 3.0F, 6, 6)
                    'g.DrawLine(New Pen(Color.Green, 2), CorePaintData.MyScaledPosition.X, CorePaintData.MyScaledPosition.Y, CorePaintData.MyScaledPosition.X + _pointerEnd.X, CorePaintData.MyScaledPosition.Y + _pointerEnd.Y)
                Else
                    path.AddPolygon(New Point() {New Point(CorePaintData.CenterPoint.X + CorePaintData.XShift * 2, CorePaintData.CenterPoint.Y + CorePaintData.YShift * 2 + 2),
                                                 New Point(CorePaintData.CenterPoint.X + CorePaintData.XShift * 2 - 6, CorePaintData.CenterPoint.Y + CorePaintData.YShift * 2 + 6),
                                                 New Point(CorePaintData.CenterPoint.X + CorePaintData.XShift * 2, CorePaintData.CenterPoint.Y + CorePaintData.YShift * 2 - 10),
                                                 New Point(CorePaintData.CenterPoint.X + CorePaintData.XShift * 2 + 6, CorePaintData.CenterPoint.Y + CorePaintData.YShift * 2 + 6)})
                    rot.RotateAt(degrees + 90, CorePaintData.CenterPoint)
                    'g.FillEllipse(Brushes.Green, CorePaintData.CenterPoint.X - 3.0F, CorePaintData.CenterPoint.Y - 3.0F, 6, 6)
                    'g.DrawLine(New Pen(Color.Green, 2), CorePaintData.CenterPoint.X, CorePaintData.CenterPoint.Y, CorePaintData.CenterPoint.X + _pointerEnd.X, CorePaintData.CenterPoint.Y + _pointerEnd.Y)
                End If
                path.Transform(rot)
            End Using
            g.FillPath(Brushes.Green, path)
            '
            'rot.RotateAt(90, New PointF(Me.Width / 2, Me.Height / 2))
            'path.Transform(rot)
        Else
            'Fill the pointer polygon
            g.FillPolygon(Brushes.Green, _
                          New PointF() {New PointF(CorePaintData.CenterPoint.X - 4, _
                                                   CorePaintData.CenterPoint.Y + 6), _
                                        New PointF(CorePaintData.CenterPoint.X, _
                                                   CorePaintData.CenterPoint.Y - 6), _
                                        New PointF(CorePaintData.CenterPoint.X + 4, _
                                                   CorePaintData.CenterPoint.Y + 6)})
        End If
    End Sub

    Private Sub PaintMob(ByVal g As Graphics, ByVal Mob As MobData)
        PaintMob(g, Mob, False)
    End Sub

    ''' <summary>
    ''' Paints a mob on the radar
    ''' </summary>
    ''' <param name="g">The graphics object to use for painting</param>
    ''' <param name="Mob">The mob data to be painted</param>
    ''' <remarks></remarks>
    Private Sub PaintMob(ByVal g As Graphics, ByVal Mob As MobData, ByVal Highlight As Boolean)
        'MobDataOverlay.Visible = False
        Try

            'Get the mobs display text
            _displayText = GetDisplayText(Mob)
            Using objectBrush = GetBrush(Mob)
                'Check to see what kind of mob we are painting
                If Mob.MobType = MobData.MobTypes.PC Then  'Paint the PC mob
                    'Paint the pc blip
                    g.FillEllipse(objectBrush, _
                                  CSng(Mob.MapX - (Settings.BlipSize / 2)), _
                                  CSng(Mob.MapY - (Settings.BlipSize / 2)), _
                                  Settings.BlipSize, Settings.BlipSize)

                    'Paint the target ping
                    If Highlight Then
                        DrawOutlineString(g, _displayText, Settings.TargetHighlightColor, Mob.MapX + Settings.BlipSize, _
                                    Mob.MapY - (Settings.BlipSize / 2) - 1, 5)
                    End If
                    g.DrawString(_displayText, _
                                 Font, _
                                 objectBrush, _
                                 Mob.MapX + Settings.BlipSize, _
                                 Mob.MapY - (Settings.BlipSize / 2) - 1)

                Else
                    '


                    'Paint the mob blip
                    If Settings.ShowSight Then
                        Dim dir As Single = Mob.Direction - (MyData.Direction + 90 * Math.PI / 180)
                        Dim endPoint As PointF
                        endPoint.Y = (Math.Sin(dir) * 10.0F)
                        endPoint.X = (endPoint.Y / Math.Tan(dir))
                        g.DrawLine(New Pen(Color.YellowGreen, 2), Mob.MapX, Mob.MapY, Mob.MapX + endPoint.X, Mob.MapY + endPoint.Y)
                    End If

                    'Paint the blip
                    g.FillEllipse(objectBrush, _
                                  CSng(Mob.MapX - (Settings.BlipSize / 2)), _
                                  CSng(Mob.MapY - (Settings.BlipSize / 2)), _
                                  Settings.BlipSize, Settings.BlipSize)

                    'Paint the target pinger if this is my current target
                    If Highlight Then
                        DrawOutlineString(g, _displayText, Settings.TargetHighlightColor, Mob.MapX + Settings.BlipSize, _
                                    Mob.MapY - (Settings.BlipSize / 2) - 1, 5)
                    End If

                    g.DrawString(_displayText, _
                                Font, _
                                objectBrush, _
                                Mob.MapX + Settings.BlipSize, _
                                Mob.MapY - (Settings.BlipSize / 2) - 1)

                End If
            End Using
        Catch ex As Exception

            'Debug.Print(Mob.Name & " : " & ex.Message)
        End Try
    End Sub

    Private Sub DrawOutlineString(ByVal g As Graphics, ByVal s As String, ByVal c As Color, ByVal x As Single, ByVal y As Single, ByVal size As Integer)
        Dim tan As Single = size / 2
        Using b As New SolidBrush(Color.FromArgb(15, c))
            For bx As Integer = 0 To size
                For by As Integer = 0 To size
                    g.DrawString(s, Me.Font, b, x - tan + bx, y - tan + by)
                Next
            Next
        End Using
    End Sub

    Private Sub PaintLinkMob(ByVal g As Graphics, ByVal mob As Contracts.Shared.MobData)
        'Paint the pc blip
        Using brush As New SolidBrush(Settings.LinkColor)
            If mob.IsPC Then
                brush.Color = Settings.PCColor
            End If
            g.FillEllipse(brush, _
                          CSng(mob.Pos.MapX - (Settings.BlipSize / 2)), _
                          CSng(mob.Pos.MapY - (Settings.BlipSize / 2)), _
                          Settings.BlipSize, Settings.BlipSize)
            _displayText = GetLinkDisplayText(mob)
            If _displayText <> String.Empty Then
                g.DrawString(_displayText, _
                             Font, _
                             brush, _
                             mob.Pos.MapX + Settings.BlipSize, _
                             mob.Pos.MapY - (Settings.BlipSize / 2) - 1)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Paints a range on the radar
    ''' </summary>
    ''' <param name="g">The graphics object used for painting</param>
    ''' <param name="Range">The radius of the range</param>
    ''' <param name="pen">The pen used for drawing the line</param>
    ''' <remarks></remarks>
    Private Sub PaintRange(ByVal g As Graphics, ByVal Range As Single, ByVal pen As Pen)
        If RadarType = RadarTypes.Mapped Then
            _rangePoint = CurrentMapEntry.ConvertPosTo2D(MyData.X - Range, MyData.Y - Range)

            _rangePoint.X = (MyData.MapX - _rangePoint.X) * 2.0F
            _rangePoint.Y = (MyData.MapY - _rangePoint.Y) * 2.0F
            Dim pointX, pointY As Single
            Using Brush = New SolidBrush(Color.FromArgb(64, pen.Color))

                If Settings.Zoom = 1.0F Then
                    pointX = MyData.MapX * CorePaintData.MapScaleX * 2
                    pointY = MyData.MapY * CorePaintData.MapScaleY * 2
                    If Settings.RangeDisplay = RadarSettings.RangeType.Solid Then
                        g.FillEllipse(New SolidBrush(Color.FromArgb(64, pen.Color)), pointX - _rangePoint.X, _
                                      pointY - _rangePoint.Y, _
                                      _rangePoint.X * 2, _
                                      _rangePoint.Y * 2)
                    Else
                        g.DrawEllipse(pen, pointX - _rangePoint.X, _
                                      pointY - _rangePoint.Y, _
                                      _rangePoint.X * 2, _
                                      _rangePoint.Y * 2)
                    End If
                Else
                    If Settings.RangeDisplay = RadarSettings.RangeType.Solid Then
                        g.FillEllipse(New SolidBrush(Color.FromArgb(64, pen.Color)),
                                      CorePaintData.CenterPoint.X - (_rangePoint.X * Settings.Zoom), _
                                      CorePaintData.CenterPoint.Y - (_rangePoint.Y * Settings.Zoom), _
                                      _rangePoint.X * 2 * Settings.Zoom, _
                                      _rangePoint.Y * 2 * Settings.Zoom) '* CorePaintData.MapScaleY
                    Else
                        g.DrawEllipse(pen,
                                      CorePaintData.CenterPoint.X - (_rangePoint.X * Settings.Zoom), _
                                      CorePaintData.CenterPoint.Y - (_rangePoint.Y * Settings.Zoom), _
                                      _rangePoint.X * 2 * Settings.Zoom, _
                                      _rangePoint.Y * 2 * Settings.Zoom)

                        'CorePaintData.CenterPoint.X + CorePaintData.XShift - (_rangePoint.X * Settings.Zoom) * CorePaintData.MapScaleX, _
                        'CorePaintData.CenterPoint.Y + CorePaintData.YShift - (_rangePoint.Y * Settings.Zoom) * CorePaintData.MapScaleY, _
                        '_rangePoint.X * 2 * Settings.Zoom * CorePaintData.MapScaleX, _
                        '_rangePoint.Y * 2 * Settings.Zoom * CorePaintData.MapScaleY)
                    End If
                End If
            End Using

        Else
            g.DrawEllipse(pen, CorePaintData.CenterPoint.X - (Range * CorePaintData.YScale / 2), _
                            CorePaintData.CenterPoint.Y - (Range * CorePaintData.YScale / 2), _
                            Range * CorePaintData.YScale, Range * CorePaintData.YScale)
        End If
    End Sub
#End Region
#End Region

#Region " PRIVATE METHODS "
    ''' <summary>
    ''' Processes the incoming mob list and filters out mobs that should not be shown
    ''' </summary>
    ''' <param name="InMobs">The incoming mob list</param>
    Private Sub ProcessMobList(ByVal InMobs As MobList)
        'Lock it down to prevent dual access to the moblist
        If Not InMobs Is Nothing Then
            MyData = InMobs.Item(MemoryScanner.Scanner.MyID)
            TargetData = InMobs.Item(MemoryScanner.Scanner.TargetID)


            'Clear the link mobs if we are running the link server
            If LinkServerRunning Then
                _myLinkMobs.Clear()
            End If

            SyncLock (syncObj)
                Me.Mobs.Clear()
                Me.Mobs.AddRange(InMobs.ToClonedArray)
                'Make sure we are either in overlay radar or we are using a good map
                If RadarType = RadarTypes.Overlay OrElse CheckMap() Then
                    'If Settings.ShowNPC OrElse Settings.ShowMobs OrElse Settings.ShowPC OrElse Settings.ShowPartyMemebrs Then
                    'Lets check on showing party members
                    'If RadarType = RadarTypes.Mapped Then
                    '    SerializeMobs("C:\MappedMobs.xml")
                    'Else
                    '    SerializeMobs("C:\OverlayMobs.xml")
                    'End If

                    For Each mob In Me.Mobs
                        mob.Filters.MapFiltered = False
                        mob.Filters.OverlayFiltered = False

                        If (Settings.ShowNPC OrElse Settings.ShowMobs OrElse Settings.ShowCampedMobs) OrElse (mob.MobType = MobData.MobTypes.PC AndAlso (Settings.ShowPC OrElse Settings.ShowPartyMembers)) Then
                            If Settings.HideOtherFloors AndAlso Math.Abs(mob.Z - MyData.Z) >= 6 Then
                                'We are hiding mobs on other floors, so lets filter this one out and move on
                                FilterMob(mob)
                            Else
                                If mob.MobType = MobData.MobTypes.PC Then
                                    If ((Settings.ShowPC Or Settings.ShowPartyMembers) AndAlso (Settings.ShowAll OrElse (mob.WarpInfo > 0 AndAlso mob.ID <> MyData.ID))) Then
                                        'Check to see if we have the setting to only show party members
                                        If Settings.ShowPartyMembers Then
                                            If Not mob.SpawnType And SpawnTypes.GroupMember = SpawnTypes.GroupMember AndAlso Not mob.SpawnType And SpawnTypes.AllianceMember = SpawnTypes.AllianceMember Then
                                                FilterMob(mob)
                                            End If
                                        End If

                                        If Settings.PCFilterType <> RadarSettings.FilterType.None AndAlso Not Settings.PCFilter Is Nothing Then
                                            'Grab each of the filter conditions
                                            Dim filters As String() = Settings.PCFilter.Split(",")
                                            'Check the filter type
                                            If Not CheckFilter(Settings.PCFilterType, mob.Name, mob.ID, filters) Then
                                                FilterMob(mob)
                                            End If
                                        End If
                                    Else
                                        FilterMob(mob)
                                    End If
                                Else
                                    _isMobCamped = False
                                    'Lets check if the mob is camped
                                    If Me.Settings.ShowCampedMobs AndAlso (mob.SpawnType = SpawnTypes.Mob) Then
                                        _isMobCamped = CampedMobExists(mob.ServerID)
                                    End If

                                    If (Settings.ShowNPC OrElse Settings.ShowMobs) AndAlso (Settings.ShowAll OrElse (mob.WarpInfo > 0 AndAlso mob.Name <> "NPC" AndAlso mob.HP > 0) OrElse _isMobCamped) Then
                                        If Not Settings.ShowNPC AndAlso (mob.SpawnType And SpawnTypes.NPC) = SpawnTypes.NPC Then
                                            FilterMob(mob)
                                        End If
                                        If Not Settings.ShowMobs AndAlso (mob.SpawnType And SpawnTypes.Mob) = SpawnTypes.Mob Then
                                            FilterMob(mob)
                                        End If

                                        If Settings.HideObjectsOrDoors AndAlso (mob.SpawnType And SpawnTypes.DoorOrObject) = SpawnTypes.DoorOrObject Then
                                            FilterMob(mob)
                                        End If

                                        If Settings.NPCFilterType <> RadarSettings.FilterType.None And Not Settings.NPCFilter Is Nothing Then
                                            Dim filters As String() = Settings.NPCFilter.Split(",")
                                            If Not CheckFilter(Settings.NPCFilterType, mob.Name, mob.ID, filters) Then
                                                FilterMob(mob)
                                            End If
                                        End If

                                    ElseIf Not Settings.ShowNPC AndAlso Not Settings.ShowMobs AndAlso Settings.ShowCampedMobs Then
                                        If Not _isMobCamped Then
                                            FilterMob(mob)
                                        End If
                                    Else
                                        FilterMob(mob)
                                    End If
                                End If
                            End If
                        Else
                            FilterMob(mob)
                        End If

                        If LinkServerRunning AndAlso Me.RadarType = RadarTypes.Mapped And mob.MobType <> MobTypes.PC AndAlso (Settings.ShowAll OrElse (mob.WarpInfo > 0 AndAlso mob.Name <> "NPC" AndAlso mob.HP > 0)) Then
                            _myLinkMobs.Add(New Contracts.Shared.MobData(Settings.CurrentMap, mob.Name, mob.ID, mob.HP, New Contracts.Shared.Position(mob.X, mob.Y, mob.Z)))
                        End If
                    Next

                End If

                'End If
                If LinkServerRunning AndAlso Me.RadarType = RadarTypes.Mapped Then
                    'Add myself since I am not included in the list
                    _myLinkMobs.Add(New Contracts.Shared.MobData(Settings.CurrentMap, MyData.Name, MyData.ID, MyData.HP, New Contracts.Shared.Position(MyData.X, MyData.Y, MyData.Z)) With {.IsPC = True})
                    RaiseEvent NewMobList(_myLinkMobs.ToArray())

                End If

            End SyncLock
        End If
    End Sub

    Private Sub FilterMob(ByVal Mob As MobData)
        If RadarType = RadarTypes.Mapped Then
            Mob.Filters.MapFiltered = True
        Else
            Mob.Filters.OverlayFiltered = True
        End If
    End Sub

    ''' <summary>
    ''' Gets the mob display text
    ''' </summary>
    ''' <param name="mob">The mob object containig the data</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDisplayText(ByVal mob As MobData) As String
        Dim display As String
        _thisMobCamped = False
        'Set the mobs name
        If mob.ID = &H77 Then
            display = String.Empty
        Else
            display = String.Empty
        End If
        If (mob.MobType <> MobData.MobTypes.PC AndAlso Settings.ShowNPCNames) OrElse (mob.MobType = MobData.MobTypes.PC AndAlso Settings.ShowPCNames) Then
            If mob.Name.Length > 24 Then
                display = String.Empty
            End If
            display &= mob.Name
        End If

        'If pro is enabled then and we are in camping mode then Show the death timer
        If Settings.ShowCampedMobs AndAlso ProEnabled Then
            Dim cmd As CampedMob() = CampedMobManager.GetCampedMobs
            Dim cm = (From c In cmd Where c.ServerID = mob.ServerID).FirstOrDefault  'GetCampedMob(mob.ServerID)
            If Not cm Is Nothing AndAlso cm.IsDead AndAlso Not IsDBNull(cm.DeathTime) Then
                Dim deathDate As DateTime
                If DateTime.TryParse(cm.DeathTime, deathDate) Then

                    Dim ts = DateTime.Now.Subtract(deathDate)
                    If ts.Days > 0 Then
                        display = String.Format("{0} {1}:{2}:{3}:{4}", display, ts.Days.ToString("00"), ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"))
                    Else
                        display = String.Format("{0} {1}:{2}:{3}", display, ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"))
                    End If

                    _thisMobCamped = True
                End If
            End If
        End If

        'Show the distance
        If Settings.ShowDistance Then
            display = String.Format("{0} {1}", display, mob.Distance.ToString("0.0"))
        End If
        'Show the HP
        If Settings.ShowHP Then
            display = String.Format("{0} {1}%", display, mob.HP)
        End If
        'Show the id if specified
        If Settings.ShowId AndAlso ProEnabled Then
            display = String.Format("{0} {1}", mob.ID.ToString("X"), display)
        End If
        'Check to see if pro is enabled and show 
        'the nyzle lamp order if so
        If ProEnabled Then
            If Settings.CurrentMap = &H4D Then
                If mob.ID >= _lampMin AndAlso mob.ID <= _lampMax Then
                    display = String.Format("[#{0}] {1}", (mob.ID - _lampMin + 1), display)
                End If
            End If
        End If
        'display = String.Format("{0} [{1}]", display, mob.SpawnType.ToString())
        Return display
    End Function

    Private Function GetLinkDisplayText(ByVal Mob As Contracts.Shared.MobData) As String
        Dim display As String
        If Mob.IsPC Then
            display = Mob.Name
        Else
            display = String.Format("(L) {0}", Mob.Name)
        End If

        If Settings.ShowDistance Then
            display = String.Format("{0} {1:0.0}", display, Math.Sqrt(Math.Abs(MyData.X - Mob.Pos.X) ^ 2 + Math.Abs(MyData.Y - Mob.Pos.Y) ^ 2))
        End If

        If Settings.ShowHP Then
            display = String.Format("{0} {1}%", display, Mob.HP)
        End If
        'Show the id if specified
        If Settings.ShowId AndAlso ProEnabled Then
            display = String.Format("{0} {1}", Mob.ID.ToString("X"), display)
        End If
        'Check to see if pro is enabled and show 
        'the nyzle lamp order if so
        If ProEnabled Then
            If Settings.CurrentMap = &H4D Then
                If Mob.ID >= &H1A4 AndAlso Mob.ID <= &H1A8 Then
                    display = String.Format("[#{0}] {1}", (Mob.ID - &H1A3), display)
                End If
            End If
        End If
        Return display
    End Function

    ''' <summary>
    ''' Gets your current target's data
    ''' </summary>
    ''' <returns>MobData class contianing all the target's info</returns>
    ''' <remarks></remarks>
    Private Function GetTargetInfo() As MobData
        Return TargetData
    End Function

    ''' <summary>
    ''' Builds the mobs display info
    ''' </summary>
    ''' <param name="mob">The mob object used to get the display info</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function BuildMobInfo(ByVal Mob As MobsRow) As String
        Return BuildMobInfo(Mob, String.Empty)
    End Function

    ''' <summary>
    ''' Builds the mobs display info
    ''' </summary>
    ''' <param name="mob">The mob object used to get the display info</param>
    ''' <param name="ClaimedBy">The id of the persont that has the mob claimed</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function BuildMobInfo(ByVal mob As MobsRow, ByVal ClaimedBy As String) As String
        Dim sb As New System.Text.StringBuilder
        sb.Append(mob.MobName)
        If mob.NM Then
            sb.Append(" [NM]")
        End If
        sb.Append(Environment.NewLine)
        If Not mob.IsFamilyNull Then
            sb.Append(String.Format("Family:{0}{0}{1}{2}", ControlChars.Tab, mob.Family & "", Environment.NewLine))
        Else
            sb.Append(String.Format("Family:{0}", Environment.NewLine))
        End If
        If Not mob.IsJobNull Then
            sb.Append(String.Format("Job:{0}{0}{1}{2}", ControlChars.Tab, mob.Job & "", Environment.NewLine))
        Else
            sb.Append(String.Format("Job:{0}", Environment.NewLine))
        End If
        sb.Append(String.Format("Behavior:{0}{0}", ControlChars.Tab))
        sb.Append(GetBehavior(mob))
        sb.Append(Environment.NewLine)
        sb.Append(GetDetection(mob))
        sb.Append(Environment.NewLine)
        sb.Append(String.Format("Level Range:{0}{1}-{2}", ControlChars.Tab, mob.MinLevel, mob.MaxLevel))

        Dim mobId As Integer = mob.MobPK
        Dim items = (From item In DataAccess.MobData.Items Join _
                     itm In DataAccess.MobData.ItemsToMobs On _
                     item.ItemID Equals itm.ItemID Where _
                     itm.MobPK = mobId Select New With {item.ItemName}).ToArray
        If Not items Is Nothing Then
            Dim isFirst As Boolean = True
            sb.Append(Environment.NewLine)
            sb.Append(String.Format("Drops:{0}{0}", ControlChars.Tab))
            For Each item In items
                If isFirst Then
                    sb.Append(item.ItemName & Environment.NewLine)
                    isFirst = False
                Else
                    sb.Append(String.Format("{0}{0}{1}{2}", ControlChars.Tab, item.ItemName, Environment.NewLine))
                End If
            Next
        End If
        If ClaimedBy <> String.Empty Then
            sb.Append(Environment.NewLine)
            sb.Append(String.Format("Claimed By:{0}{1}", ControlChars.Tab, ClaimedBy))
        End If
        'If Not mob.IsNotesNull Then
        '    sb.Append(Environment.NewLine)
        '    sb.Append("Notes:")
        '    sb.Append(Environment.NewLine)
        '    sb.Append(WordWrap(mob.Notes))
        'End If
        Return sb.ToString
    End Function

    ''' <summary>
    ''' Gets the behavior string for the current target
    ''' </summary>
    ''' <param name="Mob"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBehavior(ByVal Mob As MobsRow) As String
        Dim output As String
        If Mob.Aggressive Then
            output = "Aggressive"
        Else
            output = String.Empty
        End If
        If Mob.Links Then
            If output = String.Empty Then
                output = "Links"
            Else
                output &= ", Links"
            End If
        End If
        Return output
    End Function

    ''' <summary>
    ''' Builds the detection string for the current target
    ''' </summary>
    ''' <param name="Mob"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDetection(ByVal Mob As MobsRow) As String
        Dim output As String
        If Mob.DetectsSight Then
            output = "S"
        Else
            output = String.Empty
        End If
        If Mob.DetectsSound Then
            If output = String.Empty Then
                output = "H"
            Else
                output &= ", H"
            End If
        End If
        If Mob.DetectsMagic Then
            If output = String.Empty Then
                output = "M"
            Else
                output &= ", M"
            End If
        End If
        If Mob.DetectsLowHP Then
            If output = String.Empty Then
                output = "↓HP"
            Else
                output &= ", ↓HP"
            End If
        End If
        If Mob.DetectsHealing Then
            If output = String.Empty Then
                output = "Heal"
            Else
                output &= ", Heal"
            End If
        End If
        If Mob.TracksScent Then
            If output = String.Empty Then
                output = "Sc"
            Else
                output &= ", Sc"
            End If
        End If
        If Mob.TrueSight Then
            If output = String.Empty Then
                output = "T(S)"
            Else
                output &= ", T(S)"
            End If
        End If
        If Mob.TrueSound Then
            If output = String.Empty Then
                output = "T(H)"
            Else
                output &= ", T(H)"
            End If
        End If
        If output <> String.Empty Then
            output = String.Format("Detects:{0}{0}{1}", ControlChars.Tab, output)
        End If
        Return output
    End Function

    ''' <summary>
    ''' Gets the name of the player that has the mob claimed
    ''' </summary>
    ''' <param name="ClaimID">The ServerID of the player with claim</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetClaimedBy(ByVal ClaimID As Integer)
        Dim name = (From c In DataAccess.MobData.PC _
                    Where c.ServerID = ClaimID _
                    Select c.PCName).FirstOrDefault
        If name = String.Empty Then
            name = "Unknown"
        End If
        Return name
    End Function

    ''' <summary>
    ''' Checks for the appropriate map image based on your 
    ''' current coordinates.
    ''' </summary>
    ''' <remarks>This function relies on the map.ini</remarks>
    Private Function CheckMap() As Boolean
        Dim isFound As Boolean = False
        Dim ret As Boolean = True
        Dim thisMapFile As String
        Try
            'If Not MyData Is Nothing Then

            'End If
            If MapController.IniFound Then
                If Settings.CurrentMap <> 0 AndAlso MyData IsNot Nothing Then
                    Dim maps = From c In MapController.MapList Where c.Map = Settings.CurrentMap
                    For Each map In maps
                        If map IsNot Nothing AndAlso map.Boxes.Count > 0 Then
                            Dim box = (From c In map.Boxes Where MyData.X >= c.X1 And MyData.X <= c.X2 _
                                        And MyData.Y >= c.Y1 And MyData.Y <= c.Y2 And _
                                        MyData.Z >= c.Z1 And MyData.Z <= c.Z2).FirstOrDefault

                            If box IsNot Nothing Then
                                thisMapFile = String.Format("{0}\{1}_{2}.gif", MapPath, map.Map.ToString("x2"), map.Level)
                                If thisMapFile <> _lastMapFile Then
                                    Me.MapData = New FFXIImageMap(map.Map, thisMapFile, map.IniData.XScale, map.IniData.XModifier, map.IniData.YScale, map.IniData.YModifier)
                                    _lastMapFile = thisMapFile
                                End If
                                CurrentMapEntry = map
                                Settings.MapLevel = map.Level
                                isFound = True
                                Exit For
                            End If

                        End If
                    Next
                End If
                    'For Each map As MapData In MapController.MapList
                    '    If map.Map = Settings.CurrentMap Then
                    '        For Each entry As Box In map.Boxes
                    '            With MyData
                    '                If (.X >= entry.X1 And .X <= entry.X2) AndAlso _
                    '                   (.Y >= entry.Y1 And .Y <= entry.Y2) AndAlso _
                    '                   (.Z >= entry.Z1 And .Z <= entry.Z2) Then

                    '                    thisMapFile = String.Format("{0}\{1}_{2}.gif", MapPath, map.Map.ToString("x2"), map.Level)
                    '                    If thisMapFile <> _lastMapFile Then
                    '                        Me.MapData = New FFXIImageMap(map.Map, thisMapFile, map.IniData.XScale, map.IniData.XModifier, map.IniData.YScale, map.IniData.YModifier)
                    '                        _lastMapFile = thisMapFile
                    '                    End If
                    '                    CurrentMapEntry = map
                    '                    Settings.MapLevel = map.Level
                    '                    isFound = True
                    '                    Exit For
                    '                End If
                    '            End With
                    '        Next
                    '        If isFound Then Exit For
                    '    End If
                    'Next
            Else
                ret = False
                If Not _mapCheckWarningShown Then
                    MessageBox.Show("No Map data found. Please ensure that you have the latest maps and map.ini")
                    _mapCheckWarningShown = True
                End If
            End If
        Catch ex As Exception
            Debug.Print("CheckMap: " & ex.Message)
        Finally
            If Not isFound Then
                If MapPath <> String.Empty Then
                    thisMapFile = String.Format("{0}\0a_0.gif", MapPath)
                    If thisMapFile <> _lastMapFile Then
                        CurrentMapEntry = New MapData() With {.Map = 0, .Level = 0}
                        CurrentMapEntry.IniData.XScale = 1
                        CurrentMapEntry.IniData.XModifier = 128
                        CurrentMapEntry.IniData.YScale = -1
                        CurrentMapEntry.IniData.YModifier = 128
                        Me.MapData = New FFXIImageMap(0, thisMapFile, 1, 128, -1, 128)
                        _lastMapFile = thisMapFile
                    End If

                End If
            End If
        End Try
        Return ret
    End Function

    Private Function GetBrush(ByVal Mob As MobData) As SolidBrush
        If (Mob.SpawnType And SpawnTypes.PC) = SpawnTypes.PC Then
            If (Mob.SpawnType And SpawnTypes.AllianceMember) = SpawnTypes.AllianceMember Then
                Return New SolidBrush(Settings.AllianceColor)
            ElseIf (Mob.SpawnType And SpawnTypes.GroupMember) = SpawnTypes.GroupMember Then
                Return New SolidBrush(Settings.PartyColor)
            Else
                Return New SolidBrush(Settings.PCColor)
            End If
        Else
            If (Mob.SpawnType And SpawnTypes.Mob) = SpawnTypes.Mob Then
                If _thisMobCamped Then
                    Return New SolidBrush(Settings.CampedColor)
                Else
                    If ProEnabled AndAlso NMforZone.Where(Function(c) c.Name = Mob.Name).Count > 0 Then
                        Return New SolidBrush(Settings.NMColor)
                    ElseIf Mob.ClaimedBy > 0 AndAlso Mob.ClaimedBy <> MyData.ServerID Then
                        'The mob is claimed by another character
                        Return New SolidBrush(Color.Purple)
                    ElseIf Mob.ClaimedBy = MyData.ServerID Then
                        'The mob is claimed by me
                        Return New SolidBrush(Color.Green)
                    Else
                        Return New SolidBrush(Settings.MobColor)
                    End If
                End If
            Else
                Return New SolidBrush(Settings.NPCColor)
            End If
        End If
    End Function

    ''' <summary>
    ''' Serializes the radar settings to a file
    ''' </summary>
    ''' <param name="Path">The path to the setttings file</param>
    ''' <remarks>If the file does not exist it will be created and
    ''' if it does exist it will be overwritten</remarks>
    Private Sub SerializeSettings(ByVal Path As String)
        If Not IO.Directory.Exists(IO.Path.GetDirectoryName(Path)) Then
            IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(Path))
        End If
        Dim fs As New FileStream(Path, FileMode.Create)

        Dim s As New XmlSerializer(GetType(RadarSettings))
        s.Serialize(fs, Settings)
        fs.Close()
        fs.Dispose()
    End Sub

    Private Sub SerializeMobs(ByVal Path As String)
        If Not IO.Directory.Exists(IO.Path.GetDirectoryName(Path)) Then
            IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(Path))
        End If
        Dim fs As New FileStream(Path, FileMode.Create)
        Dim s As New XmlSerializer(GetType(List(Of MobData)))
        s.Serialize(fs, Me.Mobs)
        fs.Close()
        fs.Dispose()
    End Sub

    ''' <summary>
    ''' Deserializes the radar settings from a file
    ''' </summary>
    ''' <param name="Path">The path of the settings file</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeserializeSettings(ByVal Path As String) As RadarSettings
        Dim rs As RadarSettings = Nothing
        Dim fs As FileStream = Nothing
        Try
            If IO.File.Exists(Path) Then
                fs = IO.File.OpenRead(Path)
                Dim s As New XmlSerializer(GetType(RadarSettings))
                rs = CType(s.Deserialize(fs), RadarSettings)
                fs.Close()
                fs.Dispose()
            Else
                rs = Nothing
            End If
        Catch ex As Exception
            rs = Nothing
        Finally
            If Not fs Is Nothing Then
                fs.Close()
                fs.Dispose()
            End If
        End Try
        Return rs
    End Function

    Private Function WordWrap(ByVal text As String) As String
        Dim noteItems As String() = text.Split(" ")
        Dim lineLength As Integer = 0
        Dim retValue As String = String.Empty
        For Each item In noteItems
            lineLength += item.Length + 1
            If lineLength >= 40 Then
                retValue &= Environment.NewLine
                retValue &= String.Format("{0} ", item)
                lineLength = 0
            Else
                retValue &= String.Format("{0} ", item)
            End If
        Next
        Return retValue
    End Function

    Private Function CampedMobExists(ByVal MobServerID As Integer) As Boolean
        Try
            Dim cMobs As CampedMob() = CampedMobManager.GetCampedMobs
            Return (From c In cMobs Where c.ServerID = MobServerID AndAlso c.DeathTime <> String.Empty AndAlso c.IsDead).Count > 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function CheckFilter(ByVal FilterType As RadarSettings.FilterType, ByVal MobName As String, ByVal MobID As Integer, ByVal Filters As String()) As Boolean
        Try
            Select Case FilterType
                Case RadarSettings.FilterType.Regular
                    For Each Filter As String In Filters
                        Filter = Filter.ToLower.Trim
                        If MobName.ToLower.Contains(Filter) OrElse MobID.ToString = Filter OrElse MobID.ToString("x2") = Filter Then
                            Return True
                            Exit For
                        End If
                    Next
                Case RadarSettings.FilterType.Reverse
                    _filterPassed = True
                    For Each Filter As String In Filters
                        Filter = Filter.ToLower.Trim
                        If MobName.ToLower.Contains(Filter) OrElse MobID.ToString = Filter OrElse MobID.ToString("x2") = Filter Then
                            _filterPassed = False
                            Exit For
                        End If
                    Next
                    Return _filterPassed
                Case RadarSettings.FilterType.RegEx
                    Try
                        Return Regex.Match(MobName, Settings.NPCFilter).Success
                    Catch
                    End Try
                Case Else
                    Return True
            End Select
        Catch
            Return True
        End Try
    End Function

    Public Function RadiansToDegrees(ByVal Radians As Single) As Single
        Dim degrees As Single = CSng(Radians * (180 / Math.PI)) + 90
        If degrees < 0 Then
            degrees = 360 + degrees
        End If
        Return degrees
    End Function

    Public Function GetHeading(ByVal Direction As Single) As String
        Dim degrees As Single = RadiansToDegrees(Direction)

        If degrees >= 338 Or degrees < 23 Then
            Return "N"
        ElseIf degrees >= 23 AndAlso degrees <= 68 Then
            Return "NE"
        ElseIf degrees > 68 AndAlso degrees <= 113 Then
            Return "E"
        ElseIf degrees > 113 AndAlso degrees <= 158 Then
            Return "SE"
        ElseIf degrees > 158 AndAlso degrees <= 203 Then
            Return "S"
        ElseIf degrees > 203 AndAlso degrees <= 248 Then
            Return "SW"
        ElseIf degrees > 248 AndAlso degrees <= 293 Then
            Return "W"
        ElseIf degrees > 293 AndAlso degrees <= 338 Then
            Return "NW"
        Else
            Return "Error"
        End If
    End Function

    'Private  Sub Mob_StatusChanged(ByVal Mob As MobData, ByVal Status As MobList.MobStatus)
    '    If Status = RadarControls.MobList.MobStatus.Alive Then
    '        'Mob has spawned or shown up on radar so let's notify the client
    '    End If
    'End Sub
#End Region

#Region " PUBLIC METHODS "
    ''' <summary>
    ''' Initializes the radar starting the scan
    ''' </summary>
    ''' <remarks>This must be called when the radar is started</remarks>
    Public Sub InitializeRadar(ByVal ParentForm As LayeredForm)
        'Create a new instance of the mob id list
        'This is used to check my id's against any linked radar mobs
        _mobIDList = New List(Of Integer)
        'Create a new list of my linkmobs
        _myLinkMobs = New List(Of Contracts.Shared.MobData)

        'Create the watcher element and attach it to the scanner
        'This will watch for moblist zonechange and partymembers
        '_watcher = New Watcher(MemoryScanner.WatcherTypes.MobList Or MemoryScanner.WatcherTypes.ZoneChange)
        'MemoryScanner.Scanner.AttachWatcher(_watcher)

        Me.ParentForm = ParentForm

        MapMatrix = New ColorMatrix() With {.Matrix33 = Settings.MapOpacity}
        MapAttributes = New ImageAttributes()
        MapAttributes.SetColorMatrix(MapMatrix)
        'Start the mouse position timer
        'MousePosTimer.Start()

        'Check for the nmlist file
        If Me.ProEnabled Then
            Me.NMData = New DataLibrary.NMList.NotoriousMonstersDataTable()
            Me.NMData.ReadXml(DataLibrary.DataAccess.GetResourceDataStream("NMList.xml"))

            If IO.File.Exists(Application.StartupPath & "\NMList.txt") Then
                NMList.AddRange(IO.File.ReadAllLines(Application.StartupPath & "\NMList.txt"))
            End If
        End If

        'Get the nyzul isle lamp id's
        'Set the default values in case something goes wrong looking them up
        _lampMin = &H1A4
        _lampMax = &H1A8
        'Theses values will change if they add any more mobs to the nyzul zone with a lower id
        'they seem to put all the new mobs at the beginning of the list annoying but it's just how it's done
        Try
            'grab the zones object
            Dim z As New Zones()
            'Get the nyzul zone id
            Dim nyzulID As Short = (From c In z.ZoneList Where c.ZoneName = "Nyzul Isle" Select c.ZoneID).FirstOrDefault()
            If nyzulID > -1 Then
                'Grab the list of mobs for the zone
                Dim mobList = z.GetZoneMobList(nyzulID)
                'make sure there are actually mobs in the list
                If mobList.Count > 0 Then
                    'grab the mobs with name runic lamp
                    Dim q = (From c In mobList Where c.MobName = "Runic Lamp" Select c.MobID).ToList
                    'grab the min
                    _lampMin = q.Min
                    'gram the max
                    _lampMax = q.Max
                End If
            End If
        Catch ex As Exception
            'Do nothing, but don't crash apradar
        End Try

        _isInitialized = True
    End Sub

    Public Sub ResignWatcher()
        If Not _watcher Is Nothing Then
            MemoryScanner.Scanner.DetachWatcher(_watcher)
            _watcher = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Saves the settings to the default path
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveSettings()
        Dim path As String
        If RadarType = RadarTypes.Mapped Then
            path = MappedSettingsPath
        Else
            path = OverlaySettingsPath
        End If
        SaveSettings(path)
    End Sub

    ''' <summary>
    ''' Saves the settings to the path specified
    ''' </summary>
    ''' <param name="Path"></param>
    ''' <remarks></remarks>
    Public Sub SaveSettings(ByVal Path As String)
        SerializeSettings(Path)
    End Sub

    ''' <summary>
    ''' Loads the settings from the default path
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadSettings()
        Dim path As String
        If RadarType = RadarTypes.Mapped Then
            path = MappedSettingsPath
        Else
            path = OverlaySettingsPath
        End If
        LoadSettings(path)
    End Sub

    ''' <summary>
    ''' Loads the setting from the path specified
    ''' </summary>
    ''' <param name="Path"></param>
    ''' <remarks></remarks>
    Public Sub LoadSettings(ByVal Path As String)
        If IO.File.Exists(Path) Then
            Dim rs = DeserializeSettings(Path)
            If Not rs Is Nothing Then
                If Not IsProEnabled Then
                    rs.ShowAll = False
                    rs.ShowId = False
                    rs.ShowCampedMobs = False
                End If
                Settings = rs
                Try
                    Dim tmpFont = FontConverter.FromBase64String(rs.Font)
                    If Not tmpFont Is Nothing Then
                        Font = tmpFont
                    End If
                Catch
                End Try
            Else
                MessageBox.Show("This settings file is invalid or corrupted, Please select a valid settings file.", "Invalid Settings File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Sub SaveIniEntry()
        MapController.WriteEntry(CurrentMapEntry)
    End Sub

    Public Sub ShowSettings()
        SettingsForm.Show()
    End Sub

    Public Sub ShowMobTracker()
        Settings.ShowTracker = True
        MobTracker.Show()
    End Sub

    Private Sub TrackedMobchanged(ByVal ID As Integer) Handles _mobTracker.TrackedMobChanged
        Settings.TrackedMob = ID
        If ID > 0 Then
            ''Get the mob pointer location
            '_fMem.Address = _ffxi.MemLocs("NPCMAP") + (4 * Settings.TrackedMob)
            'Dim tAddress As Integer = _fMem.GetInt32
            For Each mob In Mobs
                If mob.ServerID = ID Then
                    _trackMob = mob
                    Exit For
                End If
            Next
        Else
            _trackMob = Nothing
        End If
    End Sub

    Private Sub TrackedMobFormClosed(ByVal sender As Object, ByVal e As EventArgs) Handles _mobTracker.Disposed
        Settings.ShowTracker = False
    End Sub

    Public Sub SaveCampedMobs()
        CampedMobManager.SaveData()
    End Sub

    Private _linkMobs As Dictionary(Of String, Contracts.Shared.MobData())
    Public ReadOnly Property LinkMobs() As Dictionary(Of String, Contracts.Shared.MobData())
        Get
            If _linkMobs Is Nothing Then
                _linkMobs = New Dictionary(Of String, Contracts.Shared.MobData())
            End If
            Return _linkMobs
        End Get
    End Property

    Public Sub ShiftX(ByVal Ammount As Single)
        CorePaintData.XShift += Ammount
    End Sub

    Public Sub ShiftY(ByVal Ammount As Single)
        CorePaintData.YShift += Ammount
    End Sub

    Public Sub ResetShift()
        CorePaintData.XShift = 0
        CorePaintData.YShift = 0
    End Sub
#End Region

#Region " SETTINGS EVENT HANDLERS "
    Private Sub Setting_Changed(ByVal sender As Object, ByVal e As PropertyValueChangedEventArgs)
        Settings = SettingsForm.propGrid.SelectedObject
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub ZoneChanged(ByVal OldZone As Short, ByVal NewZone As Short) Handles _settings.ZoneChanged
        If NewZone <> 0 Then
            Me.NMforZone = Me.Zones.GetNMListForZone(NewZone).ToList
        End If
    End Sub
#End Region

End Class

