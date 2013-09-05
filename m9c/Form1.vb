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

    'フォント基本情報
    'フォント色
    Public BaseFontColor As Color = Color.Black
    '縁取り
    Public BaseFontBorder As Color = Color.White
    '縁取り幅
    Public BaseFontBorderWidth As Integer = 0
    '影
    Public BaseFontShade As Color = Color.White
    '影有無
    Public BaseFontShadeOn As Boolean = False
    'アルファ値
    Public BaseFontAlpha As Integer = 250

    'デフォルト値設定
    Dim D_filename As String = "m9c.xml"
    Dim C_filename As String = ""
    Dim fileName As String = Application.StartupPath + "\" + D_filename
    Dim D_Titlebar As String = "m9カウンタ Ver0.05"
    Public D_Title As String = "m9カウンタ Ver0.05"
    Public D_Name01 As String = "m9(^Д^)ﾌﾟｷﾞｬｰ"
    Public D_Name02 As String = "ъ(ﾟДﾟ)ｸﾞｯｼﾞｮﾌﾞ!!"
    Public D_Name03 As String = "(・д・)ﾁｯ"
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

    Public D_EditText As String = "$t1：$c1" + vbCrLf + "$t2：$c2" + vbCrLf + "$t3：$c3"

    Public D_HTMLText As String = _
                "<html>" + vbCrLf + _
                "<head>" + vbCrLf + _
                "<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">" + vbCrLf + _
                "<title>$title</title>" + vbCrLf + _
                "</head>" + vbCrLf + _
                "<body bgcolor=""#ffeeee"">" + vbCrLf + _
                "<h3>$title</h3><hr>" + vbCrLf + _
                "<h1><a href=""/$k1"">$t1</a>：$c1" + vbCrLf + _
                "<br><a href=""/$k2"">$t2</a>：$c2" + vbCrLf + _
                "<br><a href=""/$k3"">$t3</a>：$c3" + vbCrLf + _
                "<br><a href=""/"">更新</a>" + vbCrLf + _
                "</h1>" + vbCrLf + _
                "</body>" + vbCrLf + _
                "</html>"

    'テキスト
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

    '強制遮断フラグ
    Shared ForceClose As Boolean = False
    Public ForceClose2 As Boolean = True



    Dim receiveFlag As Boolean = True
    Dim listener As System.Net.Sockets.TcpListener
    Shared gMassage As String = ""

    Shared path As String = ""
    Shared permittedIp As String = "Nothing"
    Shared permitCheck As Integer

    '音声

    'Public D_Sound01 As System.IO.Stream = My.Resources.pg2
    'Public D_Sound02 As System.IO.Stream = My.Resources.gj
    'Public D_Sound03 As System.IO.Stream = My.Resources.ti

    'Dim D_Sound01_Val As String = "<ﾌﾟｷﾞｬｰ>"
    'Dim D_Sound02_Val As String = "<ｸﾞｯｼﾞｮﾌﾞ>"
    'Dim D_Sound03_Val As String = "<ﾁｯ>"
    'Dim SoundArry As Array



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 受信.Click

        Me.受信.Enabled = False
        Me.遮断.Enabled = True

        ForceClose = False
        ForceClose2 = True

        receiveFlag = True

        '文字コードを指定する
        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")

        Dim lport As Integer = CInt(Me.RecPort.Text)
        'Dim lipadd As System.Net.IPAddress

        'If Me.CheckBox1.CheckState = CheckState.Checked Then
        '    lipadd = System.Net.IPAddress.Any
        'Else
        '    Try
        '        lipadd = System.Net.IPAddress.Parse(Me.許可IP.Text)
        '    Catch
        '        MessageBox.Show("IPアドレスが不正です")
        '        Me.受信.Enabled = True
        '        Me.遮断.Enabled = False
        '        Return
        '    End Try

        'End If

        listener = New System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, lport)

        Try
            listener.Start()
        Catch
        End Try

        If CheckAny.CheckState = CheckState.Checked Then
            Messages.Text = CStr(Now) + vbCrLf + "Anyからポート" + Me.RecPort.Text + "に受信受付中です"
        Else
            Messages.Text = CStr(Now) + vbCrLf + permittedIp + "からポート" + Me.RecPort.Text + "に受信受付中です"
        End If


        StartAccept(listener.Server)

    End Sub


    'クライアントの接続待ちスタート
    Private Shared Sub StartAccept( _
        ByVal server As System.Net.Sockets.Socket)
        'server.ReceiveTimeout = 4000
        '接続要求待機を開始する
        server.BeginAccept(New System.AsyncCallback( _
            AddressOf AcceptCallback), server)
    End Sub

    'BeginAcceptのコールバック
    Private Shared Sub AcceptCallback(ByVal ar As System.IAsyncResult)
        'サーバーSocketの取得
        Dim server As System.Net.Sockets.Socket = _
            CType(ar.AsyncState, System.Net.Sockets.Socket)

        'server.ReceiveTimeout = 4000
        'server.SendTimeout = 4000

        '接続要求を受け入れる
        Dim client As System.Net.Sockets.Socket = Nothing
        Try
            'クライアントSocketの取得
            client = server.EndAccept(ar)
            'client.ReceiveTimeout = 4000
            'client.SendTimeout = 4000
        Catch e As System.ObjectDisposedException
            'Form1.Label1.Text = Now + vbCrLf + "クライアントが切断しました"
            'Debug.Print("ここですか？")
            '接続要求待機を再開する
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
            'タイムアウト

            If permitCheck = CheckState.Checked Or permittedIp = spt(0) Then

                'クライアントから送られたデータを受信する
                Dim ms As New System.IO.MemoryStream
                Dim resBytes(256) As Byte
                Dim resSize As Integer

                'resSize = client.Receive(resBytes)
                Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_jis")

                'Debug.Print("2")

                Do
                    'データの一部を受信する
                    'Debug.Print("21")
                    resSize = client.Receive(resBytes)
                    'Debug.Print("22")
                    'Readが0を返した時はクライアントが切断したと判断
                    If resSize <= 0 Then
                        'Form1.Label1.Text = Now + vbCrLf + "クライアントが切断しました"
                        'Debug.Print("3")
                        'client.Close()
                        'Console.ReadLine()
                        'Debug.Print("4")
                        'Return
                        Exit Do
                    End If
                    '受信したデータを蓄積する
                    'Debug.Print("5")
                    ms.Write(resBytes, 0, resSize)
                    'Debug.Print("6")
                Loop While client.Available > 0 And ms.Length < 1028
                'client.Close()
                '受信したデータを文字列に変換
                Dim resMsg As String = enc.GetString(ms.ToArray())
                'Debug.Print("7")
                ms.Close()

                'Debug.Print("8")

                'ユーザエージェントを調べる
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
                    'Regexオブジェクトを作成 
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

                    ''Regexオブジェクトを作成 
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

                    'ここでは文字列を送信して、すぐに閉じている

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


                    'クライアントが接続した時の処理をここに書く
                    HTMLText = Regex.Replace(HTMLText, "\$c1", Counter01.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c2", Counter02.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c3", Counter03.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c4", Counter04.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c5", Counter05.ToString)
                    HTMLText = Regex.Replace(HTMLText, "\$c6", Counter06.ToString)

                    Dim body As String
                    body = HTMLText

                    'ここでは文字列を送信して、すぐに閉じている

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
            '強制遮断
            ForceClose = True
            Return
            'client.Shutdown(System.Net.Sockets.SocketShutdown.Both)

        End Try
        client.Close()

        '接続要求待機を再開する

        server.BeginAccept(New System.AsyncCallback( _
            AddressOf AcceptCallback), server)
    End Sub

    Private Sub 遮断_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 遮断.Click
        'receiveFlag = False
        '強制終了
        Call 強制遮断()

    End Sub

    Private Sub 強制遮断()
        Try
            listener.Stop()
            listener.Server.Close()
        Catch
        End Try
        Form1.Messages.Text = CStr(Now) + vbCrLf + "遮断しました"
        Me.受信.Enabled = True
        Me.遮断.Enabled = False
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAny.CheckedChanged
        If CheckAny.CheckState = CheckState.Checked Then
            許可IP.Enabled = False
        Else
            許可IP.Enabled = True
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

        透過()
        Me.f2.Visible = False
        Me.f3.Visible = False

        'テンポラリ読み込み



        If System.IO.File.Exists(fileName) Then
            'XmlSerializerオブジェクトの作成
            Dim serializer As _
                New System.Xml.Serialization.XmlSerializer( _
                    GetType(SaveDataClass))

            Dim doc As New System.Xml.XmlDocument()
            doc.PreserveWhitespace = True
            doc.Load(fileName)
            Dim reader As New System.Xml.XmlNodeReader(doc.DocumentElement)
            Dim o As Object = serializer.Deserialize(reader)
            Dim cls As SaveDataClass = DirectCast(o, SaveDataClass)

            ''ファイルを開く
            'Dim fs As New System.IO.FileStream( _
            '    fileName, System.IO.FileMode.Open)
            ''XMLファイルから読み込み、逆シリアル化する

            ''doc.PreserveWhitespace = True


            'Dim cls As SaveDataClass = _
            '    CType(serializer.Deserialize(fs), SaveDataClass)
            ''閉じる
            'fs.Close()

            Call Me.GetSaveData(cls)

        Else
            'デフォルト
            Me.タイトル.Text = D_Title
            'Me.名称1.Text = D_Name01
            'Me.名称2.Text = D_Name02
            'Me.名称3.Text = D_Name03
            'Me.名称4.Text = D_Name04
            'Me.名称5.Text = D_Name05
            'Me.名称6.Text = D_Name06

            DataGridView1.Rows.Add(D_Name01, "$t1", D_Counter01, "$c1", "", D_ID01, "$g1")
            DataGridView1.Rows.Add(D_Name02, "$t2", D_Counter02, "$c2", "", D_ID02, "$g2")
            DataGridView1.Rows.Add(D_Name03, "$t3", D_Counter03, "$c3", "", D_ID03, "$g3")


            For Each dgvr As DataGridViewRow In DataGridView1.Rows
                'Debug.Print(CStr(dgvr.Cells(5).Value))
            Next


            'Me.キーワード1.Text = D_ID01
            'Me.キーワード2.Text = D_ID02
            'Me.キーワード3.Text = D_ID03
            'Me.キーワード4.Text = D_KeyWord04
            'Me.キーワード5.Text = D_KeyWord05
            'Me.キーワード6.Text = D_KeyWord06

            'Me.カウンタ1.Text = CStr(0)
            'Me.カウンタ2.Text = CStr(0)
            'Me.カウンタ3.Text = CStr(0)
            'Me.カウンタ4.Text = CStr(0)
            'Me.カウンタ5.Text = CStr(0)
            'Me.カウンタ6.Text = CStr(0)

            Me.編集文字列.Text = D_EditText

            Me.送信文字列.Text = D_HTMLText

        End If

        Me.Text = D_Titlebar + " - " + D_filename

        Me.fontDetail = New FontDetail(Me)

        Timer1.Interval = 1000
        Timer1.Start()

    End Sub

    'DefaultValuesNeededイベントハンドラ
    Private Shared Sub DataGridView1_DefaultValuesNeeded(ByVal sender As Object, _
            ByVal e As DataGridViewRowEventArgs) _
            Handles DataGridView1.DefaultValuesNeeded
        'セルの既定値を指定する
        e.Row.Cells("GUID").Value = System.Guid.NewGuid().ToString
        e.Row.Cells("Column2").Value = 0
    End Sub


    'DataErrorイベントハンドラ
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
            Call 強制遮断()
            MsgBox("TCP接続が切断されました。受信を中止します。", _
                MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, _
                "接続が切断されました。")

        End If

        Call TimerEvent()


    End Sub

    Private Sub TimerEvent()
        'EDITコード
        Dim tmpstr As String = Me.編集文字列.Text
        Dim tmpstr2 As String = Me.送信文字列.Text

        tmpstr = Regex.Replace(tmpstr, "\$title", Me.タイトル.Text)
        tmpstr2 = Regex.Replace(tmpstr2, "\$title", Me.タイトル.Text)


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

        Me.表示文字列.Text = tmpstr

        'shared送信HTMLを更新

        'tmpstr2 = Regex.Replace(tmpstr2, "\$t1", Me.名称1.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t2", Me.名称2.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t3", Me.名称3.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t4", Me.名称4.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t5", Me.名称5.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$t6", Me.名称6.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k1", Me.キーワード1.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k2", Me.キーワード2.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k3", Me.キーワード3.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k4", Me.キーワード4.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k5", Me.キーワード5.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$k6", Me.キーワード6.Text)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c1", Counter01.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c2", Counter02.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c3", Counter03.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c4", Counter04.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c5", Counter05.ToString)
        'tmpstr2 = Regex.Replace(tmpstr2, "\$c6", Counter06.ToString)


        HTMLText = tmpstr2

        'キーワード保持
        KeyWord01 = Me.キーワード1.Text
        KeyWord02 = Me.キーワード2.Text
        KeyWord03 = Me.キーワード3.Text
        KeyWord04 = ""
        KeyWord05 = Me.キーワード5.Text
        KeyWord06 = Me.キーワード6.Text

        'カウンタ保持
        Me.カウンタ1.Value = Counter01
        Me.カウンタ2.Value = Counter02
        Me.カウンタ3.Value = Counter03
        'Me.カウンタ4.Value = Counter04
        Me.カウンタ5.Value = Counter05
        Me.カウンタ6.Value = Counter06


        '字幕作成
        透過()

        '音声のとこ
        Me.soundname01.Text = Me.名称1.Text
    End Sub

    Private Sub 許可IP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 許可IP.TextChanged
        permittedIp = 許可IP.Text
    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Me.fontDetail = New FontDetail(Me)
        Me.fontDetail.ShowDialog()
    End Sub

    Private Sub 透過()

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

        'フォントオブジェクトの作成
        Dim fnt As New Font(表示文字列.Font.FontFamily, 表示文字列.Size.Height, _
                       表示文字列.Font.Style, GraphicsUnit.Pixel)
        'StringFormatオブジェクトの作成
        Dim sf As New StringFormat
        Dim stringSize As SizeF = _
        g.MeasureString(Me.表示文字列.Text, fnt, 65535, sf)
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
            path2.AddString(Me.表示文字列.Text, 表示文字列.Font.FontFamily, _
                       表示文字列.Font.Style, 表示文字列.Font.Height, New Point(3, 3), _
                       StringFormat.GenericDefault)
            '文字列の中を塗りつぶす
            gBuf.FillPath(brs3, path2)
        End If

        path.AddString(Me.表示文字列.Text, 表示文字列.Font.FontFamily, _
            表示文字列.Font.Style, 表示文字列.Font.Height, New Point(0, 0), _
            StringFormat.GenericDefault)

        If Me.BaseFontBorderWidth <> 0 Then
            brs2 = New Pen(Me.BaseFontBorder, Me.BaseFontBorderWidth)

            '文字列の縁を描画する
            gBuf.DrawPath(brs2, path)
            brs2.Dispose()

        End If

        '文字列の中を塗りつぶす
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

        'リソースを開放する
        bBuf.Dispose()
        gBuf.Dispose()
        'gp.Dispose()
        g.Dispose()
        brs1.Dispose()
        brs3.Dispose()

        'フォームのアルファ値を設定する
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
        'Me.カウンタ1.Value = 0
        'Me.カウンタ2.Value = 0
        'Me.カウンタ3.Value = 0
        'Me.カウンタ4.Value = 0
        'Me.カウンタ5.Value = 0
        'Me.カウンタ6.Value = 0
        'Counter01 = 0
        'Counter02 = 0
        'Counter03 = 0
        'Counter04 = 0
        'Counter05 = 0
        'Counter06 = 0

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles キーワード6.TextChanged

    End Sub

    Private Sub Reset1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset1.Click
        Me.カウンタ1.Value = 0
        Counter01 = 0
    End Sub

    Private Sub Reset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset2.Click
        Me.カウンタ2.Value = 0
        Counter02 = 0
    End Sub

    Private Sub Reset3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset3.Click
        Me.カウンタ3.Value = 0
        Counter03 = 0
    End Sub

    Private Sub Reset4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.カウンタ4.Value = 0
        Counter04 = 0
    End Sub

    Private Sub Reset5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset5.Click
        Me.カウンタ5.Value = 0
        Counter05 = 0
    End Sub

    Private Sub Reset6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset6.Click
        Me.カウンタ6.Value = 0
        Counter06 = 0
    End Sub

    Private Sub カウンタ1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles カウンタ1.ValueChanged
        Counter01 = CInt(Me.カウンタ1.Value)
    End Sub

    Private Sub カウンタ2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles カウンタ2.ValueChanged
        Counter02 = CInt(Me.カウンタ2.Value)
    End Sub

    Private Sub カウンタ3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles カウンタ3.ValueChanged
        Counter03 = CInt(Me.カウンタ3.Value)
    End Sub

    Private Sub カウンタ4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Counter04 = CInt(Me.カウンタ4.Value)
    End Sub

    Private Sub カウンタ5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles カウンタ5.ValueChanged
        Counter05 = CInt(Me.カウンタ5.Value)
    End Sub

    Private Sub カウンタ6_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles カウンタ6.ValueChanged
        Counter06 = CInt(Me.カウンタ6.Value)
    End Sub


    'エントリポイント
    Public Sub Save()
        '保存先のファイル名

        '保存するクラス(SampleClass)のインスタンスを作成
        Dim cls As New SaveDataClass
        'cls.UMessage = Message
        'If Not pss Is Nothing Then
        '    cls.UProcessName = pss.ProcessName
        'Else
        '    cls.UProcessName = "kagami"
        'End If

        Call SetSaveData(cls)

        'XmlSerializerオブジェクトを作成
        '書き込むオブジェクトの型を指定する
        Dim serializer As _
            New System.Xml.Serialization.XmlSerializer( _
                GetType(SaveDataClass))

        ''OpenFileDialogクラスのインスタンスを作成
        'Dim ofd As New OpenFileDialog()

        ''はじめのファイル名を指定する
        ''はじめに「ファイル名」で表示される文字列を指定する
        'ofd.FileName = fileName
        ''[ファイルの種類]に表示される選択肢を指定する
        ''指定しないとすべてのファイルが表示される
        'ofd.Filter = "XMLファイル(*.xml)|*.xml"
        ''[ファイルの種類]ではじめに
        ''「すべてのファイル」が選択されているようにする
        'ofd.FilterIndex = 0
        ''タイトルを設定する
        'ofd.Title = "開くファイルを選択してください"
        ''ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        'ofd.RestoreDirectory = True

        ''ダイアログを表示する
        'If ofd.ShowDialog() = DialogResult.OK Then

        'ファイルを開く
        Dim fs As New System.IO.FileStream( _
            fileName, System.IO.FileMode.Create)
        'シリアル化し、XMLファイルに保存する
        serializer.Serialize(fs, cls)
        '閉じる
        fs.Close()

        'End If
    End Sub

    Private Sub SetSaveData(ByRef cls As SaveDataClass)
        cls.UFontFamily = 表示文字列.Font.FontFamily.Name
        cls.UFontStyle = CalcFontStyle(Messages.Font)
        cls.UFontSize = 表示文字列.Font.Size

        cls.UBaseFontColor = BaseFontColor.ToArgb
        cls.UBaseFontBorder = BaseFontBorder.ToArgb
        cls.UBaseFontBorderWidth = BaseFontBorderWidth
        cls.UBaseFontShade = BaseFontShade.ToArgb
        cls.UBaseFontShadeOn = BaseFontShadeOn
        cls.UBaseFontAlpha = BaseFontAlpha

        'cls.UDefaultIMMessage = defaultIMMessage

        'cls.UJimakuDisplay = IIf(背景透過ToolStripMenuItem.CheckState = CheckState.Checked, True, False)
        'cls.URegNumber = IIf(人数表示変換.CheckState = CheckState.Checked, True, False)

        cls.UJimakuLocation = Me.f2.Location
        cls.UJimakuSize = Me.f2.Size

        'ANY
        cls.UMainAnyFlg = CBool(IIf(CheckAny.CheckState = CheckState.Checked, True, False))

        'IP
        cls.UMainAllowed = 許可IP.Text

        '字幕ON
        cls.UMainJimakuFlg = CBool(IIf(CheckJimaku.CheckState = CheckState.Checked, True, False))

        'ポート番号
        cls.UMainPort = CInt(RecPort.Text)

        '表示項目
        cls.UDispTitle = Me.タイトル.Text
        cls.UDispName01 = Me.名称1.Text
        'cls.UDispName02 = Me.名称2.Text
        'cls.UDispName03 = Me.名称3.Text
        'cls.UDispName04 = Me.名称4.Text
        'cls.UDispName05 = Me.名称5.Text
        'cls.UDispName06 = Me.名称6.Text
        'cls.UDispKey01 = Me.キーワード1.Text
        'cls.UDispKey02 = Me.キーワード2.Text
        'cls.UDispKey03 = Me.キーワード3.Text
        'cls.UDispKey04 = Me.キーワード4.Text
        'cls.UDispKey05 = Me.キーワード5.Text
        'cls.UDispKey06 = Me.キーワード6.Text
        'cls.UDispCounter01 = CInt(Me.カウンタ1.Value)
        'cls.UDispCounter02 = CInt(Me.カウンタ2.Value)
        'cls.UDispCounter03 = CInt(Me.カウンタ3.Value)
        'cls.UDispCounter04 = CInt(Me.カウンタ4.Value)
        'cls.UDispCounter05 = CInt(Me.カウンタ5.Value)
        'cls.UDispCounter06 = CInt(Me.カウンタ6.Value)

        cls.UDispString = Me.編集文字列.Text

        '送信
        cls.USendString = Me.送信文字列.Text




        'cls.UOptMostTop = IIf(Me.dialog2.CheckBox01.CheckState = CheckState.Checked, True, False)
        'cls.UOptTaskTray = IIf(Me.dialog2.CheckBox02.CheckState = CheckState.Checked, True, False)

        'cls.UOptAlignRight = Me.BaseAlignRightFlg
        'cls.UOptHotBusy = Me.BaseBusyHotFlg
        'cls.UOptAntiArias = Me.BaseAntiAriasFlg

        'SE情報
        '進入時フラグ
        'cls.USEIn = Me.BaseSEInFlg
        ''退出時フラグ
        'cls.USEOut = Me.BaseSEOutFlg
        ''美人時フラグ
        'cls.USEBusy = Me.BaseSEBusyFlg
        ''進入時サウンド
        'cls.USEInSound = Me.soundName1
        ''退出時サウンド
        'cls.USEOutSound = Me.soundName2
        ''美人時サウンド
        'cls.USEBusySound = Me.soundName3

        cls.UIntervalTime = Timer1.Interval

    End Sub

    Private Sub GetSaveData(ByRef cls As SaveDataClass)
        Dim fontstyle As FontStyle = CType(cls.UFontStyle, Drawing.FontStyle)
        Me.表示文字列.Font = New Font(cls.UFontFamily, cls.UFontSize, fontstyle)

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

        Me.許可IP.Text = cls.UMainAllowed

        Me.RecPort.Text = cls.UMainPort.ToString

        Me.f2.Location = cls.UJimakuLocation
        Me.f3.Location = cls.UJimakuLocation
        Me.f2.Size = cls.UJimakuSize
        Me.f3.Size = cls.UJimakuSize

        '表示項目
        Me.タイトル.Text = cls.UDispTitle
        Me.名称1.Text = cls.UDispName01
        Me.名称2.Text = cls.UDispName02
        'Me.名称3.Text = cls.UDispName03
        'Me.名称4.Text = cls.UDispName04
        'Me.名称5.Text = cls.UDispName05
        'Me.名称6.Text = cls.UDispName06
        'Me.キーワード1.Text = cls.UDispKey01
        'Me.キーワード2.Text = cls.UDispKey02
        'Me.キーワード3.Text = cls.UDispKey03
        'Me.キーワード4.Text = cls.UDispKey04
        'Me.キーワード5.Text = cls.UDispKey05
        'Me.キーワード6.Text = cls.UDispKey06
        'Me.カウンタ1.Value = cls.UDispCounter01
        'Me.カウンタ2.Value = cls.UDispCounter02
        'Me.カウンタ3.Value = cls.UDispCounter03
        'Me.カウンタ4.Value = cls.UDispCounter04
        'Me.カウンタ5.Value = cls.UDispCounter05
        Me.カウンタ6.Value = cls.UDispCounter06

        Me.編集文字列.Text = cls.UDispString

        '送信
        Me.送信文字列.Text = cls.USendString



        ''進入時サウンド
        'Me.dialog2.ComboBox1.Text = cls.USEInSound
        'Me.soundName1 = cls.USEInSound

        ''退出時サウンド
        'Me.dialog2.ComboBox2.Text = cls.USEOutSound
        'Me.soundName2 = cls.USEOutSound
        ''美人時サウンド
        'Me.dialog2.ComboBox3.Text = cls.USEBusySound
        'Me.soundName3 = cls.USEBusySound

        Timer1.Interval = cls.UIntervalTime
        Me.NumericUpDown1.Value = cls.UIntervalTime
        'Me.dialog2.更新間隔.Text = cls.UIntervalTime

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

        'If 終了時に変更を保存ToolStripMenuItem.CheckState = 1 Then
        'If DialogResult.Yes = _
        '    MessageBox.Show("現在の情報を保存しますか？", "解放ヾ(*´∀｀*)ﾉ", _
        '    MessageBoxButtons.YesNo, _
        '    MessageBoxIcon.Information) Then
        Save()
        'End If
        'End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Timer1.Interval = CInt(Me.NumericUpDown1.Value)
    End Sub

    Private Sub 再描写_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 再描写.Click

        Call TimerEvent()
    End Sub

    Private Sub ロード_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ロード.Click
        'XmlSerializerオブジェクトの作成
        Dim serializer As _
            New System.Xml.Serialization.XmlSerializer( _
                GetType(SaveDataClass))

        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        ofd.FileName = fileName
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "XMLファイル(*.xml)|*.xml"
        '[ファイルの種類]ではじめに
        '「すべてのファイル」が選択されているようにする
        ofd.FilterIndex = 0
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True

        'ダイアログを表示する
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then

            ''ファイルを開く
            'Dim fs As New System.IO.FileStream( _
            '    ofd.FileName, System.IO.FileMode.Open)

            ''XMLファイルから読み込み、逆シリアル化する
            'Dim cls As SaveDataClass = _
            '    CType(serializer.Deserialize(fs), SaveDataClass)
            ''閉じる
            'fs.Close()

            'XmlSerializerオブジェクトの作成
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
            'Me.表示文字列.Font = New Font(cls.UFontFamily, cls.UFontSize, fontstyle)

            'BaseFontColor = Color.FromArgb(cls.UBaseFontColor)
            'BaseFontBorder = Color.FromArgb(cls.UBaseFontBorder)
            'BaseFontBorderWidth = cls.UBaseFontBorderWidth
            'BaseFontShade = Color.FromArgb(cls.UBaseFontShade)
            'BaseFontShadeOn = cls.UBaseFontShadeOn

            'defaultIMMessage = cls.UDefaultIMMessage
            '終了時に変更を保存ToolStripMenuItem.CheckState = cls.USaveAuto
            '音ToolStripMenuItem.CheckState = cls.USaveSound

            'カレントファイル上書き
            fileName = ofd.FileName
            C_filename = GetFileNameFromPath(fileName)
            Me.Text = D_Titlebar + " - " + C_filename

        End If
        ofd.Dispose()
    End Sub

    Private Sub セーブ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles セーブ.Click

        '保存するクラス(SampleClass)のインスタンスを作成
        Dim cls As New SaveDataClass
        Call SetSaveData(cls)

        'XmlSerializerオブジェクトの作成
        Dim serializer As _
            New System.Xml.Serialization.XmlSerializer( _
                GetType(SaveDataClass))

        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New SaveFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        ofd.FileName = fileName
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "XMLファイル(*.xml)|*.xml"
        '[ファイルの種類]ではじめに
        '「すべてのファイル」が選択されているようにする
        ofd.FilterIndex = 0
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True

        'ダイアログを表示する
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then

            ''ファイルを開く
            'Dim fs As New System.IO.FileStream( _
            '    ofd.FileName, System.IO.FileMode.Open)

            ''XMLファイルから読み込み、逆シリアル化する
            'Dim cls As SaveDataClass = _
            '    CType(serializer.Deserialize(fs), SaveDataClass)
            ''閉じる
            'fs.Close()

            'XmlSerializerオブジェクトの作成
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

            'ファイルを開く
            Dim fs As New System.IO.FileStream( _
                ofd.FileName, System.IO.FileMode.Create)
            'シリアル化し、XMLファイルに保存する
            serializer.Serialize(fs, cls)
            '閉じる
            fs.Close()

            'Dim fontstyle As FontStyle = cls.UFontStyle
            'Me.表示文字列.Font = New Font(cls.UFontFamily, cls.UFontSize, fontstyle)

            'BaseFontColor = Color.FromArgb(cls.UBaseFontColor)
            'BaseFontBorder = Color.FromArgb(cls.UBaseFontBorder)
            'BaseFontBorderWidth = cls.UBaseFontBorderWidth
            'BaseFontShade = Color.FromArgb(cls.UBaseFontShade)
            'BaseFontShadeOn = cls.UBaseFontShadeOn

            'defaultIMMessage = cls.UDefaultIMMessage
            '終了時に変更を保存ToolStripMenuItem.CheckState = cls.USaveAuto
            '音ToolStripMenuItem.CheckState = cls.USaveSound

            'カレントファイル上書き
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


    Private Sub 名称4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    'deligates

    Delegate Function DelegateTest() As Boolean
    'Sub test()
    '    ' textBox2.Focus()の実行
    '    Invoke(New DelegateTest(AddressOf 表示文字列.Focus))
    'End Sub







End Class

Public Class SaveDataClass
    'Public UMessage As String
    'Public UProcessName As String

    'フォント基本情報
    Public UFontFamily As String
    '４項目加算
    Public UFontStyle As Integer

    Public UFontSize As Single

    'フォント色
    Public UBaseFontColor As Integer
    '縁取り
    Public UBaseFontBorder As Integer
    '縁取り幅
    Public UBaseFontBorderWidth As Integer
    '影
    Public UBaseFontShade As Integer
    '影有無
    Public UBaseFontShadeOn As Boolean
    'アルファ値
    Public UBaseFontAlpha As Integer

    '表示情報
    '字幕表示
    Public UJimakuDisplay As Integer
    '人数計算
    Public URegNumber As Integer

    '字幕位置情報
    Public UJimakuLocation As Point
    Public UJimakuSize As Size

    'ANY
    Public UMainAnyFlg As Boolean

    'IP
    Public UMainAllowed As String

    '字幕ON
    Public UMainJimakuFlg As Boolean

    'ポート番号
    Public UMainPort As Integer

    '表示項目
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

    '送信
    Public USendString As String





    '///////////////////
    ''オプション情報
    ''常に最前面に表示
    'Public UOptMostTop As Boolean
    ''タスクトレイに格納する
    'Public UOptTaskTray As Boolean
    ''字幕を右寄せにする
    'Public UOptAlignRight As Boolean
    ''美人のとき赤くする
    'Public UOptHotBusy As Boolean
    ''アンチエイリアスをかける
    'Public UOptAntiArias As Boolean

    '///////////////////
    'SE情報
    ''進入時フラグ
    'Public USEIn As Boolean
    ''退出時フラグ
    'Public USEOut As Boolean
    ''美人時フラグ
    'Public USEBusy As Boolean
    ''進入時サウンド
    'Public USEInSound As String
    ''退出時サウンド
    'Public USEOutSound As String
    ''美人時サウンド
    'Public USEBusySound As String

    'Public UDefaultIMMessage As String

    ''更新時間
    Public UIntervalTime As Integer

End Class