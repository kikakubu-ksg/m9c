Imports System.Windows.Forms

Public Class FontDetail

    Dim myForm1 As Form1
    Public pFont As Font
    Dim noChgFlg As Boolean = False


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        myForm1.BaseFontColor = フォント色.BackColor
        myForm1.BaseFontBorder = 縁取り.BackColor
        myForm1.BaseFontBorderWidth = 縁取り幅.Value
        myForm1.BaseFontShade = 影.BackColor
        myForm1.BaseFontShadeOn = 影つける.Checked
        myForm1.BaseFontAlpha = Me.TrackBar1.Value
        myForm1.表示文字列.Font = pFont.Clone
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FontDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        FontDialog1.Font = New Font(pFont.Name, pFont.Size, CalcFontStyle())

        FontDialog1.ShowDialog()

        pFont = New Font(FontDialog1.Font.Name, FontDialog1.Font.Size, _
        CalcFontStyle2())
        noChgFlg = True
        太字.Checked = pFont.Bold
        斜体.Checked = pFont.Italic
        noChgFlg = False
        doFin()

    End Sub


    Private Sub フォント色_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles フォント色.Click
        ColorDialog1.Color = フォント色.BackColor
        ColorDialog1.ShowDialog()
        フォント色.BackColor = ColorDialog1.Color
        doFin()

    End Sub

    Private Sub 縁取り_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 縁取り.Click
        ColorDialog1.Color = 縁取り.BackColor
        ColorDialog1.ShowDialog()
        縁取り.BackColor = ColorDialog1.Color
        doFin()
    End Sub

    Private Sub 影_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 影.Click

        ColorDialog1.Color = 影.BackColor
        ColorDialog1.ShowDialog()
        影.BackColor = ColorDialog1.Color
        doFin()
    End Sub

    Sub doFin()
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        Dim path2 As New System.Drawing.Drawing2D.GraphicsPath()
        Dim g As Graphics = こんな感じ.CreateGraphics()

        Dim brs1 As SolidBrush = New SolidBrush(Color.FromArgb(Me.TrackBar1.Value, フォント色.BackColor))
        Dim brs2 As Pen
        Dim brs3 As SolidBrush = New SolidBrush(Color.FromArgb(Me.TrackBar1.Value, 影.BackColor))

        g.Clear(Color.White)

        If 影つける.Checked Then
            path2.AddString(こんな感じ.Text, pFont.FontFamily, _
                       pFont.Style, pFont.Height, New Point(3, 3), _
                       StringFormat.GenericDefault)


            '文字列の中を塗りつぶす
            g.FillPath(brs3, path2)
        End If

        path.AddString(こんな感じ.Text, pFont.FontFamily, _
            pFont.Style, pFont.Height, New Point(0, 0), _
            StringFormat.GenericDefault)

        If 縁取り幅.Value <> 0 Then
            brs2 = New Pen(Color.FromArgb(Me.TrackBar1.Value, 縁取り.BackColor), 縁取り幅.Value)

            '文字列の縁を描画する
            g.DrawPath(brs2, path)
            brs2.Dispose()

        End If

        '文字列の中を塗りつぶす
        g.FillPath(brs1, path)

        'リソースを開放する
        g.Dispose()
        brs1.Dispose()
        brs3.Dispose()

        フォント名.Text = pFont.FontFamily.Name
        フォントサイズ.Text = pFont.Size

    End Sub

    Private Sub 影つける_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 影つける.CheckedChanged
        doFin()
    End Sub

    Public Sub New(ByRef f As Form1)
        InitializeComponent()
        myForm1 = f
        'pFont = New Font(myForm1.Label1.Font.FontFamily, myForm1.Label1.Font.Size, myForm1.CalcFontStyle(myForm1.Label1.Font))
        pFont = myForm1.表示文字列.Font.Clone
        'pFont = New Font(Form1.Label1.Font.FontFamily, Form1.Label1.Font.Size, Form1.CalcFontStyle(Form1.Label1.Font))

        noChgFlg = True

        太字.Checked = pFont.Bold
        斜体.Checked = pFont.Italic
        下線.Checked = pFont.Underline
        取り消し線.Checked = pFont.Strikeout

        フォント色.BackColor = myForm1.BaseFontColor
        縁取り.BackColor = myForm1.BaseFontBorder
        縁取り幅.Value = myForm1.BaseFontBorderWidth
        影.BackColor = myForm1.BaseFontShade
        影つける.Checked = myForm1.BaseFontShadeOn

        フォント名.Text = pFont.FontFamily.Name
        フォントサイズ.Text = pFont.Size

        noChgFlg = False

        ' この呼び出しは、Windows フォーム デザイナで必要です。


        ' InitializeComponent() 呼び出しの後で初期化を追加します。



    End Sub

    Private Sub 太字_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 太字.CheckedChanged
        If Not noChgFlg Then
            pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
            doFin()
        End If
    End Sub

    Private Sub 斜体_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 斜体.CheckedChanged
        If Not noChgFlg Then
            pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
            doFin()
        End If
    End Sub
    Private Sub 下線_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 下線.CheckedChanged
        If Not noChgFlg Then
            pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
            doFin()
        End If
    End Sub

    Private Sub 取り消し線_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 取り消し線.CheckedChanged
        If Not noChgFlg Then
            pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
            doFin()
        End If
    End Sub

    Function CalcFontStyle() As FontStyle
        CalcFontStyle = FontStyle.Regular

        If 太字.Checked Then
            CalcFontStyle += FontStyle.Bold
        End If
        If 斜体.Checked Then
            CalcFontStyle += FontStyle.Italic
        End If
        If 下線.Checked Then
            CalcFontStyle += FontStyle.Underline
        End If
        If 取り消し線.Checked Then
            CalcFontStyle += FontStyle.Strikeout
        End If
    End Function

    Function CalcFontStyle2() As FontStyle
        CalcFontStyle2 = FontStyle.Regular

        If FontDialog1.Font.Bold Then
            CalcFontStyle2 += FontStyle.Bold
        End If
        If FontDialog1.Font.Italic Then
            CalcFontStyle2 += FontStyle.Italic
        End If
        If 下線.Checked Then
            CalcFontStyle2 += FontStyle.Underline
        End If
        If 取り消し線.Checked Then
            CalcFontStyle2 += FontStyle.Strikeout
        End If
    End Function

   
    Private Sub 再描写_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 再描写.Click
        doFin()
    End Sub

    Private Sub 縁取り幅_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 縁取り幅.ValueChanged
        doFin()
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Me.alphaVal.Text = Me.TrackBar1.Value
        pFont = New Font(pFont.Name, pFont.Size, CalcFontStyle())
        doFin()
    End Sub
End Class
