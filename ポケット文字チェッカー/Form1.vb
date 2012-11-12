Public Class Form1

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        TextBox1.Clear()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        TextBox1.Paste()
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Dim rect = Screen.PrimaryScreen.WorkingArea
        Me.Top = rect.Height - Height
        Me.Left = Windows.Forms.Cursor.Position.X - Width

        Me.Visible = True
        Me.Activate()
    End Sub

    Private Sub Form1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Visible = False
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Visible = False
        'settings.Save()
    End Sub

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me.Size = settings.Instance.size
        TextBox1.Font = settings.Instance.font.ToFont
    End Sub
End Class
