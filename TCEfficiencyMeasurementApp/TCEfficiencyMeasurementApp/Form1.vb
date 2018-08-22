Imports NationalInstruments.visa
Imports Ivi.Visa
Imports Thorlabs.PM100D_64
Imports Thorlabs.TL4000

Public Class frmTCE
    Dim pmBack, pmForward, pmOut As cls_powermeter
    Dim laser As cls_SerialPorts
    Private itc As TL4000
    Dim initCount As Int64 = 0
    Dim laserInit As Boolean = False
    Dim inputP, backP, outputP As Double
    Dim threshold As Double = 0.4 ' This is the lowest required threshold value, and must be changed when we ramp up power
    Dim mainCount As Int64 = 0 ' Count for the main loop
    Dim updateCount As Int64 = 0 ' Count for filling in power
    Dim secondsElapsed As Int64

    Private Sub frmTCE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Init_Form_PowerMeters()
        Call Init_Form_Laser()
        itc = New TL4000("USB0::4883::32847::M00284646::INSTR", True, False)

    End Sub

    Private Sub Init_Form_PowerMeters()
        tmrUpdatePower.Start()
        Dim _RM As New ResourceManager()
        Dim _Resource As IEnumerable(Of String)
        Try
            _Resource = _RM.Find("(USB0)?*INSTR*")

            For Each s As String In _Resource
                Dim result As ParseResult
                Dim _mbSession As MessageBasedSession
                result = _RM.Parse(s)
                _mbSession = _RM.Open(s)
                If Microsoft.VisualBasic.Left(DirectCast(_mbSession, NationalInstruments.Visa.UsbSession).ModelName, 5) = "PM100" Then
                    'we have a power meter
                    If IsNothing(pmForward) Then
                        pmForward = New cls_powermeter(s, DirectCast(_mbSession, NationalInstruments.Visa.UsbSession).ModelName, DirectCast(_mbSession, NationalInstruments.Visa.UsbSession).UsbSerialNumber, 1)
                        pmForward.AutoRange = True
                        pmForward.Setlambda = 1550


                    ElseIf IsNothing(pmOut) Then

                        pmOut = New cls_powermeter(s, DirectCast(_mbSession, NationalInstruments.Visa.UsbSession).ModelName, DirectCast(_mbSession, NationalInstruments.Visa.UsbSession).UsbSerialNumber, 2)
                        pmOut.AutoRange = False
                        pmOut.setRange = 8
                        pmOut.Setlambda = 1550

                    ElseIf IsNothing(pmBack) Then
                        pmBack = New cls_powermeter(s, DirectCast(_mbSession, NationalInstruments.Visa.UsbSession).ModelName, DirectCast(_mbSession, NationalInstruments.Visa.UsbSession).UsbSerialNumber, 3)
                        pmBack.AutoRange = True
                        pmBack.Setlambda = 1550

                    End If
                End If
            Next

        Catch ex As Exception
            'No Device is connected
            Debug.Print(ex.Message)
        End Try
        secondsElapsed = mainCount / 10
        txtElapsedTime.Text = secondsElapsed & " s"
    End Sub

    Private Sub Init_Form_Laser()
        Try
            laser = New cls_SerialPorts("COM3", 9600)
            laser.Prop_Connect = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub txtSpoolId_emptyText(sender As Object, e As EventArgs) Handles txtSpoolId.Click
        txtSpoolId.Text = ""
    End Sub 'Empty spool id box on click

    Private Sub tmrUpdatePower_Tick(sender As Object, e As EventArgs) Handles tmrUpdatePower.Tick
        outputP = pmOut.PowerValue
        inputP = pmForward.PowerValue
        backP = pmBack.PowerValue
        If Math.Round(updateCount / 5, 0) = updateCount / 5 Then 'Update the text boxes every second (10*100 mS, where 100 mS is the timer interval)
            txtOpP.Text = Math.Round(outputP, 3)
            txtSeedP.Text = Math.Round(inputP * 10000000, 0)
            txtBRP.Text = Math.Round(backP * 10000000, 3)
            updateCount = 0
        End If
        updateCount += 1
    End Sub

    Private Sub writeToStatus(lineToWrite As String)
        Dim lineWithReturn As String
        lineWithReturn = lineToWrite & vbNewLine
        txtStatus.AppendText(lineWithReturn)
    End Sub

    Private Sub btnStopTest_Click(sender As Object, e As EventArgs) Handles btnStopTest.Click
        laser.RS232SendCommand = "LCT0"
        tmrMain.Stop()
        writeToStatus("Stopping test...")
    End Sub

    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        If mainCount = 2 Then
            laser.Prop_Connect = True
            writeToStatus("Laser starting....")
        ElseIf mainCount = 4 Then
            laser.RS232SendCommand = "GS"
            writeToStatus("Writing GS")
        ElseIf mainCount = 6 Then
            laser.RS232SendCommand = "LCT0"
            writeToStatus("Writing LCT0")
        ElseIf mainCount = 8 Then
            laser.RS232SendCommand = "LR"
            writeToStatus("Writing LR")
        ElseIf mainCount = 10 Then
            writeToStatus("Laser intialised")
            laserInit = True
            If laser.Prop_Connect = False Then
                writeToStatus("Laser is not connected")
            ElseIf laser.Prop_Connect = True Then
                writeToStatus("Laser is connected")
            End If
        End If

        If mainCount = 50 Then
            laser.RS232SendCommand = "LCT1000"
            writeToStatus("Setting current to 1 A")
            threshold = 0.2
        ElseIf mainCount = 150 Then
            laser.RS232SendCommand = "LCT1250"
            writeToStatus("Setting current to 1.5 A")
        ElseIf mainCount = 360 Then
            laser.RS232SendCommand = "LCT1500"
            threshold = 0.7
        ElseIf mainCount = 650 Then
            laser.RS232SendCommand = "LCT1750"
            writeToStatus("Setting current to 2 A")
        ElseIf mainCount = 660 Then
            laser.RS232SendCommand = "LCT2000"
            threshold = 1.3
        ElseIf mainCount = 950 Then
            laser.RS232SendCommand = "LCT2250"
            writeToStatus("Setting current to 2.5 A")
        ElseIf mainCount = 970 Then
            laser.RS232SendCommand = "LCT2500"
            writeToStatus("Matt, this failed after the ramp to 2.5")
            threshold = 1.8
        ElseIf mainCount = 1250 Then
            laser.RS232SendCommand = "LCT2750"
            writeToStatus("Setting current to 3 A")
        ElseIf mainCount = 1270 Then
            laser.RS232SendCommand = "LCT3000"
            threshold = 2.35
        ElseIf mainCount = 1550 Then
            laser.RS232SendCommand = "LCT3300"
            writeToStatus("Setting current to 3.3 A")
            threshold = 2.7
        ElseIf mainCount = 1850 Then
            writeToStatus("Test finished. Shutting down pump laser...")
            threshold = -1
            laser.RS232SendCommand = "LCT1500"
        ElseIf mainCount = 1870 Then
            laser.RS232SendCommand = "LCT0"
        End If
        If mainCount > 60 And outputP < threshold Then ' I will start looking for an alarm 1 second after the first ramp
            laser.RS232SendCommand = "LCT0"
            writeToStatus("Quick drop alarm (went below " & threshold & " W or returned NaN)")
            laser.RS232SendCommand = "LCT0"
            tmrMain.Stop()
        End If
        If mainCount < 1850 And Double.IsNaN(outputP) Then
            laser.RS232SendCommand = "LCT0"
            writeToStatus("Quick drop alarm (returned NaN)")
            laser.RS232SendCommand = "LCT0"
            tmrMain.Stop()
        End If

        secondsElapsed = mainCount / 10
        txtElapsedTime.Text = secondsElapsed & " s"
        mainCount += 1
    End Sub


    Private Sub btnStartTest_Click(sender As Object, e As EventArgs) Handles btnStartTest.Click
        Dim backP As Double
        'itc.switchTecOutput(True)
        'itc.switchLdOutput(True)
        tmrMain.Start()

    End Sub
End Class
