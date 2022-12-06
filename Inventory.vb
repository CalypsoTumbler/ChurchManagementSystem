Imports System.Data.SqlClient
Public Class Inventory
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Calypso Tumbler\Downloads\ChurchManagementSystem\ChurchDb.mdf;Integrated Security=False;Connect Timeout=30")

    Private Sub Populate()
        Con.Open()
        Dim sql = "select * from IventoryTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, Con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        InventoryDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Main.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim Date_Change As Date
        Date_Change = Date.Now

        If ItemNameTxt.Text = "" Then
            MsgBox("Enter name of item")
        ElseIf ItemQuantityTxt.Text = "" Then
            MsgBox("Enter quantity of item")
        Else
            Con.Open()
            Dim Query As String
            Query = "insert into IventoryTbl values('" & ItemNameTxt.Text & "', '" & ItemQuantityTxt.Text & "', '" & Date_Change & "' )"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Item added successfully")
            Con.Close()
            Populate()
            Clear()
        End If




    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint


    End Sub

    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
    End Sub

    Private Sub Clear()
        ItemNameTxt.Text = ""
        ItemQuantityTxt.Text = ""
        ' Key = 0
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If Key = 0 Then
            MsgBox("Select item to be deleted")
        Else
            Con.Open()
            Dim query = "delete from IventoryTbl where ItemID = " & Key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Item Deleted")
            Con.Close()
            Populate()
            Clear()
        End If

        'Con.Open()
        'Dim query = "delete from IventoryTbl where ItemID = " & Key & ""
        'Dim cmd As SqlCommand
        'cmd = New SqlCommand(query, Con)
        'cmd.ExecuteNonQuery()
        'MsgBox("Item Deleted")
        'Con.Close()
        'Populate()
        'Clear()
    End Sub
    Dim Key = 0
    Private Sub InventoryDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles InventoryDGV.CellMouseClick
        Try
            Dim row As DataGridViewRow = InventoryDGV.Rows(e.RowIndex)
            ItemNameTxt.Text = row.Cells(1).Value.ToString
            ItemQuantityTxt.Text = row.Cells(2).Value.ToString

            If ItemNameTxt.Text = "" Then
                Key = 0
            Else
                Key = Convert.ToInt32(row.Cells(0).Value.ToString)
            End If
        Catch ex As Exception
            MsgBox("Selection error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        'ItemID = Convert.ToInt64(ItemIdLbl.Text)
        Dim Date_Change As Date
        Date_Change = Date.Now

        If Key = 0 Then
            MsgBox("Select item to be edited")
        Else
            Con.Open()
            Dim query = "Update IventoryTbl set ItemName = '" & ItemNameTxt.Text & "', ItemQuantity = '" & ItemQuantityTxt.Text & "', Last_Edited = '" & Date_Change & "' where ItemID = " & Key & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Item Information Edited Successfully")
            Con.Close()
            Populate()
            Clear()
        End If





        'Con.Open()
        'Dim query = "DBCC CHECKIDENT ('IventoryTbl', RESEED, 0)"
        'Dim cmd As SqlCommand
        'cmd = New SqlCommand(query, Con)
        'cmd.ExecuteNonQuery()
        'MsgBox("Item Information Edited Successfully")
        'Con.Close()
        'Populate()
        'Clear()

        'Dim newDataRow As DataGridViewRow
        'newDataRow = InventoryDGV.Rows(index)
        'newDataRow.Cells(1).Value = ItemNameTxt.Text
        'newDataRow.Cells(2).Value = ItemQuantityTxt.Text

    End Sub
    Dim index As Integer
    Private Sub InventoryDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles InventoryDGV.CellClick


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