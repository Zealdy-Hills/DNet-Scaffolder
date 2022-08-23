Imports Microsoft.SqlServer
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Xml

Public Class CodeGen
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private liTables As New List(Of String)
    Private Server As String = String.Empty
    Private DB As String = String.Empty
    Private Username As String = String.Empty
    Private Pass As String = String.Empty
    Private _IS As Boolean = False

    Private ReadOnly qSQLTV As String = "SELECT [name] FROM sys.objects o WHERE [type] IN ('U','V') order by [type] asc, [name] asc"

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.Text = ConvertRtfToText()
    End Sub
    Private Function ConvertRtfToText() As String
        Return New RichTextBox() With {
            .Rtf = Me.RichTextBox1.Rtf
        }.Text
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ListBox1.Items.Clear()
        For Each str As String In liTables
            If str.ToLower.Contains(TextBox1.Text.ToLower) Then
                ListBox1.Items.Add(str)
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadConfig()

        myConn = New SqlConnection("Server=" & Server & ";Database=" & DB & ";User Id=" & Username & ";Password=" & Pass & ";")
        myCmd = myConn.CreateCommand
        myCmd.CommandText = qSQLTV

        myConn.Open()
        myReader = myCmd.ExecuteReader()
        Do While myReader.Read()
            Try
                liTables.Add(myReader.GetString(0))
            Catch ex As Exception

            End Try
        Loop
        myReader.Close()
        myConn.Close()

        liTables.ForEach(Sub(x) ListBox1.Items.Add(x))
    End Sub

    Private Sub LoadConfig()
        Dim doc As New XmlDocument
        doc.LoadXml(RichTextBox1.Text.ToString())
        Try
            For Each detail As XmlElement In doc.DocumentElement.GetElementsByTagName("parameters")
                For Each subdetail As XmlElement In detail.GetElementsByTagName("parameter")
                    Dim name As String = GetAttibuteValue(subdetail, "name")
                    Dim value As String = GetAttibuteValue(subdetail, "value")
                    Select Case name
                        Case "database"
                            DB = value
                        Case "password"
                            Pass = value
                        Case "server"
                            Server = value
                        Case "uid"
                            Username = value
                        Case "Integrated Security"
                            _IS = CBool(value)
                    End Select
                Next subdetail
            Next detail
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
        End Try
    End Sub

    Private Function GetAttibuteValue(ByVal node As XmlNode, ByVal attibutename As String) As String
        Dim ret As String = String.Empty
        If node IsNot Nothing AndAlso node.Attributes IsNot Nothing Then
            Dim attrib As XmlNode = node.Attributes.GetNamedItem(attibutename)
            If attrib IsNot Nothing Then
                ret = attrib.Value
            End If
        End If
        Return ret
    End Function

    Private Function CheckedOutput() As Boolean
        Return TextBox1.Text.Trim.Length > 0
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class
