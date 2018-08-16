<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTCE
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTCE))
        Me.btnStartTest = New System.Windows.Forms.Button()
        Me.btnStopTest = New System.Windows.Forms.Button()
        Me.txtSpoolId = New System.Windows.Forms.TextBox()
        Me.txtOpP = New System.Windows.Forms.TextBox()
        Me.txtBRP = New System.Windows.Forms.TextBox()
        Me.txtSeedP = New System.Windows.Forms.TextBox()
        Me.txtElapsedTime = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.crtLiveResults = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.crtResults = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.txtFinalPump = New System.Windows.Forms.TextBox()
        Me.txtFinalEff = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblEff = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BtnEngPumpOff = New System.Windows.Forms.Button()
        Me.btnEngPumpOn = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEngPumpI = New System.Windows.Forms.TextBox()
        Me.tmrStartLaser = New System.Windows.Forms.Timer(Me.components)
        CType(Me.crtLiveResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.crtResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStartTest
        '
        Me.btnStartTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartTest.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnStartTest.Location = New System.Drawing.Point(38, 103)
        Me.btnStartTest.Name = "btnStartTest"
        Me.btnStartTest.Size = New System.Drawing.Size(154, 39)
        Me.btnStartTest.TabIndex = 0
        Me.btnStartTest.Text = "Start Test"
        Me.btnStartTest.UseVisualStyleBackColor = True
        '
        'btnStopTest
        '
        Me.btnStopTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStopTest.ForeColor = System.Drawing.Color.Red
        Me.btnStopTest.Location = New System.Drawing.Point(38, 161)
        Me.btnStopTest.Name = "btnStopTest"
        Me.btnStopTest.Size = New System.Drawing.Size(154, 39)
        Me.btnStopTest.TabIndex = 1
        Me.btnStopTest.Text = "Stop test"
        Me.btnStopTest.UseVisualStyleBackColor = True
        '
        'txtSpoolId
        '
        Me.txtSpoolId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpoolId.Location = New System.Drawing.Point(38, 52)
        Me.txtSpoolId.Name = "txtSpoolId"
        Me.txtSpoolId.Size = New System.Drawing.Size(154, 20)
        Me.txtSpoolId.TabIndex = 2
        Me.txtSpoolId.Text = "Spool ID..."
        '
        'txtOpP
        '
        Me.txtOpP.Location = New System.Drawing.Point(532, 52)
        Me.txtOpP.Name = "txtOpP"
        Me.txtOpP.Size = New System.Drawing.Size(70, 20)
        Me.txtOpP.TabIndex = 4
        '
        'txtBRP
        '
        Me.txtBRP.Location = New System.Drawing.Point(446, 52)
        Me.txtBRP.Name = "txtBRP"
        Me.txtBRP.Size = New System.Drawing.Size(70, 20)
        Me.txtBRP.TabIndex = 5
        '
        'txtSeedP
        '
        Me.txtSeedP.Location = New System.Drawing.Point(360, 52)
        Me.txtSeedP.Name = "txtSeedP"
        Me.txtSeedP.Size = New System.Drawing.Size(70, 20)
        Me.txtSeedP.TabIndex = 6
        '
        'txtElapsedTime
        '
        Me.txtElapsedTime.Location = New System.Drawing.Point(218, 52)
        Me.txtElapsedTime.Name = "txtElapsedTime"
        Me.txtElapsedTime.Size = New System.Drawing.Size(105, 20)
        Me.txtElapsedTime.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(215, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Time elapsed"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(357, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Seed [mW]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(443, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "BR [uW]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(529, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Output [W]"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(38, 237)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStatus.Size = New System.Drawing.Size(154, 216)
        Me.txtStatus.TabIndex = 12
        '
        'crtLiveResults
        '
        ChartArea3.Name = "ChartArea1"
        Me.crtLiveResults.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.crtLiveResults.Legends.Add(Legend3)
        Me.crtLiveResults.Location = New System.Drawing.Point(218, 103)
        Me.crtLiveResults.Name = "crtLiveResults"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.crtLiveResults.Series.Add(Series3)
        Me.crtLiveResults.Size = New System.Drawing.Size(384, 350)
        Me.crtLiveResults.TabIndex = 13
        Me.crtLiveResults.TabStop = False
        Me.crtLiveResults.Text = "Chart1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(38, 218)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Status:"
        '
        'crtResults
        '
        ChartArea4.Name = "ChartArea1"
        Me.crtResults.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Me.crtResults.Legends.Add(Legend4)
        Me.crtResults.Location = New System.Drawing.Point(627, 103)
        Me.crtResults.Name = "crtResults"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.crtResults.Series.Add(Series4)
        Me.crtResults.Size = New System.Drawing.Size(384, 350)
        Me.crtResults.TabIndex = 15
        Me.crtResults.TabStop = False
        Me.crtResults.Text = "Chart1"
        '
        'txtFinalPump
        '
        Me.txtFinalPump.Location = New System.Drawing.Point(256, 17)
        Me.txtFinalPump.Name = "txtFinalPump"
        Me.txtFinalPump.Size = New System.Drawing.Size(100, 23)
        Me.txtFinalPump.TabIndex = 16
        '
        'txtFinalEff
        '
        Me.txtFinalEff.Location = New System.Drawing.Point(256, 57)
        Me.txtFinalEff.Name = "txtFinalEff"
        Me.txtFinalEff.Size = New System.Drawing.Size(100, 23)
        Me.txtFinalEff.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEff)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFinalEff)
        Me.GroupBox1.Controls.Add(Me.txtFinalPump)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GroupBox1.Location = New System.Drawing.Point(627, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 86)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Final Results"
        '
        'lblEff
        '
        Me.lblEff.AutoSize = True
        Me.lblEff.Location = New System.Drawing.Point(172, 57)
        Me.lblEff.Name = "lblEff"
        Me.lblEff.Size = New System.Drawing.Size(78, 17)
        Me.lblEff.TabIndex = 19
        Me.lblEff.Text = "Efficiency"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(93, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(157, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Pump for 5 W output"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.BtnEngPumpOff)
        Me.GroupBox2.Controls.Add(Me.btnEngPumpOn)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtEngPumpI)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.OrangeRed
        Me.GroupBox2.Location = New System.Drawing.Point(39, 479)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(971, 137)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Engineering use only"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Button1.Location = New System.Drawing.Point(784, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Seed Off"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Button2.Location = New System.Drawing.Point(684, 93)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Seed On"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BtnEngPumpOff
        '
        Me.BtnEngPumpOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEngPumpOff.Location = New System.Drawing.Point(321, 94)
        Me.BtnEngPumpOff.Name = "BtnEngPumpOff"
        Me.BtnEngPumpOff.Size = New System.Drawing.Size(75, 23)
        Me.BtnEngPumpOff.TabIndex = 3
        Me.BtnEngPumpOff.Text = "Laser Off"
        Me.BtnEngPumpOff.UseVisualStyleBackColor = True
        '
        'btnEngPumpOn
        '
        Me.btnEngPumpOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEngPumpOn.Location = New System.Drawing.Point(221, 93)
        Me.btnEngPumpOn.Name = "btnEngPumpOn"
        Me.btnEngPumpOn.Size = New System.Drawing.Size(75, 23)
        Me.btnEngPumpOn.TabIndex = 2
        Me.btnEngPumpOn.Text = "Laser On"
        Me.btnEngPumpOn.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label7.Location = New System.Drawing.Point(97, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Current [mA]"
        '
        'txtEngPumpI
        '
        Me.txtEngPumpI.Location = New System.Drawing.Point(97, 94)
        Me.txtEngPumpI.Name = "txtEngPumpI"
        Me.txtEngPumpI.Size = New System.Drawing.Size(100, 23)
        Me.txtEngPumpI.TabIndex = 0
        '
        'tmrStartLaser
        '
        '
        'frmTCE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 639)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.crtResults)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.crtLiveResults)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtElapsedTime)
        Me.Controls.Add(Me.txtSeedP)
        Me.Controls.Add(Me.txtBRP)
        Me.Controls.Add(Me.txtOpP)
        Me.Controls.Add(Me.txtSpoolId)
        Me.Controls.Add(Me.btnStopTest)
        Me.Controls.Add(Me.btnStartTest)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTCE"
        Me.Text = "TC1500Y Efficiency measurement"
        CType(Me.crtLiveResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.crtResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStartTest As Button
    Friend WithEvents btnStopTest As Button
    Friend WithEvents txtSpoolId As TextBox
    Friend WithEvents txtOpP As TextBox
    Friend WithEvents txtBRP As TextBox
    Friend WithEvents txtSeedP As TextBox
    Friend WithEvents txtElapsedTime As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents crtLiveResults As DataVisualization.Charting.Chart
    Friend WithEvents Label5 As Label
    Friend WithEvents crtResults As DataVisualization.Charting.Chart
    Friend WithEvents txtFinalPump As TextBox
    Friend WithEvents txtFinalEff As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblEff As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents BtnEngPumpOff As Button
    Friend WithEvents btnEngPumpOn As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtEngPumpI As TextBox
    Friend WithEvents tmrStartLaser As Timer
End Class
