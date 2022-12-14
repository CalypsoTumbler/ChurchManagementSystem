Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Public Class MemberDetails
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Main.Show()

        DOBapLbl.Text = Nothing
        NameLbl.Text = Nothing
        DOBLbl.Text = Nothing
        PhoneLbl.Text = Nothing
        MaritalLbl.Text = Nothing
        OccupationLbl.Text = Nothing
        ResidenceLbl.Text = Nothing
        FatherLbl.Text = Nothing
        FatherhLbl.Text = Nothing
        MotherLbl.Text = Nothing
        MotherhLbl.Text = Nothing
        ProfilePictureBox.Image = Nothing
        SexLbl.Text = Nothing
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Dim Con As New SqlConnection("Data Source=SQL8003.site4now.net;Initial Catalog=db_a91405_calypsotumbler001;User Id=db_a91405_calypsotumbler001_admin;Password=C@lypso2022")

    Private Sub SearchByPhone()
        Try
            Con.Open()
            Dim Query2 = "select * from MemberTbl where MemberPhone = '" & SearchTxt.Text & "'"
            Dim cmd2 = New SqlCommand(Query2, Con)
            Dim sqa2 = New SqlDataAdapter(cmd2)
            Dim ds = New DataSet()
            sqa2.Fill(ds, "sql temp table")
            sqa2.Dispose()

            Dim a As Integer
            a = ds.Tables(0).Rows.Count

            If a = 0 Then
                MsgBox("Member not found")
                Con.Close()
            Else

                Dim Query = "select * from MemberTbl where MemberPhone = '" & SearchTxt.Text & "'"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(Query, Con)
                Dim dt As DataTable
                dt = New DataTable
                Dim sqa As SqlDataAdapter
                sqa = New SqlDataAdapter(cmd)
                sqa.Fill(dt)


                For Each dr As DataRow In dt.Rows
                    DOBapLbl.Text = dr(1).ToString()
                    NameLbl.Text = dr(2).ToString()
                    DOBLbl.Text = dr(3).ToString()
                    PhoneLbl.Text = dr(4).ToString()
                    MaritalLbl.Text = dr(5).ToString()
                    OccupationLbl.Text = dr(6).ToString()
                    ResidenceLbl.Text = dr(7).ToString()
                    FatherLbl.Text = dr(8).ToString()
                    FatherhLbl.Text = dr(9).ToString()
                    MotherLbl.Text = dr(10).ToString()
                    MotherhLbl.Text = dr(11).ToString()
                    Dim img() As Byte
                    img = dt.Rows(0)(12)
                    Dim ms As New MemoryStream(img)
                    ProfilePictureBox.Image = Image.FromStream(ms)
                    SexLbl.Text = dr(13).ToString()
                Next
                Con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Con.Close()
        End Try

    End Sub

    Private Sub SearchByName()
        Try
            Con.Open()
            Dim Query2 = "select * from MemberTbl where MemberName ='" & SearchTxt.Text & "'"
            Dim cmd2 = New SqlCommand(Query2, Con)
            Dim sqa2 = New SqlDataAdapter(cmd2)
            Dim ds = New DataSet()
            sqa2.Fill(ds, "sql temp table")
            sqa2.Dispose()

            Dim a As Integer
            a = ds.Tables(0).Rows.Count

            If a = 0 Then
                MsgBox("Member not found")
                Con.Close()
            Else

                Dim Query = "select * from MemberTbl where MemberName = '" & SearchTxt.Text & "'"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(Query, Con)
                Dim dt As DataTable
                dt = New DataTable
                Dim sqa As SqlDataAdapter
                sqa = New SqlDataAdapter(cmd)
                sqa.Fill(dt)


                For Each dr As DataRow In dt.Rows
                    DOBapLbl.Text = dr(1).ToString()
                    NameLbl.Text = dr(2).ToString()
                    DOBLbl.Text = dr(3).ToString()
                    PhoneLbl.Text = dr(4).ToString()
                    MaritalLbl.Text = dr(5).ToString()
                    OccupationLbl.Text = dr(6).ToString()
                    ResidenceLbl.Text = dr(7).ToString()
                    FatherLbl.Text = dr(8).ToString()
                    FatherhLbl.Text = dr(9).ToString()
                    MotherLbl.Text = dr(10).ToString()
                    MotherhLbl.Text = dr(11).ToString()
                    Dim img() As Byte
                    img = dt.Rows(0)(12)
                    Dim ms As New MemoryStream(img)
                    ProfilePictureBox.Image = Image.FromStream(ms)
                    SexLbl.Text = dr(13).ToString()
                Next
                Con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Con.Close()
        End Try

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If SearchComboBox.SelectedItem = Nothing Or SearchTxt.Text = "" Then
            MsgBox("Select search criteria or Enter search information")
        ElseIf SearchComboBox.SelectedItem = "Phone number" Then

            SearchByPhone()

        ElseIf SearchComboBox.SelectedItem = "Name" Then
            SearchByName()

        End If



    End Sub

    Private Sub EditByName()
        Try
            Con.Open()
            Dim Query = "select * from MemberTbl where MemberName = '" & SearchTxt.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            Dim dt As DataTable
            dt = New DataTable
            Dim sqa As SqlDataAdapter
            sqa = New SqlDataAdapter(cmd)
            sqa.Fill(dt)

            Dim obj As New Member()

            'Insert DateOfBaptismDTP.Value etc as Global variables 
            For Each dr As DataRow In dt.Rows
                obj.DateOfBaptismDTP.Value = dr(1).ToString()
                obj.NameTxt.Text = dr(2).ToString()
                obj.DateOfBirthDTP.Text = dr(3).ToString()
                obj.PhoneTxt.Text = dr(4).ToString()
                obj.MaritalComboBox.SelectedItem = dr(5).ToString()
                obj.OccupationTxt.Text = dr(6).ToString()
                obj.ResidenceComboBox.SelectedItem = dr(7).ToString()
                obj.FatherTxt.Text = dr(8).ToString()
                obj.FatherHomeTxt.Text = dr(9).ToString()
                obj.MotherTxt.Text = dr(10).ToString()
                obj.MotherHomeTxt.Text = dr(11).ToString()
                Dim img() As Byte
                img = dt.Rows(0)(12)
                Dim ms As New MemoryStream(img)
                obj.MemberPicture.Image = Image.FromStream(ms)
                obj.SexComboBox.SelectedItem = dr(13).ToString()
            Next
            Con.Close()
            clear()
            Me.Hide()

            obj.Show()
            obj.SaveBtn.Hide()
            obj.UpdateBtn.Show()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Con.Close()
        End Try
    End Sub

    Private Sub EditByPhone()
        Try
            Con.Open()
            Dim Query = "select * from MemberTbl where MemberPhone = '" & SearchTxt.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            Dim dt As DataTable
            dt = New DataTable
            Dim sqa As SqlDataAdapter
            sqa = New SqlDataAdapter(cmd)
            sqa.Fill(dt)

            Dim obj As New Member()

            'Insert DateOfBaptismDTP.Value etc as Global variables 
            For Each dr As DataRow In dt.Rows
                obj.DateOfBaptismDTP.Value = dr(1).ToString()
                obj.NameTxt.Text = dr(2).ToString()
                obj.DateOfBirthDTP.Text = dr(3).ToString()
                obj.PhoneTxt.Text = dr(4).ToString()
                obj.MaritalComboBox.SelectedItem = dr(5).ToString()
                obj.OccupationTxt.Text = dr(6).ToString()
                obj.ResidenceComboBox.SelectedItem = dr(7).ToString()
                obj.FatherTxt.Text = dr(8).ToString()
                obj.FatherHomeTxt.Text = dr(9).ToString()
                obj.MotherTxt.Text = dr(10).ToString()
                obj.MotherHomeTxt.Text = dr(11).ToString()
                Dim img() As Byte
                img = dt.Rows(0)(12)
                Dim ms As New MemoryStream(img)
                obj.MemberPicture.Image = Image.FromStream(ms)
                obj.SexComboBox.SelectedItem = dr(13).ToString()
            Next
            Con.Close()
            clear()
            Me.Hide()

            obj.Show()
            obj.SaveBtn.Hide()
            obj.UpdateBtn.Show()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If DOBapLbl.Text = Nothing Or NameLbl.Text = Nothing Or PhoneLbl.Text = "" Or SexLbl.Text = Nothing Or ResidenceLbl.Text = Nothing Then
            MsgBox("Missing Information")
        ElseIf SearchComboBox.SelectedItem = "Phone number" Then
            EditByPhone()
        ElseIf SearchComboBox.SelectedItem = "Name" Then
            EditByName()

        End If

    End Sub

    Private Sub clear()
        DOBapLbl.Text = Nothing
        NameLbl.Text = Nothing
        DOBLbl.Text = Nothing
        PhoneLbl.Text = Nothing
        MaritalLbl.Text = Nothing
        OccupationLbl.Text = Nothing
        ResidenceLbl.Text = Nothing
        FatherLbl.Text = Nothing
        FatherhLbl.Text = Nothing
        MotherLbl.Text = Nothing
        MotherhLbl.Text = Nothing
        ProfilePictureBox.Image = Nothing
        SexLbl.Text = Nothing
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Try
            If DOBapLbl.Text = Nothing Or NameLbl.Text = "" Or PhoneLbl.Text = "" Or SexLbl.Text = Nothing Or ResidenceLbl.Text = Nothing Then
                MsgBox("Select Member to be deleted")
            Else
                Con.Open()
                Dim query = "delete from MemberTbl where MemberPhone = '" & PhoneLbl.Text & "'"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Member Deleted")
                Con.Close()
                clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Con.Close()
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub MemberDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub AutoCompleteName()
        Try
            Con.Open()
            Dim query = "select * from MemberTbl order by MemberName asc"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            Dim ds As New DataSet
            Dim dadapter As SqlDataAdapter
            dadapter = New SqlDataAdapter(cmd)
            dadapter.Fill(ds, "MemberName")
            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("MemberName").ToString)
            Next
            Con.Close()

            SearchTxt.AutoCompleteSource = AutoCompleteSource.CustomSource
            SearchTxt.AutoCompleteCustomSource = col
            SearchTxt.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Con.Close()
        End Try



    End Sub

    Sub AutoCompleteNumber()
        Try
            Con.Open()
            Dim query = "select * from MemberTbl order by MemberPhone asc"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            Dim ds As New DataSet
            Dim dadapter As SqlDataAdapter
            dadapter = New SqlDataAdapter(cmd)
            dadapter.Fill(ds, "MemberPhone")
            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("MemberPhone").ToString)
            Next
            Con.Close()

            SearchTxt.AutoCompleteSource = AutoCompleteSource.CustomSource
            SearchTxt.AutoCompleteCustomSource = col
            SearchTxt.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Con.Close()
        End Try




    End Sub

    Private Sub SearchTxt_TextChanged(sender As Object, e As EventArgs) Handles SearchTxt.TextChanged
    End Sub

    Private Sub SearchTxt_MouseClick(sender As Object, e As MouseEventArgs) Handles SearchTxt.MouseClick
        If SearchComboBox.SelectedItem = "Phone number" Then
            AutoCompleteNumber()
        ElseIf SearchComboBox.SelectedItem = "Name" Then
            AutoCompleteName()
        End If

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

        DOBapLbl.Text = Nothing
        NameLbl.Text = Nothing
        DOBLbl.Text = Nothing
        PhoneLbl.Text = Nothing
        MaritalLbl.Text = Nothing
        OccupationLbl.Text = Nothing
        ResidenceLbl.Text = Nothing
        FatherLbl.Text = Nothing
        FatherhLbl.Text = Nothing
        MotherLbl.Text = Nothing
        MotherhLbl.Text = Nothing
        ProfilePictureBox.Image = Nothing
        SexLbl.Text = Nothing
    End Sub
End Class