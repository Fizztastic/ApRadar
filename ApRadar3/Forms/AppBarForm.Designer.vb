﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppBarForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppBarForm))
        Me.CloseMenu = New System.Windows.Forms.ToolStrip()
        Me.positionSpacer = New System.Windows.Forms.ToolStripSeparator()
        Me.tsPosition = New System.Windows.Forms.ToolStripLabel()
        Me.tsZone = New System.Windows.Forms.ToolStripLabel()
        Me.zoneSpacer = New System.Windows.Forms.ToolStripSeparator()
        Me.tsClock = New System.Windows.Forms.ToolStripLabel()
        Me.clockSpacer = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRSS = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CheckForNewNewsItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsProcess = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsExit = New System.Windows.Forms.ToolStripButton()
        Me.tsOverlayRadar = New System.Windows.Forms.ToolStripButton()
        Me.MainMenu = New System.Windows.Forms.ToolStrip()
        Me.tsApRadar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsMapped = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsOverlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsCampingMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsChat = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFFXIRemoteChat = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsSpawnAlerts = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSpawnFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsPedometer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRecipeSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsCampedMobBrowser = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsScanDatsForMobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDatItemBrowser = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsMapUpdateCheck = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsCheckForUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsIniGenerator = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsAutoHideBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsSearchProvider = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsWiki = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsAlla = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFFXIAH = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsRecipes = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.tsSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsTargetInfo = New System.Windows.Forms.ToolStripLabel()
        Me.tsAddMob = New System.Windows.Forms.ToolStripButton()
        Me.tsMappedRadar = New System.Windows.Forms.ToolStripButton()
        Me.ApRadarIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ntsMapRadar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsOverlayRadar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsCampingMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsApRadarChat = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsFFXIChatServer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ntsSpawnAlerts = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsSpawnFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ntsRecipeSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsViewTod = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsScanDatsForNewMobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsDatItemBrowser = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsSeperator = New System.Windows.Forms.ToolStripSeparator()
        Me.ntsMapUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ntsActivatePro = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsAboutApRadar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessSeperator = New System.Windows.Forms.ToolStripSeparator()
        Me.ntsSelectProcess = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ntsAutoHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntsExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MouseOverTimer = New System.Windows.Forms.Timer(Me.components)
        Me.processWatchTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CurrentZoneTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CampingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NewsTimer = New System.Windows.Forms.Timer(Me.components)
        Me.testTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CloseMenu.SuspendLayout()
        Me.MainMenu.SuspendLayout()
        Me.NotifyMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'CloseMenu
        '
        Me.CloseMenu.BackColor = System.Drawing.Color.Transparent
        Me.CloseMenu.Dock = System.Windows.Forms.DockStyle.Right
        Me.CloseMenu.GripMargin = New System.Windows.Forms.Padding(0)
        Me.CloseMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.CloseMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CloseMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.positionSpacer, Me.tsPosition, Me.tsZone, Me.zoneSpacer, Me.tsClock, Me.clockSpacer, Me.tsRSS, Me.ToolStripSeparator9, Me.tsProcess, Me.tsExit})
        Me.CloseMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.CloseMenu.Location = New System.Drawing.Point(327, 0)
        Me.CloseMenu.Name = "CloseMenu"
        Me.CloseMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.CloseMenu.Size = New System.Drawing.Size(414, 36)
        Me.CloseMenu.TabIndex = 1
        Me.CloseMenu.Text = "ToolStrip1"
        '
        'positionSpacer
        '
        Me.positionSpacer.Name = "positionSpacer"
        Me.positionSpacer.Size = New System.Drawing.Size(6, 36)
        '
        'tsPosition
        '
        Me.tsPosition.Name = "tsPosition"
        Me.tsPosition.Size = New System.Drawing.Size(95, 33)
        Me.tsPosition.Text = "Pos: X: 0 Y: 0 Z: 0"
        '
        'tsZone
        '
        Me.tsZone.Name = "tsZone"
        Me.tsZone.Size = New System.Drawing.Size(93, 33)
        Me.tsZone.Text = "Zone: 0 - 0:00:00"
        '
        'zoneSpacer
        '
        Me.zoneSpacer.Name = "zoneSpacer"
        Me.zoneSpacer.Size = New System.Drawing.Size(6, 36)
        '
        'tsClock
        '
        Me.tsClock.Name = "tsClock"
        Me.tsClock.Size = New System.Drawing.Size(46, 33)
        Me.tsClock.Text = "3:45PM"
        '
        'clockSpacer
        '
        Me.clockSpacer.Name = "clockSpacer"
        Me.clockSpacer.Size = New System.Drawing.Size(6, 36)
        '
        'tsRSS
        '
        Me.tsRSS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRSS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForNewNewsItemsToolStripMenuItem})
        Me.tsRSS.Image = Global.ApRadar3.My.Resources.Resources.Rss
        Me.tsRSS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsRSS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRSS.Name = "tsRSS"
        Me.tsRSS.Size = New System.Drawing.Size(37, 33)
        Me.tsRSS.Text = "News"
        Me.tsRSS.ToolTipText = "ApRadar News"
        '
        'CheckForNewNewsItemsToolStripMenuItem
        '
        Me.CheckForNewNewsItemsToolStripMenuItem.Name = "CheckForNewNewsItemsToolStripMenuItem"
        Me.CheckForNewNewsItemsToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.CheckForNewNewsItemsToolStripMenuItem.Text = "Check for new news items..."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 36)
        '
        'tsProcess
        '
        Me.tsProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsProcess.ForeColor = System.Drawing.Color.Lime
        Me.tsProcess.Image = CType(resources.GetObject("tsProcess.Image"), System.Drawing.Image)
        Me.tsProcess.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsProcess.Name = "tsProcess"
        Me.tsProcess.Size = New System.Drawing.Size(94, 33)
        Me.tsProcess.Text = "Select Process"
        '
        'tsExit
        '
        Me.tsExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsExit.Image = CType(resources.GetObject("tsExit.Image"), System.Drawing.Image)
        Me.tsExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsExit.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsExit.Name = "tsExit"
        Me.tsExit.Size = New System.Drawing.Size(23, 33)
        Me.tsExit.Text = "Exit"
        '
        'tsOverlayRadar
        '
        Me.tsOverlayRadar.Image = Global.ApRadar3.My.Resources.Resources.RadarIcon
        Me.tsOverlayRadar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsOverlayRadar.Margin = New System.Windows.Forms.Padding(2, 1, 0, 2)
        Me.tsOverlayRadar.Name = "tsOverlayRadar"
        Me.tsOverlayRadar.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.tsOverlayRadar.Size = New System.Drawing.Size(120, 33)
        Me.tsOverlayRadar.Tag = "Item"
        Me.tsOverlayRadar.Text = "Overlay Radar"
        Me.tsOverlayRadar.Visible = False
        '
        'MainMenu
        '
        Me.MainMenu.BackColor = System.Drawing.Color.Transparent
        Me.MainMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsApRadar, Me.ToolStripSeparator1, Me.tsSearchProvider, Me.txtSearch, Me.tsSearch, Me.ToolStripSeparator2, Me.tsTargetInfo, Me.tsAddMob, Me.tsOverlayRadar, Me.tsMappedRadar})
        Me.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(683, 36)
        Me.MainMenu.TabIndex = 2
        Me.MainMenu.Text = "MainMenu"
        '
        'tsApRadar
        '
        Me.tsApRadar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsApRadar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMapped, Me.tsOverlay, Me.tsCampingMode, Me.tsChat, Me.tsFFXIRemoteChat, Me.ToolStripSeparator4, Me.tsSpawnAlerts, Me.tsSpawnFilter, Me.ToolStripSeparator12, Me.tsPedometer, Me.ToolStripSeparator14, Me.tsRecipeSearch, Me.tsDatabase, Me.tsCampedMobBrowser, Me.ToolStripSeparator11, Me.tsSettings, Me.tsScanDatsForMobs, Me.tsDatItemBrowser, Me.ToolStripSeparator5, Me.tsMapUpdateCheck, Me.tsCheckForUpdates, Me.tsIniGenerator, Me.ToolStripSeparator3, Me.tsAbout, Me.ToolStripSeparator6, Me.tsAutoHideBar, Me.ExitToolStripMenuItem})
        Me.tsApRadar.Image = Global.ApRadar3.My.Resources.Resources.ApRadar_32
        Me.tsApRadar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsApRadar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsApRadar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsApRadar.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.tsApRadar.Name = "tsApRadar"
        Me.tsApRadar.ShowDropDownArrow = False
        Me.tsApRadar.Size = New System.Drawing.Size(78, 36)
        Me.tsApRadar.Text = "ApRadar"
        '
        'tsMapped
        '
        Me.tsMapped.Name = "tsMapped"
        Me.tsMapped.Size = New System.Drawing.Size(209, 22)
        Me.tsMapped.Text = "Map Radar"
        '
        'tsOverlay
        '
        Me.tsOverlay.Name = "tsOverlay"
        Me.tsOverlay.Size = New System.Drawing.Size(209, 22)
        Me.tsOverlay.Text = "Overlay Radar"
        '
        'tsCampingMode
        '
        Me.tsCampingMode.CheckOnClick = True
        Me.tsCampingMode.Name = "tsCampingMode"
        Me.tsCampingMode.Size = New System.Drawing.Size(209, 22)
        Me.tsCampingMode.Tag = "pro"
        Me.tsCampingMode.Text = "Camping Mode"
        '
        'tsChat
        '
        Me.tsChat.Name = "tsChat"
        Me.tsChat.Size = New System.Drawing.Size(209, 22)
        Me.tsChat.Text = "ApRadar Chat"
        '
        'tsFFXIRemoteChat
        '
        Me.tsFFXIRemoteChat.Name = "tsFFXIRemoteChat"
        Me.tsFFXIRemoteChat.Size = New System.Drawing.Size(209, 22)
        Me.tsFFXIRemoteChat.Tag = "pro"
        Me.tsFFXIRemoteChat.Text = "FFXI Remote Chat Server"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(206, 6)
        '
        'tsSpawnAlerts
        '
        Me.tsSpawnAlerts.CheckOnClick = True
        Me.tsSpawnAlerts.Name = "tsSpawnAlerts"
        Me.tsSpawnAlerts.Size = New System.Drawing.Size(209, 22)
        Me.tsSpawnAlerts.Tag = "pro"
        Me.tsSpawnAlerts.Text = "Spawn Alerts"
        '
        'tsSpawnFilter
        '
        Me.tsSpawnFilter.Name = "tsSpawnFilter"
        Me.tsSpawnFilter.Size = New System.Drawing.Size(209, 22)
        Me.tsSpawnFilter.Tag = "pro"
        Me.tsSpawnFilter.Text = "Spawn Alert Filter"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(206, 6)
        '
        'tsPedometer
        '
        Me.tsPedometer.Name = "tsPedometer"
        Me.tsPedometer.Size = New System.Drawing.Size(209, 22)
        Me.tsPedometer.Tag = "pro"
        Me.tsPedometer.Text = "Pedometer"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(206, 6)
        '
        'tsRecipeSearch
        '
        Me.tsRecipeSearch.Name = "tsRecipeSearch"
        Me.tsRecipeSearch.Size = New System.Drawing.Size(209, 22)
        Me.tsRecipeSearch.Text = "Recipe Searcher"
        '
        'tsDatabase
        '
        Me.tsDatabase.Name = "tsDatabase"
        Me.tsDatabase.Size = New System.Drawing.Size(209, 22)
        Me.tsDatabase.Text = "Database Browser"
        '
        'tsCampedMobBrowser
        '
        Me.tsCampedMobBrowser.Name = "tsCampedMobBrowser"
        Me.tsCampedMobBrowser.Size = New System.Drawing.Size(209, 22)
        Me.tsCampedMobBrowser.Tag = "pro"
        Me.tsCampedMobBrowser.Text = "View ToD's"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(206, 6)
        '
        'tsSettings
        '
        Me.tsSettings.Name = "tsSettings"
        Me.tsSettings.Size = New System.Drawing.Size(209, 22)
        Me.tsSettings.Text = "Settings"
        '
        'tsScanDatsForMobs
        '
        Me.tsScanDatsForMobs.Name = "tsScanDatsForMobs"
        Me.tsScanDatsForMobs.Size = New System.Drawing.Size(209, 22)
        Me.tsScanDatsForMobs.Text = "Scan dats for new mobs..."
        '
        'tsDatItemBrowser
        '
        Me.tsDatItemBrowser.Name = "tsDatItemBrowser"
        Me.tsDatItemBrowser.Size = New System.Drawing.Size(209, 22)
        Me.tsDatItemBrowser.Text = "Dat Item Browser"
        Me.tsDatItemBrowser.ToolTipText = "Lets you browse the dats for various item types"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(206, 6)
        '
        'tsMapUpdateCheck
        '
        Me.tsMapUpdateCheck.Name = "tsMapUpdateCheck"
        Me.tsMapUpdateCheck.Size = New System.Drawing.Size(209, 22)
        Me.tsMapUpdateCheck.Text = "Check For Map Updates..."
        '
        'tsCheckForUpdates
        '
        Me.tsCheckForUpdates.Name = "tsCheckForUpdates"
        Me.tsCheckForUpdates.Size = New System.Drawing.Size(209, 22)
        Me.tsCheckForUpdates.Text = "Check For Updates..."
        '
        'tsIniGenerator
        '
        Me.tsIniGenerator.Name = "tsIniGenerator"
        Me.tsIniGenerator.Size = New System.Drawing.Size(209, 22)
        Me.tsIniGenerator.Text = "Map INI Line Generator"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(206, 6)
        '
        'tsAbout
        '
        Me.tsAbout.Name = "tsAbout"
        Me.tsAbout.Size = New System.Drawing.Size(209, 22)
        Me.tsAbout.Text = "About ApRadar"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(206, 6)
        '
        'tsAutoHideBar
        '
        Me.tsAutoHideBar.CheckOnClick = True
        Me.tsAutoHideBar.Name = "tsAutoHideBar"
        Me.tsAutoHideBar.Size = New System.Drawing.Size(209, 22)
        Me.tsAutoHideBar.Text = "Auto Hide Bar"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 36)
        '
        'tsSearchProvider
        '
        Me.tsSearchProvider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsSearchProvider.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsWiki, Me.tsAlla, Me.tsFFXIAH, Me.tsItems, Me.tsRecipes})
        Me.tsSearchProvider.Image = CType(resources.GetObject("tsSearchProvider.Image"), System.Drawing.Image)
        Me.tsSearchProvider.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSearchProvider.Name = "tsSearchProvider"
        Me.tsSearchProvider.Size = New System.Drawing.Size(29, 33)
        Me.tsSearchProvider.Tag = "0"
        Me.tsSearchProvider.Text = "Search Provider"
        Me.tsSearchProvider.ToolTipText = "Search Provider"
        '
        'tsWiki
        '
        Me.tsWiki.Image = CType(resources.GetObject("tsWiki.Image"), System.Drawing.Image)
        Me.tsWiki.Name = "tsWiki"
        Me.tsWiki.Size = New System.Drawing.Size(154, 22)
        Me.tsWiki.Tag = "0"
        Me.tsWiki.Text = "FFXIClopedia"
        '
        'tsAlla
        '
        Me.tsAlla.Image = CType(resources.GetObject("tsAlla.Image"), System.Drawing.Image)
        Me.tsAlla.Name = "tsAlla"
        Me.tsAlla.Size = New System.Drawing.Size(154, 22)
        Me.tsAlla.Tag = "1"
        Me.tsAlla.Text = "Allakhazam"
        '
        'tsFFXIAH
        '
        Me.tsFFXIAH.Image = Global.ApRadar3.My.Resources.Resources.ffxiah
        Me.tsFFXIAH.Name = "tsFFXIAH"
        Me.tsFFXIAH.Size = New System.Drawing.Size(154, 22)
        Me.tsFFXIAH.Tag = "4"
        Me.tsFFXIAH.Text = "FFXIAH"
        '
        'tsItems
        '
        Me.tsItems.Image = CType(resources.GetObject("tsItems.Image"), System.Drawing.Image)
        Me.tsItems.Name = "tsItems"
        Me.tsItems.Size = New System.Drawing.Size(154, 22)
        Me.tsItems.Tag = "2"
        Me.tsItems.Text = "Items Database"
        Me.tsItems.Visible = False
        '
        'tsRecipes
        '
        Me.tsRecipes.Image = CType(resources.GetObject("tsRecipes.Image"), System.Drawing.Image)
        Me.tsRecipes.Name = "tsRecipes"
        Me.tsRecipes.Size = New System.Drawing.Size(154, 22)
        Me.tsRecipes.Tag = "3"
        Me.tsRecipes.Text = "Synth Recipes"
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(150, 36)
        '
        'tsSearch
        '
        Me.tsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsSearch.Image = CType(resources.GetObject("tsSearch.Image"), System.Drawing.Image)
        Me.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(23, 33)
        Me.tsSearch.Text = "Search Web"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 36)
        '
        'tsTargetInfo
        '
        Me.tsTargetInfo.ForeColor = System.Drawing.Color.White
        Me.tsTargetInfo.Name = "tsTargetInfo"
        Me.tsTargetInfo.Size = New System.Drawing.Size(60, 33)
        Me.tsTargetInfo.Text = "No Target"
        '
        'tsAddMob
        '
        Me.tsAddMob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsAddMob.ForeColor = System.Drawing.Color.Lime
        Me.tsAddMob.Image = CType(resources.GetObject("tsAddMob.Image"), System.Drawing.Image)
        Me.tsAddMob.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAddMob.Name = "tsAddMob"
        Me.tsAddMob.Size = New System.Drawing.Size(44, 33)
        Me.tsAddMob.Text = "Add +"
        Me.tsAddMob.Visible = False
        '
        'tsMappedRadar
        '
        Me.tsMappedRadar.Image = Global.ApRadar3.My.Resources.Resources.MappedRadar
        Me.tsMappedRadar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsMappedRadar.Margin = New System.Windows.Forms.Padding(2, 1, 0, 2)
        Me.tsMappedRadar.Name = "tsMappedRadar"
        Me.tsMappedRadar.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.tsMappedRadar.Size = New System.Drawing.Size(124, 33)
        Me.tsMappedRadar.Tag = "Item"
        Me.tsMappedRadar.Text = "Mapped Radar"
        Me.tsMappedRadar.Visible = False
        '
        'ApRadarIcon
        '
        Me.ApRadarIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ApRadarIcon.BalloonTipTitle = "ApRadar 3"
        Me.ApRadarIcon.ContextMenuStrip = Me.NotifyMenu
        Me.ApRadarIcon.Icon = CType(resources.GetObject("ApRadarIcon.Icon"), System.Drawing.Icon)
        Me.ApRadarIcon.Visible = True
        '
        'NotifyMenu
        '
        Me.NotifyMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ntsMapRadar, Me.ntsOverlayRadar, Me.ntsCampingMode, Me.ntsApRadarChat, Me.ntsFFXIChatServer, Me.ToolStripSeparator7, Me.ntsSpawnAlerts, Me.ntsSpawnFilter, Me.ToolStripSeparator13, Me.ntsRecipeSearch, Me.ntsDatabase, Me.ntsViewTod, Me.ntsSettings, Me.ntsScanDatsForNewMobs, Me.ntsDatItemBrowser, Me.ntsSeperator, Me.ntsMapUpdates, Me.ntsUpdates, Me.ToolStripSeparator8, Me.ntsActivatePro, Me.ntsAboutApRadar, Me.ProcessSeperator, Me.ntsSelectProcess, Me.ToolStripSeparator10, Me.ntsAutoHide, Me.ntsExit})
        Me.NotifyMenu.Name = "NotifyMenu"
        Me.NotifyMenu.Size = New System.Drawing.Size(208, 480)
        '
        'ntsMapRadar
        '
        Me.ntsMapRadar.Name = "ntsMapRadar"
        Me.ntsMapRadar.Size = New System.Drawing.Size(207, 22)
        Me.ntsMapRadar.Text = "Map Radar"
        '
        'ntsOverlayRadar
        '
        Me.ntsOverlayRadar.Name = "ntsOverlayRadar"
        Me.ntsOverlayRadar.Size = New System.Drawing.Size(207, 22)
        Me.ntsOverlayRadar.Text = "Overlay Radar"
        '
        'ntsCampingMode
        '
        Me.ntsCampingMode.CheckOnClick = True
        Me.ntsCampingMode.Name = "ntsCampingMode"
        Me.ntsCampingMode.Size = New System.Drawing.Size(207, 22)
        Me.ntsCampingMode.Tag = "pro"
        Me.ntsCampingMode.Text = "Camping Mode"
        '
        'ntsApRadarChat
        '
        Me.ntsApRadarChat.Name = "ntsApRadarChat"
        Me.ntsApRadarChat.Size = New System.Drawing.Size(207, 22)
        Me.ntsApRadarChat.Text = "ApRadar Chat"
        '
        'ntsFFXIChatServer
        '
        Me.ntsFFXIChatServer.Name = "ntsFFXIChatServer"
        Me.ntsFFXIChatServer.Size = New System.Drawing.Size(207, 22)
        Me.ntsFFXIChatServer.Tag = "pro"
        Me.ntsFFXIChatServer.Text = "FFXI Remote Chat Server"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(204, 6)
        '
        'ntsSpawnAlerts
        '
        Me.ntsSpawnAlerts.CheckOnClick = True
        Me.ntsSpawnAlerts.Name = "ntsSpawnAlerts"
        Me.ntsSpawnAlerts.Size = New System.Drawing.Size(207, 22)
        Me.ntsSpawnAlerts.Tag = "pro"
        Me.ntsSpawnAlerts.Text = "Spawn Alerts"
        '
        'ntsSpawnFilter
        '
        Me.ntsSpawnFilter.Name = "ntsSpawnFilter"
        Me.ntsSpawnFilter.Size = New System.Drawing.Size(207, 22)
        Me.ntsSpawnFilter.Tag = "pro"
        Me.ntsSpawnFilter.Text = "Spawn Alert Filter"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(204, 6)
        '
        'ntsRecipeSearch
        '
        Me.ntsRecipeSearch.Name = "ntsRecipeSearch"
        Me.ntsRecipeSearch.Size = New System.Drawing.Size(207, 22)
        Me.ntsRecipeSearch.Text = "Recipe Searcher"
        '
        'ntsDatabase
        '
        Me.ntsDatabase.Name = "ntsDatabase"
        Me.ntsDatabase.Size = New System.Drawing.Size(207, 22)
        Me.ntsDatabase.Text = "Database Browser"
        '
        'ntsViewTod
        '
        Me.ntsViewTod.Name = "ntsViewTod"
        Me.ntsViewTod.Size = New System.Drawing.Size(207, 22)
        Me.ntsViewTod.Tag = "pro"
        Me.ntsViewTod.Text = "View ToD's"
        '
        'ntsSettings
        '
        Me.ntsSettings.Name = "ntsSettings"
        Me.ntsSettings.Size = New System.Drawing.Size(207, 22)
        Me.ntsSettings.Text = "Settings"
        '
        'ntsScanDatsForNewMobs
        '
        Me.ntsScanDatsForNewMobs.Name = "ntsScanDatsForNewMobs"
        Me.ntsScanDatsForNewMobs.Size = New System.Drawing.Size(207, 22)
        Me.ntsScanDatsForNewMobs.Text = "Scan Dats For New Mobs"
        '
        'ntsDatItemBrowser
        '
        Me.ntsDatItemBrowser.Name = "ntsDatItemBrowser"
        Me.ntsDatItemBrowser.Size = New System.Drawing.Size(207, 22)
        Me.ntsDatItemBrowser.Text = "Dat Item Browser"
        '
        'ntsSeperator
        '
        Me.ntsSeperator.Name = "ntsSeperator"
        Me.ntsSeperator.Size = New System.Drawing.Size(204, 6)
        '
        'ntsMapUpdates
        '
        Me.ntsMapUpdates.Name = "ntsMapUpdates"
        Me.ntsMapUpdates.Size = New System.Drawing.Size(207, 22)
        Me.ntsMapUpdates.Text = "Check for Map Updates..."
        '
        'ntsUpdates
        '
        Me.ntsUpdates.Name = "ntsUpdates"
        Me.ntsUpdates.Size = New System.Drawing.Size(207, 22)
        Me.ntsUpdates.Text = "Check for Updates..."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(204, 6)
        '
        'ntsActivatePro
        '
        Me.ntsActivatePro.Name = "ntsActivatePro"
        Me.ntsActivatePro.Size = New System.Drawing.Size(207, 22)
        Me.ntsActivatePro.Text = "Activate Pro"
        '
        'ntsAboutApRadar
        '
        Me.ntsAboutApRadar.Name = "ntsAboutApRadar"
        Me.ntsAboutApRadar.Size = New System.Drawing.Size(207, 22)
        Me.ntsAboutApRadar.Text = "About ApRadar"
        '
        'ProcessSeperator
        '
        Me.ProcessSeperator.Name = "ProcessSeperator"
        Me.ProcessSeperator.Size = New System.Drawing.Size(204, 6)
        '
        'ntsSelectProcess
        '
        Me.ntsSelectProcess.Name = "ntsSelectProcess"
        Me.ntsSelectProcess.Size = New System.Drawing.Size(207, 22)
        Me.ntsSelectProcess.Text = "Select Process..."
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(204, 6)
        '
        'ntsAutoHide
        '
        Me.ntsAutoHide.CheckOnClick = True
        Me.ntsAutoHide.Name = "ntsAutoHide"
        Me.ntsAutoHide.Size = New System.Drawing.Size(207, 22)
        Me.ntsAutoHide.Text = "Auto Hide Bar"
        '
        'ntsExit
        '
        Me.ntsExit.Name = "ntsExit"
        Me.ntsExit.Size = New System.Drawing.Size(207, 22)
        Me.ntsExit.Text = "Exit"
        '
        'MouseOverTimer
        '
        '
        'processWatchTimer
        '
        Me.processWatchTimer.Interval = 3000
        '
        'CurrentZoneTimer
        '
        Me.CurrentZoneTimer.Interval = 500
        '
        'CampingTimer
        '
        Me.CampingTimer.Interval = 500
        '
        'NewsTimer
        '
        Me.NewsTimer.Interval = 1800000
        '
        'testTimer
        '
        Me.testTimer.Interval = 10000
        '
        'AppBarForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(741, 36)
        Me.Controls.Add(Me.MainMenu)
        Me.Controls.Add(Me.CloseMenu)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AppBarForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ApRadar"
        Me.TopMost = True
        Me.CloseMenu.ResumeLayout(False)
        Me.CloseMenu.PerformLayout()
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.NotifyMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CloseMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents txtSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsSearchProvider As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsWiki As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsAlla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApRadarIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsPosition As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsTargetInfo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsApRadar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsRecipeSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsDatabase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsOverlayRadar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsMappedRadar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsItems As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsRecipes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MouseOverTimer As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsProcess As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents processWatchTimer As System.Windows.Forms.Timer
    Friend WithEvents tsCampedMobBrowser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsMapUpdateCheck As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsCheckForUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFFXIAH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents positionSpacer As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsZone As System.Windows.Forms.ToolStripLabel
    Friend WithEvents zoneSpacer As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CurrentZoneTimer As System.Windows.Forms.Timer
    Friend WithEvents tsClock As System.Windows.Forms.ToolStripLabel
    Friend WithEvents clockSpacer As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsAddMob As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsMapped As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsOverlay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsAutoHideBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ntsMapRadar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsOverlayRadar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ntsRecipeSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsDatabase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsViewTod As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsSeperator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ntsMapUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ntsActivatePro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsAboutApRadar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessSeperator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ntsSelectProcess As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ntsAutoHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CampingTimer As System.Windows.Forms.Timer
    Friend WithEvents tsCampingMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsCampingMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsChat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFFXIRemoteChat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsApRadarChat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsFFXIChatServer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsRSS As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CheckForNewNewsItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewsTimer As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsScanDatsForMobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents testTimer As System.Windows.Forms.Timer
    Friend WithEvents tsSpawnAlerts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSpawnFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ntsSpawnAlerts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsSpawnFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDatItemBrowser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsScanDatsForNewMobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntsDatItemBrowser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsPedometer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsIniGenerator As System.Windows.Forms.ToolStripMenuItem
End Class
