Public Class ConStrInputWithList
    Public Sub New()
    End Sub
#Region "ASPX"

    '0=FileName, 1=Title, 2=Input Field, 3=EmptyPlaceholder, 4=JSFooter
    Public InputWithoutList As String = "<%@ Page Language=""vb"" AutoEventWireup=""false"" CodeBehind=""{0}.aspx.vb"" Inherits="".{0}"" %>
<%@ Register TagPrefix=""cc1"" Namespace=""KTB.DNet.WebCC"" Assembly=""KTB.DNet.WebCC"" %>
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">
<html>
<head>
    <title>{0}</title>
    <meta content=""Microsoft Visual Studio .NET 7.1"" name=""GENERATOR"">
    <meta content=""Visual Basic .NET 7.1"" name=""CODE_LANGUAGE"">
    <meta content=""JavaScript"" name=""vs_defaultClientScript"">
    <meta content=""http://schemas.microsoft.com/intellisense/ie5"" name=""vs_targetSchema"">
    <link href=""../WebResources/stylesheet.css"" type=""text/css"" rel=""stylesheet"">
    <script language=""javascript"" src=""../WebResources/PreventNewWindow.js""></script>
    <script language=""javascript"" src=""../WebResources/InputValidation.js""></script>
    <script type=""text/javascript"">
    </script>
</head>
<body ms_positioning=""GridLayout"">
    <form id=""Form1"" method=""post"" enctype=""multipart/form-data"" runat=""server"">
        <table id=""Table1"" cellspacing=""0"" cellpadding=""0"" width=""100%"" border=""0"">
            <tr>
                <td class=""titlePage"">{1}</td>
            </tr>
            <tr>
                <td background=""../images/bg_hor.gif"" height=""1"">
                    <img height=""1"" src=""../images/bg_hor.gif"" border=""0""></td>
            </tr>
            <tr>
                <td height=""10"">
                    <img height=""1"" src=""../images/dot.gif"" border=""0""></td>
            </tr>
            <tr id=""trDetail"" runat=""server"">
                <td valign=""top"">
                    <table id=""Table2"" width=""100%"" border=""0"">{2}
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <hr>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>{3}{4}
</body>
</html>
"
    '0=FileName, 1=Title, 2=Input Field, 3=GridColumn, 4=JSFooter
    Public InputWithList As String = "<%@ Page Language=""vb"" AutoEventWireup=""false"" CodeBehind=""{0}.aspx.vb"" Inherits="".{0}"" %>
<%@ Register TagPrefix=""cc1"" Namespace=""KTB.DNet.WebCC"" Assembly=""KTB.DNet.WebCC"" %>
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">
<html>
<head>
    <title>{0}</title>
    <meta content=""Microsoft Visual Studio .NET 7.1"" name=""GENERATOR"">
    <meta content=""Visual Basic .NET 7.1"" name=""CODE_LANGUAGE"">
    <meta content=""JavaScript"" name=""vs_defaultClientScript"">
    <meta content=""http://schemas.microsoft.com/intellisense/ie5"" name=""vs_targetSchema"">
    <link href=""../WebResources/stylesheet.css"" type=""text/css"" rel=""stylesheet"">
    <script language=""javascript"" src=""../WebResources/PreventNewWindow.js""></script>
    <script language=""javascript"" src=""../WebResources/InputValidation.js""></script>
    <script type=""text/javascript"">
    </script>
</head>
<body ms_positioning=""GridLayout"">
    <form id=""Form1"" method=""post"" enctype=""multipart/form-data"" runat=""server"">
        <table id=""Table1"" cellspacing=""0"" cellpadding=""0"" width=""100%"" border=""0"">
            <tr>
                <td class=""titlePage"">{1}</td>
            </tr>
            <tr>
                <td background=""../images/bg_hor.gif"" height=""1"">
                    <img height=""1"" src=""../images/bg_hor.gif"" border=""0""></td>
            </tr>
            <tr>
                <td height=""10"">
                    <img height=""1"" src=""../images/dot.gif"" border=""0""></td>
            </tr>
            <tr id=""trDetail"" runat=""server"">
                <td valign=""top"">
                    <table id=""Table2"" width=""100%"" border=""0"">{2}
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <hr>
                </td>
            </tr>
            <tr id=""trGrid"" runat=""server"">
                <td valign=""top"">
                    <div id=""div1"" runat=""server"" style=""overflow: auto; height: auto"">
                        <asp:DataGrid ID=""dgList"" runat=""server"" Width=""100%"" CellSpacing=""1"" ForeColor=""GhostWhite""
                            PageSize=""20"" AllowSorting=""True"" AllowPaging=""True"" AllowCustomPaging=""True"" BorderColor=""#CDCDCD""
                            BorderStyle=""None"" BorderWidth=""0px"" BackColor=""Gainsboro"" CellPadding=""3"" GridLines=""Horizontal"" AutoGenerateColumns=""False"">
                            <SelectedItemStyle Font-Bold=""True"" ForeColor=""#F7F7F7"" BackColor=""#738A9C""></SelectedItemStyle>
                            <AlternatingItemStyle BackColor=""#F6F6F6""></AlternatingItemStyle>
                            <ItemStyle BackColor=""White""></ItemStyle>
                            <FooterStyle ForeColor=""#4A3C8C"" BackColor=""#B5C7DE""></FooterStyle>
                            <Columns>
                                <asp:BoundColumn Visible=""false"" DataField=""ID""></asp:BoundColumn>{3}
                            </Columns>
                            <PagerStyle HorizontalAlign=""Right"" ForeColor=""#4A3C8C"" BackColor=""#E7E7FF"" Mode=""NumericPages""></PagerStyle>
                        </asp:DataGrid>
                    </div>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>{4}
</body>
</html>
"
    Public JSFooter As String = "
    <script language=""javascript"">
        if (window.parent == window) {
            if (!navigator.appName == ""Microsoft Internet Explorer"") {
                self.opener = null;
                self.close();
            }
            else {
                this.name = ""origWin"";
                origWin = window.open(window.location, ""origWin"");
                window.opener = top;
                window.close();
            }
        }
    </script>"
    '0=FieldName, 1=FieldID
    Public InputFieldLabel As String = "
<tr>
    <td class=""titleField"" style=""width: 138px"" width=""138"" height=""24"">{0}</td>
    <td width=""1"" height=""24"">:</td>
    <td style=""width: 428px""  width=""428"">
        <asp:Label ID=""lbl{1}"" runat=""server""></asp:Label>
    </td>
</tr>"
    '0=FieldName, 1=FieldID
    Public InputFieldTextBox As String = "
<tr>
    <td class=""titleField"" style=""width: 138px"" width=""138"" height=""24"">{0}</td>
    <td width=""1"" height=""24"">:</td>
    <td style=""width: 428px""  width=""428"">
        <asp:TextBox onblur=""omitSomeCharacter('txt{1}','<>?*%$')"" ID=""txt{1}"" runat=""server"" Width=""150px""></asp:TextBox>
    </td>
</tr>"
    '0=FieldName, 1=FieldID
    Public InputFieldDDL As String = "
<tr>
    <td class=""titleField"" style=""width: 138px"" width=""138"" height=""24"">{0}</td>
    <td width=""1"" height=""24"">:</td>
    <td style=""width: 428px""  width=""428"">
        <asp:DropDownList ID=""ddl{1}"" runat=""server""></asp:DropDownList>
    </td>
</tr>"
    '0=FieldName, 1=FieldID
    Public InputFieldDate As String = "
<tr>
    <td class=""titleField"" style=""width: 138px"" width=""138"" height=""24"">{0}</td>
    <td width=""1"" height=""24"">:</td>
    <td style=""width: 428px""  width=""428"">
        <cc1:IntiCalendar ID=""ic{1}"" runat=""server""></cc1:IntiCalendar>
    </td>
</tr>"
    '0=FieldName, 1=FieldID
    Public InputFieldDateFromToWithCheck As String = "
<tr>
    <td class=""titleField"" style=""width: 138px"" width=""138"" height=""24"">{0}</td>
    <td width=""1"" height=""24"">:</td>
    <td style=""width: 428px""  width=""428"">
        <table>
            <tr>
                <td>
                    <asp:CheckBox ID=""chk{1}"" runat=""server""></asp:CheckBox>
                </td>
                <td>
                    <cc1:IntiCalendar ID=""{1}From"" runat=""server"" TextBoxWidth=""70""></cc1:IntiCalendar>
                </td>
                <td>&nbsp;s.d&nbsp;</td>
                <td>
                    <cc1:IntiCalendar ID=""{1}To"" runat=""server"" TextBoxWidth=""70""></cc1:IntiCalendar>
                </td>
            </tr>
        </table>
    </td>
</tr>"
    '0=FieldName, 1=FieldID
    Public InputFieldDateFromToWithoutCheck As String = "
<tr>
    <td class=""titleField"" style=""width: 138px"" width=""138"" height=""24"">{0}</td>
    <td width=""1"" height=""24"">:</td>
    <td style=""width: 428px""  width=""428"">
        <table>
            <tr>
                <td>
                    <cc1:IntiCalendar ID=""{1}From"" runat=""server"" TextBoxWidth=""70""></cc1:IntiCalendar>
                </td>
                <td>&nbsp;s.d&nbsp;</td>
                <td>
                    <cc1:IntiCalendar ID=""{1}To"" runat=""server"" TextBoxWidth=""70""></cc1:IntiCalendar>
                </td>
            </tr>
        </table>
    </td>
</tr>"
    '0=FieldName
    Public InputFieldPlaceHolderOnly As String = "
<tr>
    <td class=""titleField"" style=""width: 138px"" width=""138"" height=""24"">{0}</td>
    <td width=""1"" height=""24"">:</td>
    <td style=""width: 428px""  width=""428"">
        PlaceholderOnly
    </td>
</tr>"
    '0=ButtonPlaceHolder
    Public InputFieldButtonPlaceHolder As String = "
<tr>
    <td class=""titleField"" style=""width: 138px"" width=""138"" height=""24""></td>
    <td width=""1"" height=""24"">:</td>
    <td style=""width: 428px""  width=""428"">{0}
    </td>
</tr>"
    '0=ButtonName, 1=ButtonID
    Public InputFieldButtons As String = "
<asp:Button ID=""btn{1}"" runat=""server"" Width=""70"" Text=""{0}""></asp:Button><span style=""width: 5px""></span>"
    '0=Column Name, 1=CtrlID
    Public GridColumn As String = "
<asp:TemplateColumn HeaderText=""{0}"">
    <HeaderStyle Width=""5%"" CssClass=""titleTableService""></HeaderStyle>
    <ItemStyle Wrap=""False"" HorizontalAlign=""Center"" VerticalAlign=""Top""></ItemStyle>
    <ItemTemplate>
        <asp:Label runat=""server"" ID=""lbl{1}""></asp:Label>
    </ItemTemplate>
</asp:TemplateColumn>"
    Public GridButtonPlaceHolder As String = "
<asp:TemplateColumn>
    <HeaderStyle Width=""10%"" CssClass=""titleTableService""></HeaderStyle>
    <ItemStyle HorizontalAlign=""Center"" VerticalAlign=""Top""></ItemStyle>
    <ItemTemplate>
        {0}
    </ItemTemplate>
</asp:TemplateColumn>"
    Public GridButtonView As String = "
<asp:LinkButton ID=""btnLihat"" runat=""server"" Text=""Lihat"" CausesValidation=""False"" CommandName=""View"">
				<img src=""../images/detail.gif"" border=""0"" alt=""Lihat""></asp:LinkButton>"
    Public GridButtonEdit As String = "
<asp:LinkButton ID=""btnUbah"" runat=""server"" Text=""Ubah"" CausesValidation=""False"" CommandName=""Edit"">
				<img src=""../images/edit.gif"" border=""0"" alt=""Ubah""></asp:LinkButton>"
    Public GridButtonActive As String = "
<asp:LinkButton ID=""btnActive"" runat=""server"" Text=""Aktif"" CausesValidation=""False"" CommandName=""Active"">
				<img src=""../images/aktif.gif"" border=""0"" alt=""Aktif""></asp:LinkButton>"
    Public GridButtonInactive As String = "
<asp:LinkButton ID=""btnInActive"" runat=""server"" Text=""Inaktif"" CausesValidation=""False"" CommandName=""InActive"">
				<img src=""../images/in-aktif.gif"" border=""0"" alt=""Inaktif""></asp:LinkButton>"
    Public GridButtonDelete As String = "
<asp:LinkButton ID=""btnHapus"" runat=""server"" Text=""Hapus"" CausesValidation=""False"" CommandName=""Delete"">
				<img src=""../images/trash.gif"" border=""0"" alt=""Hapus""></asp:LinkButton>"

#End Region

#Region "VB"
    '0=FileName, 1=FieldControlDefault, 2=EmptyPlaceholder, 3=EmptyPlaceholder, 4=ButtonHandler, 5=EmptyPlaceholder
    Public VBInputWithoutList As String = "Imports KTB.DNet.Domain
Imports KTB.DNet.Domain.Search
Imports KTB.DNet.Utility
Imports KTB.DNet.BusinessFacade.Helper

Public Class {0}
    Inherits System.Web.UI.Page
    Const Insert As String = ""Insert""
    Const Edit As String = ""Edit""
    Const View As String = ""View""

    Dim gridColNo As Integer = 0
    Dim oDealer As Dealer
    Private sessHelper As New SessionHelper
    Private SessionName As String
    Private Mode As String = Insert
    Private SessionData As String = ""{0}.SessionData""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        oDealer = sessHelper.GetSession(""DEALER"")
        If Not Page.IsPostBack Then
            ViewState(Mode) = Insert
            Dim pageID As String = Guid.NewGuid().ToString()
            SessionName = pageID.Substring(pageID.Length = 10)
            ViewState(""sessionName"") = SessionName
            InitForm()
        End If
        ButtonControl()
        InitiateAuthorization()
        Debug()
    End Sub

    Private Sub Debug()
    End Sub

    Private Sub InitiateAuthorization()
        '' If Not SecurityProvider.Authorize(Context.User, SR.) Then
        ''     Server.Transfer(""../FrmAccessDenied.aspx?modulName="")
        '' End If
    End Sub

    Private Sub ButtonControl()
    End Sub

    Private Sub InitForm()
        If oDealer.Title <> EnumDealerTittle.DealerTittle.KTB Then
            {1}
        End If
    End Sub{2}{3}
    {4}
    {5}
End Class"
    '0=FileName, 1=FieldControlDefault, 2=ColumnControlDeclaration, 3=CrudGrid, 4=ButtonHandler, 5=ItemCommand
    Public VBInputWithList As String = "Imports KTB.DNet.Domain
Imports KTB.DNet.Domain.Search
Imports KTB.DNet.Utility
Imports KTB.DNet.BusinessFacade.Helper

Public Class {0}
    Inherits System.Web.UI.Page
    Const Insert As String = ""Insert""
    Const Edit As String = ""Edit""
    Const View As String = ""View""

    Dim gridColNo As Integer = 0
    Dim oDealer As Dealer
    Private sessHelper As New SessionHelper
    Private SessionName As String
    Private Mode As String = Insert
    Private SessionData As String = ""{0}.SessionData""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        oDealer = sessHelper.GetSession(""DEALER"")
        If Not Page.IsPostBack Then
            ViewState(Mode) = Insert
            Dim pageID As String = Guid.NewGuid().ToString()
            SessionName = pageID.Substring(pageID.Length = 10)
            ViewState(""sessionName"") = SessionName
            InitForm()
        End If
        ButtonControl()
        InitiateAuthorization()
        Debug()
    End Sub

    Private Sub Debug()
    End Sub

    Private Sub InitiateAuthorization()
        '' If Not SecurityProvider.Authorize(Context.User, SR.) Then
        ''     Server.Transfer(""../FrmAccessDenied.aspx?modulName="")
        '' End If
    End Sub

    Private Sub ButtonControl()
    End Sub

    Private Sub InitForm()
        ViewState(""CurrentSortColumn"") = ""ID""
        ViewState(""CurrentSortDirect"") = Sort.SortDirection.ASC

        If oDealer.Title <> EnumDealerTittle.DealerTittle.KTB Then
            {1}
        End If

        If Not IsNothing(ViewState(""NewPageIndex"")) Then
            BindDataGrid(ViewState(""NewPageIndex""))
        Else
            BindDataGrid(0)
        End If
    End Sub

    Private Sub BindDataGrid(ByVal indexPage As Integer)
        gridColNo = dgList.PageSize * indexPage
        Dim arrData As ArrayList = New ArrayList ''New DealerFacade(User).Retrieve(CriteriaSearch())
        sessHelper.SetSession(ViewState(""sessionName"") & SessionData, arrData)
        If arrData.Count > 0 Then
            CommonFunction.SortListControl(arrData, CType(ViewState(""CurrentSortColumn""), String), CType(ViewState(""CurrentSortDirect""), Integer))
            Dim PagedList As ArrayList = ArrayListPager.DoPage(arrData, indexPage, dgList.PageSize)
            sessHelper.SetSession(ViewState(""sessionName"") & ""{0}"", PagedList)
            dgList.DataSource = PagedList
            dgList.VirtualItemCount = arrData.Count
            dgList.CurrentPageIndex = indexPage
            dgList.DataBind()
        Else
            dgList.DataSource = New ArrayList
            dgList.VirtualItemCount = 0
            dgList.CurrentPageIndex = 0
            dgList.DataBind()

            MessageBox.Show(""Data tidak ditemukan"")
        End If
    End Sub

    Private Function CriteriaSearch() As CriteriaComposite
        Dim crit As CriteriaComposite ''= New CriteriaComposite(New Criteria(GetType(Dealer), ""RowStatus"", MatchType.Exact, CShort(DBRowStatus.Active)))
        Return crit
    End Function

    Protected Sub dgList_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dgList.ItemDataBound
        Try
            If Not e.Item.DataItem Is Nothing Then
            {2}
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Protected Sub dgList_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs) Handles dgList.PageIndexChanged
        Try
            dgList.CurrentPageIndex = e.NewPageIndex
            ViewState(""NewPageIndex"") = e.NewPageIndex
            BindDataGrid(e.NewPageIndex)
        Catch ex As Exception
        End Try
    End Sub
    {4}
    {5}
End Class"
    '0=ButtonName
    Public ButtonHandlerStr As String = "
    Protected Sub btn{0}_Click(sender As Object, e As EventArgs) Handles btn{0}.Click
        MessageBox.Show(""Hallo"")
    End Sub
"
    '0=DropdownControl
    Public BindDDLPlaceHolder As String = "
    Private Sub BindDDLJenis(ByVal ddlJenis As DropDownList)
        {0}
    End Sub
"
    '0=DropdownID
    Public BindDDLControl As String = "
        With {0}.Items
            .Clear()
            .Add(New ListItem(""Silahkan Pilih"", ""-1""))
        End With
"
    Public ItemCommandPlaceHolder As String = "
    Private Sub dgList_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dgList.ItemCommand
        Try
            ''If (e.CommandName = """") Then
            ''    Dim id As Integer = CInt(e.Item.Cells(0).Text)
            ''    Dim item As Object = New ObjectFacade(User).Retrieve(id)

                If Not IsNothing(ViewState(""NewPageIndex"")) Then
                    BindDataGrid(ViewState(""NewPageIndex""))
                Else
                    BindDataGrid(0)
                End If
            ''End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
"
#End Region
End Class
