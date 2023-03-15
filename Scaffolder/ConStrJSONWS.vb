Public Class ConStrJSONWS
    '0=Filename, 1=Json Class, 2=Facade(substring Json from Json Class), 3=Copas Json Class
    Public strJsonParser As String = "#Region "".NET Base Class Namespace Imports""
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.Principal
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Linq
#End Region

#Region ""Custom Namespace Imports""
Imports KTB.DNet.Domain
Imports KTB.DNet.Parser.Domain
Imports KTB.DNet.Domain.Search
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports KTB.DNet.BusinessFacade.SparePart
Imports System.Globalization

#End Region

Namespace KTB.DNet.Parser
    Public Class {0}
        Inherits AbstractParser

#Region ""Private Variables""
        Private grammar As Regex
        Private jsonData As List(Of {1})
        Private errorMessage As StringBuilder
#End Region

#Region ""Constructors/Destructors/Finalizers""
        Public Sub New()
            grammar = MyBase.GetGrammarParser()
        End Sub
#End Region

        Protected Overrides Function DoParse(fileName As String, user As String) As Object
            Throw New NotImplementedException()
        End Function

        Protected Overrides Function DoTransaction() As Integer
            Throw New NotImplementedException()
        End Function

        Protected Overrides Function DoParseFixFormatFile(fileName As String, user As String) As Object
            Throw New NotImplementedException()
        End Function

        Protected Overrides Function DoParse(ByVal KeyName As String, ByVal Content As String, ByRef msg As String) As Object
            Try
                msg = String.Empty
                jsonData = JsonConvert.DeserializeObject(Of List(Of {1}))(Content)
            Catch ex As Exception
                SysLogParameter.LogErrorToSyslog(ex.Message.ToString, ""json-worker"", ""{0}.vb"", ""Parsing"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, SysLogParameter.ParserType.{0}, BlockName)
                Dim e As Exception = New Exception(KeyName & Chr(13) & Chr(10) & Chr(13) & Chr(10) & ex.Message)
                Dim rethrow As Boolean = ExceptionPolicy.HandleException(e, ""Parser Policy"")
                jsonData = Nothing

                Dim err As String = ""Parsing Error : "" & ex.Message
                msg = IIf(String.IsNullOrEmpty(msg), err, String.Concat(msg, "" | "", err))
            End Try

            Return jsonData
        End Function

        Protected Overrides Function DoTransaction(ByRef msg As String) As Integer
            Dim isSuccess As Integer = 1
            Try
                If jsonData.Count > 0 Then
                    For Each data As {1} In jsonData
                        Dim _{2}Facade As {2}Facade
                        Try
                            ' _{2}Facade = New {2}Facade(New System.Security.Principal.GenericPrincipal(New GenericIdentity(""WSJson""), Nothing))
                            ' _{2}Facade.Update(_{2}, {2}Details)
                        Catch ex As Exception
                            SysLogParameter.LogErrorToSyslog(ex.Message.ToString, ""WSJson-worker"", ""{0}.vb"", ""Transaction"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, SysLogParameter.ParserType.{0})
                            Dim e As Exception = New Exception(""{2}"" & Chr(13) & Chr(10) & ex.Message)
                            If ex.Message.Substring(0, 3) = ""O/C"" Then
                                Throw New System.Exception(""O/C status in D-NET is not locked. Update failed."")
                            End If
                            Dim rethrow As Boolean = ExceptionPolicy.HandleException(e, ""Parser Policy"")
                            isSuccess = 0

                            Dim err As String = ""Transaction Error : "" & ex.Message)
                            msg = IIf(String.IsNullOrEmpty(msg), err, String.Concat(msg, "" | "", err))
                        End Try
                    Next
                End If
            Catch ex As Exception

            End Try
            Return isSuccess
        End Function

#Region ""Private Methods""
#End Region
    End Class
End Namespace
{3}
"

    '0=Content Namespace
    Public strNamespace As String = "Namespace KTB.DNet.Parser.Domain
    {0}
End Namespace"

    '0=Class Name
    Public strClass As String = "    Public Class {0}
        'Copy Json String And Edit > Paste Special Here
    End Class"
    Public Sub New()
    End Sub
End Class
