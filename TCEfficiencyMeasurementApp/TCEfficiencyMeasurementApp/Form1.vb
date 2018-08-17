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

    Private Sub frmTCE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Init_Form_PowerMeters()
        Call Init_Form_Laser()
        itc = New TL4000("USB0::4883::32847::M00284646::INSTR", True, False)
    End Sub

    Private Sub Init_Form_PowerMeters()

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
                        pmOut.AutoRange = True
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

    Private Sub writeToStatus(lineToWrite As String)
        Dim lineWithReturn As String
        lineWithReturn = lineToWrite & vbNewLine
        txtStatus.AppendText(lineWithReturn)
    End Sub

    Private Sub btnStopTest_Click(sender As Object, e As EventArgs) Handles btnStopTest.Click
        itc.switchLdOutput(False)
    End Sub

    Private Sub tmrStartLaser_Tick(sender As Object, e As EventArgs) Handles tmrStartLaser.Tick

        If initCount = 2 Then
            'laser.Prop_Connect = True
            writeToStatus("Laser starting....")
        ElseIf initCount = 4 Then
            'laser.RS232SendCommand = "GS"
            writeToStatus("Writing GS")
        ElseIf initCount = 6 Then
            'laser.RS232SendCommand = "LCT0"
            writeToStatus("Writing LCT0")
        ElseIf initCount = 8 Then
            'laser.RS232SendCommand = "LR"
            writeToStatus("Writing LR")
        ElseIf initCount > 10 Then
            writeToStatus("Laser intialised")
            laserInit = True
            If laser.Prop_Connect = False Then
                writeToStatus("Laser is not connected")
            ElseIf laser.Prop_Connect = True Then
                writeToStatus("Laser is connected")
            End If
            tmrStartLaser.Stop()
        End If

        initCount += 1
    End Sub

    Private Sub btnStartTest_Click(sender As Object, e As EventArgs) Handles btnStartTest.Click
        Dim backP As Double
        'itc.switchTecOutput(True)
        'itc.switchLdOutput(True)

        backP = pmBack.PowerValue()
        writeToStatus("Power is " & backP & " W")

    End Sub
End Class
