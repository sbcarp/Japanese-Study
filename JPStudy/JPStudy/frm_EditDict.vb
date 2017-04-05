Public Class frm_EditDict
    Private question As cls_Question
    Private dictIndex As Long, questionIndex As Long
    Private dictionary As cls_Dictionary
    Private Sub frm_EditDict_Load(sender As Object, e As EventArgs) Handles Me.Load
        dictIndex = -1
        questionIndex = -1
        question = Nothing
        If Me.Tag <> "" Then
            Dim splited() As String = Me.Tag.ToString.Split(",")
            dictIndex = CLng(splited(0))
            dictionary = Dictionaries(dictIndex)
            If splited.Length > 1 Then
                questionIndex = CLng(splited(1))
                question = Dictionaries(dictIndex).QuestionSetHashTable.Item(questionIndex)
            Else
                question = New cls_Question
            End If
        End If
    End Sub
    Private Sub LoadQuestion()
        If questionIndex = -1 Then Exit Sub
        TBox_Question.Text = question.Context
        TBox_Explain.Text = question.Explaination
        TBox_Answer.Lines = question.Answers
        TBox_Choices.Lines = question.Choices
        If question.Type = cls_Question.questionType.mutipleChoice Then
            RButton_MC.Checked = True
        ElseIf question.Type = cls_Question.questionType.fillInBlank Then
            RButton_FB.Checked = True
        ElseIf question.Type = cls_Question.questionType.both Then
            RButton_Both.Checked = True
        End If
        CBox_Reverse.Checked = question.CanReverseQuestion
    End Sub
    Private Sub SaveQuestion()
        If questionIndex = -1 Then
            question.IsActive = True
            question.RepeatProb_MutipleChoice = 1
            question.RepeatProb_MutipleChoice_reverse = 1
            question.RepeatProb_FillInBlank = 1
        End If
        question.Context = Trim(TBox_Question.Text)
        If question.Context = "" Then
            MsgBox("Must enter question context")
            Exit Sub
        End If
        question.Explaination = Trim(TBox_Explain.Text)
        Dim AnswerLines() As String = TBox_Answer.Lines
        Dim count As Integer = 0
        For i = 0 To AnswerLines.Length - 1
            AnswerLines(i) = Trim(AnswerLines(i))
            If AnswerLines(i) <> "" Then
                ReDim Preserve question.Answers(count)
                question.Answers(count) = AnswerLines(i)
                count += 1
            End If
        Next
        If count = 0 Then
            MsgBox("Must enter at least one answer")
            Exit Sub
        End If
        count = 0
        Dim ChoiceLines() As String = TBox_Choices.Lines
        For i = 0 To ChoiceLines.Length - 1
            ChoiceLines(i) = Trim(ChoiceLines(i))
            If ChoiceLines(i) <> "" Then
                ReDim Preserve question.Choices(count)
                question.Choices(count) = ChoiceLines(i)
                count += 1
            End If
        Next
        If RButton_MC.Checked Then
            question.Type = cls_Question.questionType.mutipleChoice
        ElseIf RButton_FB.Checked Then
            question.Type = cls_Question.questionType.fillInBlank
        ElseIf RButton_Both.Checked Then
            question.Type = cls_Question.questionType.both
        End If
        question.CanReverseQuestion = CBox_Reverse.Checked

        If questionIndex = -1 Then
            dictionary.AddQuestion(dictionary.GenerateUniqeKey, question, True)
        Else
            dictionary.AddQuestion(questionIndex, question, True)
        End If
        Me.Close()
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        SaveQuestion()

    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub

    Private Sub frm_EditDict_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadQuestion()
    End Sub
End Class