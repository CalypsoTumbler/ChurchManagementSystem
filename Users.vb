Imports System.Data.SqlClient
Public Class Users
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Login.Show()
    End Sub

    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Calypso Tumbler\Downloads\ChurchManagementSystem\ChurchDb.mdf;Integrated Security=False;Connect Timeout=30")

    Private Sub DisplayUsers()
        Con.Open()
        Dim Sql = "select * from UserTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(Sql, Con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        UsersDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub Clear()
        NameTxt.Text = ""
        PhoneTxt.Text = ""
        PassTxt.Text = ""
        Key = 0
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click

        If NameTxt.Text = "" Or PhoneTxt.Text = "" Or PassTxt.Text = "" Then
            MsgBox("Missing Information")



        Else
            Dim pass = PassTxt.Text
            Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim bytes() As Byte = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pass))
            Dim password As String

            For Each i As Byte In bytes
                password &= i.ToString("x2")
            Next

            PassTxt.Text = password

            Con.Open()
            Dim Query As String
            Query = "insert into UserTbl values('" & NameTxt.Text & "', '" & PhoneTxt.Text & "', '" & password & "' )"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Item added successfully")
            Con.Close()
            DisplayUsers()
            Clear()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Clear()
    End Sub

    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayUsers()
    End Sub

    Dim Key = 0
    Private Sub UsersDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles UsersDGV.CellMouseClick
        Try
            Dim row As DataGridViewRow = UsersDGV.Rows(e.RowIndex)
            NameTxt.Text = row.Cells(1).Value.ToString
            PhoneTxt.Text = row.Cells(2).Value.ToString
            PassTxt.Text = row.Cells(3).Value.ToString
            If NameTxt.Text = "" Then
                Key = 0
            Else
                Key = Convert.ToInt32(row.Cells(0).Value.ToString)
            End If

        Catch ex As Exception
            MsgBox("Selection error")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Key = 0 Then
            MsgBox("Missing Information")
        Else
            Con.Open()
            Dim query = "delete from UserTbl where UserID = " & Key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("User Deleted")
            Con.Close()
            DisplayUsers()
            Clear()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If NameTxt.Text = "" Or PhoneTxt.Text = "" Or PassTxt.Text = "" Then
            MsgBox("Missing Information")



        Else
            Dim pass = PassTxt.Text
            Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim bytes() As Byte = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pass))
            Dim password As String

            For Each i As Byte In bytes
                password &= i.ToString("x2")
            Next

            PassTxt.Text = password

            Con.Open()
            Dim query = "Update UserTbl set UserName = '" & NameTxt.Text & "', UserPhone = '" & PhoneTxt.Text & "', UserPassword = '" & PassTxt.Text & "' where UserId = " & Key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("User Information Edited Successfully")
            Con.Close()
            DisplayUsers()
            Clear()
        End If


    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Application.Exit()
    End Sub
End Class