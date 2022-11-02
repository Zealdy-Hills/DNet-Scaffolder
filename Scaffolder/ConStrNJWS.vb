Public Class ConStrNJWS
    Public WebConfigStr As String = "'Add to Web.Config
'<add key=""{0}_NAME"" value=""{0}"" />
"
    Public SysLogStr As String = "'Add to SyslogParameter.vb
'{0}Parser
"
    Public RestFullW1 As String = "'Add to RestFullWorker.vb Region ""Variable Declaration""
'Private _{0}_NAME As String = String.Empty
"
    Public RestFullW2 As String = "'Add to RestFullWorker.vb  Region ""Declar Parser""
'Private _{0}Parser As {0}Parser
"
    Public RestFullW3 As String = "'Add to RestFullWorker.vb  Function InitKeyName()
'_{0}_NAME = System.Configuration.ConfigurationManager.AppSettings(""{0}_NAME"").ToString().ToUpper()
"
    Public RestFullW4 As String = "'Add to RestFullWorker.vb  Function Distribute()
'Case _{0}_NAME
'_{0}Parser = New {0}Parser()
'_{0}Parser.SourceName = KeyName
'_{0}Parser.BlockName = ""{0}Parser""
'_{0}Parser.ParseWithTransactionWS(KeyName, content)
'If Not _{0}Parser Is Nothing Then
'    _{0}Parser = Nothing
'End If
"
    Public DecVar As String = "Dim {0} As String = cols({1}).Trim" & vbLf
    '0=DetailTable
    Public DetailDoParseVar As String = "_a{0} = New ArrayList()
                o{0} = Nothing"
    '0=DetailTable
    Public DetailGlobalVar As String = "Private o{0} As {0}
        Private _a{0} As ArrayList"
    '0=VarName
    Public VarTDom As String = "
                '{0}
                If {0} = String.Empty Then
                    Throw New Exception(""{0} can't be empty"")
                Else
                    o{1}.{0} = {0}
                End If
"
    '0=HeaderTable, 1=DetailTable
    Public DetailDoParseStr As String = "ElseIf ind = MyBase.IndicatorDetail Then
                            If IsNothing(obj{0}) OrElse Not IsNothing(obj{0}.ErrorMessage) Then
                            Else
                                obj{1} = ParseDetail(line)
                                If Not IsNothing(obj{1}) Then
                                    obj{1}.{0} = obj{0}
                                    obj{0}.{1}s.Add(obj{1})
                                    If Not IsNothing(obj{1}.ErrorMessage) AndAlso obj{1}.ErrorMessage.Trim <> String.Empty Then
                                        obj{0}.ErrorMessage = obj{0}.ErrorMessage & "";"" & obj{1}.ErrorMessage
                                    End If
                                End If
                            End If"
    '0=DetailTable, 1=DetailVariable, 2=DetailtoDomain
    Public ParseDetailStr As String = "Private Function ParseDetail(ByVal line As String) As {0}
            Dim cols As String() = line.Split(MyBase.ColSeparator)
            Dim PDCode As String

            obj{0} = New {0}
            
            If cols.Length = 0 Then ' validasi colom Count
                writeError(""Invalid Header Format"")
            Else
                {1}
                {2}
                obj{0}.RowStatus = 0

            End If

            Return obj{0}
        End Function
"
    '0=Filename, 1=DBTable, 2=WS String, 3=ParseHeader Variable, 4=Variable to Domain, 5=Footer, 6=DetailDoParse, 7=ParseDetail, 8=DetailGlobalVar, 9=DoParseDetailVar
    Public StrParserFileOnlyHeader As String = "#Region "".NET Base Class Namespace Imports""
Imports System
Imports System.IO
Imports System.Collections
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.Principal
#End Region

#Region ""Custom Namespace Imports""
Imports KTB.DNet.Domain
Imports KTB.DNet.BusinessFacade.General
Imports KTB.DNet.BusinessFacade
Imports KTB.DNet.BusinessFacade.Transfer
Imports KTB.DNet.Domain.Search
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports System.Data
Imports System.Linq
Imports System.Collections.Generic
#End Region

Namespace KTB.DNet.Parser
    Public Class {0}
        Inherits AbstractParser

#Region ""Private Variables""
        Private _Stream As StreamReader
        Private Grammar As Regex
        Private _fileName As String
        Private errorMessage As StringBuilder
        Private o{1} As {1}
        Private _a{1} As ArrayList
        {8}
#End Region

#Region ""Constructors/Destructors/Finalizers""
        Public Sub New()
            Grammar = MyBase.GetGrammarParser()
        End Sub
#End Region

        Protected Overrides Function DoParse(ByVal KeyName As String, ByVal Content As String) As Object
            Try
                Dim lines As String() = MyBase.GetLines(Content)
                Dim ind As String
                Dim line As String

                _a{1} = New ArrayList()
                o{1} = Nothing
                {9}

                For i As Integer = 0 To lines.Length - 1
                    Try
                        line = lines(i)

                        ind = line.Split(MyBase.ColSeparator)(0)
                        If ind = MyBase.IndicatorHeader Then
                            errorMessage = New StringBuilder()
                            o{1} = ParseHeader(line)
                            If Not IsNothing(o{1}) Then
                                If Not IsNothing(errorMessage) AndAlso errorMessage.ToString() <> String.Empty Then o{1}.ErrorMessage = errorMessage.ToString()
                                _a{1}.Add(o{1})
                                o{1} = Nothing
                            End If
                        {6}
                        End If
                    Catch ex As Exception
                        SysLogParameter.LogErrorToSyslog(ex.Message.ToString, ""ws-worker"", ""{0}.vb"", ""Parsing"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.{0}, BlockName)
                        Dim e As Exception = New Exception(KeyName & Chr(13) & Chr(10) & ex.Message)
                        Dim rethrow As Boolean = ExceptionPolicy.HandleException(e, ""Parser Policy"")
                        o{1} = Nothing
                    End Try
                Next

            Catch ex As Exception
                Throw ex
            Finally

            End Try

            Return _a{1}
        End Function

        Protected Overrides Function DoParseFixFormatFile(fileName As String, user As String) As Object
            Return Nothing
        End Function

        Protected Overrides Function DoTransaction() As Integer
            Dim nError As Integer = 0
            Dim sMsg As String = """"
            Dim user As GenericPrincipal = New System.Security.Principal.GenericPrincipal(New GenericIdentity(""ws""), Nothing)
            Dim fac{1} As New {1}Facade(user)
            For Each o{1} As {1} In _a{1}
                Try
                    If Not IsNothing(o{1}) Then
                        Dim criterias As CriteriaComposite = New CriteriaComposite(New Criteria(GetType({1}), ""RowStatus"", MatchType.Exact, CType(DBRowStatus.Active, Short)))
                        Dim {1}List As ArrayList = New {1}Facade(user).Retrieve(criterias)
                        If {1}List.Count > 0 Then
                            For Each old As {1} In {1}List
                                With old
                                    CheckHere
                                End With
                                old = o{1}
                                If fac{1}.Update(old) < 0 Then
                                    sMsg &= ""Gagal Update"" & "";""
                                    nError += 1
                                End If
                            Next
                        Else
                            If fac{1}.Insert(o{1}) < 0 Then
                                sMsg &= ""Gagal Insert"" & "";""
                                nError += 1
                            End If
                        End If
                    End If
                Catch ex As Exception
                    sMsg &= ex.Message.ToString() & "";""
                    nError += 1
                End Try
            Next

            If nError > 0 Then
                SysLogParameter.LogErrorToSyslog(""Failed "" & nError.ToString() & "" of "" & _a{1}.Count.ToString(), ""ws-worker"", ""{0}.vb"", ""Transaction"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.{0}, BlockName)
                SysLogParameter.LogErrorToSyslog(""Error Message :"" & sMsg, ""ws-worker"", ""{0}.vb"", ""Transaction"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.{0}, BlockName)
                Throw New Exception(sMsg)
            End If
            Return 0
        End Function

#Region ""Private Methods""
        Private Sub writeError(str As String)
            errorMessage.Append(str & Chr(13) & Chr(10))
        End Sub

        Private Function ParseHeader(ByVal line As String) As {1}

            '{2}

            Dim cols As String() = line.Split(MyBase.ColSeparator)
            Dim user As GenericPrincipal = New System.Security.Principal.GenericPrincipal(New GenericIdentity(""ws""), Nothing)
            o{1} = New {1}

            errorMessage = New StringBuilder()
            If cols.Length = 0 Then ' validasi colom Count
                writeError(""Invalid Header Format"")
            Else
                CheckHere
                {3}
                {4}
                If Not IsNothing(errorMessage) AndAlso errorMessage.ToString().Trim() <> """" Then
                    o{1}.ErrorMessage = errorMessage.ToString() & vbCrLf & line
                Else
                    o{1}.LastUpdateBy = ""WS""
                    o{1}.LastUpdateTime = Date.Now
                End If
            End If

            Return o{1}
        End Function

        {7}
#End Region
#Region ""Copas to Other Files""

{5}
#End Region
    End Class
End Namespace
"

    Public Sub New()
    End Sub
End Class
