Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml

Public Class CodeGen
    Private aspxCode As String

    Private Function ConvertRtfToText(ByVal rtb As RichTextBox) As String
        Return New RichTextBox() With {
            .Rtf = rtb.Rtf
        }.Text
    End Function

    Private Sub rtbStringWS_TextChanged(sender As Object, e As EventArgs) Handles rtbStringWS.TextChanged
        rtbStringWS.Text = ConvertRtfToText(rtbStringWS)
        rtbStringWS.SelectionStart = rtbStringWS.Text.Length
        rtbStringWS.Focus()
        If rtbStringWS.Text.Contains("H") Then
            txtHeaderTName.Enabled = True
        Else
            txtHeaderTName.Enabled = False
        End If

        If rtbStringWS.Text.Contains("D") Then
            txtDetailTName.Enabled = True
        Else
            txtDetailTName.Enabled = False
        End If
    End Sub

    Private Function FindSeparator(ByVal str As String) As Char
        Dim _return As Char = String.Empty
        Dim counts = From n In str Group n By n Into Group
                     Select n, Count = Group.Count()
                     Order By Count Descending

        For Each c In counts
            _return = c.n
            Exit For
        Next
        Return _return
    End Function

    Private Sub CodeGen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlTabs()
        txtOutputFolder.Enabled = False
    End Sub

    Private Sub InitiateControlIWL()
        txtLegend.Text = "Field Name;Control"
        Label5.Text = "Field List" & vbLf & "lbl = Label" & vbLf & "txt = TextBox" & vbLf & "ddl = Dropdown List" & vbLf & "dt = Date" & vbLf & "dr = Date Range" & vbLf & "drc = Date Range with Checkbox" & vbLf & "ph = Placeholder Only" & vbLf & "b = Button" & vbLf
        TextBox1.Text = "Without Control = Label" & vbLf & "crud;veaid"
        Label6.Text = "Grid Column " & vbLf & "v = View" & vbLf & "e = Edit" & vbLf & "a = Active" & vbLf & "i = Inactive " & vbLf & "d = Delete"

        txtIWLFileName.Text = "FrmMasterKPI"
        txtIWLPageTitle.Text = "Master Data KPI STNK Tracking"
    End Sub

    Private Sub InitiateControlNJWS()
        txtHeaderTName.Enabled = False
        txtDetailTName.Enabled = False
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) ' Handles RichTextBox1.TextChanged
        RichTextBox1.Text = ConvertRtfToText(RichTextBox1)
        RichTextBox1.SelectionStart = RichTextBox1.Text.Length
        RichTextBox1.Focus()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If Not CheckedOutput() Then
            MessageBox.Show("Fill Output Folder")
            Exit Sub
        End If

        Select Case TabControl1.SelectedTab.Name
            Case "InputWithList"
                GeneratePageInputWithList()
            Case "InputWithoutList"
            Case "NonJsonWS"
            Case "JSONWS"
        End Select
    End Sub
    Private Function CheckedOutput() As Boolean
        Return txtOutputFolder.Text.Trim.Length > 0
    End Function

    Private Sub ControlTabs()
        Select Case TabControl1.SelectedTab.Name
            Case "InputWithList"
                InitiateControlIWL()
            Case "InputWithoutList"
            Case "NonJsonWS"
                InitiateControlNJWS()
            Case "JSONWS"
        End Select
        txtOutputFolder.Text = "C:\Users\azadmin\Documents\Test"
    End Sub

    Private Sub TabControl1_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.TabIndexChanged
        ControlTabs()
    End Sub

    Private Sub GeneratePageInputWithList()
        GenerateASPXPageInputWithList()
        'GenerateVBCodeInputWithList()
        MessageBox.Show("Code Ready to Copy", "Alert")
    End Sub

    Private Sub GenerateVBCodeInputWithList()
        Throw New NotImplementedException()
    End Sub

    Private Sub GenerateASPXPageInputWithList()
        Dim ConStr As New ConStrInputWithList()
        Dim BaseStr As String = ConStr.InputWithList
        Dim buildCtrl As String = String.Empty
        Dim buildGridColumn As String = String.Empty
        Dim buildGridColumnButtons As Boolean = False
        Dim buildButton As String = String.Empty
        Dim buildButtonFlag As Boolean = False

        For Each fieldNames In RichTextBox1.Lines
            Dim fieldName As String = If(fieldNames.Split(";")(0), "")
            Dim fieldCtrl As String = If(fieldNames.Split(";")(1), "")
            Dim ctrlStr As String = String.Empty
            Select Case fieldCtrl
                Case "lbl"
                    ctrlStr = ConStr.InputFieldLabel
                Case "txt"
                    ctrlStr = ConStr.InputFieldTextBox
                Case "ddl"
                    ctrlStr = ConStr.InputFieldDDL
                Case "dt"
                    ctrlStr = ConStr.InputFieldDate
                Case "dr"
                    ctrlStr = ConStr.InputFieldDateFromToWithoutCheck
                Case "drc"
                    ctrlStr = ConStr.InputFieldDateFromToWithCheck
                Case "ph"
                    ctrlStr = ConStr.InputFieldPlaceHolderOnly
                Case "b"
                    buildButtonFlag = True
                    FormatStringCtrl(buildButton, ConStr.InputFieldButtons, fieldName, fieldName.Replace(" ", ""))
                    Continue For
            End Select
            FormatStringCtrl(buildCtrl, ctrlStr, fieldName, fieldName.Replace(" ", ""))
        Next

        If buildButtonFlag Then
            buildCtrl &= String.Format(ConStr.InputFieldButtonPlaceHolder, buildButton)
        End If

        Dim ctrlStrCol As String = String.Empty
        For Each gridCol In RichTextBox2.Lines
            If gridCol.Split(";").Length = 1 Then
                FormatStringCtrl(buildGridColumn, ConStr.GridColumn, gridCol, gridCol.Replace(" ", ""))
            Else
                Dim colName As String = gridCol.Split(";")(0)
                Dim btnType As Char() = gridCol.Split(";")(1).ToLower.ToCharArray()
                For Each ch As Char In btnType
                    Select Case ch
                        Case "v"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonView
                        Case "e"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonEdit
                        Case "a"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonActive
                        Case "i"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonInactive
                        Case "d"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonDelete
                    End Select
                Next
            End If
        Next

        If buildGridColumnButtons Then
            buildGridColumn &= String.Format(ConStr.GridButtonPlaceHolder, ctrlStrCol)
        End If

        aspxCode = String.Format(BaseStr, txtIWLFileName.Text, txtIWLPageTitle.Text, buildCtrl, buildGridColumn, ConStr.JSFooter)
    End Sub

    Private Sub FormatStringCtrl(ByRef buildCtrl As String, ByVal ctrlStr As String, ByVal FieldName As String, ByVal FieldID As String)
        If ctrlStr.Contains("{1}") Then
            buildCtrl &= String.Format(ctrlStr, FieldName, FieldID)
        Else
            buildCtrl &= String.Format(ctrlStr, FieldName)
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtOutputFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub LinkLabel1_MouseClick(sender As Object, e As MouseEventArgs) Handles LinkLabel1.MouseClick
        Clipboard.SetText(aspxCode)
        MessageBox.Show("Code Copied to Clipboard", "Alert")
    End Sub

    Private Sub LinkLabel2_MouseClick(sender As Object, e As MouseEventArgs) Handles LinkLabel2.MouseClick
        'MessageBox.Show("Code Copied to Clipboard", "Alert")
        MessageBox.Show("Not Yet Implemented", "Alert")
    End Sub

    Private Sub LinkLabel3_MouseClick(sender As Object, e As MouseEventArgs) Handles LinkLabel3.MouseClick
        MessageBox.Show("Not Yet Implemented", "Alert")
    End Sub
End Class
