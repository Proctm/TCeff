Imports NationalInstruments.Visa
Imports Ivi.Visa
Imports Thorlabs.PM100D_64
Imports Thorlabs.TL4000
Imports System.IO

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
    Dim secondsElapsed, minDispl, secDispl As Int64
    Dim fullFileName As String
    Private AvgPower As Double()
    Private Points As New List(Of PointF)()

    Private Sub frmTCE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Init_Form_PowerMeters()
        Call Init_Form_Laser()
        minDispl = 0
        secDispl = 0
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
        ElseIf mainCount = 15 Then
            itc.setLdCurrSetpoint(0.54)
            itc.switchTecOutput(True)
            itc.switchLdOutput(True)

        End If

        If mainCount = 50 Then ' So this is a bit long, but essentially we've added some extra steps to ramp up slowly. Too quickly, and the PM
            'will return NaN, which will trigger an alarm. The current is sent to the laser, the new threshold value set, and the nthe current is increased again to the target test value
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

            DataAnalysis()
        ElseIf mainCount = 1860 Then
            itc.switchLdOutput(False)
            itc.switchTecOutput(False)
        ElseIf mainCount = 1870 Then
            laser.RS232SendCommand = "LCT0"
        End If
        '----------------------------- This is the alarm section, which is always looking for NaN or power < threshold
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
        '----------------------------- The next section handles plotting and creating csv string for data dump
        Dim CSVString As String = ""

        If Not IsNothing(pmBack) Then
            crtLiveResults.Series(0).IsVisibleInLegend = True
            crtLiveResults.Series(0).Points.AddY(CDbl(outputP))
            CSVString &= "," & outputP
        End If
        If Not IsNothing(pmOut) Then
            crtLiveResults.Series(1).IsVisibleInLegend = True
            crtLiveResults.Series(1).Points.AddY(CDbl(backP))
            CSVString &= "," & backP

        End If
        If Not IsNothing(pmForward) Then
            crtLiveResults.Series(2).IsVisibleInLegend = True
            crtLiveResults.Series(2).Points.AddY(CDbl(inputP))
            CSVString &= "," & inputP
        End If
        '-----------------opens up my raw data file (only once though)
        If mainCount = 0 Then
            Dim path As String = "\\FCHO-SBS-1\Public2\Eng\Data\Doped\TCtestDB\"
            Dim fileID As String = txtSpoolId.Text.Replace("/", "_").Replace("\", "_").Replace("-", "_").Replace(" ", "_")
            Dim testdate As DateTime = Now
            fullFileName = path & fileID & ".csv"

            'Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(fullfilename, False)
            fullFileName = CheckFile(fullFileName)
            Dim fs As FileStream = File.Create(fullFileName, FileMode.Open)
            fs.Close()
        End If
        '---------------Following is my timer code which doesn't work well
        secondsElapsed = mainCount / 10
        If secondsElapsed = 60 Or secondsElapsed = 120 Or secondsElapsed = 180 Or secondsElapsed = 240 Or secondsElapsed = 300 Then
            minDispl += 1
        End If
        secDispl = secondsElapsed - 60 * minDispl
        txtElapsedTime.Text = minDispl & " : " & secDispl
        mainCount += 1
        '-------------------Try to write to csv every second
        If Math.Round(mainCount / 10, 0) = mainCount / 10 Then
            WritetoCSV(CSVString)
        End If
    End Sub

    Private Sub WritetoCSV(ByVal CSVString As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(fullFileName, True)
        file.WriteLine(secondsElapsed & CSVString)
        file.Close()
    End Sub

    Public Function CheckFile(ByVal NameFile As String)
        'function to change savename if about to overwrite a previous measurement
        'Works for files with .*** at end, will not currently cope with anything other than 3 letter extensions

        Dim TmpName As String
        Dim I As Integer

        TmpName = NameFile
        I = 1

        Do While File.Exists(TmpName) = True
            TmpName = Strings.Left(NameFile, Len(NameFile) - 4) & "-" & Format(I, "##") _
            & Strings.Right(NameFile, 4)
            I = I + 1
        Loop
        CheckFile = TmpName

    End Function

    Private Sub btnStartTest_Click(sender As Object, e As EventArgs) Handles btnStartTest.Click
        itc.switchTecOutput(True)
        itc.switchLdOutput(True)
        itc.setLdCurrSetpoint(0.54)
        MsgBox("Wait for seed power to display ~700 uW")
        tmrMain.Start()

    End Sub
    Function getAverage(y As Double()) As Double
        Dim z As Double
        For Each i As Double In y
            z += i
        Next
        Return z / y.Length
    End Function
    Private Sub DataAnalysis()

        Dim sData() As String
        Dim arrName, arrValue As New List(Of Double)()

        Using sr As New StreamReader(fullFileName)
            While Not sr.EndOfStream
                sData = sr.ReadLine().Split(","c)

                arrName.Add(sData(0).Trim())
                arrValue.Add(sData(2).Trim())

            End While
        End Using

        Dim dataTime() As Double = arrName.ToArray
        Dim dataValue() As Double = arrValue.ToArray

        Dim lBound(5) As Double
        Dim UBound(5) As Double

        lBound(0) = 75
        lBound(1) = 135
        lBound(2) = 195
        lBound(3) = 255
        lBound(4) = 315
        lBound(5) = 375

        UBound(0) = lBound(0) + 35
        UBound(1) = lBound(1) + 35
        UBound(2) = lBound(2) + 35
        UBound(3) = lBound(3) + 35
        UBound(4) = lBound(4) + 35
        UBound(5) = lBound(5) + 35


        'Dim lBound As Double = 25
        'Dim uBound As Double = 35
        AvgPower = New Double(5) {}

        For kk = 0 To 5

            Dim matchedItems() As Double = Array.FindAll(dataTime, Function(x) x >= lBound(kk) And x <= UBound(kk))
            Dim sss As Double()
            sss = New Double(matchedItems.Length - 1) {}
            For i = 0 To matchedItems.Length - 1

                Dim gg As Integer = Array.IndexOf(dataTime, matchedItems(i))
                Dim ddd As Double = dataValue.GetValue(gg)
                sss(i) = ddd

            Next i

            Dim avgValue As Double = getAverage(sss)
            AvgPower(kk) = (1 / 0.935) * avgValue 'Combiner loss considered.

        Next kk

        'Dim pumpin() As Double = {1.14, 5.41, 9.5, 13.7, 18.0, 22.3} 'before
        'Dim pumpin() As Double = {0.74, 2.49, 8.32, 14.12, 19.8, 25.4} 'calibrated at 29/9/2017
        'Dim pumpin() As Double = {8.32, 14.12, 19.8, 22.6, 25.4, 28.1} 'calibrated at 29/9/2017
        'Dim pumpin() As Double = {2.49, 8.32, 14.12, 19.8, 22.6, 25.4} 'calibrated at 29/9/2017
        'Dim pumpin() As Double = {2.43, 8.17, 13.9, 19.5, 22.3, 25.0} 'calibrated on 2/8/18 MBP
        Dim pumpin() As Double = {2.23, 4.87, 7.54, 10.21, 12.8, 14.4} 'calibrated on 15/8/18 MBP following rework
        Dim pts() As PointF

        For jjj = 1 To pumpin.Count
            pts =
       {
            New PointF(pumpin(jjj - 1), AvgPower(jjj - 1))
       }
            Points.Add(pts(0))
        Next

        Dim slope As Double
        Dim intercept As Double

        FindLinearLeastSquaresFit(Points, slope, intercept)

        Dim pumpPower As Double
        pumpPower = (5 - intercept) / slope
        Dim newpumpPower As Double = pumpPower * 1.0 '0.86 I don't think this is right.. MBP


        txtFinalPump.Text = Format(newpumpPower, "0.00") '0.86 : Pump wavelength comepensation due to new pump laser wavelength 
        txtFinalEff.Text = Format((5 / newpumpPower) * 100, "0.00")


        Dim filedb As System.IO.StreamWriter
        Dim filedbname As String
        filedbname = "\\FCHO-SBS-1\Public2\Eng\Data\Doped\TCtestDB\DoNOTdelete\filedB.csv"
        Dim Results As String = txtSpoolId.Text & "," & secondsElapsed & "," & txtFinalPump.Text & "," & txtFinalEff.Text

        If IO.File.Exists(filedbname) Then
            'Dim Results As String = TextBox1.Text & "," & _elapseStartTime.ToString & "," & TextBox7.Text & "," & TextBox6.Text
            filedb = My.Computer.FileSystem.OpenTextFileWriter(filedbname, True)
            filedb.WriteLine(Results)
            filedb.Close()

        Else
            Dim fdbs As FileStream = File.Create(filedbname)
            fdbs.Close()
            filedb = My.Computer.FileSystem.OpenTextFileWriter(filedbname, True)
            filedb.WriteLine(Results)
            filedb.Close()
        End If


        'Dim Points As New List(Of List(Of Point))
        'Dim pts() As Double = {New (X)}
        'Points.Add(pumpin(0), AvgPower(0))


        crtResults.Series(0).IsVisibleInLegend = True
        crtResults.Series(0).Points.DataBindXY(pumpin, AvgPower)

        Points.Clear()
    End Sub

    Public Function FindLinearLeastSquaresFit(ByVal points As _
 List(Of PointF), ByRef m As Double, ByRef b As Double) _
 As Double
        'Public Function FindLinearLeastSquaresFit(ByVal pumpin() As Array _
        ' , ByVal AvgPower() As Array, ByRef m As Double, ByRef b As Double) _
        ' As Double
        ' Perform the calculation.
        ' Find the values S1, Sx, Sy, Sxx, and Sxy.
        Dim S1 As Double = points.Count
        Dim Sx As Double = 0
        Dim Sy As Double = 0
        Dim Sxx As Double = 0
        Dim Sxy As Double = 0
        Dim ppp As New List(Of Double)


        For Each pt As PointF In points
            Sx += pt.X
            Sy += pt.Y
            Sxx += pt.X * pt.X
            Sxy += pt.X * pt.Y
        Next pt

        ' Solve for m and b.
        m = (Sxy * S1 - Sx * Sy) / (Sxx * S1 - Sx * Sx)
        b = (Sxy * Sx - Sy * Sxx) / (Sx * Sx - S1 * Sxx)

        Return Math.Sqrt(ErrorSquared(points, m, b))

    End Function
    Public Function ErrorSquared(ByVal points As List(Of PointF), ByVal m As Double, ByVal b As Double) As Double
        Dim total As Double = 0
        For Each pt As PointF In points
            Dim dy As Double = pt.Y - (m * pt.X + b)
            total += dy * dy
        Next pt
        Return total
    End Function
End Class
