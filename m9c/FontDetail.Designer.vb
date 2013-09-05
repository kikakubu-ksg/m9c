<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FontDetail
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.こんな感じ = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.縁取り幅 = New System.Windows.Forms.NumericUpDown
        Me.影つける = New System.Windows.Forms.CheckBox
        Me.影 = New System.Windows.Forms.Button
        Me.縁取り = New System.Windows.Forms.Button
        Me.フォント色 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.斜体 = New System.Windows.Forms.CheckBox
        Me.太字 = New System.Windows.Forms.CheckBox
        Me.フォントサイズ = New System.Windows.Forms.Label
        Me.フォント名 = New System.Windows.Forms.Label
        Me.取り消し線 = New System.Windows.Forms.CheckBox
        Me.下線 = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.再描写 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        Me.alphaVal = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.縁取り幅, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(318, 253)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 21)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "キャンセル"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "フォント色"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "縁取り"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "影"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(141, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(54, 26)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "選択"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FontDialog1
        '
        Me.FontDialog1.ShowEffects = False
        '
        'こんな感じ
        '
        Me.こんな感じ.AutoSize = True
        Me.こんな感じ.BackColor = System.Drawing.Color.White
        Me.こんな感じ.ForeColor = System.Drawing.Color.White
        Me.こんな感じ.Location = New System.Drawing.Point(11, 15)
        Me.こんな感じ.MinimumSize = New System.Drawing.Size(420, 55)
        Me.こんな感じ.Name = "こんな感じ"
        Me.こんな感じ.Size = New System.Drawing.Size(420, 55)
        Me.こんな感じ.TabIndex = 8
        Me.こんな感じ.Text = "こんな感じ"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.alphaVal)
        Me.GroupBox1.Controls.Add(Me.TrackBar1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.縁取り幅)
        Me.GroupBox1.Controls.Add(Me.影つける)
        Me.GroupBox1.Controls.Add(Me.影)
        Me.GroupBox1.Controls.Add(Me.縁取り)
        Me.GroupBox1.Controls.Add(Me.フォント色)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 148)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "色設定"
        '
        '縁取り幅
        '
        Me.縁取り幅.Location = New System.Drawing.Point(159, 43)
        Me.縁取り幅.Name = "縁取り幅"
        Me.縁取り幅.Size = New System.Drawing.Size(36, 19)
        Me.縁取り幅.TabIndex = 14
        '
        '影つける
        '
        Me.影つける.AutoSize = True
        Me.影つける.Location = New System.Drawing.Point(137, 73)
        Me.影つける.Name = "影つける"
        Me.影つける.Size = New System.Drawing.Size(52, 16)
        Me.影つける.TabIndex = 13
        Me.影つける.Text = "つける"
        Me.影つける.UseVisualStyleBackColor = True
        '
        '影
        '
        Me.影.BackColor = System.Drawing.Color.White
        Me.影.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.影.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.影.Location = New System.Drawing.Point(88, 72)
        Me.影.Name = "影"
        Me.影.Size = New System.Drawing.Size(42, 17)
        Me.影.TabIndex = 12
        Me.影.UseVisualStyleBackColor = False
        '
        '縁取り
        '
        Me.縁取り.BackColor = System.Drawing.Color.White
        Me.縁取り.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.縁取り.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.縁取り.Location = New System.Drawing.Point(88, 44)
        Me.縁取り.Name = "縁取り"
        Me.縁取り.Size = New System.Drawing.Size(42, 17)
        Me.縁取り.TabIndex = 11
        Me.縁取り.UseVisualStyleBackColor = False
        '
        'フォント色
        '
        Me.フォント色.BackColor = System.Drawing.Color.White
        Me.フォント色.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.フォント色.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.フォント色.Location = New System.Drawing.Point(88, 18)
        Me.フォント色.Name = "フォント色"
        Me.フォント色.Size = New System.Drawing.Size(42, 17)
        Me.フォント色.TabIndex = 10
        Me.フォント色.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "幅"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.斜体)
        Me.GroupBox2.Controls.Add(Me.太字)
        Me.GroupBox2.Controls.Add(Me.フォントサイズ)
        Me.GroupBox2.Controls.Add(Me.フォント名)
        Me.GroupBox2.Controls.Add(Me.取り消し線)
        Me.GroupBox2.Controls.Add(Me.下線)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(248, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(209, 150)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "フォントタイプ"
        '
        '斜体
        '
        Me.斜体.AutoSize = True
        Me.斜体.Location = New System.Drawing.Point(85, 74)
        Me.斜体.Name = "斜体"
        Me.斜体.Size = New System.Drawing.Size(48, 16)
        Me.斜体.TabIndex = 10
        Me.斜体.Text = "斜体"
        Me.斜体.UseVisualStyleBackColor = True
        '
        '太字
        '
        Me.太字.AutoSize = True
        Me.太字.Location = New System.Drawing.Point(17, 74)
        Me.太字.Name = "太字"
        Me.太字.Size = New System.Drawing.Size(48, 16)
        Me.太字.TabIndex = 9
        Me.太字.Text = "太字"
        Me.太字.UseVisualStyleBackColor = True
        '
        'フォントサイズ
        '
        Me.フォントサイズ.AutoSize = True
        Me.フォントサイズ.Location = New System.Drawing.Point(15, 38)
        Me.フォントサイズ.Name = "フォントサイズ"
        Me.フォントサイズ.Size = New System.Drawing.Size(34, 12)
        Me.フォントサイズ.TabIndex = 8
        Me.フォントサイズ.Text = "サイズ"
        '
        'フォント名
        '
        Me.フォント名.AutoSize = True
        Me.フォント名.Location = New System.Drawing.Point(15, 19)
        Me.フォント名.Name = "フォント名"
        Me.フォント名.Size = New System.Drawing.Size(50, 12)
        Me.フォント名.TabIndex = 7
        Me.フォント名.Text = "フォント名"
        '
        '取り消し線
        '
        Me.取り消し線.AutoSize = True
        Me.取り消し線.Location = New System.Drawing.Point(85, 95)
        Me.取り消し線.Name = "取り消し線"
        Me.取り消し線.Size = New System.Drawing.Size(77, 16)
        Me.取り消し線.TabIndex = 6
        Me.取り消し線.Text = "取り消し線"
        Me.取り消し線.UseVisualStyleBackColor = True
        '
        '下線
        '
        Me.下線.AutoSize = True
        Me.下線.Location = New System.Drawing.Point(17, 94)
        Me.下線.Name = "下線"
        Me.下線.Size = New System.Drawing.Size(48, 16)
        Me.下線.TabIndex = 5
        Me.下線.Text = "下線"
        Me.下線.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.こんな感じ)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.Location = New System.Drawing.Point(12, 168)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(445, 79)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "字幕サンプル"
        '
        '再描写
        '
        Me.再描写.Location = New System.Drawing.Point(18, 256)
        Me.再描写.Name = "再描写"
        Me.再描写.Size = New System.Drawing.Size(70, 21)
        Me.再描写.TabIndex = 12
        Me.再描写.Text = "再描写"
        Me.再描写.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "非透明度"
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(75, 100)
        Me.TrackBar1.Maximum = 255
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(129, 42)
        Me.TrackBar1.TabIndex = 16
        Me.TrackBar1.TickFrequency = 10
        Me.TrackBar1.Value = 255
        '
        'alphaVal
        '
        Me.alphaVal.BackColor = System.Drawing.SystemColors.Control
        Me.alphaVal.Enabled = False
        Me.alphaVal.Location = New System.Drawing.Point(13, 123)
        Me.alphaVal.Name = "alphaVal"
        Me.alphaVal.Size = New System.Drawing.Size(39, 19)
        Me.alphaVal.TabIndex = 17
        '
        'FontDetail
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(476, 292)
        Me.Controls.Add(Me.再描写)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FontDetail"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "フォント設定"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.縁取り幅, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents こんな感じ As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents 取り消し線 As System.Windows.Forms.CheckBox
    Friend WithEvents 下線 As System.Windows.Forms.CheckBox
    Friend WithEvents 斜体 As System.Windows.Forms.CheckBox
    Friend WithEvents 太字 As System.Windows.Forms.CheckBox
    Friend WithEvents フォントサイズ As System.Windows.Forms.Label
    Friend WithEvents フォント名 As System.Windows.Forms.Label
    Friend WithEvents フォント色 As System.Windows.Forms.Button
    Friend WithEvents 影 As System.Windows.Forms.Button
    Friend WithEvents 縁取り As System.Windows.Forms.Button
    Friend WithEvents 影つける As System.Windows.Forms.CheckBox
    Friend WithEvents 再描写 As System.Windows.Forms.Button
    Friend WithEvents 縁取り幅 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents alphaVal As System.Windows.Forms.TextBox

End Class
