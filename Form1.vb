Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window

Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Dim Con As New SqlConnection("Data Source=SQL8003.site4now.net;Initial Catalog=db_a91405_calypsotumbler001;User Id=db_a91405_calypsotumbler001_admin;Password=C@lypso2022")
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Try
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 140 Then
            Try
                Con = New SqlConnection
                With Con
                    .ConnectionString = "Data Source=SQL8003.site4now.net;Initial Catalog=db_a91405_calypsotumbler001;User Id=db_a91405_calypsotumbler001_admin;Password=C@lypso2022"
                    .Open()
                End With
            Catch ex As Exception
                Timer1.Enabled = False
                Con.Close()
                MsgBox("Unable to connect. Please check internet connection", vbExclamation)
                Application.Exit()

            End Try
        ElseIf ProgressBar1.Value = 200 Then
            Con.Close()
                Me.Hide()
                Dim Log = New Login
                Log.Show()
                Timer1.Enabled = False


            End If


        ' Catch ex As Exception
        'Timer1.Enabled = False
        ' MsgBox("Program failed to start.", vbExclamation)
        'Application.Exit()


        ' End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()


    End Sub


End Class
