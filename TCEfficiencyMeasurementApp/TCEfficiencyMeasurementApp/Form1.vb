Public Class frmTCE

    Dim count As Int64 = 0

    Private Sub frmTCE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtSpoolId_emptyText(sender As Object, e As EventArgs) Handles txtSpoolId.Click
        txtSpoolId.Text = ""
    End Sub 'Empty spool id box on click

    Private Sub writeToStatus(lineToWrite As String)
        Dim lineWithReturn As String
        lineWithReturn = lineToWrite & vbNewLine
        txtStatus.AppendText(lineWithReturn)
    End Sub

    Private Sub btnStartTest_Click(sender As Object, e As EventArgs) Handles btnStartTest.Click

    End Sub

End Class
