Public Class cls_SelectionPage
    Private p_Window As Form

    Private button_Selections(3) As Button
    Private correctSelection As String
    Private afterSelection As Boolean = False
    Private hidedSelection As Boolean = False

    Public Delegate Sub selectionEventHandler(ByVal isCorrect As Boolean)
    Public Event selectionEvent As selectionEventHandler
    Sub New(ByRef targetWindow As Form)
        p_Window = targetWindow
        'AddHandler selectionEvent, AddressOf Selection
    End Sub
    Public Sub LoadSelectionsUI(ReferenceY As Integer)
        For i = 0 To button_Selections.Length - 1
            button_Selections(i) = New Button
            With button_Selections(i)
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .FlatAppearance.BorderColor = Color.FromArgb(128, 128, 128)
                .BackColor = Color.FromArgb(250, 250, 250)
                .Font = New Font("Microsoft YaHei UI", p_Window.Width * 0.02)
                .ForeColor = Color.FromArgb(85, 85, 85)
                .FlatAppearance.MouseDownBackColor = Color.FromArgb(188, 188, 188)
                .Text = " "
                .Tag = i
                .MinimumSize = New Size(p_Window.Width * 0.455, 67)
                .AutoSizeMode = AutoSizeMode.GrowAndShrink
                .AutoSize = True
                AddHandler .Click, AddressOf Selection_Click
            End With
            p_Window.Controls.Add(button_Selections(i))
        Next
        ButtonSelectionsResize(ReferenceY)
    End Sub
    Public Sub HideSelectionsUI()
        hidedSelection = True
        For i = 0 To button_Selections.Length - 1
            With button_Selections(i)
                .Visible = False
            End With
        Next
    End Sub
    Public Sub ShowSelectionsUI(ReferenceY As Integer)
        hidedSelection = False
        ButtonSelectionsResize(ReferenceY)
        For i = 0 To button_Selections.Length - 1
            With button_Selections(i)
                .Visible = True
            End With
        Next
    End Sub
    Public Sub LoadAnswers(answers() As String, correctSelection As String)
        afterSelection = False
        Me.correctSelection = correctSelection
        For i = 0 To button_Selections.Length - 1
            With button_Selections(i)
                .Text = answers(i)
            End With
        Next
    End Sub
    Public Sub ButtonSelectionsResize(ReferenceY As Integer)
        If hidedSelection Then Exit Sub
        Dim fontSizeForHeight As Integer = p_Window.Height * 0.02
        Dim fontSizeForWidth As Integer = p_Window.Width * 0.04
        For i = 0 To button_Selections.Length - 1
            button_Selections(i).Font = New Font("Microsoft YaHei UI", IIf(fontSizeForHeight > fontSizeForWidth, fontSizeForWidth, fontSizeForHeight))
            button_Selections(i).MinimumSize = New Size(p_Window.Width * 0.455, button_Selections(i).Font.Height + 40)
        Next
        button_Selections(0).Location = New Point(p_Window.Width / 2 - button_Selections(0).Width / 2, ReferenceY + 40)
        For i = 1 To button_Selections.Length - 1
            button_Selections(i).Location = New Point(p_Window.Width / 2 - button_Selections(i).Width / 2, button_Selections(i - 1).Location.Y + button_Selections(i - 1).Height + 30) '(p_Window.Height / 10) ^ 2 * 0.0035)
        Next
    End Sub
    Public Sub RestoreSelections()
        For i = 0 To button_Selections.Length - 1
            With button_Selections(i)
                .BackColor = Color.FromArgb(250, 250, 250)
                .ForeColor = Color.FromArgb(85, 85, 85)
            End With
        Next
    End Sub
    Private Sub Selection_Click(sender As Object, e As EventArgs)
        If afterSelection = False Then
            Dim selectedStr As String = Trim(sender.text)
            Dim selected As Integer = sender.tag
            correctSelection = Trim(correctSelection)
            If selectedStr = correctSelection Then
                For i = 0 To button_Selections.Length - 1
                    If button_Selections(i).Text = selectedStr Then
                        button_Selections(i).BackColor = Color.FromArgb(54, 189, 102)
                        button_Selections(i).ForeColor = Color.FromArgb(250, 250, 250)
                    End If
                Next
            Else
                For i = 0 To button_Selections.Length - 1
                    If button_Selections(i).Text = correctSelection Then
                        button_Selections(i).BackColor = Color.FromArgb(54, 189, 102)
                        button_Selections(i).ForeColor = Color.FromArgb(250, 250, 250)
                    End If
                Next
                button_Selections(selected).BackColor = Color.FromArgb(237, 98, 71)
            End If
            button_Selections(selected).ForeColor = Color.FromArgb(250, 250, 250)

            afterSelection = True
            RaiseEvent selectionEvent(selectedStr = correctSelection)

        End If


    End Sub

    Private Sub Selection(isCorrect As Boolean)

    End Sub
End Class
