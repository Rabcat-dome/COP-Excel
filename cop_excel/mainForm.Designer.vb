<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.BtnConnectDB = New System.Windows.Forms.Button()
        Me.BtnDBExcelSetting = New System.Windows.Forms.Button()
        Me.BtnDBTNGSetting = New System.Windows.Forms.Button()
        Me.lblCPU = New System.Windows.Forms.Label()
        Me.lblRAM = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStatusClear = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.btnInputClear = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.SourceName = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOwnerID = New System.Windows.Forms.TextBox()
        Me.txtTopic = New System.Windows.Forms.TextBox()
        Me.txtDomain = New System.Windows.Forms.TextBox()
        Me.PFCPU = New System.Diagnostics.PerformanceCounter()
        Me.PFRAM = New System.Diagnostics.PerformanceCounter()
        Me.TMin = New System.Windows.Forms.Timer(Me.components)
        Me.PgbRAM = New COP_Excel.VerticalProgressBar()
        Me.PgbCPU = New COP_Excel.VerticalProgressBar()
        Me.counter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PFCPU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PFRAM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnConnectDB
        '
        Me.BtnConnectDB.Location = New System.Drawing.Point(895, 14)
        Me.BtnConnectDB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnConnectDB.Name = "BtnConnectDB"
        Me.BtnConnectDB.Size = New System.Drawing.Size(202, 129)
        Me.BtnConnectDB.TabIndex = 1
        Me.BtnConnectDB.Text = "Start"
        Me.BtnConnectDB.UseVisualStyleBackColor = True
        '
        'BtnDBExcelSetting
        '
        Me.BtnDBExcelSetting.Location = New System.Drawing.Point(13, 14)
        Me.BtnDBExcelSetting.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnDBExcelSetting.Name = "BtnDBExcelSetting"
        Me.BtnDBExcelSetting.Size = New System.Drawing.Size(176, 37)
        Me.BtnDBExcelSetting.TabIndex = 2
        Me.BtnDBExcelSetting.Text = "DB  Excel Settings"
        Me.BtnDBExcelSetting.UseVisualStyleBackColor = True
        '
        'BtnDBTNGSetting
        '
        Me.BtnDBTNGSetting.Enabled = False
        Me.BtnDBTNGSetting.Location = New System.Drawing.Point(13, 61)
        Me.BtnDBTNGSetting.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnDBTNGSetting.Name = "BtnDBTNGSetting"
        Me.BtnDBTNGSetting.Size = New System.Drawing.Size(176, 37)
        Me.BtnDBTNGSetting.TabIndex = 38
        Me.BtnDBTNGSetting.Text = "DB  TNG Settings"
        Me.BtnDBTNGSetting.UseVisualStyleBackColor = True
        '
        'lblCPU
        '
        Me.lblCPU.AutoSize = True
        Me.lblCPU.Location = New System.Drawing.Point(22, 336)
        Me.lblCPU.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCPU.Name = "lblCPU"
        Me.lblCPU.Size = New System.Drawing.Size(32, 20)
        Me.lblCPU.TabIndex = 39
        Me.lblCPU.Text = "0%"
        '
        'lblRAM
        '
        Me.lblRAM.AutoSize = True
        Me.lblRAM.Location = New System.Drawing.Point(77, 336)
        Me.lblRAM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRAM.Name = "lblRAM"
        Me.lblRAM.Size = New System.Drawing.Size(32, 20)
        Me.lblRAM.TabIndex = 40
        Me.lblRAM.Text = "0%"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(132, 119)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(82, 24)
        Me.CheckBox2.TabIndex = 44
        Me.CheckBox2.Text = "Status"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(66, 103)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 40)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "RAM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Usage"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 103)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 40)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "CPU" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Usage"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnStatusClear
        '
        Me.btnStatusClear.Location = New System.Drawing.Point(132, 321)
        Me.btnStatusClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStatusClear.Name = "btnStatusClear"
        Me.btnStatusClear.Size = New System.Drawing.Size(288, 35)
        Me.btnStatusClear.TabIndex = 47
        Me.btnStatusClear.Text = "Clear"
        Me.btnStatusClear.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(132, 159)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStatus.Size = New System.Drawing.Size(286, 166)
        Me.txtStatus.TabIndex = 46
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(426, 119)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(107, 24)
        Me.CheckBox1.TabIndex = 48
        Me.CheckBox1.Text = "InputData"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(426, 159)
        Me.txtData.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtData.Multiline = True
        Me.txtData.Name = "txtData"
        Me.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtData.Size = New System.Drawing.Size(295, 166)
        Me.txtData.TabIndex = 49
        '
        'btnInputClear
        '
        Me.btnInputClear.Location = New System.Drawing.Point(426, 321)
        Me.btnInputClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnInputClear.Name = "btnInputClear"
        Me.btnInputClear.Size = New System.Drawing.Size(295, 35)
        Me.btnInputClear.TabIndex = 50
        Me.btnInputClear.Text = "Clear"
        Me.btnInputClear.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.SourceName)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtSource)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtOwnerID)
        Me.GroupBox1.Controls.Add(Me.txtTopic)
        Me.GroupBox1.Controls.Add(Me.txtDomain)
        Me.GroupBox1.Location = New System.Drawing.Point(741, 159)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(356, 197)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DDS Setting"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(81, 168)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 39
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 93)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 20)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "OwnerStaionID  :"
        '
        'SourceName
        '
        Me.SourceName.AutoSize = True
        Me.SourceName.Location = New System.Drawing.Point(7, 129)
        Me.SourceName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SourceName.Name = "SourceName"
        Me.SourceName.Size = New System.Drawing.Size(138, 20)
        Me.SourceName.TabIndex = 38
        Me.SourceName.Text = "SourceName        :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 63)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(135, 20)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Topic                :"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(154, 129)
        Me.txtSource.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(109, 26)
        Me.txtSource.TabIndex = 34
        Me.txtSource.Text = "MOTOTRBO"
        Me.txtSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 27)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 20)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Domain ID          :"
        '
        'txtOwnerID
        '
        Me.txtOwnerID.Location = New System.Drawing.Point(154, 93)
        Me.txtOwnerID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOwnerID.Name = "txtOwnerID"
        Me.txtOwnerID.Size = New System.Drawing.Size(109, 26)
        Me.txtOwnerID.TabIndex = 30
        Me.txtOwnerID.Text = "1.1.1.2"
        Me.txtOwnerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTopic
        '
        Me.txtTopic.Location = New System.Drawing.Point(154, 57)
        Me.txtTopic.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTopic.Name = "txtTopic"
        Me.txtTopic.Size = New System.Drawing.Size(109, 26)
        Me.txtTopic.TabIndex = 22
        Me.txtTopic.Text = "COP_Track"
        Me.txtTopic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDomain
        '
        Me.txtDomain.Location = New System.Drawing.Point(154, 21)
        Me.txtDomain.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDomain.Name = "txtDomain"
        Me.txtDomain.Size = New System.Drawing.Size(109, 26)
        Me.txtDomain.TabIndex = 23
        Me.txtDomain.Text = "0"
        Me.txtDomain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PFCPU
        '
        Me.PFCPU.CategoryName = "Thread"
        Me.PFCPU.CounterName = "% Processor Time"
        Me.PFCPU.InstanceName = "Idle/0"
        '
        'PFRAM
        '
        Me.PFRAM.CategoryName = "Memory"
        Me.PFRAM.CounterName = "% Committed Bytes In Use"
        '
        'TMin
        '
        Me.TMin.Enabled = True
        Me.TMin.Interval = 10000
        '
        'PgbRAM
        '
        Me.PgbRAM.Location = New System.Drawing.Point(74, 159)
        Me.PgbRAM.Name = "PgbRAM"
        Me.PgbRAM.Size = New System.Drawing.Size(35, 166)
        Me.PgbRAM.TabIndex = 45
        '
        'PgbCPU
        '
        Me.PgbCPU.Location = New System.Drawing.Point(19, 159)
        Me.PgbCPU.Name = "PgbCPU"
        Me.PgbCPU.Size = New System.Drawing.Size(35, 166)
        Me.PgbCPU.TabIndex = 41
        '
        'counter
        '
        Me.counter.Location = New System.Drawing.Point(834, 17)
        Me.counter.Name = "counter"
        Me.counter.Size = New System.Drawing.Size(50, 26)
        Me.counter.TabIndex = 52
        Me.counter.Text = "0"
        Me.counter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(734, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Counter    :"
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 365)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.counter)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnInputClear)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btnStatusClear)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.PgbRAM)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PgbCPU)
        Me.Controls.Add(Me.lblRAM)
        Me.Controls.Add(Me.lblCPU)
        Me.Controls.Add(Me.BtnDBTNGSetting)
        Me.Controls.Add(Me.BtnDBExcelSetting)
        Me.Controls.Add(Me.BtnConnectDB)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mainForm"
        Me.Text = "COP_Excel"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PFCPU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PFRAM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnConnectDB As Button
    Friend WithEvents BtnDBExcelSetting As Button
    Friend WithEvents BtnDBTNGSetting As Button
    Friend WithEvents lblCPU As Label
    Friend WithEvents lblRAM As Label
    Friend WithEvents PgbCPU As VerticalProgressBar
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PgbRAM As VerticalProgressBar
    Friend WithEvents btnStatusClear As Button
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtData As TextBox
    Friend WithEvents btnInputClear As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents SourceName As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtSource As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtOwnerID As TextBox
    Friend WithEvents txtTopic As TextBox
    Friend WithEvents txtDomain As TextBox
    Friend WithEvents PFCPU As PerformanceCounter
    Friend WithEvents PFRAM As PerformanceCounter
    Friend WithEvents TMin As Timer
    Friend WithEvents counter As TextBox
    Friend WithEvents Label1 As Label
End Class
