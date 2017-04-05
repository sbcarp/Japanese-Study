Public Class cls_InputPage
    Private p_Window As Form

    Private button_Confirm As Button
    Private tBox_Response As TextBox
    Private answers() As String

    Private hidedInput As Boolean = False
    Private afterSelection As Boolean = False

    Private _answers() As String
    Public Delegate Sub selectionEventHandler(ByVal isCorrect As Boolean)
    Public Event selectionEvent As selectionEventHandler

    Private disable_Button_Confirm As Boolean = False
    Public Delegate Sub moveNextEventHandler()
    Public Event moveNextEvent As moveNextEventHandler
    Sub New(ByRef targetWindow As Form)
        p_Window = targetWindow
        'AddHandler selectionEvent, AddressOf Selection
    End Sub
    Public Sub HideInputUI()
        hidedInput = True
        button_Confirm.Visible = False
        tBox_Response.Visible = False
    End Sub
    Public Sub RestoreInputUI()
        With button_Confirm
            .BackColor = Color.FromArgb(250, 250, 250)
            .ForeColor = Color.FromArgb(64, 64, 64)
            .Text = "Confirm"
        End With
        tBox_Response.Text = ""

    End Sub
    Public Sub LoadAnswers(answers() As String)
        afterSelection = False
        disable_Button_Confirm = False
        _answers = answers
    End Sub
    Public Sub ShowInputUI(ReferenceY As Integer)
        hidedInput = False
        TBoxResponseResize(ReferenceY)
        ButtonSelectionsResize()
        button_Confirm.Visible = True
        tBox_Response.Visible = True
        tBox_Response.Focus()
    End Sub
    Private Sub tBox_Response_Keypress(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            button_Confirm.PerformClick()
        End If
    End Sub
    Public Sub LoadInputUI(ReferenceY As Integer)
        tBox_Response = New TextBox
        AddHandler tBox_Response.KeyDown, AddressOf tBox_Response_Keypress
        With tBox_Response
            .Multiline = False
            .TextAlign = HorizontalAlignment.Center
        End With
        p_Window.Controls.Add(tBox_Response)
        TBoxResponseResize(ReferenceY)

        button_Confirm = New Button
        AddHandler button_Confirm.Click, AddressOf button_Confirm_Click
        With button_Confirm
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.BorderColor = Color.FromArgb(128, 128, 128)
            .BackColor = Color.FromArgb(250, 250, 250)
            .Font = New Font("Microsoft YaHei UI", p_Window.Width * 0.02)
            .ForeColor = Color.FromArgb(64, 64, 64)
            .FlatAppearance.MouseDownBackColor = Color.FromArgb(188, 188, 188)
            .Text = "Confirm"

            '.MinimumSize = New Size(p_Window.Width * 0.455, 67)
            .AutoSizeMode = AutoSizeMode.GrowAndShrink
            .AutoSize = False
        End With
        p_Window.Controls.Add(button_Confirm)
        ButtonSelectionsResize()

        tBox_Response.Focus()
    End Sub
    Private Sub button_Confirm_Click(sender As Object, e As EventArgs)
        If afterSelection = True And disable_Button_Confirm = False Then
            RaiseEvent moveNextEvent()
            Exit Sub
        End If
        afterSelection = True
        Dim selectedStr As String = sender.text
        Dim selected As Integer = sender.tag
        With button_Confirm
            For Each answer As String In _answers
                If Trim(answer) = Trim(tBox_Response.Text) Then
                    .BackColor = Color.FromArgb(54, 189, 102)
                    .ForeColor = Color.FromArgb(250, 250, 250)
                    .Text = "Correct!"
                    disable_Button_Confirm = True
                    RaiseEvent selectionEvent(True)
                    Exit Sub
                End If
            Next
            .BackColor = Color.FromArgb(237, 98, 71)
            .ForeColor = Color.FromArgb(250, 250, 250)
            .Text = _answers(0)
            RaiseEvent selectionEvent(False)

        End With

    End Sub

    Public Sub TBoxResponseResize(ReferenceY As Integer)
        If hidedInput Then Exit Sub
        With tBox_Response
            Dim fontSizeForHeight As Integer = p_Window.Height * 0.19
            Dim fontSizeForWidth As Integer = p_Window.Width * 0.028
            .Width = p_Window.Width * 0.5
            .Font = New Font("Microsoft YaHei UI", IIf(fontSizeForHeight > fontSizeForWidth, fontSizeForWidth, fontSizeForHeight))
            .Location = New Point(p_Window.Width / 2 - tBox_Response.Width / 2, ReferenceY + p_Window.Height * 0.08)
        End With
    End Sub
    Public Sub ButtonSelectionsResize()
        If hidedInput Then Exit Sub
        With button_Confirm
            Dim fontSizeForHeight As Integer = p_Window.Height * 0.08
            Dim fontSizeForWidth As Integer = p_Window.Width * 0.023
            .Width = tBox_Response.Width
            .Height = tBox_Response.Height
            .Font = New Font("Microsoft YaHei UI", IIf(fontSizeForHeight > fontSizeForWidth, fontSizeForWidth, fontSizeForHeight))
            .Location = New Point(p_Window.Width / 2 - button_Confirm.Width / 2, tBox_Response.Location.Y + tBox_Response.Height + 20)
        End With
    End Sub
End Class
