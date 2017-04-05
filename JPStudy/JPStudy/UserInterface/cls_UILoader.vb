Imports System.Windows.Forms
Public Class cls_UILoader
    Private p_Window As Form

    Private label_Banner As Label
    Private button_ChangeDict As Button
    Private label_Question As Label
    Private label_Explaination As Label
    Public selectionPage As cls_SelectionPage
    Public inputPage As cls_InputPage
    Private button_NextPage As Button
    Private button_Settings As Button
    Private frmMainLogic As cls_frmMainLogic


    Sub New(ByRef targetWindow As Form, ByRef LogicCls As cls_frmMainLogic)
        frmMainLogic = LogicCls
        p_Window = targetWindow

        p_Window.Size = New Size(Screen.PrimaryScreen.Bounds.Width * 0.618, Screen.PrimaryScreen.Bounds.Height * 0.8)
        p_Window.MinimumSize = New Size(640, 640)
        p_Window.BackColor = Color.FromArgb(240, 240, 240)
        p_Window.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - p_Window.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - p_Window.Height) / 2)
    End Sub
    Public Sub ResizeAll()
        frm_Main_SizeChanged(Nothing, Nothing)
    End Sub
    Public Sub LoadStartupControls()
        AddHandler p_Window.SizeChanged, AddressOf frm_Main_SizeChanged

        label_Banner = New Label
        With label_Banner
            .BackColor = Color.LightSkyBlue
            .Text = ""
            .ForeColor = Color.FromArgb(245, 245, 245)
            .TextAlign = ContentAlignment.MiddleCenter
            .AutoSize = False
            '.AutoSize = True
            .Location = New Point(0, 0)
        End With
        p_Window.Controls.Add(label_Banner)
        LableBannerResize()

        button_ChangeDict = New Button
        AddHandler button_ChangeDict.Click, AddressOf ButtonChangeDict_Click
        With button_ChangeDict
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .BackColor = p_Window.BackColor
            .BringToFront()
            .Text = ""
            .BackgroundImageLayout = ImageLayout.Stretch
            .Size = New Size(43, 43)
            .BackgroundImage = My.Resources.big_dictionary
        End With
        p_Window.Controls.Add(button_ChangeDict)
        ButtonChangeDictResize()

        label_Question = New Label
        With label_Question
            .ForeColor = Color.FromArgb(50, 50, 50)
            .Text = ""
            '.Font = New Font("Microsoft YaHei UI", 25)
            .AutoSize = True
        End With
        p_Window.Controls.Add(label_Question)
        LabelQuestionResize()

        label_Explaination = New Label
        With label_Explaination
            .ForeColor = Color.FromArgb(128, 128, 128)
            .Text = ""
            .Font = New Font("Microsoft YaHei UI", 15)
            .AutoSize = True
        End With
        p_Window.Controls.Add(label_Explaination)
        LabelExplainationResize()

        button_NextPage = New Button
        AddHandler button_NextPage.Click, AddressOf ButtonNextPage_Click
        With button_NextPage
            .FlatStyle = FlatStyle.Flat
            .BackColor = label_Banner.BackColor
            .BringToFront()
            .Text = "Next"
            .ForeColor = Color.FromArgb(55, 55, 55)
            .AutoSizeMode = AutoSizeMode.GrowAndShrink
            .AutoSize = True
            .BackColor = Color.FromArgb(250, 250, 250)
            .FlatAppearance.BorderSize = 0
            .Visible = False
        End With
        p_Window.Controls.Add(button_NextPage)
        ButtonNextPageResize()

        button_Settings = New Button
        AddHandler button_Settings.Click, AddressOf ButtonSettings_Click
        With button_Settings
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .BackColor = p_Window.BackColor
            .BringToFront()
            .Text = ""
            .BackgroundImageLayout = ImageLayout.Stretch
            .Size = New Size(50, 50)
            .BackgroundImage = My.Resources.Gear_alter
        End With
        p_Window.Controls.Add(button_Settings)
        ButtonSettingsResize()

        selectionPage = New cls_SelectionPage(p_Window)
        AddHandler selectionPage.selectionEvent, AddressOf SelectionPage_Selection
        selectionPage.LoadSelectionsUI(label_Explaination.Location.Y + label_Explaination.Height)
        selectionPage.HideSelectionsUI()

        inputPage = New cls_InputPage(p_Window)
        AddHandler inputPage.selectionEvent, AddressOf SelectionPage_Selection
        AddHandler inputPage.moveNextEvent, AddressOf moveNextPage
        inputPage.LoadInputUI(label_Explaination.Location.Y + label_Explaination.Height)

        LoadDefaultPage()
    End Sub
    Public Sub moveNextPage()
        frmMainLogic.MoveToNextExercise(False)
    End Sub
    Public Sub LoadQuestion(ByVal context As String, ByVal Optional explaination As String = "")
        SetLableQuestionText(context)
        label_Explaination.Text = explaination
        frm_Main_SizeChanged(Nothing, Nothing)
    End Sub
    Public Sub LoadDefaultPage()
        HideInputUI()
        HideSelectionsUI()
        HideButtonNextPage()
        SetLableBannerText("Japanese Learning")
        SetLableQuestionText("Han Fang")
        SetExplainationText("Japanese 101")
        ResizeAll()
    End Sub

    Public Sub ClearAllInterface()
        HideInputUI()
        HideSelectionsUI()
        HideButtonNextPage()
        SetLableBannerText("")
        SetLableQuestionText("")
        SetExplainationText("")
    End Sub
    Public Sub ShowInputUI()
        inputPage.ShowInputUI(label_Explaination.Location.Y + label_Explaination.Height)
    End Sub
    Public Sub HideInputUI()
        inputPage.HideInputUI()
    End Sub
    Public Sub ShowSelectionsUI()
        selectionPage.ShowSelectionsUI(label_Explaination.Location.Y + label_Explaination.Height)
    End Sub
    Public Sub HideSelectionsUI()
        selectionPage.HideSelectionsUI()
        selectionPage.RestoreSelections()
    End Sub
    Private Sub LableBannerResize()
        With label_Banner
            Dim fontSizeForHeight As Integer = p_Window.Size.Height * 0.05
            Dim fontSizeForWidth As Integer = p_Window.Size.Width * 0.025
            .Font = New Font("Microsoft YaHei UI", IIf(fontSizeForHeight > fontSizeForWidth, fontSizeForWidth, fontSizeForHeight))
            .Size = New Size(p_Window.Width, .Font.Height + 16)
        End With

    End Sub
    Private Sub ButtonNextPageResize()
        With button_NextPage
            '.Location = New Point(p_Window.Width - .Width - 100, p_Window.Height - .Height - 100)
            Dim fontSizeForHeight As Integer = p_Window.Size.Height * 0.04
            Dim fontSizeForWidth As Integer = p_Window.Size.Width * 0.03
            .Font = New Font("Microsoft YaHei UI", IIf(fontSizeForHeight > fontSizeForWidth, fontSizeForWidth, fontSizeForHeight))
            .Dock = DockStyle.Bottom
            .Size = New Size(p_Window.Width, .Font.Height + 10)
        End With
    End Sub
    Private Sub ButtonChangeDictResize()
        With button_ChangeDict
            .Location = New Point(label_Banner.Width - button_ChangeDict.Width - 30, label_Banner.Height + 13)
        End With
    End Sub
    Private Sub LabelQuestionResize()
        With label_Question
            Dim fontSizeForHeight As Integer = p_Window.Height * 0.06
            Dim fontSizeForWidth As Integer = p_Window.Width * 0.06
            .Font = New Font("Microsoft YaHei UI", IIf(fontSizeForHeight > fontSizeForWidth, fontSizeForWidth, fontSizeForHeight))
            .Location = New Point(p_Window.Width / 2 - .Width / 2, label_Banner.Height + 50)
        End With
    End Sub
    Private Sub LabelExplainationResize()
        With label_Explaination
            Dim fontSizeForHeight As Integer = p_Window.Height * 0.02
            Dim fontSizeForWidth As Integer = p_Window.Width * 0.02
            .Font = New Font("Microsoft YaHei UI", IIf(fontSizeForHeight > fontSizeForWidth, fontSizeForWidth, fontSizeForHeight))
            .Location = New Point(p_Window.Width / 2 - .Width / 2, label_Question.Location.Y + label_Question.Height + 5)
        End With
    End Sub
    Private Sub ButtonSettingsResize()
        With button_Settings
            .Location = New Point(10, label_Banner.Height + 10)
        End With
    End Sub
    Public Sub SetExplainationText(text As String)
        label_Explaination.Text = text
    End Sub
    Public Sub SetLableQuestionText(text As String)
        label_Question.Text = text
    End Sub
    Public Sub SetLableBannerText(text As String)
        label_Banner.Text = text
    End Sub
    Private Sub frm_Main_SizeChanged(sender As Object, e As EventArgs)
        LableBannerResize()
        ButtonChangeDictResize()
        LabelQuestionResize()
        LabelExplainationResize()
        ButtonNextPageResize()
        ButtonSettingsResize()
        selectionPage.ButtonSelectionsResize(label_Explaination.Location.Y + label_Explaination.Height)
        inputPage.TBoxResponseResize(label_Explaination.Location.Y + label_Explaination.Height)
        inputPage.ButtonSelectionsResize()
    End Sub
    Public Sub ShowButtonNextPage()
        button_NextPage.Visible = True
    End Sub
    Public Sub HideButtonNextPage()
        button_NextPage.Visible = False
    End Sub
    Private Sub SelectionPage_Selection(isCorrect As Boolean)
        If isCorrect Then
            Delay(700)
            frmMainLogic.MoveToNextExercise(isCorrect)
        Else
            ShowButtonNextPage()
        End If
    End Sub
    Public Sub Delay(ByVal DelayTime As Single)
        Dim Time_Span As New cls_TimeSpan
        Time_Span.Start()
        While Int(Time_Span.Stop_Time) < DelayTime
            Application.DoEvents()
            System.Threading.Thread.Sleep(10)
        End While
        Time_Span = Nothing
    End Sub
    Private Sub ButtonNextPage_Click(sender As Object, e As EventArgs)
        selectionPage.RestoreSelections()
        HideButtonNextPage()
        frmMainLogic.MoveToNextExercise(False)
    End Sub
    Private Sub ButtonSettings_Click(sender As Object, e As EventArgs)
        Dim newSettingsForm As New frm_Settings
        newSettingsForm.Tag = "General"
        AddHandler newSettingsForm.LoadEvent, AddressOf frmMainLogic.StartExercise
        newSettingsForm.ShowDialog(p_Window)
        newSettingsForm.Dispose()
    End Sub

    Private Sub ButtonChangeDict_Click(sender As Object, e As EventArgs)
        Dim newSettingsForm As New frm_Settings
        newSettingsForm.Tag = "Dict"
        AddHandler newSettingsForm.LoadEvent, AddressOf frmMainLogic.StartExercise
        newSettingsForm.ShowDialog(p_Window)
        newSettingsForm.Dispose()
    End Sub
End Class
