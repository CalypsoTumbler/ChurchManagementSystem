Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            ProgressBar1.Increment(1)
            If ProgressBar1.Value = 100 Then
                Me.Hide()
                Dim Log = New Login
                Log.Show()
                Timer1.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("Program failed to start")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class
