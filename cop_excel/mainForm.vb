Public Class mainForm
    'สิ่งที่ต้องใช้ใน DDS
    Dim DomainQoS As New HSDDB.DomainParticipantQoSCLs
    Dim PublisherQoS As New HSDDB.PublisherQoSCls
    Dim DataWriterQoS As New HSDDB.DataWriterQoSCls
    Private iDDS As New HSDDB.COPDataDistributionCls
    Private WithEvents DataWriter As HSDDB.COPDataWriterMessageTrackMod1Cls

    Private CN As System.Data.IDbConnection = Nothing   'DB connection
    Private iTNG As New TrackNumberGenerator.TrackNumberGeneratorCls 'COP TRACK GENERATOR
    Private Last_Date As DateTime = Nothing             'วันที่ล่าสุด

    'object ที่จะใช้เก็บ Track
    Friend Class TrackDataCls
        Public TrackNumber As Integer
        Public Latitude As Double
        Public Longitude As Double
        Public Heading As Double
        Public Speed As Double
        Public Altitude As Double
        Public IdentityNumber As Integer
        Public SIDC As String
        Public LastUpdate As System.DateTime = Now
    End Class

    'Form Load
    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnConnectDB.Enabled = False
        txtSource.Text = My.Settings.Source
        txtOwnerID.Text = My.Settings.Owner
    End Sub

    'DB CONNECT and START Program
    Private Sub BtnConnectDB_Click(sender As Object, e As EventArgs) Handles BtnConnectDB.Click
        Dim DB As New PanuTIDatabaseConnection.DbSqlCls
        DB.SetSettingsFromString(My.Settings.DbExcelSettings)

        My.Settings.Owner = txtOwnerID.Text
        My.Settings.Source = txtSource.Text
        My.Settings.Save()

        Try
            CN = DB.iOpenConnection
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        If IsNothing(CN) Then
            MsgBox("Database Excel connection failed")
            Beep()
            Exit Sub
        Else
            txtStatus.AppendText(vbCrLf & "DB Excel conected")
        End If

        With iTNG
            .DbSettingsString = My.Settings.DbTNGSettings
            .SourceName = txtSource.Text
            .MinTrackNumber = "JT000"
            .MaxTrackNumber = "ZZ777"
            .COPStationID = txtOwnerID.Text.ToString
            .ReadDatabase(My.Settings.DbTNGSettings)
        End With

        With DomainQoS
            .DomainID = CInt(txtDomain.Text)
        End With

        With DataWriterQoS
            .Topic = txtTopic.Text
            .DataType = HSDDB.COPDataCls.enuCOPDataType.cdt_COP_MSG_TRACK_MOD1
        End With

        Dim ErrDescription As String = ""
        Dim DT As New dSetText(AddressOf SetText)

        Try
            If Not iDDS.JoinDomain(DomainQoS, ErrDescription) Then
                txtStatus.AppendText(vbCrLf & ErrDescription)
                Me.Invoke(DT, New Object() {txtStatus, ""})
                Exit Sub
            End If
            If Not iDDS.CreatePublisher(PublisherQoS, ErrDescription) Then
                txtStatus.AppendText(vbCrLf & ErrDescription)
                Me.Invoke(DT, New Object() {txtStatus, ""})
                iDDS.LeaveDomain()
                Exit Sub
            End If
            If Not iDDS.CreateDataWriter(DataWriterQoS, ErrDescription) Then
                txtStatus.AppendText(vbCrLf & ErrDescription)
                Me.Invoke(DT, New Object() {txtStatus, ""})
                iDDS.LeaveDomain()
                Exit Sub
            End If

            Dim DataWriter As HSDDB.COPDataWriterCls
            DataWriter = iDDS.GetDataWriter(DataWriterQoS.Topic)
            If Not IsNothing(DataWriter) Then
                AddHandler DataWriter.eStatus, AddressOf OnOutputStatus
            End If
        Catch ex As Exception
            txtStatus.AppendText(vbCrLf & ErrDescription)
            Me.Invoke(DT, New Object() {txtStatus, ""})
            iDDS.LeaveDomain()
            Exit Sub
        End Try

        FetchDB()
    End Sub

    Private Sub FetchDB()
        Dim Command As System.Data.IDbCommand = CN.CreateCommand
        Dim Reader As System.Data.IDataReader
        Dim ST As String = ""

        Dim TrackNumber As String, OwnerStationID As String, SourceName As String
        Dim Latitude As Single, Longitude As Single, Heading As Single, Speed As Single, Altitude As Single
        Dim CodingScheme As Integer, Identity As Integer, Environment As Integer, FunctionID As Integer, ModifierID As Integer, CountryCode As Integer, OrderOfBattle As Integer
        Dim CallSign As String, TrackName As String

        ST = "Select TrackNumber, OwnerStationID, Latitude, Longitude, Heading, Speed, Altitude, "
        ST &= "CodingScheme, Identity, Environment, FunctionID, ModifierID, CountryCode, OrderOfBattle, "
        ST &= "CallSign, "
        ST &= "TrackName, "
        ST &= "SourceName "
        ST &= "From Tracks2"

        txtStatus.AppendText(vbCrLf & "Last: " & Last_Date.ToString)
        txtStatus.AppendText(vbCrLf & "Fetching started")

        Command.CommandText = ST
        Try
            Reader = Command.ExecuteReader
            While Reader.Read
                'common data
                TrackNumber = Reader.GetString(0)
                OwnerStationID = txtOwnerID.Text
                SourceName = txtSource.Text

                'position data
                Latitude = CSng(Reader.GetValue(2))
                Longitude = CSng(Reader.GetValue(3))
                Heading = CSng(Reader.GetValue(4))
                Speed = CSng(Reader.GetValue(5))
                Altitude = CSng(Reader.GetValue(6))
                Send_TrackPosition(TrackNumber, OwnerStationID, SourceName, Latitude, Longitude, Heading, Speed, Altitude)

                'Symbol
                CodingScheme = CInt(Reader.GetValue(7))
                Identity = CInt(Reader.GetValue(8))
                Environment = CInt(Reader.GetValue(9))
                FunctionID = CInt(Reader.GetValue(10))
                ModifierID = CInt(Reader.GetValue(11))
                CountryCode = CInt(Reader.GetValue(12))
                OrderOfBattle = CInt(Reader.GetValue(13))
                Send_TrackSymbol(TrackNumber, OwnerStationID, SourceName, CodingScheme, Identity, Environment, FunctionID, ModifierID, CountryCode, OrderOfBattle)

                'Call Sign
                If Reader.IsDBNull(14) Then
                    CallSign = ""
                Else
                    CallSign = Reader.GetString(14).Trim
                End If
                Send_TrackCallSign(TrackNumber, OwnerStationID, SourceName, CallSign)

                'Track Name
                If Reader.IsDBNull(15) Then
                    TrackName = ""
                Else
                    TrackName = Reader.GetString(15).Trim
                End If
                Send_TrackTrackName(TrackNumber, OwnerStationID, SourceName, TrackName)

                txtData.AppendText(vbCrLf & "id:" & SourceName & " " & DateTime.Now & " position" & Latitude & "/" & Longitude & " speed: " & Speed)
                counter.Text = (Integer.Parse(counter.Text) + 1).ToString()

            End While
            Reader.Close()
        Catch ex As Exception
        End Try
    End Sub

    '===== Output Data To DDS =====
    Private Sub Send_TrackPosition(ByVal TrackNumber As String, ByVal OwnerStationID As String, ByVal SourceName As String, ByVal Latitude As Single, ByVal Longitude As Single, ByVal Heading As Single, ByVal Speed As Single, ByVal Altitude As Single)
        Dim ErrDescription As String = ""
        Try
            DataWriter.Send_P3_1_1_TrackPosition(TrackNumber, OwnerStationID, Latitude, Longitude, CInt(Int(Heading)), Speed, CInt(Int(Altitude)), HSDDB.COPEnumerator.enu_ALTITUDE_SOURCE.NO_STATEMENT, HSDDB.COPEnumerator.enu_TRACK_QUALITY.NON_REAL_TIME_TRACK, Now, SourceName, ErrDescription, True)
        Catch ex As Exception
            Debug.WriteLine("Error UPDATE_TRACK_POSITION : " & ex.Message)
        End Try
    End Sub

    ''Database Management
    ''DB TNG Setting    
    'Private Sub BtnDBTNGSetting_Click(sender As Object, e As EventArgs) Handles BtnDBTNGSetting.Click
    '    Dim iTNG As New TrackNumberGenerator.TrackNumberGeneratorCls
    '    MsgBox(My.Settings.DbTNGSettings)
    '    iTNG.DisplayDBSettings("COP_Excel TNG", My.Settings.DbTNGSettings)
    '    txtStatus.AppendText(vbCrLf & "DB TNG Setting is done")
    'End Sub
    'Private Function GetCOPTrackNumber(ByVal ReferenceID As String) As String
    '    Dim TrackNumberDecimal As Integer
    '    Dim TrackNumber As String = ""
    '    Dim TrackNumberAction As TrackNumberGenerator.TrackNumberGeneratorCls.enuGetTrackNumberAction
    '    Dim ErrDescription As String = ""

    '    If iTNG.GetTrackNumber(ReferenceID, TrackNumberDecimal, TrackNumber, TrackNumberAction, ErrDescription) Then
    '        Return TrackNumber
    '    Else
    '        Return ""
    '    End If
    'End Function
    'DB Excel setting
    Private Sub BtnDBExcelSetting_Click(sender As Object, e As EventArgs) Handles BtnDBExcelSetting.Click
        Dim DB As New PanuTIDatabaseConnection.DbSqlCls
        DB.SetSettingsFromString(My.Settings.DbExcelSettings)
        DB.DisplaySettings("COP Excel")
        txtStatus.AppendText(vbCrLf & "DB Excel Setting is done")
        My.Settings.DbExcelSettings = DB.GetSettingsString
        My.Settings.Save()

        BtnConnectDB.Enabled = True
    End Sub

    'btnClear   เคลียร์ค่าทิ้ง
    Private Sub btnStatusClear_Click(sender As Object, e As EventArgs) Handles btnStatusClear.Click
        txtStatus.Text = ""
    End Sub
    'btnClear
    Private Sub btnInputClear_Click(sender As Object, e As EventArgs) Handles btnInputClear.Click
        txtData.Text = ""
    End Sub


    'Progress bar   แสดงค่าการใช้งาน CPU RAM
    Private Sub TMin_Tick(sender As Object, e As EventArgs) Handles TMin.Tick
        Dim cpuLoad As Integer = CInt(PFCPU.NextValue)
        cpuLoad = 100 - cpuLoad
        lblCPU.Text = cpuLoad.ToString() & "%"
        On Error Resume Next
        PgbCPU.Value = cpuLoad

        Dim ramLoad As Integer = CInt(PFRAM.NextValue)
        lblRAM.Text = ramLoad.ToString() & "%"
        On Error Resume Next
        PgbRAM.Value = ramLoad
    End Sub


    'ค่าที่ต้องใช้ใน txtStatus
    Private Delegate Sub dSetText(ByRef cText As System.Windows.Forms.TextBox, ByVal ST As String)
    Private Sub d_SetText(ByRef cText As System.Windows.Forms.TextBox, ByVal ST As String)
        cText.Text = ST
        cText.SelectionStart = cText.TextLength
        cText.ScrollToCaret()
    End Sub
    Private Sub SetText(ByRef cText As System.Windows.Forms.TextBox, ByVal ST As String)
        Dim D As New dSetText(AddressOf d_SetText)
        Me.Invoke(D, New Object() {cText, ST})
    End Sub
    Private LastAction As String = "", LastActionTime As DateTime = Now


    Private Sub OnOutputStatus(TopicName As String, COPDataType As HSDDB.COPDataCls.enuCOPDataType, EventCategory As HSDDB.COPDataWriterCls.enuDataWriterEvent, Status As String)
        LastAction = Status
        LastActionTime = Now
    End Sub

    '===== Data =====
    Private cTrackData As New Collection

    Private Sub Send_TrackSymbol(ByVal TrackNumber As String, ByVal OwnerStationID As String, ByVal SourceName As String, ByVal CodingScheme As Integer, ByVal Identity As Integer, ByVal Environment As Integer, ByVal FunctionID As Integer, ByVal ModifierID As Integer, ByVal CountryCode As Integer, ByVal OrderOfBattle As Integer)
        Dim ErrDescription As String = ""
        Try
            Select Case CodingScheme
                Case 1  'War Fighting
                    DataWriter.Send_P3_1_2_TrackSymbolSIDC_WarFighting(TrackNumber, OwnerStationID, False, CType(Identity, HSDDB.COPEnumerator.enu_SIDC_IDENTITY), CType(Environment, HSDDB.COPEnumerator.enu_SIDC_S_ENVIRONMENT), FunctionID, CType(ModifierID, HSDDB.COPEnumerator.enu_SIDC_ECHELON), CType(CountryCode, HSDDB.COPEnumerator.enu_SIDC_COUNTRY_CODE), CType(OrderOfBattle, HSDDB.COPEnumerator.enu_SIDC_ORDER_OF_BATTLE), Now, SourceName, ErrDescription, True)
                Case 2  'Tactical Graphics
                    DataWriter.Send_P3_1_2_TrackSymbolSIDC_TacticalGraphics(TrackNumber, OwnerStationID, False, CType(Identity, HSDDB.COPEnumerator.enu_SIDC_IDENTITY), CType(Environment, HSDDB.COPEnumerator.enu_SIDC_G_CATEGORY), FunctionID, CType(CountryCode, HSDDB.COPEnumerator.enu_SIDC_COUNTRY_CODE), CType(OrderOfBattle, HSDDB.COPEnumerator.enu_SIDC_ORDER_OF_BATTLE), Now, SourceName, ErrDescription, True)
                Case 7  'COP Extension
                    DataWriter.Send_P3_1_2_TrackSymbolSIDC_COPExtension(TrackNumber, OwnerStationID, False, CType(Identity, HSDDB.COPEnumerator.enu_SIDC_IDENTITY), CType(Environment, HSDDB.COPEnumerator.enu_SIDC_C_CATEGORY), FunctionID, CType(CountryCode, HSDDB.COPEnumerator.enu_SIDC_COUNTRY_CODE), Now, SourceName, ErrDescription, True)
            End Select
        Catch ex As Exception
            Debug.WriteLine("Error UPDATE_TRACK_POSITION : " & ex.Message)
        End Try
    End Sub

    Private Sub Send_TrackCallSign(ByVal TrackNumber As String, ByVal OwnerStationID As String, ByVal SourceName As String, ByVal CallSign As String)
        Dim ErrDescription As String = ""
        Try
            DataWriter.Send_P3_1_5_CallSign(TrackNumber, OwnerStationID, CallSign, Now, SourceName, ErrDescription, True)
        Catch ex As Exception
            Debug.WriteLine("Error UPDATE_CALLSIGN : " & ex.Message)
        End Try
    End Sub

    Private Sub Send_TrackTrackName(ByVal TrackNumber As String, ByVal OwnerStationID As String, ByVal SourceName As String, ByVal TrackName As String)
        Dim ErrDescription As String = ""
        Try
            DataWriter.Send_P3_1_6_TrackName(TrackNumber, OwnerStationID, TrackName, Now, SourceName, ErrDescription, True)
        Catch ex As Exception
            Debug.WriteLine("Error UPDATE_TRACKNAME : " & ex.Message)
        End Try
    End Sub

End Class