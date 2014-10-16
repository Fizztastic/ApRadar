﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatItemBrowser
    Inherits ApRadar3.ResizableForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatItemBrowser))
        Me.bwFileScanner = New System.ComponentModel.BackgroundWorker()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.dgItems = New System.Windows.Forms.DataGridView()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SlotsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RacesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmsSearch = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsFFXIAH = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsWiki = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.lblHeder = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlProgress = New System.Windows.Forms.Panel()
        Me.lblStatusMessage = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmdClearFilter = New System.Windows.Forms.Button()
        Me.cmdApplyFilter = New System.Windows.Forms.Button()
        Me.txtLevelMax = New System.Windows.Forms.TextBox()
        Me.txtLevelMin = New System.Windows.Forms.TextBox()
        Me.cboJob = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboRace = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSlot = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblItemCount = New System.Windows.Forms.Label()
        Me.cmdAddToDatabase = New System.Windows.Forms.Button()
        Me.bwItemAdder = New System.ComponentModel.BackgroundWorker()
        CType(Me.dgItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsSearch.SuspendLayout()
        Me.HeaderPanel.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProgress.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bwFileScanner
        '
        Me.bwFileScanner.WorkerReportsProgress = True
        Me.bwFileScanner.WorkerSupportsCancellation = True
        '
        'pbLoading
        '
        Me.pbLoading.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLoading.Location = New System.Drawing.Point(39, 172)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(504, 23)
        Me.pbLoading.TabIndex = 9
        '
        'dgItems
        '
        Me.dgItems.AllowUserToAddRows = False
        Me.dgItems.AllowUserToDeleteRows = False
        Me.dgItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgItems.AutoGenerateColumns = False
        Me.dgItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.LevelDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn, Me.SlotsDataGridViewTextBoxColumn, Me.RacesDataGridViewTextBoxColumn, Me.JobsDataGridViewTextBoxColumn, Me.TypeNameDataGridViewTextBoxColumn})
        Me.dgItems.DataSource = Me.bsItems
        Me.dgItems.Location = New System.Drawing.Point(12, 182)
        Me.dgItems.MultiSelect = False
        Me.dgItems.Name = "dgItems"
        Me.dgItems.ReadOnly = True
        Me.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItems.Size = New System.Drawing.Size(584, 334)
        Me.dgItems.TabIndex = 3
        Me.dgItems.Tag = "exclude"
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LevelDataGridViewTextBoxColumn
        '
        Me.LevelDataGridViewTextBoxColumn.DataPropertyName = "Level"
        Me.LevelDataGridViewTextBoxColumn.HeaderText = "Level"
        Me.LevelDataGridViewTextBoxColumn.Name = "LevelDataGridViewTextBoxColumn"
        Me.LevelDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescriptionDataGridViewTextBoxColumn.Visible = False
        '
        'SlotsDataGridViewTextBoxColumn
        '
        Me.SlotsDataGridViewTextBoxColumn.DataPropertyName = "Slots"
        Me.SlotsDataGridViewTextBoxColumn.HeaderText = "Slots"
        Me.SlotsDataGridViewTextBoxColumn.Name = "SlotsDataGridViewTextBoxColumn"
        Me.SlotsDataGridViewTextBoxColumn.ReadOnly = True
        Me.SlotsDataGridViewTextBoxColumn.Visible = False
        '
        'RacesDataGridViewTextBoxColumn
        '
        Me.RacesDataGridViewTextBoxColumn.DataPropertyName = "Races"
        Me.RacesDataGridViewTextBoxColumn.HeaderText = "Races"
        Me.RacesDataGridViewTextBoxColumn.Name = "RacesDataGridViewTextBoxColumn"
        Me.RacesDataGridViewTextBoxColumn.ReadOnly = True
        Me.RacesDataGridViewTextBoxColumn.Visible = False
        '
        'JobsDataGridViewTextBoxColumn
        '
        Me.JobsDataGridViewTextBoxColumn.DataPropertyName = "Jobs"
        Me.JobsDataGridViewTextBoxColumn.HeaderText = "Jobs"
        Me.JobsDataGridViewTextBoxColumn.Name = "JobsDataGridViewTextBoxColumn"
        Me.JobsDataGridViewTextBoxColumn.ReadOnly = True
        Me.JobsDataGridViewTextBoxColumn.Visible = False
        '
        'TypeNameDataGridViewTextBoxColumn
        '
        Me.TypeNameDataGridViewTextBoxColumn.DataPropertyName = "TypeName"
        Me.TypeNameDataGridViewTextBoxColumn.HeaderText = "TypeName"
        Me.TypeNameDataGridViewTextBoxColumn.Name = "TypeNameDataGridViewTextBoxColumn"
        Me.TypeNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.TypeNameDataGridViewTextBoxColumn.Visible = False
        '
        'bsItems
        '
        Me.bsItems.DataSource = GetType(FFXIMemory.Item)
        '
        'cmsSearch
        '
        Me.cmsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsFFXIAH, Me.tsWiki})
        Me.cmsSearch.Name = "cmsSearch"
        Me.cmsSearch.Size = New System.Drawing.Size(153, 70)
        '
        'tsFFXIAH
        '
        Me.tsFFXIAH.Name = "tsFFXIAH"
        Me.tsFFXIAH.Size = New System.Drawing.Size(152, 22)
        Me.tsFFXIAH.Text = "FFXIAH"
        '
        'tsWiki
        '
        Me.tsWiki.Name = "tsWiki"
        Me.tsWiki.Size = New System.Drawing.Size(152, 22)
        Me.tsWiki.Text = "FFXIClopedia"
        '
        'cboType
        '
        Me.cboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Armor", "Weapons", "General Items", "Usable Items", "Puppet Items"})
        Me.cboType.Location = New System.Drawing.Point(12, 39)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(392, 21)
        Me.cboType.TabIndex = 0
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackgroundImage = Global.ApRadar3.My.Resources.Resources.tbg
        Me.HeaderPanel.Controls.Add(Me.lblHeder)
        Me.HeaderPanel.Controls.Add(Me.btnClose)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Padding = New System.Windows.Forms.Padding(5, 0, 6, 0)
        Me.HeaderPanel.Size = New System.Drawing.Size(608, 33)
        Me.HeaderPanel.TabIndex = 4
        '
        'lblHeder
        '
        Me.lblHeder.AutoSize = True
        Me.lblHeder.BackColor = System.Drawing.Color.Transparent
        Me.lblHeder.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeder.ForeColor = System.Drawing.Color.White
        Me.lblHeder.Location = New System.Drawing.Point(9, 6)
        Me.lblHeder.Name = "lblHeder"
        Me.lblHeder.Size = New System.Drawing.Size(115, 18)
        Me.lblHeder.TabIndex = 1
        Me.lblHeder.Text = "Dat Item Browser"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.Image = Global.ApRadar3.My.Resources.Resources.Close
        Me.btnClose.Location = New System.Drawing.Point(586, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(16, 33)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnClose.TabIndex = 0
        Me.btnClose.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Slot"
        '
        'pnlProgress
        '
        Me.pnlProgress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlProgress.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.pnlProgress.Controls.Add(Me.lblStatusMessage)
        Me.pnlProgress.Controls.Add(Me.pbLoading)
        Me.pnlProgress.Location = New System.Drawing.Point(12, 182)
        Me.pnlProgress.Name = "pnlProgress"
        Me.pnlProgress.Size = New System.Drawing.Size(584, 334)
        Me.pnlProgress.TabIndex = 2
        Me.pnlProgress.Visible = False
        '
        'lblStatusMessage
        '
        Me.lblStatusMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusMessage.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusMessage.ForeColor = System.Drawing.Color.White
        Me.lblStatusMessage.Location = New System.Drawing.Point(39, 146)
        Me.lblStatusMessage.Name = "lblStatusMessage"
        Me.lblStatusMessage.Size = New System.Drawing.Size(504, 23)
        Me.lblStatusMessage.TabIndex = 10
        Me.lblStatusMessage.Text = "Loading Data..."
        Me.lblStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.cmdClearFilter)
        Me.GroupBox1.Controls.Add(Me.cmdApplyFilter)
        Me.GroupBox1.Controls.Add(Me.txtLevelMax)
        Me.GroupBox1.Controls.Add(Me.txtLevelMin)
        Me.GroupBox1.Controls.Add(Me.cboJob)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboRace)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboSlot)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(12, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(584, 114)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(92, 16)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(176, 20)
        Me.txtName.TabIndex = 0
        '
        'cmdClearFilter
        '
        Me.cmdClearFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.cmdClearFilter.Location = New System.Drawing.Point(489, 68)
        Me.cmdClearFilter.Name = "cmdClearFilter"
        Me.cmdClearFilter.Size = New System.Drawing.Size(85, 23)
        Me.cmdClearFilter.TabIndex = 7
        Me.cmdClearFilter.Text = "Clear"
        Me.cmdClearFilter.UseVisualStyleBackColor = True
        '
        'cmdApplyFilter
        '
        Me.cmdApplyFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdApplyFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.cmdApplyFilter.Location = New System.Drawing.Point(398, 67)
        Me.cmdApplyFilter.Name = "cmdApplyFilter"
        Me.cmdApplyFilter.Size = New System.Drawing.Size(85, 23)
        Me.cmdApplyFilter.TabIndex = 6
        Me.cmdApplyFilter.Text = "Apply"
        Me.cmdApplyFilter.UseVisualStyleBackColor = True
        '
        'txtLevelMax
        '
        Me.txtLevelMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLevelMax.Location = New System.Drawing.Point(470, 43)
        Me.txtLevelMax.Name = "txtLevelMax"
        Me.txtLevelMax.Size = New System.Drawing.Size(40, 20)
        Me.txtLevelMax.TabIndex = 5
        Me.txtLevelMax.Text = "99"
        '
        'txtLevelMin
        '
        Me.txtLevelMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLevelMin.Location = New System.Drawing.Point(398, 43)
        Me.txtLevelMin.Name = "txtLevelMin"
        Me.txtLevelMin.Size = New System.Drawing.Size(40, 20)
        Me.txtLevelMin.TabIndex = 4
        Me.txtLevelMin.Text = "1"
        '
        'cboJob
        '
        Me.cboJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJob.FormattingEnabled = True
        Me.cboJob.Location = New System.Drawing.Point(398, 16)
        Me.cboJob.Name = "cboJob"
        Me.cboJob.Size = New System.Drawing.Size(176, 21)
        Me.cboJob.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(444, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "To"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(308, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Level"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(308, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Job"
        '
        'cboRace
        '
        Me.cboRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRace.FormattingEnabled = True
        Me.cboRace.Location = New System.Drawing.Point(92, 69)
        Me.cboRace.Name = "cboRace"
        Me.cboRace.Size = New System.Drawing.Size(176, 21)
        Me.cboRace.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Race"
        '
        'cboSlot
        '
        Me.cboSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSlot.FormattingEnabled = True
        Me.cboSlot.Location = New System.Drawing.Point(92, 42)
        Me.cboSlot.Name = "cboSlot"
        Me.cboSlot.Size = New System.Drawing.Size(176, 21)
        Me.cboSlot.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(90, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(235, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Note: You may use % for wildcards in the name filter field"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Name"
        '
        'lblItemCount
        '
        Me.lblItemCount.AutoSize = True
        Me.lblItemCount.ForeColor = System.Drawing.Color.White
        Me.lblItemCount.Location = New System.Drawing.Point(9, 519)
        Me.lblItemCount.Name = "lblItemCount"
        Me.lblItemCount.Size = New System.Drawing.Size(74, 13)
        Me.lblItemCount.TabIndex = 12
        Me.lblItemCount.Text = "0 Items Found"
        '
        'cmdAddToDatabase
        '
        Me.cmdAddToDatabase.Enabled = False
        Me.cmdAddToDatabase.Location = New System.Drawing.Point(410, 38)
        Me.cmdAddToDatabase.Name = "cmdAddToDatabase"
        Me.cmdAddToDatabase.Size = New System.Drawing.Size(176, 23)
        Me.cmdAddToDatabase.TabIndex = 13
        Me.cmdAddToDatabase.Text = "Add To Database"
        Me.cmdAddToDatabase.UseVisualStyleBackColor = True
        '
        'bwItemAdder
        '
        Me.bwItemAdder.WorkerReportsProgress = True
        '
        'DatItemBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(608, 541)
        Me.Controls.Add(Me.cmdAddToDatabase)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlProgress)
        Me.Controls.Add(Me.dgItems)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Controls.Add(Me.lblItemCount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DatItemBrowser"
        Me.Text = "Dat Item Browser"
        CType(Me.dgItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsSearch.ResumeLayout(False)
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProgress.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HeaderPanel As System.Windows.Forms.Panel
    Friend WithEvents lblHeder As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.PictureBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents pbLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents bwFileScanner As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgItems As System.Windows.Forms.DataGridView
    Friend WithEvents bsItems As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlProgress As System.Windows.Forms.Panel
    Friend WithEvents lblStatusMessage As System.Windows.Forms.Label
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LevelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SlotsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RacesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JobsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSlot As System.Windows.Forms.ComboBox
    Friend WithEvents cboJob As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboRace As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClearFilter As System.Windows.Forms.Button
    Friend WithEvents cmdApplyFilter As System.Windows.Forms.Button
    Friend WithEvents txtLevelMax As System.Windows.Forms.TextBox
    Friend WithEvents txtLevelMin As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblItemCount As System.Windows.Forms.Label
    Friend WithEvents cmsSearch As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsFFXIAH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsWiki As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdAddToDatabase As System.Windows.Forms.Button
    Friend WithEvents bwItemAdder As System.ComponentModel.BackgroundWorker
End Class
