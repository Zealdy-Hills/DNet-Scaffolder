Public Class ConStrWebService
    Public WebConfigStr As String = "<add key=""{0}_NAME"" value=""{0}"" />"
    Public SysLogStr As String = "{0}Parser"
    Public RestFullW1 As String = "Private _{0}_NAME As String = String.Empty"
    Public RestFullW2 As String = "Private _{0}Parser As SPStoragePenaltyPaymentParser"
    Public RestFullW3 As String = "_{0}_NAME = System.Configuration.ConfigurationManager.AppSettings(""{0}_NAME"").ToString().ToUpper()"
    Public RestFullW4 As String = "Private _{0}_NAME As String = String.Empty"
    Public StrParserFileWithDetail As String = "Namespace KTB.DNet.Parser
Public Class {0}
    Inherits AbstractParser

#Region ""Private Variables""
    Private _Stream As StreamReader
    Private Grammar As Regex
    Private _fileName As String
    Private errorMessage As StringBuilder

    Private _{1}s As ArrayList
    Private _{1} As {1}
    Private _{2} As {2}
#End Region

#Region ""Constructors/Destructors/Finalizers""

    Public Sub New()
        Grammar = MyBase.GetGrammarParser()
    End Sub

#End Region

    Protected Overrides Function DoParse(KeyName As String, Content As String) As Object
        Dim lines As String() = MyBase.GetLines(Content)
        Dim ind As String
        Dim line As String

        _{1}s = New ArrayList()
        _{1} = Nothing

        For i As Integer = 0 To lines.Length - 1
            Try
                line = lines(i)

                ind = line.Split(MyBase.ColSeparator)(0)
                If ind = MyBase.IndicatorHeader Then
                    _{1} = Nothing

                    errorMessage = New StringBuilder()
                    _{1} = ParseHeader(line)

                    If Not IsNothing(_{1}) Then
                        _{1}s.Add(_{1})
                    End If
                ElseIf ind = MyBase.IndicatorDetail Then
                    If IsNothing(_{1}) OrElse Not IsNothing(_{1}.ErrorMessage) Then
                    Else
                        _{2} = ParseDetail(line)

                        If Not IsNothing(_{2}) Then
                            _{2}.{1} = _{1}
                            _{1}.{2}s.Add(_{2})
                            If Not IsNothing(_{2}.ErrorMessage) AndAlso _{2}.ErrorMessage.Trim <> String.Empty Then
                                _{1}.ErrorMessage = _{1}.ErrorMessage & "";"" & _{2}.ErrorMessage
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                SysLogParameter.LogErrorToSyslog(ex.Message.ToString, ""ws-worker"", ""{1}Parser.vb"", ""Parsing"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.{1}Parser, BlockName)
                Dim e As Exception = New Exception(KeyName & Chr(13) & Chr(10) & ex.Message)
                Dim rethrow As Boolean = ExceptionPolicy.HandleException(e, ""Parser Policy"")
            End Try
        Next
        Return _{1}s
    End Function

    Protected Overrides Function DoParseFixFormatFile(fileName As String, user As String) As Object
        Return Nothing
    End Function

    Protected Overrides Function DoTransaction() As Integer
        Dim obj{1}Facade As {1}Facade
        Dim nError As Integer = 0
        Dim sMsg As String = """"

        For Each obj{1} As {1} In _{1}s
            Try
                If Not IsNothing(obj{1}.ErrorMessage) AndAlso obj{1}.ErrorMessage <> """" Then
                    nError += 1
                    sMsg = sMsg & obj{1}.ErrorMessage.ToString()
                Else
                    obj{1}Facade = New {1}Facade(New System.Security.Principal.GenericPrincipal(New GenericIdentity(""WS {1}""), Nothing))
                    obj{1}Facade.InsertFromWebSevice(obj{1})
                End If

            Catch ex As Exception
                SysLogParameter.LogErrorToSyslog(ex.Message.ToString(), ""ws-worker"", ""{1}Parser.vb"", ""Transaction"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.PurchaseOrderParser, BlockName)
                Dim e As Exception = New Exception(_fileName & Chr(13) & Chr(10) & obj{1}.TOPSPTransferPayment.RegNumber & Chr(13) & Chr(10) & ex.Message)
                Dim rethrow As Boolean = ExceptionPolicy.HandleException(e, ""Parser Policy"")
            End Try
        Next

        If nError > 0 Then
            SysLogParameter.LogErrorToSyslog(""Failed "" & nError.ToString() & "" of "" & _{1}s.Count.ToString(), ""ws-worker"", ""{1}Parser.vb"", ""Transaction"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.{1}Parser, BlockName)
            SysLogParameter.LogErrorToSyslog(""Error Message :"" & sMsg, ""ws-worker"", ""{1}Parser.vb"", ""Transaction"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.{1}Parser, BlockName)
            Throw New Exception(sMsg)
        End If
        Return 0
    End Function

#Region ""Private Methods""
    Private Sub writeError(str As String)
        errorMessage.Append(str & Chr(13) & Chr(10))
    End Sub

    Private Function ParseHeader(ByVal line As String) As {1}
        Dim cols As String() = line.Split(MyBase.ColSeparator)
        Dim user As GenericPrincipal = New System.Security.Principal.GenericPrincipal(New GenericIdentity(""ws""), Nothing)

        Dim obj{1} As New {1}
        Dim obj{1}Facade As New {1}Facade(user)
		
        errorMessage = New StringBuilder()
        If cols.Length <> 6 Then
            writeError(""Invalid Header Format"")
        Else
            If cols(1).Trim = String.Empty Then
                writeError(""DealerCode can't be empty"")
            ElseIf cols(2).Trim = String.Empty Then
                writeError(""RegNumber can't be empty"")
            ElseIf cols(3).Trim = String.Empty Then
                writeError(""AmountPenalty can't be empty"")
            ElseIf cols(4).Trim = String.Empty Then
                writeError(""DebitMemoDate can't be empty"")
            ElseIf cols(5).Trim = String.Empty Then
                writeError(""DebitMemoNumber can't be empty"")
            Else
                Try
                    Dim _validation As Boolean = True
                    Dim vDealerCode As String = cols(1).Trim
                    Dim vRegNumber As String = cols(2).Trim
                    Dim vAmountPenalty As Decimal = CDec(cols(3).Trim)

                    Dim Thn As Integer = CInt(Strings.Left(cols(4).Trim, 4))
                    Dim Bln As Integer = CInt(cols(4).Trim.Substring(4, 2))
                    Dim Tgl As Integer = CInt(cols(4).Trim.Substring(6, 2))
                    Dim vDebitMemoDate As Date = New DateTime(Thn, Bln, Tgl)
                    Dim vDebitMemoNumber As String = cols(5).Trim

                    Dim oDealer As Dealer = New DealerFacade(user).Retrieve(vDealerCode)
                    If IsNothing(oDealer) OrElse (Not IsNothing(oDealer) And oDealer.ID = 0) Then
                        writeError(""DealerCode doesn't exist in database"")
                        _validation = False
                    End If
                    Dim oTOPSPTransferPayment As TOPSPTransferPayment = New TOPSPTransferPaymentFacade(user).Retrieve(vRegNumber)
                    If IsNothing(oTOPSPTransferPayment) Then
                        writeError(""RegNumber doesn't exist in database"")
                        _validation = False
                    End If

                    If _validation Then
                        obj{1}Facade = New {1}Facade(user)
                        'obj{1} = GetData{1}(vDealerCode, vRegNumber, vDebitMemoNumber)
                        obj{1}.Dealer = New DealerFacade(user).Retrieve(vDealerCode)
                        obj{1}.TOPSPTransferPayment = New TOPSPTransferPaymentFacade(user).Retrieve(vRegNumber)
                        obj{1}.Amount = vAmountPenalty
                        obj{1}.DebitMemoDate = vDebitMemoDate
                        obj{1}.DebitMemoNumber = vDebitMemoNumber
                        If obj{1}.ID = 0 Then
                            obj{1}.StatusPenalty = 0  '--Proses
                        End If
                    End If

                Catch ex As Exception
                    writeError(""TOP SparePart Penalty error: "" & ex.Message)
                End Try
            End If
        End If
        If Not IsNothing(errorMessage) AndAlso errorMessage.ToString().Trim() <> """" Then
            If IsNothing(obj{1}) Then obj{1} = New {1}()
            obj{1}.ErrorMessage = errorMessage.ToString()
        End If

        Return obj{1}
    End Function

    Private Function ParseDetail(ByVal line As String) As {2}
        Dim cols As String() = line.Split(MyBase.ColSeparator)

        _{2} = New {2}

        If (cols.Length <> 8) Then
            writeError(""Invalid Detail Format"")
        Else
            'D;BillingNumber;AccountingDocNo;ActualTransfer;ActualTransferDate(yyyymmdd);PenaltyDays;AmountPenalty;PaymentType
            'D;7820122964;22123132;6679200;20190218;31;33396;1\n

            '1. BillingNumber
            If cols(1).Trim = String.Empty Then
                writeError(""Billing Number Can't Be Empty"")
            Else
                Dim objSPBill As New SparePartBilling
                Dim user As GenericPrincipal = New System.Security.Principal.GenericPrincipal(New GenericIdentity(""ws""), Nothing)
                Dim crit As CriteriaComposite = New CriteriaComposite(New Criteria(GetType(SparePartBilling), ""RowStatus"", MatchType.Exact, CType(DBRowStatus.Active, Short)))
                crit.opAnd(New Criteria(GetType(SparePartBilling), ""BillingNumber"", MatchType.Exact, cols(1).Trim))
                Dim arlList As ArrayList = New SparePartBillingFacade(user).Retrieve(crit)
                If Not IsNothing(arlList) AndAlso arlList.Count > 0 Then
                    objSPBill = CType(arlList(0), SparePartBilling)
                Else
                    writeError(""Invalid Billing Number"")
                End If
                _{2}.SparePartBilling = objSPBill
            End If

            '2. AccountingDocNo
            If cols(2).Trim = String.Empty Then
                writeError(""AccountingDoc Number Can't Be Empty"")
            Else
                _{2}.AccountingDocNo = cols(2).Trim
            End If

            '3. ActualTransfer
            If cols(3).Trim = String.Empty Then
                writeError(""Actual Transfer Amount Can't Be Empty"")
            Else
                Try
                    _{2}.ActualTransferAmount = CType(cols(3), Double)
                Catch ex As Exception
                    _{2}.ActualTransferAmount = 0
                    writeError(""Invalid Actual Transfer Amount"")
                End Try
            End If

            '4. ActualTransferDate(yyyymmdd)
            If cols(4).Trim() = String.Empty Then
                writeError(""Actual Transfer Date Can't Be Empty"")
            Else
                Dim sTemp As String = cols(4).Trim()
                If sTemp.Length > 0 Then
                    Try
                        Dim Thn As Integer = CInt(Strings.Left(sTemp, 4))
                        Dim Bln As Integer = CInt(sTemp.Substring(4, 2))
                        Dim Tgl As Integer = CInt(sTemp.Substring(6, 2))
                        _{2}.ActualTransferDate = New DateTime(Thn, Bln, Tgl)
                    Catch ex As Exception
                        writeError(""Invalid Actual Transfer Date"")
                    End Try
                Else
                    writeError(""Invalid Actual Transfer Date"")
                End If
            End If

            '5. PenaltyDays
            If cols(5).Trim = String.Empty Then
                writeError(""Penalty Days Can't Be Empty"")
            Else
                Try
                    _{2}.PenaltyDays = CType(cols(5), Integer)
                Catch ex As Exception
                    _{2}.PenaltyDays = 0
                    writeError(""Invalid Penalty Days"")
                End Try
            End If

            '6. AmountPenalty
            If cols(6).Trim = String.Empty Then
                writeError(""Amount Penalty Can't Be Empty"")
            Else
                Try
                    _{2}.AmountPenalty = CType(cols(6), Double)
                Catch ex As Exception
                    _{2}.AmountPenalty = 0
                    writeError(""Invalid Amount Penalty"")
                End Try
            End If

            '7. PaymentType
            If cols(7).Trim = String.Empty Then
                writeError(""Payment Type Can't Be Empty"")
            Else
                Try
                    Dim objSC As New StandardCode
                    Dim user As GenericPrincipal = New System.Security.Principal.GenericPrincipal(New GenericIdentity(""ws""), Nothing)
                    Dim crit As CriteriaComposite = New CriteriaComposite(New Criteria(GetType(StandardCode), ""RowStatus"", MatchType.Exact, CType(DBRowStatus.Active, Short)))
                    crit.opAnd(New Criteria(GetType(StandardCode), ""Category"", MatchType.Exact, ""Enum{1}.TipePembayaran""))
                    crit.opAnd(New Criteria(GetType(StandardCode), ""ValueId"", MatchType.Exact, CType(cols(7), Integer)))
                    Dim arlList As ArrayList = New StandardCodeFacade(user).Retrieve(crit)
                    If Not IsNothing(arlList) AndAlso arlList.Count > 0 Then
                        objSC = CType(arlList(0), StandardCode)
                    End If
                    If objSC.ID > 0 Then
                        _{2}.PaymentType = CType(cols(7), Integer)
                    Else
                        _{2}.PaymentType = 0
                        writeError(""Invalid Payment Type"")
                    End If
                Catch ex As Exception
                    _{2}.PaymentType = 0
                    writeError(""Invalid Payment Type"")
                End Try
            End If
        End If

        If Not IsNothing(errorMessage) Then
            _{2}.ErrorMessage = errorMessage.ToString()
        End If

        Return _{2}
    End Function
#End Region

End Class
End Namespace
"
    Public StrParserFileOnlyHeader As String = "Namespace KTB.DNet.Parser
Public Class {0}
    Inherits AbstractParser

#Region ""Private Variables""
    Private _Stream As StreamReader
    Private Grammar As Regex
    Private _fileName As String
    Private errorMessage As StringBuilder

    Private _{1}s As ArrayList
    Private _{1} As {1}
#End Region

#Region ""Constructors/Destructors/Finalizers""

    Public Sub New()
        Grammar = MyBase.GetGrammarParser()
    End Sub

#End Region

    Protected Overrides Function DoParse(KeyName As String, Content As String) As Object
        Dim lines As String() = MyBase.GetLines(Content)
        Dim ind As String
        Dim line As String

        _{1}s = New ArrayList()
        _{1} = Nothing

        For i As Integer = 0 To lines.Length - 1
            Try
                line = lines(i)

                ind = line.Split(MyBase.ColSeparator)(0)
                _{1} = Nothing

                errorMessage = New StringBuilder()
                _{1} = ParseHeader(line)

                If Not IsNothing(_{1}) Then
                    _{1}s.Add(_{1})
                End If
            Catch ex As Exception
                SysLogParameter.LogErrorToSyslog(ex.Message.ToString, ""ws-worker"", ""{1}Parser.vb"", ""Parsing"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.{1}Parser, BlockName)
                Dim e As Exception = New Exception(KeyName & Chr(13) & Chr(10) & ex.Message)
                Dim rethrow As Boolean = ExceptionPolicy.HandleException(e, ""Parser Policy"")
            End Try
        Next
        Return _{1}s
    End Function

    Protected Overrides Function DoParseFixFormatFile(fileName As String, user As String) As Object
        Return Nothing
    End Function

    Protected Overrides Function DoTransaction() As Integer
        Dim o{1}Facade As {1}Facade
        Dim nError As Integer = 0
        Dim sMsg As String = """"

        For Each o{1} As {1} In _{1}s
            Try
                If Not IsNothing(o{1}.ErrorMessage) AndAlso o{1}.ErrorMessage <> """" Then
                    nError += 1
                    sMsg = sMsg & o{1}.ErrorMessage.ToString()
                Else
                    o{1}Facade = New {1}Facade(New System.Security.Principal.GenericPrincipal(New GenericIdentity(""WS {1}""), Nothing))
                    o{1}Facade.InsertFromWebSevice(o{1})
                End If

            Catch ex As Exception
                SysLogParameter.LogErrorToSyslog(ex.Message.ToString(), ""ws-worker"", ""{1}Parser.vb"", ""Transaction"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.PurchaseOrderParser, BlockName)
                Dim e As Exception = New Exception(_fileName & Chr(13) & Chr(10) & o{1}.TOPSPTransferPayment.RegNumber & Chr(13) & Chr(10) & ex.Message)
                Dim rethrow As Boolean = ExceptionPolicy.HandleException(e, ""Parser Policy"")
            End Try
        Next

        If nError > 0 Then
            SysLogParameter.LogErrorToSyslog(""Failed "" & nError.ToString() & "" of "" & _{1}s.Count.ToString(), ""ws-worker"", ""{1}Parser.vb"", ""Transaction"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.{1}Parser, BlockName)
            SysLogParameter.LogErrorToSyslog(""Error Message :"" & sMsg, ""ws-worker"", ""{1}Parser.vb"", ""Transaction"", KTB.DNet.[Lib].DNetLogFormatStatus.Direct, SourceName, WSMSyslogParameter.ParserType.{1}Parser, BlockName)
            Throw New Exception(sMsg)
        End If
        Return 0
    End Function

#Region ""Private Methods""
    Private Sub writeError(str As String)
        errorMessage.Append(str & Chr(13) & Chr(10))
    End Sub

    Private Function ParseHeader(ByVal line As String) As {1}
        Dim cols As String() = line.Split(MyBase.ColSeparator)
        Dim user As GenericPrincipal = New System.Security.Principal.GenericPrincipal(New GenericIdentity(""ws""), Nothing)

        Dim o{1} As New {1}
        Dim o{1}Facade As New {1}Facade(user)
		
        errorMessage = New StringBuilder()
        If cols.Length <> 6 Then
            writeError(""Invalid Header Format"")
        Else
            If cols(1).Trim = String.Empty Then
                writeError(""DealerCode cannot be empty"")
            ElseIf cols(2).Trim = String.Empty Then
                writeError(""RegNumber cannot be empty"")
            ElseIf cols(3).Trim = String.Empty Then
                writeError(""AmountPenalty cannot be empty"")
            ElseIf cols(4).Trim = String.Empty Then
                writeError(""DebitMemoDate cannot be empty"")
            ElseIf cols(5).Trim = String.Empty Then
                writeError(""DebitMemoNumber cannot be empty"")
            Else
                Try
                    Dim _validation As Boolean = True
                    Dim vDealerCode As String = cols(1).Trim
                    Dim vRegNumber As String = cols(2).Trim
                    Dim vAmountPenalty As Decimal = CDec(cols(3).Trim)

                    Dim Thn As Integer = CInt(Strings.Left(cols(4).Trim, 4))
                    Dim Bln As Integer = CInt(cols(4).Trim.Substring(4, 2))
                    Dim Tgl As Integer = CInt(cols(4).Trim.Substring(6, 2))
                    Dim vDebitMemoDate As Date = New DateTime(Thn, Bln, Tgl)
                    Dim vDebitMemoNumber As String = cols(5).Trim

                    Dim oDealer As Dealer = New DealerFacade(user).Retrieve(vDealerCode)
                    If IsNothing(oDealer) OrElse (Not IsNothing(oDealer) And oDealer.ID = 0) Then
                        writeError(""DealerCode does not exist in database"")
                        _validation = False
                    End If
                    Dim oTOPSPTransferPayment As TOPSPTransferPayment = New TOPSPTransferPaymentFacade(user).Retrieve(vRegNumber)
                    If IsNothing(oTOPSPTransferPayment) Then
                        writeError(""RegNumber does not exist in database"")
                        _validation = False
                    End If

                    If _validation Then
                        o{1}Facade = New {1}Facade(user)
                        o{1}.Dealer = New DealerFacade(user).Retrieve(vDealerCode)
                        o{1}.TOPSPTransferPayment = New TOPSPTransferPaymentFacade(user).Retrieve(vRegNumber)
                        o{1}.Amount = vAmountPenalty
                        o{1}.DebitMemoDate = vDebitMemoDate
                        o{1}.DebitMemoNumber = vDebitMemoNumber
                        If o{1}.ID = 0 Then
                            o{1}.StatusPenalty = 0  '--Proses
                        End If
                    End If

                Catch ex As Exception
                    writeError(""TOP SparePart Penalty error: "" & ex.Message)
                End Try
            End If
        End If
        If Not IsNothing(errorMessage) AndAlso errorMessage.ToString().Trim() <> """" Then
            If IsNothing(o{1}) Then o{1} = New {1}()
            o{1}.ErrorMessage = errorMessage.ToString()
        End If

        Return o{1}
    End Function
#End Region

End Class
End Namespace
"

    Public Input2ColsWithList As String = ""
    Public InputWithoutList As String = ""
    Public Input2ColsWithoutList As String = ""
    Public PageList As String = ""

    Public Sub New()
    End Sub
End Class
