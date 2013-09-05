Option Explicit On
Option Strict On

Imports System
Imports System.Globalization
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class Form1

    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Private Declare Function GetSystemMetrics Lib "user32" (ByVal lnIndex As Long) As Long

    Private Const SM_CXFULLSCREEN As Long = 16
    Private Const SM_CYFULLSCREEN As Long = 17

    Private Const COUNTMAX As Long = 999999999
    Private Const COUNTMIN As Long = -999999999


    Dim Message As String = "Not Defined"

    Public f2 As New Jimaku()
    Public f3 As New Jimaku()
    'Private dialog2 As New Dialog2()
    Public fontDetail As FontDetail

    '�t�H���g��{���
    '�t�H���g�F
    Public BaseFontColor As Color = Color.Black
    '�����
    Public BaseFontBorder As Color = Color.White
    '����蕝
    Public BaseFontBorderWidth As Integer = 0
    '�e
    Public BaseFontShade As Color = Color.White
    '�e�L��
    Public BaseFontShadeOn As Boolean = False
    '�A���t�@�l
    Public BaseFontAlpha As Integer = 250

    '�f�t�H���g�l�ݒ�
    Dim D_filename As String = "m9c.xml"
    Dim C_filename As String = ""
    Dim fileName As String = Application.StartupPath + "\" + D_filename
    Dim D_Titlebar As String = "m9�J�E���^ Ver0.05"
    Public D_Title As String = "m9�J�E���^ Ver0.05"
    Public D_Name01 As String = "m9(^�D^)�߷ެ�"
    Public D_Name02 As String = "��(߄D�)�ޯ�ޮ��!!"
    Public D_Name03 As String = "(�E�t�E)��"
    Public D_Name04 As String = ""
    Public D_Name05 As String = ""
    Public D_Name06 As String = ""

    Public D_ID01 As String = "5023bda4-7b30-496b-b27f-5bacd2eab3ac"
    Public D_ID02 As String = "1b254391-583e-4e44-a182-c422de8b46c7"
    Public D_ID03 As String = "77c359fb-045a-48ac-b7f0-164b8743bdb7"
    Public D_KeyWord04 As String = ""
    Public D_KeyWord05 As String = ""
    Public D_KeyWord06 As String = ""

    Public D_Counter01 As Integer = 0
    Public D_Counter02 As Integer = 0
    Public D_Counter03 As Integer = 0
    Public D_Counter04 As Integer = 0
    Public D_Counter05 As Integer = 0
    Public D_Counter06 As Integer = 0

    Public D_EditText As String = "$t1�F$c1" + vbCrLf + "$t2�F$c2" + vbCrLf + "$t3�F$c3"

    Public D_HTMLText As String = _
                "<html>" + vbCrLf + _
                "<head>" + vbCrLf + _
                "<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">" + vbCrLf + _
                "<title>$title</title>" + vbCrLf + _
                "</head>" + vbCrLf + _
                "<body bgcolor=""#ffeeee"">" + vbCrLf + _
                "<h3>$title</h3><hr>" + vbCrLf + _
                "<h1><a href=""/$k1"">$t1</a>�F$c1" + vbCrLf + _
                "<br><a href=""/$k2"">$t2</a>�F$c2" + vbCrLf + _
                "<br><a href=""/$k3"">$t3</a>�F$c3" + vbCrLf + _
                "<br><a href=""/"">�X�V</a>" + vbCrLf + _
                "</h1>" + vbCrLf + _
                "</body>" + vbCrLf + _
                "</html>"

    '�e�L�X�g
    'Shared Title As String
    'Shared Name01 As String
    'Shared Name02 As String
    'Shared Name03 As String
    'Shared Name04 As String
    'Shared Name05 As String
    'Shared Name06 As String

    Shared KeyWord01 As String
    Shared KeyWord02 As String
    Shared KeyWord03 As String
    Shared KeyWord04 As String
    Shared KeyWord05 As String
    Shared KeyWord06 As String

    Shared Counter01 As Integer = 0
    Shared Counter02 As Integer = 0
    Shared Counter03 As Integer = 0
    Shared Counter04 As Integer = 0
    Shared Counter05 As Integer = 0
    Shared Counter06 As Integer = 0

    'Redirect Port
    Shared RedirectPort As String

    'Shared EditText As String
    Shared HTMLText As String

    '�����Ւf�t���O
    Shared ForceClose As Boolean = False
    Public ForceClose2 As Boolean = True



    Dim receiveFlag As Boolean = True
    Dim listener As System.Net.Sockets.TcpListener
    Shared gMassage As String = ""

    Shared path As String = ""
    Shared permittedIp As String = "Nothing"
    Shared permitCheck As Integer

    '����

    'Public D_Sound01 As System.IO.Stream = My.Resources.pg2
    'Public D_Sound02 As System.IO.Stream = My.Resources.gj
    'Public D_Sound03 As System.IO.Stream = My.Resources.ti

    'Dim D_Sound01_Val As String = "<�߷ެ�>"
    'Dim D_Sound02_Val As String = "<�ޯ�ޮ��>"
    'Dim D_Sound03_Val As String = "<��>"
    'Dim SoundArry As Array



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��M.Click

        Me.��M.Enabled = False
        Me.�Ւf.Enabled = True

        ForceClose = False
        ForceClose2 = True

        receiveFlag = True

        '�����R�[�h���w�肷��
        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")

        Dim lport As Integer = CInt(Me.RecPort.Text)
        'Dim lipadd As System.Net.IPAddress

        'If Me.CheckBox1.CheckState = CheckState.Checked Then
        '    lipadd = System.Net.IPAddress.Any
        'Else
        '    Try
        '        lipadd = System.Net.IPAddress.Parse(Me.����IP.Text)
        '    Catch
        '        MessageBox.Show("IP�A�h���X���s���ł�")
        '        Me.��M.Enabled = True
        '        Me.�Ւf.Enabled = False
        '        Return
        '    End Try

        'End If

        listener = New System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, lport)

        Try
            listener.Start()
        Catch
        End Try

        If CheckAny.CheckState = CheckState.Checked Then
            Messages.Text = CStr(Now) + vbCrLf + "Any����|�[�g" + Me.RecPort.Text + "�Ɏ�M��t���ł�"
        Else
            Messages.Text = CStr(Now) + vbCrLf + permittedIp + "����|�[�g" + Me.RecPort.Text + "�Ɏ�M��t���ł�"
        End If


        StartAccept(listener.Server)

    End Sub


    '�N���C�A���g�̐ڑ��҂��X�^�[�g
    Private Shared Sub StartAccept( _
        ByVal server As System.Net.Sockets.Socket)
        'server.ReceiveTimeout = 4000
        '�ڑ��v���ҋ@���J�n����
        server.BeginAccept(New System.AsyncCallback( _
            AddressOf AcceptCallback), server)
    End Sub

    'BeginAccept�̃R�[���o�b�N
    Private Shared Sub AcceptCallback(ByVal ar As System.IAsyncResult)
        '�T�[�o�[Socket�̎擾
        Dim server As System.Net.Sockets.Socket = _
            CType(ar.AsyncState, System.Net.Sockets.Socket)

        'server.ReceiveTimeout = 4000
        'server.SendTimeout = 4000

        '�ڑ��v�����󂯓����
        Dim client As System.Net.Sockets.Socket = Nothing
        Try
            '�N���C�A���gSocket�̎擾
            client = server.EndAccept(ar)
            'client.ReceiveTimeout = 4000
            'client.SendTimeout = 4000
        Catch e As System.ObjectDisposedException
            'Form1.Label1.Text = Now + vbCrLf + "�N���C�A���g���ؒf���܂���"
            'Debug.Print("�����ł����H")
            '�ڑ��v���ҋ@���ĊJ����
            Return

        Catch
            server.BeginAccept(New System.AsyncCallback( _
                AddressOf AcceptCallback), server)

            Return

        End Try

        'Debug.Print(client.RemoteEndPoint.ToString())
        Dim tmp As String = client.RemoteEndPoint.ToString()
        Dim spt() As String
        spt = Split(tmp, ":")

        'Debug.Print("1")

        Try
            '�^�C���A�E�g

            If permitCheck = CheckState.Checked Or permittedIp = spt(0) Then

                '�N���C�A���g���瑗��ꂽ�f�[�^����M����
                Dim ms As New System.IO.MemoryStream
                Dim resBytes(256) As Byte
                Dim resSize As Integer

                'resSize = client.Receive(resBytes)
                Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")

                'Debug.Print("2")

                Do
                    '�f�[�^�̈ꕔ����M����
                    'Debug.Print("21")
                    resSize = client.Receive(resBytes)
                    'Debug.Print("22")
                    'Read��0��Ԃ������̓N���C�A���g���ؒf�����Ɣ��f
                    If resSize <= 0 Then
                        'Form1.Label1.Text = Now + vbCrLf + "�N���C�A���g���ؒf���܂���"
                        'Debug.Print("3")
                        'client.Close()
                        'Console.ReadLine()
                        'Debug.Print("4")
                        'Return
                        Exit Do
                    End If
                    '��M�����f�[�^��~�ς���
                    'Debug.Print("5")
                    ms.Write(resBytes, 0, resSize)
                    'Debug.Print("6")
                Loop While client.Available > 0 And ms.Length < 1028
                'client.Close()
                '��M�����f�[�^�𕶎���ɕϊ�
                Dim resMsg As String = enc.GetString(ms.ToArray())
                'Debug.Print("7")
                ms.Close()

                'Debug.Print("8")

                '���[�U�G�[�W�F���g�𒲂ׂ�
                Dim resMsgArr As Array = resMsg.Split(CChar(vbCr))
                Dim NSPflug As Boolean = False

                For i As Integer = 0 To resMsgArr.Length - 1

                    Debug.Print(CStr(resMsgArr.GetValue(i)))

                    If System.Text.RegularExpressions.Regex.IsMatch( _
                        CStr(resMsgArr.GetValue(i)), _
                        "(USER-AGENT|user-agent|User-Agent).*NSPlayer", _
                        System.Text.RegularExpressions.RegexOptions.ECMAScript) Then

                        NSPflug = True
                        Exit For
                    End If
                Next

                Dim LocationMsg As String = ""
                If spt(0) = "127.0.0.1" Then
                    LocationMsg = "localhost"
                    'Debug.Print(LocationMsg)
                Else
                    'Regex�I�u�W�F�N�g���쐬 
                    Dim r As New System.Text.RegularExpressions.Regex( _
                        "http://([^:/]*)(:([0-9]+))?(/.*)?", _
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    Dim mc As System.Text.RegularExpressions.MatchCollection = _
                        r.Matches(CStr(resMsgArr.GetValue(0)))
                    Try
                        'LocationMsg = "125.197.225.46"
                        'Debug.Print(LocationMsg)
                    Catch
                    End Try

                End If

                If NSPflug = True Then

                    'Dim LocationMsg As String

                    ''Regex�I�u�W�F�N�g���쐬 
                    'Dim r As New System.Text.RegularExpressions.Regex( _
                    '    "http://([^:/]*)(:([0-9]+))?(/.*)?", _
                    '    System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    'Dim mc As System.Text.RegularExpressions.MatchCollection = _
                    '    r.Matches(resMsgArr.GetValue(0))

                    'mc.
                    'Try
                    '    LocationMsg = mc.Item(0).Groups(1).Value
                    'Catch
                    'End Try

                    'Debug.Print(LocationMsg)

                    '�����ł͕�����𑗐M���āA�����ɕ��Ă���

                    client.Send(System.Text.Encoding.UTF8.GetBytes( _
                        "HTTP/1.1 301 Moved Permanently" + vbCrLf + _
                        "Server: Apache" + vbCrLf + _
                        "Location: http://" + LocationMsg + ":" + RedirectPort + "/" + vbCrLf + _
                        vbCrLf _
                           ))
                Else



                    gMassage = CStr(resMsgArr.GetValue(0))

                    If (KeyWord01.Equals("") = False And gMassage.Contains(KeyWord01) And Counter01 < COUNTMAX) Then
                        Counter01 = Counter01 + 1
                    End If
                    If (KeyWord02.Equals("") = False And gMassage.Contains(KeyWord02) And Counter02 < COUNTMAX) Then
                        Counter02 = Counter02 + 1
                    End If
                    If (KeyWord03.Equals("") = False And gMassage.Contains(KeyWord03) And Counter03 < COUNTMAX) Then
                        Counter03 = Counter03 + 1
                    End If
                    If (KeyWord04.Equals("") = False And gMassage.Contains(KeyWord04) And Counter04 < COUNTMAX) Then
                        Counter04 = Counter04 + 1
                    End If
                    If (KeyWord05.Equals("") = False And gMassage.Contains(KeyWord05) And Counter05 < COUNTMAX) Then
                        Counter05 = Counter05 + 1
                    End If
                    If (KeyWord06.Equals("") = False And gMassage.Contains(KeyWord06) And Counter06 < COUNTMAX) Then
                        Counter06 = Counter06 + 1
                    End If

                    For Each dgvr As DataGridViewRow In Form1.DataGridView1.Rows
                        Debug.Print(CStr(dgvr.Cells(5).Value))
                    Next



                    'Debug.Print(resMsg)


                    '�N���C�A���g���ڑ��������̏����������ɏ���
                    HTMLText = Regex.Replace(HTMLText, "\$c1", Counter01.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c2", Counter02.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c3", Counter03.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c4", Counter04.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c5", Counter05.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c6", Counter06.ToString)

                    Dim body As String
                    body = HTMLText

                    '�����ł͕�����𑗐M���āA�����ɕ��Ă���

                    client.Send(System.Text.Encoding.UTF8.GetBytes( _
                        "HTTP/1.1 200 OK" + vbCrLf + _
                        vbCrLf + body _
                           ))

                    'client.Shutdown(System.Net.Sockets.SocketShutdown.Both)
                    'Debug.Print("9")
                End If
            End If
            client.Shutdown(System.Net.Sockets.SocketShutdown.Both)
            '
        Catch e As Exception
            'Return 
            'Debug.Print(e.Message)
            '�����Ւf
            ForceClose = True
            Return
            'client.Shutdown(System.Net.Sockets.SocketShutdown.Both)

        End Try
        client.Close()

        '�ڑ��v���ҋ@���ĊJ����

        server.BeginAccept(New System.AsyncCallback( _
            AddressOf AcceptCallback), server)
    End Sub

    Private Sub �Ւf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �Ւf.Click
        'receiveFlag = False
        '�����I��
        Call �����Ւf()

    End Sub

    Private Sub �����Ւf()
        Try
            listener.Stop()
            listener.Server.Close()
        Catch
        End Try
        Form1.Messages.Text = CStr(Now) + vbCrLf + "�Ւf���܂���"
        Me.��M.Enabled = True
        Me.�Ւf.Enabled = False
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAny.CheckedChanged
        If CheckAny.CheckState = CheckState.Checked Then
            ����IP.Enabled = False
        Else
            ����IP.Enabled = True
        End If

        permitCheck = CheckAny.CheckState

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.f2.setFormPair(Me.f3)
        Me.f2.setFormParent(Me)
        Me.f3.setFormPair(Me.f2)
        Me.f3.setFormParent(Me)
        Me.f2.Show()
        Me.f3.Show()

        ����()
        Me.f2.Visible = False
        Me.f3.Visible = False

        '�e���|�����ǂݍ���



        If System.IO.File.Exists(fileName) Then
            'XmlSerializer�I�u�W�F�N�g�̍쐬
            Dim serializer As _
                New System.Xml.Serialization.XmlSerializer( _
                    GetType(SaveDataClass))

            Dim doc As New System.Xml.XmlDocument()
            doc.PreserveWhitespace = True
            doc.Load(fileName)
            Dim reader As New System.Xml.XmlNodeReader(doc.DocumentElement)
            Dim o As Object = serializer.Deserialize(reader)
            Dim cls As SaveDataClass = DirectCast(o, SaveDataClass)

            ''�t�@�C�����J��
            'Dim fs As New System.IO.FileStream( _
            '    fileName, System.IO.FileMode.Open)
            ''XML�t�@�C������ǂݍ��݁A�t�V���A��������

            ''doc.PreserveWhitespace = True


            'Dim cls As SaveDataClass = _
            '    CType(serializer.Deserialize(fs), SaveDataClass)
            ''����
            'fs.Close()

            Call Me.GetSaveData(cls)

        Else
            '�f�t�H���g
            Me.�^�C�g��.Text = D_Title
            'Me.����1.Text = D_Name01
            'Me.����2.Text = D_Name02
            'Me.����3.Text = D_Name03
            'Me.����4.Text = D_Name04
            'Me.����5.Text = D_Name05
            'Me.����6.Text = D_Name06

            DataGridView1.Rows.Add(D_Name01, "$t1", D_Counter01, "$c1", "", D_ID01, "$g1")
            DataGridView1.Rows.Add(D_Name02, "$t2", D_Counter02, "$c2", "", D_ID02, "$g2")
            DataGridView1.Rows.Add(D_Name03, "$t3", D_Counter03, "$c3", "", D_ID03, "$g3")


            For Each dgvr As DataGridViewRow In DataGridView1.Rows
                'Debug.Print(CStr(dgvr.Cells(5).Value))
            Next


            'Me.�L�[���[�h1.Text = D_ID01
            'Me.�L�[���[�h2.Text = D_ID02
            'Me.�L�[���[�h3.Text = D_ID03
            'Me.�L�[���[�h4.Text = D_KeyWord04
            'Me.�L�[���[�h5.Text = D_KeyWord05
            'Me.�L�[���[�h6.Text = D_KeyWord06

            'Me.�J�E���^1.Text = CStr(0)
            'Me.�J�E���^2.Text = CStr(0)
            'Me.�J�E���^3.Text = CStr(0)
            'Me.�J�E���^4.Text = CStr(0)
            'Me.�J�E���^5.Text = CStr(0)
            'Me.�J�E���^6.Text = CStr(0)

            Me.�ҏW������.Text = D_EditText

            Me.���M������.Text = D_HTMLText

        End If

        Me.Text = D_Titlebar + " - " + D_filename

        Me.fontDetail = New FontDetail(Me)

        Timer1.Interval = 1000
        Timer1.Start()

    End Sub

    'DefaultValuesNeeded�C�x���g�n���h��
    Private Shared Sub DataGridView1_DefaultValuesNeeded(ByVal sender As Object, _
            ByVal e As DataGridViewRowEventArgs) _
            Handles DataGridView1.DefaultValuesNeeded
        '�Z���̊���l���w�肷��
        e.Row.Cells("GUID").Value = System.Guid.NewGuid().ToString
        e.Row.Cells("Column2").Value = 0
    End Sub


    'DataError�C�x���g�n���h��
    Private Shared Sub DataGridView1_DataError(ByVal sender As Object, _
            ByVal e As DataGridViewDataErrorEventArgs) _
            Handles DataGridView1.DataError
        e.Cancel = False
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If (gMassage.Contains("pugyaa")) Then
        '    pg = pg + 1
        'ElseIf (gMassage.Contains("goodjob")) Then
        '    gj = gj + 1
        'End If
        'gMassage = ""
        If ForceClose = True And ForceClose2 = True Then
            ForceClose2 = False
            Call �����Ւf()
            MsgBox("TCP�ڑ����ؒf����܂����B��M�𒆎~���܂��B", _
                MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, _
                "�ڑ����ؒf����܂����B")

        End If

        Call TimerEvent()


    End Sub

    Private Sub TimerEvent()
        'EDIT�R�[�h
        Dim tmpstr As String = Me.�ҏW������.Text
        Dim tmpstr2 As String = Me.���M������.Text

        tmpstr = Regex.Replace(tmpstr, "\$title", Me.�^�C�g��.Text)
        tmpstr2 = Regex.Replace(tmpstr2, "\$title", Me.�^�C�g��.Text)


        For Each dgvr As DataGridViewRow In DataGridView1.Rows

            If CStr(dgvr.Cells(5).Value) = "" Then Exit For

            tmpstr = Regex.Replace(tmpstr, "\" & CStr(dgvr.Cells(1).Value), CStr(dgvr.Cells(0).Value))
            tmpstr2 = Regex.Replace(tmpstr2, "\" & CStr(dgvr.Cells(1).Value), CStr(dgvr.Cells(0).Value))
            tmpstr = Regex.Replace(tmpstr, "\" & CStr(dgvr.Cells(6).Value), CStr(dgvr.Cells(5).Value))
            tmpstr2 = Regex.Replace(tmpstr2, "\" & CStr(dgvr.Cells(6).Value), CStr(dgvr.Cells(5).Value))
            tmpstr = Regex.Replace(tmpstr, "\" & CStr(dgvr.Cells(3).Value), CStr(dgvr.Cells(2).Value))
            tmpstr2 = Regex.Replace(tmpstr2, "\" & CStr(dgvr.Cells(3).Value), CStr(dgvr.Cells(2).Value))

            'Debug.Print(CStr(dgvr.Cells(5).Value))
        Next

        Me.�\��������.Text = tmpstr

        'shared���MHTML���X�V

        'tmpstr2 = Regex.Replace(tmpstr2, "\$t1", Me.����1.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t2", Me.����2.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t3", Me.����3.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t4", Me.����4.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t5", Me.����5.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t6", Me.����6.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k1", Me.�L�[���[�h1.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k2", Me.�L�[���[�h2.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k3", Me.�L�[���[�h3.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k4", Me.�L�[���[�h4.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k5", Me.�L�[���[�h5.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k6", Me.�L�[���[�h6.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c1", Counter01.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c2", Counter02.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c3", Counter03.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c4", Counter04.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c5", Counter05.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c6", Counter06.ToString)


        HTMLText = tmpstr2

        '�L�[���[�h�ێ�
        KeyWord01 = Me.�L�[���[�h1.Text
        KeyWord02 = Me.�L�[���[�h2.Text
        KeyWord03 = Me.�L�[���[�h3.Text
        KeyWord04 = ""
        KeyWord05 = Me.�L�[���[�h5.Text
        KeyWord06 = Me.�L�[���[�h6.Text

        '�J�E���^�ێ�
        Me.�J�E���^1.Value = Counter01
        Me.�J�E���^2.Value = Counter02
        Me.�J�E���^3.Value = Counter03
        'Me.�J�E���^4.Value = Counter04
        Me.�J�E���^5.Value = Counter05
        Me.�J�E���^6.Value = Counter06


        '�����쐬
        ����()

        '�����̂Ƃ�
        Me.soundname01.Text = Me.����1.Text
    End Sub

    Private Sub ����IP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����IP.TextChanged
        permittedIp = ����IP.Text
    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Me.fontDetail = New FontDetail(Me)
        Me.fontDetail.ShowDialog()
    End Sub

    Private Sub ����()

        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        Dim path2 As New System.Drawing.Drawing2D.GraphicsPath()
        Dim g As Graphics = Me.f2.CreateGraphics()
        Dim gs As Graphics = Me.f3.CreateGraphics()

        'If Me.dialog2.CheckBox05.CheckState = CheckState.Checked Then
        '    g.TextRenderingHint = TextRenderingHint.AntiAlias
        '    gs.TextRenderingHint = TextRenderingHint.AntiAlias

        'End If


        Dim brs1 As SolidBrush

        brs1 = New SolidBrush(Me.BaseFontColor)

        Dim brs2 As Pen
        Dim brs3 As SolidBrush = New SolidBrush(Me.BaseFontShade)

        '�t�H���g�I�u�W�F�N�g�̍쐬
        Dim fnt As New Font(�\��������.Font.FontFamily, �\��������.Size.Height, _
                       �\��������.Font.Style, GraphicsUnit.Pixel)
        'StringFormat�I�u�W�F�N�g�̍쐬
        Dim sf As New StringFormat
        Dim stringSize As SizeF = _
        g.MeasureString(Me.�\��������.Text, fnt, 65535, sf)
        If stringSize.Height = 0 Or stringSize.Width = 0 Then
            stringSize.Height = 1
            stringSize.Width = 1
        End If

        Dim bBuf As New Bitmap(CInt(stringSize.Width * 1.17), CInt(stringSize.Height * 1.17))
        Dim gBuf As Graphics = Graphics.FromImage(bBuf)

        'If Me.BaseAntiAriasFlg Then
        gBuf.SmoothingMode = SmoothingMode.AntiAlias
        'gBuf.PixelOffsetMode = PixelOffsetMode.HighQuality
        'End If



        gBuf.Clear(Color.Transparent)
        'Debug.Print(bBuf.GetPixel(Int(bBuf.Width / 2), 0).ToString)


        If Me.BaseFontShadeOn Then
            path2.AddString(Me.�\��������.Text, �\��������.Font.FontFamily, _
                       �\��������.Font.Style, �\��������.Font.Height, New Point(3, 3), _
                       StringFormat.GenericDefault)
            '������̒���h��Ԃ�
            gBuf.FillPath(brs3, path2)
        End If

        path.AddString(Me.�\��������.Text, �\��������.Font.FontFamily, _
            �\��������.Font.Style, �\��������.Font.Height, New Point(0, 0), _
            StringFormat.GenericDefault)

        If Me.BaseFontBorderWidth <> 0 Then
            brs2 = New Pen(Me.BaseFontBorder, Me.BaseFontBorderWidth)

            '������̉���`�悷��
            gBuf.DrawPath(brs2, path)
            brs2.Dispose()

        End If

        '������̒���h��Ԃ�
        gBuf.FillPath(brs1, path)

        Dim drawPoint As Point
        'If Me.BaseAlignRightFlg Then
        'drawPoint = New Point(Me.f2.Location.X + Me.f2.Width - stringSize.Width * 1.17, Me.f2.Location.Y)
        'Else
        drawPoint = New Point(Me.f2.Location.X, Me.f2.Location.Y)
        'End If

        Me.f2.Height = CInt(stringSize.Height * 1.17)
        Me.f2.Width = CInt(stringSize.Width * 1.17)
        Me.f3.Height = CInt(stringSize.Height * 1.17)
        Me.f3.Width = CInt(stringSize.Width * 1.17)

        'Debug.Print(stringSize.Height)
        'Debug.Print(stringSize.Width)

        Me.f2.Location = drawPoint
        Me.f3.Location = drawPoint

        g.Clear(Color.White)
        g.DrawImage(bBuf, 0, 0)

        gs.Clear(Color.White)
        gs.DrawImage(bBuf, 0, 0)

        'bBuf.MakeTransparent(Color.White)

        '���\�[�X���J������
        bBuf.Dispose()
        gBuf.Dispose()
        'gp.Dispose()
        g.Dispose()
        brs1.Dispose()
        brs3.Dispose()

        '�t�H�[���̃A���t�@�l��ݒ肷��
        Me.f2.Opacity = BaseFontAlpha / 255
        Me.f3.Opacity = BaseFontAlpha / 255

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckJimaku.CheckedChanged

        If CheckJimaku.CheckState = CheckState.Checked Then
            Me.f2.Visible = True
            Me.f3.Visible = True
        Else
            Me.f2.Visible = False
            Me.f3.Visible = False
        End If
    End Sub


    Private Sub ALLCounter_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALLCounter_Reset.Click
        'Me.�J�E���^1.Value = 0
        'Me.�J�E���^2.Value = 0
        'Me.�J�E���^3.Value = 0
        'Me.�J�E���^4.Value = 0
        'Me.�J�E���^5.Value = 0
        'Me.�J�E���^6.Value = 0
        'Counter01 = 0
        'Counter02 = 0
        'Counter03 = 0
        'Counter04 = 0
        'Counter05 = 0
        'Counter06 = 0

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �L�[���[�h6.TextChanged

    End Sub

    Private Sub Reset1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset1.Click
        Me.�J�E���^1.Value = 0
        Counter01 = 0
    End Sub

    Private Sub Reset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset2.Click
        Me.�J�E���^2.Value = 0
        Counter02 = 0
    End Sub

    Private Sub Reset3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset3.Click
        Me.�J�E���^3.Value = 0
        Counter03 = 0
    End Sub

    Private Sub Reset4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.�J�E���^4.Value = 0
        Counter04 = 0
    End Sub

    Private Sub Reset5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset5.Click
        Me.�J�E���^5.Value = 0
        Counter05 = 0
    End Sub

    Private Sub Reset6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset6.Click
        Me.�J�E���^6.Value = 0
        Counter06 = 0
    End Sub

    Private Sub �J�E���^1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �J�E���^1.ValueChanged
        Counter01 = CInt(Me.�J�E���^1.Value)
    End Sub

    Private Sub �J�E���^2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �J�E���^2.ValueChanged
        Counter02 = CInt(Me.�J�E���^2.Value)
    End Sub

    Private Sub �J�E���^3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �J�E���^3.ValueChanged
        Counter03 = CInt(Me.�J�E���^3.Value)
    End Sub

    Private Sub �J�E���^4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Counter04 = CInt(Me.�J�E���^4.Value)
    End Sub

    Private Sub �J�E���^5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �J�E���^5.ValueChanged
        Counter05 = CInt(Me.�J�E���^5.Value)
    End Sub

    Private Sub �J�E���^6_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �J�E���^6.ValueChanged
        Counter06 = CInt(Me.�J�E���^6.Value)
    End Sub


    '�G���g���|�C���g
    Public Sub Save()
        '�ۑ���̃t�@�C����

        '�ۑ�����N���X(SampleClass)�̃C���X�^���X���쐬
        Dim cls As New SaveDataClass
        'cls.UMessage = Message
        'If Not pss Is Nothing Then
        '    cls.UProcessName = pss.ProcessName
        'Else
        '    cls.UProcessName = "kagami"
        'End If

        Call SetSaveData(cls)

        'XmlSerializer�I�u�W�F�N�g���쐬
        '�������ރI�u�W�F�N�g�̌^���w�肷��
        Dim serializer As _
            New System.Xml.Serialization.XmlSerializer( _
                GetType(SaveDataClass))

        ''OpenFileDialog�N���X�̃C���X�^���X���쐬
        'Dim ofd As New OpenFileDialog()

        ''�͂��߂̃t�@�C�������w�肷��
        ''�͂��߂Ɂu�t�@�C�����v�ŕ\������镶������w�肷��
        'ofd.FileName = fileName
        ''[�t�@�C���̎��]�ɕ\�������I�������w�肷��
        ''�w�肵�Ȃ��Ƃ��ׂẴt�@�C�����\�������
        'ofd.Filter = "XML�t�@�C��(*.xml)|*.xml"
        ''[�t�@�C���̎��]�ł͂��߂�
        ''�u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
        'ofd.FilterIndex = 0
        ''�^�C�g����ݒ肷��
        'ofd.Title = "�J���t�@�C����I�����Ă�������"
        ''�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
        'ofd.RestoreDirectory = True

        ''�_�C�A���O��\������
        'If ofd.ShowDialog() = DialogResult.OK Then

        '�t�@�C�����J��
        Dim fs As New System.IO.FileStream( _
            fileName, System.IO.FileMode.Create)
        '�V���A�������AXML�t�@�C���ɕۑ�����
        serializer.Serialize(fs, cls)
        '����
        fs.Close()

        'End If
    End Sub

    Private Sub SetSaveData(ByRef cls As SaveDataClass)
        cls.UFontFamily = �\��������.Font.FontFamily.Name
        cls.UFontStyle = CalcFontStyle(Messages.Font)
        cls.UFontSize = �\��������.Font.Size

        cls.UBaseFontColor = BaseFontColor.ToArgb
        cls.UBaseFontBorder = BaseFontBorder.ToArgb
        cls.UBaseFontBorderWidth = BaseFontBorderWidth
        cls.UBaseFontShade = BaseFontShade.ToArgb
        cls.UBaseFontShadeOn = BaseFontShadeOn
        cls.UBaseFontAlpha = BaseFontAlpha

        'cls.UDefaultIMMessage = defaultIMMessage

        'cls.UJimakuDisplay = IIf(�w�i����ToolStripMenuItem.CheckState = CheckState.Checked, True, False)
        'cls.URegNumber = IIf(�l���\���ϊ�.CheckState = CheckState.Checked, True, False)

        cls.UJimakuLocation = Me.f2.Location
        cls.UJimakuSize = Me.f2.Size

        'ANY
        cls.UMainAnyFlg = CBool(IIf(CheckAny.CheckState = CheckState.Checked, True, False))

        'IP
        cls.UMainAllowed = ����IP.Text

        '����ON
        cls.UMainJimakuFlg = CBool(IIf(CheckJimaku.CheckState = CheckState.Checked, True, False))

        '�|�[�g�ԍ�
        cls.UMainPort = CInt(RecPort.Text)

        '�\������
        cls.UDispTitle = Me.�^�C�g��.Text
        cls.UDispName01 = Me.����1.Text
        'cls.UDispName02 = Me.����2.Text
        'cls.UDispName03 = Me.����3.Text
        'cls.UDispName04 = Me.����4.Text
        'cls.UDispName05 = Me.����5.Text
        'cls.UDispName06 = Me.����6.Text
        'cls.UDispKey01 = Me.�L�[���[�h1.Text
        'cls.UDispKey02 = Me.�L�[���[�h2.Text
        'cls.UDispKey03 = Me.�L�[���[�h3.Text
        'cls.UDispKey04 = Me.�L�[���[�h4.Text
        'cls.UDispKey05 = Me.�L�[���[�h5.Text
        'cls.UDispKey06 = Me.�L�[���[�h6.Text
        'cls.UDispCounter01 = CInt(Me.�J�E���^1.Value)
        'cls.UDispCounter02 = CInt(Me.�J�E���^2.Value)
        'cls.UDispCounter03 = CInt(Me.�J�E���^3.Value)
        'cls.UDispCounter04 = CInt(Me.�J�E���^4.Value)
        'cls.UDispCounter05 = CInt(Me.�J�E���^5.Value)
        'cls.UDispCounter06 = CInt(Me.�J�E���^6.Value)

        cls.UDispString = Me.�ҏW������.Text

        '���M
        cls.USendString = Me.���M������.Text




        'cls.UOptMostTop = IIf(Me.dialog2.CheckBox01.CheckState = CheckState.Checked, True, False)
        'cls.UOptTaskTray = IIf(Me.dialog2.CheckBox02.CheckState = CheckState.Checked, True, False)

        'cls.UOptAlignRight = Me.BaseAlignRightFlg
        'cls.UOptHotBusy = Me.BaseBusyHotFlg
        'cls.UOptAntiArias = Me.BaseAntiAriasFlg

        'SE���
        '�i�����t���O
        'cls.USEIn = Me.BaseSEInFlg
        ''�ޏo���t���O
        'cls.USEOut = Me.BaseSEOutFlg
        ''���l���t���O
        'cls.USEBusy = Me.BaseSEBusyFlg
        ''�i�����T�E���h
        'cls.USEInSound = Me.soundName1
        ''�ޏo���T�E���h
        'cls.USEOutSound = Me.soundName2
        ''���l���T�E���h
        'cls.USEBusySound = Me.soundName3

        cls.UIntervalTime = Timer1.Interval

    End Sub

    Private Sub GetSaveData(ByRef cls As SaveDataClass)
        Dim fontstyle As FontStyle = CType(cls.UFontStyle, Drawing.FontStyle)
        Me.�\��������.Font = New Font(cls.UFontFamily, cls.UFontSize, fontstyle)

        BaseFontColor = Color.FromArgb(cls.UBaseFontColor)
        BaseFontBorder = Color.FromArgb(cls.UBaseFontBorder)
        BaseFontBorderWidth = cls.UBaseFontBorderWidth
        BaseFontShade = Color.FromArgb(cls.UBaseFontShade)
        BaseFontShadeOn = cls.UBaseFontShadeOn
        BaseFontAlpha = cls.UBaseFontAlpha

        'defaultIMMessage = cls.UDefaultIMMessage

        If cls.UMainAnyFlg Then
            Me.CheckAny.CheckState = CheckState.Checked
        Else
            Me.CheckAny.CheckState = CheckState.Unchecked
        End If
        If cls.UMainJimakuFlg Then
            Me.CheckJimaku.CheckState = CheckState.Checked
        Else
            Me.CheckJimaku.CheckState = CheckState.Unchecked
        End If

        Me.����IP.Text = cls.UMainAllowed

        Me.RecPort.Text = cls.UMainPort.ToString

        Me.f2.Location = cls.UJimakuLocation
        Me.f3.Location = cls.UJimakuLocation
        Me.f2.Size = cls.UJimakuSize
        Me.f3.Size = cls.UJimakuSize

        '�\������
        Me.�^�C�g��.Text = cls.UDispTitle
        Me.����1.Text = cls.UDispName01
        Me.����2.Text = cls.UDispName02
        'Me.����3.Text = cls.UDispName03
        'Me.����4.Text = cls.UDispName04
        'Me.����5.Text = cls.UDispName05
        'Me.����6.Text = cls.UDispName06
        'Me.�L�[���[�h1.Text = cls.UDispKey01
        'Me.�L�[���[�h2.Text = cls.UDispKey02
        'Me.�L�[���[�h3.Text = cls.UDispKey03
        'Me.�L�[���[�h4.Text = cls.UDispKey04
        'Me.�L�[���[�h5.Text = cls.UDispKey05
        'Me.�L�[���[�h6.Text = cls.UDispKey06
        'Me.�J�E���^1.Value = cls.UDispCounter01
        'Me.�J�E���^2.Value = cls.UDispCounter02
        'Me.�J�E���^3.Value = cls.UDispCounter03
        'Me.�J�E���^4.Value = cls.UDispCounter04
        'Me.�J�E���^5.Value = cls.UDispCounter05
        Me.�J�E���^6.Value = cls.UDispCounter06

        Me.�ҏW������.Text = cls.UDispString

        '���M
        Me.���M������.Text = cls.USendString



        ''�i�����T�E���h
        'Me.dialog2.ComboBox1.Text = cls.USEInSound
        'Me.soundName1 = cls.USEInSound

        ''�ޏo���T�E���h
        'Me.dialog2.ComboBox2.Text = cls.USEOutSound
        'Me.soundName2 = cls.USEOutSound
        ''���l���T�E���h
        'Me.dialog2.ComboBox3.Text = cls.USEBusySound
        'Me.soundName3 = cls.USEBusySound

        Timer1.Interval = cls.UIntervalTime
        Me.NumericUpDown1.Value = cls.UIntervalTime
        'Me.dialog2.�X�V�Ԋu.Text = cls.UIntervalTime

    End Sub

    Function CalcFontStyle(ByVal vFont As Font) As FontStyle
        CalcFontStyle = FontStyle.Regular

        If vFont.Bold Then
            CalcFontStyle = CType(CalcFontStyle + FontStyle.Bold, FontStyle)
        End If
        If vFont.Italic Then
            CalcFontStyle = CType(CalcFontStyle + FontStyle.Italic, FontStyle)
        End If
        If vFont.Underline Then
            CalcFontStyle = CType(CalcFontStyle + FontStyle.Underline, FontStyle)
        End If
        If vFont.Strikeout Then
            CalcFontStyle = CType(CalcFontStyle + FontStyle.Strikeout, FontStyle)
        End If
    End Function

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'If �I�����ɕύX��ۑ�ToolStripMenuItem.CheckState = 1 Then
        'If DialogResult.Yes = _
        '    MessageBox.Show("���݂̏���ۑ����܂����H", "����S(*�L�́M*)�", _
        '    MessageBoxButtons.YesNo, _
        '    MessageBoxIcon.Information) Then
        Save()
        'End If
        'End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Timer1.Interval = CInt(Me.NumericUpDown1.Value)
    End Sub

    Private Sub �ĕ`��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �ĕ`��.Click

        Call TimerEvent()
    End Sub

    Private Sub ���[�h_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���[�h.Click
        'XmlSerializer�I�u�W�F�N�g�̍쐬
        Dim serializer As _
            New System.Xml.Serialization.XmlSerializer( _
                GetType(SaveDataClass))

        'OpenFileDialog�N���X�̃C���X�^���X���쐬
        Dim ofd As New OpenFileDialog()

        '�͂��߂̃t�@�C�������w�肷��
        '�͂��߂Ɂu�t�@�C�����v�ŕ\������镶������w�肷��
        ofd.FileName = fileName
        '[�t�@�C���̎��]�ɕ\�������I�������w�肷��
        '�w�肵�Ȃ��Ƃ��ׂẴt�@�C�����\�������
        ofd.Filter = "XML�t�@�C��(*.xml)|*.xml"
        '[�t�@�C���̎��]�ł͂��߂�
        '�u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
        ofd.FilterIndex = 0
        '�^�C�g����ݒ肷��
        ofd.Title = "�J���t�@�C����I�����Ă�������"
        '�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
        ofd.RestoreDirectory = True

        '�_�C�A���O��\������
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then

            ''�t�@�C�����J��
            'Dim fs As New System.IO.FileStream( _
            '    ofd.FileName, System.IO.FileMode.Open)

            ''XML�t�@�C������ǂݍ��݁A�t�V���A��������
            'Dim cls As SaveDataClass = _
            '    CType(serializer.Deserialize(fs), SaveDataClass)
            ''����
            'fs.Close()

            'XmlSerializer�I�u�W�F�N�g�̍쐬
            'Dim serializer As _
            '    New System.Xml.Serialization.XmlSerializer( _
            '        GetType(SaveDataClass))

            Dim doc As New System.Xml.XmlDocument()
            doc.PreserveWhitespace = True
            doc.Load(ofd.FileName)
            Dim reader As New System.Xml.XmlNodeReader(doc.DocumentElement)
            Dim o As Object = serializer.Deserialize(reader)
            Dim cls As SaveDataClass = DirectCast(o, SaveDataClass)


            Call GetSaveData(cls)

            'Dim fontstyle As FontStyle = cls.UFontStyle
            'Me.�\��������.Font = New Font(cls.UFontFamily, cls.UFontSize, fontstyle)

            'BaseFontColor = Color.FromArgb(cls.UBaseFontColor)
            'BaseFontBorder = Color.FromArgb(cls.UBaseFontBorder)
            'BaseFontBorderWidth = cls.UBaseFontBorderWidth
            'BaseFontShade = Color.FromArgb(cls.UBaseFontShade)
            'BaseFontShadeOn = cls.UBaseFontShadeOn

            'defaultIMMessage = cls.UDefaultIMMessage
            '�I�����ɕύX��ۑ�ToolStripMenuItem.CheckState = cls.USaveAuto
            '��ToolStripMenuItem.CheckState = cls.USaveSound

            '�J�����g�t�@�C���㏑��
            fileName = ofd.FileName
            C_filename = GetFileNameFromPath(fileName)
            Me.Text = D_Titlebar + " - " + C_filename

        End If
        ofd.Dispose()
    End Sub

    Private Sub �Z�[�u_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �Z�[�u.Click

        '�ۑ�����N���X(SampleClass)�̃C���X�^���X���쐬
        Dim cls As New SaveDataClass
        Call SetSaveData(cls)

        'XmlSerializer�I�u�W�F�N�g�̍쐬
        Dim serializer As _
            New System.Xml.Serialization.XmlSerializer( _
                GetType(SaveDataClass))

        'OpenFileDialog�N���X�̃C���X�^���X���쐬
        Dim ofd As New SaveFileDialog()

        '�͂��߂̃t�@�C�������w�肷��
        '�͂��߂Ɂu�t�@�C�����v�ŕ\������镶������w�肷��
        ofd.FileName = fileName
        '[�t�@�C���̎��]�ɕ\�������I�������w�肷��
        '�w�肵�Ȃ��Ƃ��ׂẴt�@�C�����\�������
        ofd.Filter = "XML�t�@�C��(*.xml)|*.xml"
        '[�t�@�C���̎��]�ł͂��߂�
        '�u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
        ofd.FilterIndex = 0
        '�^�C�g����ݒ肷��
        ofd.Title = "�J���t�@�C����I�����Ă�������"
        '�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
        ofd.RestoreDirectory = True

        '�_�C�A���O��\������
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then

            ''�t�@�C�����J��
            'Dim fs As New System.IO.FileStream( _
            '    ofd.FileName, System.IO.FileMode.Open)

            ''XML�t�@�C������ǂݍ��݁A�t�V���A��������
            'Dim cls As SaveDataClass = _
            '    CType(serializer.Deserialize(fs), SaveDataClass)
            ''����
            'fs.Close()

            'XmlSerializer�I�u�W�F�N�g�̍쐬
            'Dim serializer As _
            '    New System.Xml.Serialization.XmlSerializer( _
            '        GetType(SaveDataClass))

            'Dim doc As New System.Xml.XmlDocument()
            'doc.PreserveWhitespace = True
            'doc.Load(ofd.FileName)
            'Dim reader As New System.Xml.XmlNodeReader(doc.DocumentElement)
            'Dim o As Object = serializer.Deserialize(reader)
            'Dim cls As SaveDataClass = DirectCast(o, SaveDataClass)


            'Call GetSaveData(cls)

            '�t�@�C�����J��
            Dim fs As New System.IO.FileStream( _
                ofd.FileName, System.IO.FileMode.Create)
            '�V���A�������AXML�t�@�C���ɕۑ�����
            serializer.Serialize(fs, cls)
            '����
            fs.Close()

            'Dim fontstyle As FontStyle = cls.UFontStyle
            'Me.�\��������.Font = New Font(cls.UFontFamily, cls.UFontSize, fontstyle)

            'BaseFontColor = Color.FromArgb(cls.UBaseFontColor)
            'BaseFontBorder = Color.FromArgb(cls.UBaseFontBorder)
            'BaseFontBorderWidth = cls.UBaseFontBorderWidth
            'BaseFontShade = Color.FromArgb(cls.UBaseFontShade)
            'BaseFontShadeOn = cls.UBaseFontShadeOn

            'defaultIMMessage = cls.UDefaultIMMessage
            '�I�����ɕύX��ۑ�ToolStripMenuItem.CheckState = cls.USaveAuto
            '��ToolStripMenuItem.CheckState = cls.USaveSound

            '�J�����g�t�@�C���㏑��
            fileName = ofd.FileName
            C_filename = GetFileNameFromPath(fileName)
            Me.Text = D_Titlebar + " - " + C_filename
        End If
    End Sub

    Public Function GetFileNameFromPath(ByVal s As String) As String
        Dim tmp As Array = s.Split(CChar("\"))

        Return CStr(tmp.GetValue(tmp.Length - 1))
    End Function

    Private Sub Redirect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Redirect.CheckedChanged
        RedirectPort = Redirect_Port.Text
    End Sub


    Private Sub ����4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    'deligates

    Delegate Function DelegateTest() As Boolean
    'Sub test()
    '    ' textBox2.Focus()�̎��s
    '    Invoke(New DelegateTest(AddressOf �\��������.Focus))
    'End Sub







End Class

Public Class SaveDataClass
    'Public UMessage As String
    'Public UProcessName As String

    '�t�H���g��{���
    Public UFontFamily As String
    '�S���ډ��Z
    Public UFontStyle As Integer

    Public UFontSize As Single

    '�t�H���g�F
    Public UBaseFontColor As Integer
    '�����
    Public UBaseFontBorder As Integer
    '����蕝
    Public UBaseFontBorderWidth As Integer
    '�e
    Public UBaseFontShade As Integer
    '�e�L��
    Public UBaseFontShadeOn As Boolean
    '�A���t�@�l
    Public UBaseFontAlpha As Integer

    '�\�����
    '�����\��
    Public UJimakuDisplay As Integer
    '�l���v�Z
    Public URegNumber As Integer

    '�����ʒu���
    Public UJimakuLocation As Point
    Public UJimakuSize As Size

    'ANY
    Public UMainAnyFlg As Boolean

    'IP
    Public UMainAllowed As String

    '����ON
    Public UMainJimakuFlg As Boolean

    '�|�[�g�ԍ�
    Public UMainPort As Integer

    '�\������
    Public UDispTitle As String
    Public UDispName01 As String
    Public UDispName02 As String
    Public UDispName03 As String
    Public UDispName04 As String
    Public UDispName05 As String
    Public UDispName06 As String
    Public UDispKey01 As String
    Public UDispKey02 As String
    Public UDispKey03 As String
    Public UDispKey04 As String
    Public UDispKey05 As String
    Public UDispKey06 As String
    Public UDispCounter01 As Integer
    Public UDispCounter02 As Integer
    Public UDispCounter03 As Integer
    Public UDispCounter04 As Integer
    Public UDispCounter05 As Integer
    Public UDispCounter06 As Integer

    Public UDispString As String

    '���M
    Public USendString As String





    '///////////////////
    ''�I�v�V�������
    ''��ɍőO�ʂɕ\��
    'Public UOptMostTop As Boolean
    ''�^�X�N�g���C�Ɋi�[����
    'Public UOptTaskTray As Boolean
    ''�������E�񂹂ɂ���
    'Public UOptAlignRight As Boolean
    ''���l�̂Ƃ��Ԃ�����
    'Public UOptHotBusy As Boolean
    ''�A���`�G�C���A�X��������
    'Public UOptAntiArias As Boolean

    '///////////////////
    'SE���
    ''�i�����t���O
    'Public USEIn As Boolean
    ''�ޏo���t���O
    'Public USEOut As Boolean
    ''���l���t���O
    'Public USEBusy As Boolean
    ''�i�����T�E���h
    'Public USEInSound As String
    ''�ޏo���T�E���h
    'Public USEOutSound As String
    ''���l���T�E���h
    'Public USEBusySound As String

    'Public UDefaultIMMessage As String

    ''�X�V����
    Public UIntervalTime As Integer

End Class