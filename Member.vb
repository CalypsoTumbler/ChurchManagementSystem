Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO

Public Class Member
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            MemberPicture.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MaritalComboBox.SelectedIndexChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Main.Show()

    End Sub
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Calypso Tumbler\Downloads\ChurchManagementSystem\ChurchDb.mdf;Integrated Security=False;Connect Timeout=30")
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If DateOfBaptismDTP.Value = Nothing Or NameTxt.Text = "" Or PhoneTxt.Text = "" Or SexComboBox.SelectedItem = Nothing Or ResidenceComboBox.SelectedItem = Nothing Then
            MsgBox("Missing Information")
        Else
            
            Dim picture As New MemoryStream()
            MemberPicture.Image.Save(picture, MemberPicture.Image.RawFormat)


            Con.Open()
            'DateOfBaptismDTP.Format = DateTimePickerFormat.Custom
            'DateOfBirthDTP.Format = DateTimePickerFormat.Custom
            'DateOfBaptismDTP.CustomFormat = "DD-MM-YYYY"
            Try
                Dim Query As String
                Query = "insert into MemberTbl (MemberDateOfBaptism, MemberName, MemberDateOfBirth, MemberPhone, MemberMaritalStatus,MemberOccupation, MemberResidence, MemberFatherName, MemberFatherHometown, MemberMotherName, MemberMotherHometown, MemberPicture, MemberSex) values (@DOBap, @Name, @DOB, @Phone, @Marital, @Occupation, @Residence, @FatherName, @FatherH, @MotherName, @MotherH, @Picture, @Sex)"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(Query, Con)
                cmd.Parameters.AddWithValue("@DOBap", DateOfBaptismDTP.Value.Date)
                cmd.Parameters.AddWithValue("@Name", NameTxt.Text)
                cmd.Parameters.AddWithValue("@DOB", DateOfBirthDTP.Value.Date)
                cmd.Parameters.AddWithValue("@Phone", "233" + PhoneTxt.Text)
                cmd.Parameters.AddWithValue("@Marital", MaritalComboBox.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@Occupation", OccupationTxt.Text)
                cmd.Parameters.AddWithValue("@Residence", ResidenceComboBox.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@FatherName", FatherTxt.Text)
                cmd.Parameters.AddWithValue("@FatherH", FatherHomeTxt.Text)
                cmd.Parameters.AddWithValue("@MotherName", MotherTxt.Text)
                cmd.Parameters.AddWithValue("@MotherH", MotherHomeTxt.Text)
                cmd.Parameters.AddWithValue("@Picture", picture.ToArray())
                cmd.Parameters.AddWithValue("@Sex", SexComboBox.SelectedItem.ToString())
                cmd.ExecuteNonQuery()
                MsgBox("Member added successfully")
                clear()
                Con.Close()

            Catch ex As Exception
                MsgBox("Record already exist in the database")
            End Try


        End If
    End Sub

    Private Function RawFormat() As EncoderParameters
        Throw New NotImplementedException()
    End Function
    Private Sub clear()
        DateOfBaptismDTP.Value = Date.Now
        NameTxt.Text = Nothing
        DateOfBirthDTP.Value = Date.Now
        PhoneTxt.Text = Nothing
        MaritalComboBox.SelectedItem = Nothing
        OccupationTxt.Text = Nothing
        ResidenceComboBox.SelectedItem = Nothing
        FatherTxt.Text = Nothing
        FatherHomeTxt.Text = Nothing
        MotherTxt.Text = Nothing
        MotherHomeTxt.Text = Nothing
        MemberPicture.Image = Nothing
        SexComboBox.SelectedItem = Nothing
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click


        If DateOfBaptismDTP.Value = Nothing Or NameTxt.Text = "" Or PhoneTxt.Text = "" Or SexComboBox.SelectedItem = Nothing Or ResidenceComboBox.SelectedItem = Nothing Then
            MsgBox("Missing Information")
        Else
            Dim picture As New MemoryStream()
            MemberPicture.Image.Save(picture, MemberPicture.Image.RawFormat)
            Con.Open()
            Dim Query As String
            Query = "Update MemberTbl SET MemberDateOfBaptism = @DOBap, MemberName = @Name, MemberDateOfBirth = @DOB, MemberMaritalStatus = @Marital, MemberOccupation = @Occupation, MemberResidence = @Residence, MemberFatherName = @FatherName, MemberFatherHometown = @FatherH, MemberMotherName = @MotherName, MemberMotherHometown = @MotherH, MemberPicture = @Picture, MemberSex = @Sex WHERE MemberPhone = @Phone"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            cmd.Parameters.AddWithValue("@DOBap", DateOfBaptismDTP.Value.Date)
            cmd.Parameters.AddWithValue("@Name", NameTxt.Text)
            cmd.Parameters.AddWithValue("@DOB", DateOfBirthDTP.Value.Date)
            cmd.Parameters.AddWithValue("@Phone", PhoneTxt.Text)
            cmd.Parameters.AddWithValue("@Marital", MaritalComboBox.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@Occupation", OccupationTxt.Text)
            cmd.Parameters.AddWithValue("@Residence", ResidenceComboBox.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@FatherName", FatherTxt.Text)
            cmd.Parameters.AddWithValue("@FatherH", FatherHomeTxt.Text)
            cmd.Parameters.AddWithValue("@MotherName", MotherTxt.Text)
            cmd.Parameters.AddWithValue("@MotherH", MotherHomeTxt.Text)
            cmd.Parameters.AddWithValue("@Picture", picture.ToArray())
            cmd.Parameters.AddWithValue("@Sex", SexComboBox.SelectedItem.ToString())
            cmd.ExecuteNonQuery()
            MsgBox("Member Information Updated Successfully")
            Con.Close()
        End If
    End Sub

    Private Sub DateOfBaptismDTP_ValueChanged(sender As Object, e As EventArgs) Handles DateOfBaptismDTP.ValueChanged

    End Sub

    Private Sub Member_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateBtn.Hide()

    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Hide()
        Dim Cong As New Congregation
        Cong.Show()
    End Sub

    Private Sub PhoneTxt_TextChanged(sender As Object, e As EventArgs) Handles PhoneTxt.TextChanged

    End Sub

    Private Sub PhoneTxt_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PhoneTxt.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class