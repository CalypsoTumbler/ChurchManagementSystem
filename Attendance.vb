Imports System.Data.SqlClient

Public Class Attendance
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Dim Con As New SqlConnection("Data Source=SQL8003.site4now.net;Initial Catalog=db_a91405_calypsotumbler001;User Id=db_a91405_calypsotumbler001_admin;Password=C@lypso2022")
    Private Sub Attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Con.Open()
        'Dim Sql = "select MemberName, MemberSex, MemberPhone From MemberTbl Order By MemberName Asc"
        'Dim adapter As SqlDataAdapter
        'adapter = New SqlDataAdapter(Sql, Con)
        'Dim builder As SqlCommandBuilder
        'builder = New SqlCommandBuilder(adapter)
        'Dim ds As DataSet
        'ds = New DataSet
        'adapter.Fill(ds)
        'AttendanceDGV.DataSource = ds.Tables(0)
        'Con.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Main.Show()
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim cmd As New SqlCommand("Select AttendanceDate from AttendanceTbl where AttendanceDate = @Date", Con)
        cmd.Parameters.AddWithValue("Date", AttendanceDTP.Value.Date)
        Try
            Con.Open()
            Dim myreader As SqlDataReader = cmd.ExecuteReader
            If myreader.Read Then
                Con.Close()
                MsgBox("Attendance for this date already recorded")
            Else
                Con.Close()
                For Each row As DataGridViewRow In AttendanceDGV.Rows
                    Dim cmd1 As New SqlCommand("Insert into AttendanceTbl(AttendanceDate, MemberName, MemberSex, MemberPhone, AttendanceStatus) Values(@Date, @Name, @sex, @Phone, @Status)", Con)
                    cmd1.Parameters.AddWithValue("@Date", AttendanceDTP.Value.Date)
                    cmd1.Parameters.AddWithValue("@Name", row.Cells("MemberName").Value)
                    cmd1.Parameters.AddWithValue("@Sex", row.Cells("MemberSex").Value)
                    cmd1.Parameters.AddWithValue("@Phone", row.Cells("MemberPhone").Value)
                    Dim statuscolumn As Integer
                    If Convert.ToBoolean(row.Cells("AttendanceStatus").Value) Then
                        statuscolumn = 1
                    Else
                        statuscolumn = 0
                    End If
                    cmd1.Parameters.AddWithValue("@Status", statuscolumn)
                    Con.Open()
                    cmd1.ExecuteNonQuery()
                    Con.Close()
                Next
                MsgBox("Attendance recorded sucessfully")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ReportBtn.Click

        Try
            Con.Open()
            Dim Sql = "select AttendanceDate, MemberName, MemberSex, MemberPhone, AttendanceStatus From AttendanceTbl where AttendanceDate = '" & AttendanceDTP.Value.Date & "'Order By MemberName Asc"
            Dim adapter As SqlDataAdapter
            adapter = New SqlDataAdapter(Sql, Con)
            Dim builder As SqlCommandBuilder
            builder = New SqlCommandBuilder(adapter)
            Dim ds As DataSet
            ds = New DataSet
            adapter.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count

            If a = 0 Then
                MsgBox("No attendance recorded for this date")
                Con.Close()
            Else
                Dim report As New CrystalReport1
                Dim At_Report As New AttendanceReport
                report.SetDataSource(ds.Tables(0))
                report.SetParameterValue(0, AttendanceDTP.Value.Date)
                At_Report.CrystalReportViewer1.ReportSource = report
                At_Report.CrystalReportViewer1.Zoom(100%)
                At_Report.CrystalReportViewer1.Refresh()
                At_Report.Show()
                'Dim At_Report As New AttendanceReport
                'At_Report.Show()

                Con.Close()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Con.Close()
        End Try

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Hide()
        Dim Main1 As New Main
        Main1.Show()
    End Sub
End Class