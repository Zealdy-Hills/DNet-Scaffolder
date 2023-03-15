Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.Reflection
Imports System.Text
Imports System.Linq
Imports System.Web.Script.Serialization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
Imports Newtonsoft
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Schema

Public Class CodeGen
    Private aspxCode As String
    Private vbCode As String
    Private njwsCode As String
    Private njwsKey As String
    Private jwsCode As String
    Private liControl As List(Of String)
    Private liGridCmd As List(Of String)

    Const ROW_LINEBREAKER As String = "\n"
    Const COL_SEPARATOR As String = ";"
    Const INDICATOR_KEY As String = "K"
    Const INDICATOR_HEADER As String = "H"
    Const INDICATOR_DETAIL As String = "D"
    Const INDICATOR_DETAIL_CHILD As String = "DD"

    Const Ver As String = "0.7"

    Private Sub CodeGen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "D-Net Scaffolder " & Ver
        'TabControl1.SelectedIndex = 2
        ControlTabs()
        txtOutputFolder.Enabled = False
    End Sub

    Private Function ConvertRtfToText(ByVal rtb As RichTextBox) As String
        Return New RichTextBox() With {
            .Rtf = rtb.Rtf
        }.Text
    End Function

    Protected Function GetLines(ByRef str As String) As String()
        Dim lines As String() = str.Split(ROW_LINEBREAKER)
        Dim nRow As Integer = lines.Length

        If lines(nRow - 1).Substring(1).Trim() = String.Empty Then nRow = nRow - 1
        Dim ls(nRow - 1) As String

        For i As Integer = 0 To nRow - 1 ' lines.Length - 1
            If i = 0 Then
                ls(i) = lines(i)
            Else
                ls(i) = lines(i).Substring(1)
            End If
        Next

        Return ls
    End Function

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Select Case TabControl1.SelectedTab.Name
            Case "InputWithList"
                GeneratePageInputWithList()
            Case "NonJsonWS"
                GenerateNJWS()
            Case "JSONWS"
                GenerateJWS()
        End Select
    End Sub

    Private Sub LinkLabel3_MouseClick(sender As Object, e As MouseEventArgs) Handles LinkLabel3.MouseClick
        If Not CheckedOutput() Then
            MessageBox.Show("Fill Output Folder")
            Exit Sub
        End If
        MessageBox.Show("Not Yet Implemented", "Alert")
    End Sub

    Private Function CheckedOutput() As Boolean
        Return txtOutputFolder.Text.Trim.Length > 0
    End Function

    Private Sub ControlTabs()
        Select Case TabControl1.SelectedTab.Name
            Case "InputWithList"
                InitiateControlIWL()
            Case "NonJsonWS"
                InitiateControlNJWS()
            Case "JSONWS"
                InitiateControlJWS()
        End Select
        txtOutputFolder.Text = "C:\Users\azadmin\Documents\Test"
        liControl = New List(Of String)
        liGridCmd = New List(Of String)
    End Sub

    Private Sub TabControl1_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        ControlTabs()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtOutputFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub rtbStringWS_TextChanged(sender As Object, e As EventArgs) Handles rtbStringWS.TextChanged, rtbJsonString.TextChanged
        sender.Text = ConvertRtfToText(sender)
        sender.SelectionStart = sender.Text.Length
        sender.Focus()
    End Sub

#Region "JSON WS"
    Private Sub InitiateControlJWS()
        'rtbJsonString.Text = "[{""SONumber"":""7580072892"",""Detail"":[{""PartNumber"":""4250D596"",""PartName"":""WHEEL,DISC 18"",""Qty"":""1"",""Reason"":""Z9""}]},{""SONumber"":""7580072893"",""Detail"":[{""PartNumber"":""4250D593"",""PartName"":""WHEEL,DISC 19"",""Qty"":""3"",""Reason"":""Z7""}]"
        rtbJsonString.Text = "{""LetterNo"":""008/PROM-689/02/23"",""Iklan"":[{""MediaBroadcastPeriodBegin"":""2023-02-01T00:00:00"",""MediaBroadcastPeriodEnd"":""2023-02-28T00:00:00"",""MediaDetails"":[{""Media"":""Service Campaign 10k"",""MediaName"":""Mothers Day""}],""DealerName"":""SUN STAR MOTOR, PT.""}],""ProposalCode"":""I022300016""}"
        'rtbJsonString.Text = "{""LetterNo"":""008/PROM-689/02/23"",""ProposalCode"":""I022300016"",""MediaBroadcastPeriodBegin"":""2023-02-01T00:00:00"",""MediaBroadcastPeriodEnd"":""2023-02-28T00:00:00"",""Media"":""Service Campaign 10k"",""MediaName"":""Mothers Day"",""DealerName"":""SUN STAR MOTOR, PT.""}"
        'rtbJsonString.Text = "{""SONumber"":""7580072892"",""Detail"":[""4250D596"",""WHEEL,DISC 18"",""Z9""]}"
        txtJsonKey.Text = "SOCANCEL"
        txtJsonParserName.Text = "SOCancelJsonParser"
        txtJsonObjectName.Text = "SOCancelJson"
        LinkLabel1.Visible = False
        LinkLabel2.Visible = True
    End Sub

    Private Sub GenerateJWS()
        'Construct Json Class
        Dim jss As New JavaScriptSerializer()
        Dim dict As Dictionary(Of Object, Object) = jss.Deserialize(Of Dictionary(Of Object, Object))(rtbJsonString.Text.Trim)
        Dim sortDict As New Dictionary(Of String, String)
        For Each item As KeyValuePair(Of Object, Object) In dict
            sortDict.Add(item.Key, item.Value.GetType.Name)
        Next

        'Dim pack As New StringBuilder
        'Dim current As String = txtJsonObjectName.Text
        'jsonSearch(current, dict, pack)

        'Construct Parser
        Dim ConStr As New ConStrJSONWS()
        Dim parserStr As String = ConStr.strJsonParser
        Dim ClassObjStr As String = String.Format(ConStr.strClass, txtJsonObjectName.Text)
        Dim NamespaceStr As String = String.Format(ConStr.strNamespace, ClassObjStr)
        jwsCode = String.Format(parserStr, txtJsonParserName.Text, txtJsonObjectName.Text, txtJsonObjectName.Text.Replace("Json", ""), NamespaceStr)

        'Dim cla As String = String.Format(ConStr.strClass, txtJsonObjectName.Text, pack.ToString())
        'Dim q As String = pack.ToString()
        Dim debug = ""
    End Sub

    Private Sub jsonSearch(currentClass As String, dict As Dictionary(Of Object, Object), ByRef pack As StringBuilder)
        For Each keys In dict.Keys
            If dict(keys).GetType.Name = "Object[]" Then
                jsonSearchChild(keys, dict(keys), pack)
            Else
                pack.AppendLine("Public " & keys & " As " & dict(keys).GetType.Name)
            End If
        Next
    End Sub
    Private Sub jsonSearchChild(currentClass As String, dict As Object, ByRef pack As StringBuilder)
        For Each keys In dict
            If dict(keys).GetType.Name = "Object[]" Then
                jsonSearchChild(keys, dict(keys), pack)
            Else
                pack.AppendLine("Public " & keys & " As " & dict(keys).GetType.Name)
            End If
        Next
    End Sub
#End Region

#Region "Non JSON WS"
    Private Sub InitiateControlNJWS()
        rtbStringWS.Text = "K;MasterAccrued_20210921210013\nH;BussinessAreaCode;AccKey;Description;Type;CostCenterCode;InternalOrderCode\nD;BussinessAreaCodeASD;AccKeyASD;DescriptionASD;TypeASD;CostCenterCodeASD;InternalOrderCodeASD\n"
        txtParserName.Text = "MasterAccruedParser"
        txtHeaderTName.Text = "MasterAccrued"
        txtDetailTName.Text = "MasterAccrued2"
        LinkLabel1.Visible = False
        LinkLabel2.Visible = True
    End Sub

    Private Function ReadStrNJWS(ConStr As ConStrNJWS, ByRef detailFlag As Boolean) As String
        Dim baseStr As String = String.Empty
        For Each line As String In GetLines(rtbStringWS.Text)
            Dim ind As String = line.Split(COL_SEPARATOR)(0)
            If ind = INDICATOR_HEADER Then
                baseStr = ConStr.StrParserFileOnlyHeader
            ElseIf ind = INDICATOR_DETAIL Then
                detailFlag = True
            ElseIf ind = INDICATOR_KEY Then
                Dim lineKey As String = line.Split(COL_SEPARATOR)(1)
                njwsKey = lineKey.Split("_")(0)
            End If
        Next
        Return baseStr
    End Function

    Private Sub GenerateNJWS()
        Dim ConStr As New ConStrNJWS()
        Dim DetailFlag As Boolean = False
        Dim baseStr As String = ReadStrNJWS(ConStr, DetailFlag)
        Dim ParseHeaderVariable As String = String.Empty
        Dim HeaderVariableToDomain As String = String.Empty
        Dim NJWSFooter As String = String.Empty
        Dim NJWSDetailDoParse As String = String.Empty
        Dim NJWSParseDetail As String = String.Empty
        Dim NJWSDetailGVar As String = String.Empty
        Dim NJWSDetailDoParseVar As String = String.Empty
        BuildParseVariable(ParseHeaderVariable, ConStr)
        BuildVariableToDomain(HeaderVariableToDomain, ConStr.VarTDom)
        BuildFooterNJWS(NJWSFooter, ConStr)
        If DetailFlag Then
            BuildDetailDoParse(NJWSDetailDoParse, ConStr)
            BuildParseDetail(NJWSParseDetail, ConStr)
            NJWSDetailGVar = String.Format(ConStr.DetailGlobalVar, txtDetailTName.Text)
            NJWSDetailDoParseVar = String.Format(ConStr.DetailDoParseVar, txtDetailTName.Text)
        End If

        njwsCode = String.Format(baseStr, txtParserName.Text, txtHeaderTName.Text, rtbStringWS.Text, ParseHeaderVariable, HeaderVariableToDomain, NJWSFooter, NJWSDetailDoParse, NJWSParseDetail, NJWSDetailGVar, NJWSDetailDoParseVar)
        MessageBox.Show("Code Ready to Copy", "Alert")
    End Sub

    Private Sub BuildParseDetail(ByRef nJWSParseDetail As String, conStr As ConStrNJWS)
        Dim DetailVar As String = String.Empty
        Dim DetailToDomain As String = String.Empty
        BuildParseVariable(DetailVar, conStr, False)
        BuildVariableToDomain(DetailToDomain, conStr.VarTDom, False)
        nJWSParseDetail = String.Format(conStr.ParseDetailStr, txtDetailTName.Text, DetailVar, DetailToDomain)
    End Sub

    Private Sub BuildDetailDoParse(ByRef nJWSDetailDoParse As String, conStr As ConStrNJWS)
        nJWSDetailDoParse = String.Format(conStr.DetailDoParseStr, txtHeaderTName.Text, txtDetailTName.Text)
    End Sub

    Private Sub BuildFooterNJWS(ByRef nJWSFooter As String, ConStr As ConStrNJWS)
        nJWSFooter &= String.Format(ConStr.WebConfigStr, njwsKey.ToUpper) & vbLf
        nJWSFooter &= String.Format(ConStr.SysLogStr, njwsKey) & vbLf
        nJWSFooter &= String.Format(ConStr.RestFullW1, njwsKey.ToUpper) & vbLf
        nJWSFooter &= String.Format(ConStr.RestFullW2, njwsKey.ToUpper) & vbLf
        nJWSFooter &= String.Format(ConStr.RestFullW3, njwsKey.ToUpper) & vbLf
        nJWSFooter &= String.Format(ConStr.RestFullW4, njwsKey.ToUpper) & vbLf
    End Sub

    Private Sub BuildVariableToDomain(ByRef variableToDomain As String, ConStr As String, Optional HeaderOnly As Boolean = True)
        Dim VarTDom As String = ConStr
        For Each line As String In GetLines(rtbStringWS.Text)
            Dim strNJWS As String() = line.Split(COL_SEPARATOR)
            If strNJWS(0) = INDICATOR_KEY Then Continue For
            For Each str As String In strNJWS
                If str = INDICATOR_HEADER OrElse str = INDICATOR_DETAIL Then Continue For
                If HeaderOnly Then
                    If strNJWS(0) = INDICATOR_DETAIL Then Exit For
                Else
                    If strNJWS(0) = INDICATOR_HEADER Then Continue For
                End If
                If strNJWS(0) = INDICATOR_HEADER Then
                    variableToDomain &= String.Format(VarTDom, str.Replace(" ", ""), txtHeaderTName.Text)
                End If
                If strNJWS(0) = INDICATOR_DETAIL Then
                    variableToDomain &= String.Format(VarTDom, str.Replace(" ", ""), txtDetailTName.Text)
                End If
            Next
        Next
    End Sub

    Private Sub BuildParseVariable(ByRef parseVariable As String, ConStr As ConStrNJWS, Optional HeaderOnly As Boolean = True)
        Dim DecVar As String = ConStr.DecVar
        For Each line As String In GetLines(rtbStringWS.Text)
            Dim strNJWS As String() = line.Split(COL_SEPARATOR)
            If strNJWS(0) = INDICATOR_KEY Then Continue For
            Dim i As Integer = 1
            For Each str As String In strNJWS
                If str = INDICATOR_HEADER OrElse str = INDICATOR_DETAIL Then Continue For
                If HeaderOnly Then
                    If strNJWS(0) = INDICATOR_DETAIL Then Exit For
                Else
                    If strNJWS(0) = INDICATOR_HEADER Then Continue For
                End If
                parseVariable &= String.Format(DecVar, str.Replace(" ", ""), i) & vbTab & vbTab & vbTab & vbTab
                i += 1
            Next
        Next
    End Sub
#End Region

#Region "Input With List"
    Private Sub InitiateControlIWL()
        txtLegend.Text = "Field Name;Control"
        Label5.Text = "Field List" & vbLf & "lbl = Label" & vbLf & "txt = TextBox" & vbLf & "ddl = Dropdown List" & vbLf & "dt = Date" & vbLf & "dr = Date Range" & vbLf & "drc = Date Range with Checkbox" & vbLf & "ph = Placeholder Only" & vbLf & "b = Button" & vbLf
        TextBox1.Text = "Without Control = Label" & vbLf & "crud;veaid"
        Label6.Text = "Grid Column " & vbLf & "v = View" & vbLf & "e = Edit" & vbLf & "a = Active" & vbLf & "i = Inactive " & vbLf & "d = Delete"

        txtIWLFileName.Text = "FrmMasterKPI"
        txtIWLPageTitle.Text = "Master Data KPI STNK Tracking"
        LinkLabel1.Visible = True
        LinkLabel2.Visible = False
    End Sub

    Private Sub GeneratePageInputWithList()
        GenerateASPXPageInputWithList()
        GenerateVBCodeInputWithList()
        MessageBox.Show("Code Ready to Copy", "Alert")
    End Sub

    Private Sub GenerateVBCodeInputWithList()
        Dim withList As Boolean = If(RichTextBox2.TextLength = 0, False, True)
        Dim ConStr As New ConStrInputWithList()
        Dim BaseStr As String = ConStr.VBInputWithList
        If Not withList Then
            BaseStr = ConStr.VBInputWithoutList
        End If
    End Sub

    Private Sub GenerateASPXPageInputWithList()
        Dim withList As Boolean = If(RichTextBox2.TextLength = 0, False, True)
        Dim ConStr As New ConStrInputWithList()
        Dim BaseStr As String = ConStr.InputWithList
        If Not withList Then
            BaseStr = ConStr.InputWithoutList
        End If

        Dim buildCtrl As String = String.Empty
        Dim buildGridColumn As String = String.Empty
        Dim buildGridColumnButtons As Boolean = False
        Dim buildButton As String = String.Empty
        Dim buildButtonFlag As Boolean = False

        For Each fieldNames In RichTextBox1.Lines
            Dim fieldName As String = If(fieldNames.Split(";")(0), "")
            Dim fieldCtrl As String = If(fieldNames.Split(";")(1), "")
            Dim fieldID As String = fieldName.Replace(" ", "")
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
                    FormatStringCtrl(buildButton, ConStr.InputFieldButtons, fieldName, fieldID)
                    liControl.Add(fieldCtrl & ";" & fieldID)
                    Continue For
            End Select
            FormatStringCtrl(buildCtrl, ctrlStr, fieldName, fieldID)
            liControl.Add(fieldCtrl & ";" & fieldID)
        Next

        If buildButtonFlag Then
            buildCtrl &= String.Format(ConStr.InputFieldButtonPlaceHolder, buildButton)
        End If

        Dim ctrlStrCol As String = String.Empty
        For Each gridCol In RichTextBox2.Lines
            If gridCol.Split(";").Length = 1 Then
                Dim gridColID As String = gridCol.Replace(" ", "")
                FormatStringCtrl(buildGridColumn, ConStr.GridColumn, gridCol, gridColID)
                liGridCmd.Add("lbl;" & gridColID)
            Else
                Dim colName As String = gridCol.Split(";")(0)
                Dim btnType As Char() = gridCol.Split(";")(1).ToLower.ToCharArray()
                For Each ch As Char In btnType
                    Select Case ch
                        Case "v"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonView
                            liGridCmd.Add(ch & ";View")
                        Case "e"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonEdit
                            liGridCmd.Add(ch & ";Edit")
                        Case "a"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonActive
                            liGridCmd.Add(ch & ";Active")
                        Case "i"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonInactive
                            liGridCmd.Add(ch & ";Inactive")
                        Case "d"
                            buildGridColumnButtons = True
                            ctrlStrCol &= ConStr.GridButtonDelete
                            liGridCmd.Add(ch & ";Delete")
                        Case Else
                            Continue For
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

    Private Sub LinkLabel1_MouseClick(sender As Object, e As MouseEventArgs) Handles LinkLabel1.MouseClick
        Clipboard.SetText(aspxCode)
        MessageBox.Show("Code Copied to Clipboard", "Alert")
    End Sub

    Private Sub LinkLabel2_MouseClick(sender As Object, e As MouseEventArgs) Handles LinkLabel2.MouseClick
        Select Case TabControl1.SelectedTab.Name
            Case "NonJsonWS"
                Clipboard.SetText(njwsCode)
                MessageBox.Show("Code Copied to Clipboard", "Alert")
            Case Else
                MessageBox.Show("Not Yet Implemented", "Alert")
        End Select
    End Sub
#End Region

End Class

Public Class Rootobject
    Public Property LetterNo As String
    Public Property ProposalCode As String
    Public Property Iklan() As Iklan
End Class

Public Class Iklan
    Public Property MediaBroadcastPeriodBegin As Date
    Public Property MediaBroadcastPeriodEnd As Date
    Public Property MediaDetails() As Mediadetail
    Public Property DealerName As String
End Class

Public Class Mediadetail
    Public Property Media As String
    Public Property MediaName As String
End Class

