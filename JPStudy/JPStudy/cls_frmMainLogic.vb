Public Class cls_frmMainLogic
    Private UI As cls_UILoader
    Private exercise As cls_Exercise
    Public Sub SetUICls(UICls As cls_UILoader)
        UI = UICls
    End Sub
    Public Sub Initialize()
        Try
            CreateDictFolder()
            ScanDictionaries()
        Catch ex As Exception
            MsgBox("Could not create folder for Vocabularies.")
            Application.Exit()
        End Try
        'Initialize settings component
        Dim XMLManager As cls_XMLProcessor = New cls_XMLProcessor
        XMLManager.OpenXMLFile(Application.StartupPath + "\" + "Settings.xml", True)
        Dim Content As String = ""
        XMLManager.ReadElement(Content, "General", "Mode")
        If Content = "" Then
            XMLManager.SaveElement("2", "General", "Mode")
            Settings_General_Mode = cls_Question.questionType.both
        Else
            Settings_General_Mode = CInt(Content)
        End If
    End Sub
    Public Sub StartExercise(ByVal dictionary As cls_Dictionary)
        Try
            exercise = Nothing
            RemoveHandler exercise.PostQuestionEvent, AddressOf PostQuestion
        Catch ex As Exception

        End Try
        exercise = New cls_Exercise(dictionary)
        If exercise.LoadExercise(Settings_General_Mode, 3) = False Then
            MsgBox("Load exercise faild, no enough records.")
            Exit Sub
        End If
        UI.ClearAllInterface()
        UI.ResizeAll()
        AddHandler exercise.PostQuestionEvent, AddressOf PostQuestion
        AddHandler exercise.EndExerciseEvent, AddressOf EndExercise
        UI.SetLableBannerText(dictionary.Name)
        exercise.Start()
    End Sub
    Public Sub MoveToNextExercise(feedback As Boolean)
        exercise.Feedback(feedback)
        exercise.Start()
    End Sub
    Private Sub EndExercise()
        UI.HideSelectionsUI()
        UI.HideInputUI()
        UI.HideButtonNextPage()
        UI.SetLableQuestionText(Format(exercise.CorrectRate, "0%"))
        UI.SetExplainationText("Total accuracy")
        UI.ResizeAll()
    End Sub
    Private Sub PostQuestion(ByVal index As Long, ByVal question As cls_Question, ByVal type As cls_Question.questionType, ByVal isReserve As Boolean)
        If type = cls_Question.questionType.mutipleChoice Then
            UI.selectionPage.RestoreSelections()
            UI.HideInputUI()
            UI.ShowSelectionsUI()
            UI.selectionPage.LoadAnswers(question.Choices, question.Answers(0))
            If isReserve Then
                UI.LoadQuestion(question.Context)
            Else
                UI.LoadQuestion(question.Context, question.Explaination)
            End If

        ElseIf type = cls_Question.questionType.fillInBlank Then
            UI.inputPage.RestoreInputUI()
            UI.ShowInputUI()
            UI.HideSelectionsUI()
            UI.HideButtonNextPage()
            UI.LoadQuestion(question.Context, question.Explaination)
            UI.inputPage.LoadAnswers(question.Answers)
        End If
    End Sub
End Class
