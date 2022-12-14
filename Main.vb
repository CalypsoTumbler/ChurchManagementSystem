Imports System.Data.SqlClient
Public Class Main
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        Congregation.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
        Congregation.Show()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Try
            Con.Open()
            Dim sql = "select * from IventoryTbl"
            Dim adapter As SqlDataAdapter
            adapter = New SqlDataAdapter(sql, Con)
            Dim builder As SqlCommandBuilder
            builder = New SqlCommandBuilder(adapter)
            Dim ds As DataSet
            ds = New DataSet
            adapter.Fill(ds)
            Inventory.InventoryDGV.DataSource = ds.Tables(0)
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
        Me.Hide()
        Inventory.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Hide()
        Inventory.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Me.Show()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Hide()
        Anouncements.Show()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Hide()
        Anouncements.Show()
    End Sub

    Dim Con As New SqlConnection("Data Source=SQL8003.site4now.net;Initial Catalog=db_a91405_calypsotumbler001;User Id=db_a91405_calypsotumbler001_admin;Password=C@lypso2022")

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Try
            Con.Open()
            Dim Sql = "select MemberName, MemberSex, MemberPhone From MemberTbl Order By MemberName Asc"
            Dim adapter As SqlDataAdapter
            adapter = New SqlDataAdapter(Sql, Con)
            Dim builder As SqlCommandBuilder
            builder = New SqlCommandBuilder(adapter)
            Dim ds As DataSet
            ds = New DataSet
            adapter.Fill(ds)
            Attendance.AttendanceDGV.DataSource = ds.Tables(0)
            Con.Close()
            Me.Hide()
            Attendance.Show()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.Hide()
        Dim Login1 As New Login
        Login1.Show()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()
        Dim Login1 As New Login
        Login1.Show()
    End Sub
End Class