
Imports System.Data.SqlClient
Imports Zenoph.Notify.Collections
Imports Zenoph.Notify.Enums
Imports Zenoph.Notify.Request
Imports Zenoph.Notify.Response
Imports Zenoph.Notify.Store


Public Class Anouncements
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Main.Show()
    End Sub

    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Calypso Tumbler\Downloads\ChurchManagementSystem\ChurchDb.mdf;Integrated Security=False;Connect Timeout=30")
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If RichTextBox1.Text = Nothing Then
            MsgBox("Enter message to be sent")
        Else
            SMSRequest.setHost("api.smsonlinegh.com")
            Try

                ' Initialise SMS request with the authentication profile
                Dim sr2 As SMSRequest = New SMSRequest()

                ' set API key for authentication
                sr2.setAuthModel(AuthModel.API_KEY)
                sr2.setAuthApiKey("fa92a80f3b9d77a7636db019acd971bc9331dbcd853343f8200b177c753cdeb4")
                ' use secure connection
                SMSRequest.useSecureConnection(True)
                ' set message properties and submit
                sr2.setMessage(RichTextBox1.Text)
                sr2.setMessageType(TextMessageType.TEXT)
                sr2.setSender("COC KASOA")

                'Extract MemberPhone to Arraylist
                Dim Numbers As New ArrayList
                Con.Open()
                Dim q1 As String = "Select MemberPhone From MemberTbl"
                Dim cm1 = New SqlCommand(q1, Con)
                Dim dr1 As SqlDataReader = cm1.ExecuteReader()
                While dr1.Read()
                    For i As Integer = 0 To CType(dr1, IDataRecord).FieldCount - 1
                        Numbers.Add(dr1(i).ToString)
                    Next
                End While
                dr1.Close()
                Con.Close()
                'Set Arraylist as message destination
                If Numbers IsNot Nothing Then
                    For Each num As String In Numbers
                        sr2.addDestination(num, False)
                    Next
                End If
                sr2.submit()

                ' submit message and store the response
                'Dim resp As MessageResponse = sr2.submit()

                MsgBox("Message sent successfully")
                RichTextBox1.Text = Nothing








            Catch ex As RequestException
                ' get the handshake indicator to know the cause of the error
                Dim rh As RequestHandshake = ex.getRequestHandshake()
                Dim rhex As String = getRequestHandshakeDesc(rh)
                'Exception catch code continues
                MsgBox("Request Error: " + rh)

            Catch ex As Exception
                ' Exception catch code continues
                MsgBox("Error: " + ex.Message)
            End Try

        End If


    End Sub

    Private Function getRequestHandshakeDesc(ByVal rh As RequestHandshake) As String
        Select Case rh
            Case RequestHandshake.HSHK_ERR_UA_AUTH ' authentication failure
                Return "Authentication failed"

                ' inspection can continue.

            Case Else
                Return "Connection timeout: check internet connection"
        End Select
    End Function

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        RichTextBox1.Text = Nothing
        Me.Hide()
        Dim Main1 As New Main
        Main1.Show()
    End Sub
End Class