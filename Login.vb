Imports System.Data.SqlClient
Public Class Login
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles UsernameTxt.TextChanged

    End Sub
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Calypso Tumbler\Downloads\ChurchManagementSystem\ChurchDb.mdf;Integrated Security=False;Connect Timeout=30")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Try
            If UsernameTxt.Text = "" Then
                MsgBox("Enter the Username")
            ElseIf PasswordTxt.Text = "" Then
                MsgBox("Enter the Password")
            ElseIf UsernameTxt.Text = "Admin" And PasswordTxt.Text = "Admin" Then
                Dim Admin As New Users
                Admin.Show()
                UsernameTxt.Text = ""
                PasswordTxt.Text = ""
                Me.Hide()
            Else
                Dim pass = PasswordTxt.Text
                Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
                Dim bytes() As Byte = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pass))
                Dim password As String

                For Each i As Byte In bytes
                    password &= i.ToString("x2")
                Next


                PasswordTxt.Text = password
                Con.Open()
                Dim query = "select * from UserTbl where UserName = '" & UsernameTxt.Text & "' and UserPassword = '" & password & "'"
                Dim cmd = New SqlCommand(query, Con)
                Dim da = New SqlDataAdapter(cmd)
                Dim ds = New DataSet()
                da.Fill(ds)
                Dim a As Integer
                a = ds.Tables(0).Rows.Count

                If a = 0 Then
                    MsgBox("Wrong Username or Password")
                    PasswordTxt.Text = ""
                Else
                    Me.Hide()
                    Dim Main1 As New Main
                    Main1.Show()
                    UsernameTxt.Text = ""
                    PasswordTxt.Text = ""
                End If
                Con.Close()
            End If

        Catch ex As Exception
            MsgBox("Connection timeout")
        End Try










    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub PasswordTxt_TextChanged(sender As Object, e As EventArgs) Handles PasswordTxt.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub
End Class