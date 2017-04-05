Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class cls_Exercise

    Private _exerciseMode As cls_Question.questionType
    Private _dictionary As cls_Dictionary
    Private _QuestionSet As Hashtable

    Private _current_Index As Long
    Private _current_Type As cls_Question.questionType
    Private _current_IsReserve As Boolean

    Private _mutipleGroup As Hashtable
    Private _mutipleGroup_Keys() As Long
    Private _mutipleReserveGroup As Hashtable
    Private _mutipleReserveGroup_Keys() As Long
    Private _fillBlankGroup As Hashtable
    Private _fillBlankGroup_Keys() As Long

    Private _question_Total As Integer
    Private _question_Correct As Integer

    Private _iterator As Integer
    Private _iterator_group As Integer

    Private _exerciseQuantity As Integer
    Private _minimumExerciseQuantity As Integer

    Private _randomor As Random
    Enum LoadStatus
        Normal = 0
        Finished = 1
        Skipped = 2
    End Enum

    Public Delegate Sub PostQuestionEventHandler(ByVal index As Long, ByVal question As cls_Question, ByVal type As cls_Question.questionType, ByVal isReserve As Boolean)
    Public Event PostQuestionEvent As PostQuestionEventHandler
    Public Delegate Sub EndExerciseEventHandler()
    Public Event EndExerciseEvent As EndExerciseEventHandler

    Sub New(dictionary As cls_Dictionary)
        _mutipleGroup = New Hashtable
        _mutipleReserveGroup = New Hashtable
        _fillBlankGroup = New Hashtable
        _question_Total = 0
        _iterator = 0
        _iterator_group = 0
        _question_Correct = 0
        _minimumExerciseQuantity = 0
        _exerciseQuantity = 0
        _dictionary = dictionary
        _QuestionSet = _dictionary.QuestionSetHashTable
        _randomor = New Random(Now.Millisecond)
    End Sub
    Private Sub setMinimumExerciseQuantity(minimumExerciseQuantity As Integer)
        _minimumExerciseQuantity = minimumExerciseQuantity
        If _exerciseQuantity < _minimumExerciseQuantity Then _minimumExerciseQuantity = _exerciseQuantity
    End Sub
    Private Function randomQuestions(ByVal table As Hashtable) As Long()

        'Dim questions() As cls_Question = table.Values.Cast(Of cls_Question)().ToArray
        Dim keys() As Long = table.Keys.Cast(Of Long)().ToArray
        If table.Count <= 1 Then Return keys
        Dim rnd As Random = _randomor
        Dim target As Integer = 0
        Dim tmpK As Long
        For i = 0 To keys.Length - 1
            target = rnd.Next(keys.Length)
            If target = i Then Continue For
            tmpK = keys(target)
            keys(target) = keys(i)
            keys(i) = tmpK
        Next
        Return keys
        'table.key
    End Function
    Public Function LoadExercise(exerciseMode As cls_Question.questionType, minimumQuestion As Integer) As Boolean
        _exerciseMode = exerciseMode
        For Each key As Long In _QuestionSet.Keys
            Dim question As cls_Question = _QuestionSet.Item(key)
            If question.IsActive Then
                Select Case question.Type
                    Case cls_Question.questionType.mutipleChoice
                        If _exerciseMode = cls_Question.questionType.both Or _exerciseMode = cls_Question.questionType.mutipleChoice Then
                            _mutipleGroup.Add(key, question)

                            If question.CanReverseQuestion Then
                                _mutipleReserveGroup.Add(key, question)
                            End If
                        End If
                    Case cls_Question.questionType.fillInBlank
                        If _exerciseMode = cls_Question.questionType.both Or _exerciseMode = cls_Question.questionType.fillInBlank Then
                            _fillBlankGroup.Add(key, question)
                        End If
                    Case cls_Question.questionType.both
                        If _exerciseMode = cls_Question.questionType.both Or _exerciseMode = cls_Question.questionType.mutipleChoice Then
                            _mutipleGroup.Add(key, question)
                            If question.CanReverseQuestion Then
                                _mutipleReserveGroup.Add(key, question)
                            End If
                        End If
                        If _exerciseMode = cls_Question.questionType.both Or _exerciseMode = cls_Question.questionType.fillInBlank Then
                            _fillBlankGroup.Add(key, question)
                        End If
                End Select
            End If
        Next
        If _mutipleGroup.Count = 0 And _mutipleReserveGroup.Count = 0 And _fillBlankGroup.Count = 0 Then
            Return False
        Else
            _mutipleGroup_Keys = randomQuestions(_mutipleGroup)
            _mutipleReserveGroup_Keys = randomQuestions(_mutipleReserveGroup)
            _fillBlankGroup_Keys = randomQuestions(_fillBlankGroup)
            _exerciseQuantity = _mutipleGroup.Count + _mutipleReserveGroup.Count + _fillBlankGroup.Count
            setMinimumExerciseQuantity(minimumQuestion)
            Return True
        End If
    End Function
    Public Function Start() As Boolean
        Static Passed_Count As Integer = 0

firstGroup:
        Select Case _iterator_group
            Case 0
                Select Case Test(_mutipleGroup, cls_Question.questionType.mutipleChoice, False, _mutipleGroup_Keys)
                    Case LoadStatus.Normal
                        _iterator += 1
                        Passed_Count += 1
                    Case LoadStatus.Finished
                        _iterator = 0
                        _iterator_group += 1
                        GoTo secondGroup
                    Case LoadStatus.Skipped
                        _iterator += 1
                        GoTo firstGroup
                End Select
            Case 1
secondGroup:
                Select Case Test(_mutipleReserveGroup, cls_Question.questionType.mutipleChoice, True, _mutipleReserveGroup_Keys)
                    Case LoadStatus.Normal
                        _iterator += 1
                        Passed_Count += 1
                    Case LoadStatus.Finished
                        _iterator = 0
                        _iterator_group += 1
                        GoTo thirdGroup
                    Case LoadStatus.Skipped
                        _iterator += 1
                        GoTo secondGroup
                End Select
            Case 2
thirdGroup:
                Select Case Test(_fillBlankGroup, cls_Question.questionType.fillInBlank, False, _fillBlankGroup_Keys)
                    Case LoadStatus.Normal
                        _iterator += 1
                        Passed_Count += 1
                    Case LoadStatus.Finished
                        _iterator = 0
                        _iterator_group += 1
                        GoTo endGroup
                    Case LoadStatus.Skipped
                        _iterator += 1
                        GoTo thirdGroup
                End Select
            Case 3
endGroup:
                If Passed_Count < _minimumExerciseQuantity Then
                    _iterator = 0
                    _iterator_group = 0
                    GoTo firstGroup
                End If
                RaiseEvent EndExerciseEvent()
                Return False
        End Select
        Return True
        'Test(_mutipleGroup, cls_Question.questionType.mutipleChoice, False)
        'Test(_mutipleReserveGroup, cls_Question.questionType.mutipleChoice, True)
        'Test(_fillBlankGroup, cls_Question.questionType.fillInBlank, False)

    End Function

    Public Shared Function DeepClone(Of T)(obj As T) As T
        Using ms = New MemoryStream()
            Dim formatter = New BinaryFormatter()
            formatter.Serialize(ms, obj)
            ms.Position = 0

            DeepClone = DirectCast(formatter.Deserialize(ms), T)
            formatter = Nothing
            ms.Close()
            ms.Dispose()
        End Using
    End Function
    Private Function Test(group As Hashtable, ByVal type As cls_Question.questionType, ByVal isReserve As Boolean, ByVal randomKeys() As Long) As LoadStatus
        If group.Count = 0 Then Return LoadStatus.Finished
        If _iterator >= group.Keys.Count Then Return LoadStatus.Finished
        Dim key As Long = randomKeys(_iterator)
        Dim questionSource As cls_Question = group.Item(key)

        If type = cls_Question.questionType.mutipleChoice And isReserve = False Then
            If Not DrawLots(questionSource.RepeatProb_MutipleChoice) Then Return LoadStatus.Skipped
        ElseIf type = cls_Question.questionType.mutipleChoice And isReserve = True Then
            If Not DrawLots(questionSource.RepeatProb_MutipleChoice_reverse) Then Return LoadStatus.Skipped
        ElseIf type = cls_Question.questionType.fillInBlank Then
            If Not DrawLots(questionSource.RepeatProb_FillInBlank) Then Return LoadStatus.Skipped
        End If

        Dim question As cls_Question = DeepClone(Of cls_Question)(questionSource)
        _current_Index = key
        _current_IsReserve = isReserve
        _current_Type = type
        If type = cls_Question.questionType.mutipleChoice And isReserve = False Then
            fillChoices(question)
            RaiseEvent PostQuestionEvent(key, question, type, isReserve)
        ElseIf type = cls_Question.questionType.mutipleChoice And isReserve = True Then
            fillChoicesReserve(question)
            RaiseEvent PostQuestionEvent(key, question, type, isReserve)
        ElseIf type = cls_Question.questionType.fillInBlank Then
            RaiseEvent PostQuestionEvent(key, question, type, isReserve)
        End If
        Return LoadStatus.Normal
    End Function
    Private Sub fillChoicesReserve(ByRef question As cls_Question)
        Dim rnd As Random = _randomor
        Dim answerIndex As Integer, choiceIndex As Integer
        Dim answerStr As String = ""
        For i = 0 To question.Answers.Length - 2
            answerStr += question.Answers(i) + ", "
        Next
        answerStr += question.Answers(question.Answers.Length - 1)
        ReDim question.Answers(0)
        question.Answers(0) = question.Context
        question.Context = answerStr
        ReDim question.Choices(3)
        answerIndex = rnd.Next(question.Choices.Length)
        Console.WriteLine(answerIndex)
        question.Choices(answerIndex) = question.Answers(0)

        Dim alterChoices As New List(Of String)
        For Each key As Long In _QuestionSet.Keys
            If key <> _current_Index Then
                Dim singleQuestion As cls_Question = _QuestionSet.Item(key)
                If singleQuestion.Type = cls_Question.questionType.mutipleChoice Or singleQuestion.Type = cls_Question.questionType.both Then
                    alterChoices.Add(singleQuestion.Context)
                End If

            End If
        Next

        If alterChoices.Count <> 0 Then
            For i = 1 To 3
                choiceIndex = rnd.Next(alterChoices.Count)
                For q = 0 To 3
                    If question.Choices(q) = "" Then
                        question.Choices(q) = alterChoices(choiceIndex)
                        alterChoices.RemoveAt(choiceIndex)
                        If alterChoices.Count = 0 Then

                            Exit Sub
                        End If
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub fillChoices(ByRef question As cls_Question)
        Dim rnd As Random = _randomor
        Randomize()
        Dim index As Integer
        Dim originChoicesCount As Integer
        If question.Choices IsNot Nothing Then
            originChoicesCount = question.Choices.Length
        Else
            originChoicesCount = 0
        End If
        If originChoicesCount < 3 Then
            Dim alterChoices As New List(Of String)
            For Each key As Long In _QuestionSet.Keys
                If key <> _current_Index Then
                    Dim singleQuestion As cls_Question = _QuestionSet.Item(key)
                    For i = 0 To singleQuestion.Answers.Length - 1
                        alterChoices.Add(singleQuestion.Answers(i))
                    Next
                End If
            Next
            If alterChoices.Count > 0 Then


                For i = 1 To (3 - originChoicesCount)
                    ReDim Preserve question.Choices(originChoicesCount)
                    originChoicesCount = question.Choices.Length
                    index = rnd.Next(alterChoices.Count)
                    question.Choices(question.Choices.Length - 1) = alterChoices(index)
                    alterChoices.RemoveAt(index)
                    If alterChoices.Count = 0 Then Exit For
                Next
            End If
        End If

        Dim choices(3) As String
        index = rnd.Next(choices.Length)
        Dim answerStr As String = ""
        For i = 0 To question.Answers.Length - 2
            answerStr += question.Answers(i) + ", "
        Next
        answerStr += question.Answers(question.Answers.Length - 1)
        question.Answers(0) = answerStr
        choices(index) = answerStr
        Dim choiceCount As Integer = 0
        If question.Choices IsNot Nothing Then
            For i = 0 To question.Choices.Length - 1
                For q = i To 3
                    If choices(q) = "" Then
                        choices(q) = question.Choices(i)
                        choiceCount += 1
                        Exit For
                    End If
                Next
                If choiceCount >= 3 Then Exit For
            Next
        End If
        question.Choices = choices
    End Sub
    Public Function CorrectRate() As Double
        If _question_Total = 0 Then Return 1
        Return _question_Correct / _question_Total
    End Function
    Public Sub Delay(ByVal DelayTime As Single)
        Dim Time_Span As New cls_TimeSpan
        Time_Span.Start()
        While Int(Time_Span.Stop_Time) < DelayTime
            Application.DoEvents()
            System.Threading.Thread.Sleep(10)
        End While
        Time_Span = Nothing
    End Sub
    Public Sub Feedback(ByVal result As Boolean)
        Dim question As cls_Question = _QuestionSet.Item(_current_Index)
        _question_Total += 1
        If result Then _question_Correct += 1
        If _current_Type = cls_Question.questionType.mutipleChoice And _current_IsReserve = False Then
            If result Then
                question.RepeatProb_MutipleChoice /= 1.5
                If question.RepeatProb_MutipleChoice < 0.05 Then question.RepeatProb_MutipleChoice = 0.05
            Else
                question.RepeatProb_MutipleChoice *= 1.5
                If question.RepeatProb_MutipleChoice > 1 Then question.RepeatProb_MutipleChoice = 1
            End If
        ElseIf _current_Type = cls_Question.questionType.mutipleChoice And _current_IsReserve = True Then
            If result Then
                question.RepeatProb_MutipleChoice_reverse /= 1.5
                If question.RepeatProb_MutipleChoice_reverse < 0.05 Then question.RepeatProb_MutipleChoice_reverse = 0.05
            Else
                question.RepeatProb_MutipleChoice_reverse *= 1.5
                If question.RepeatProb_MutipleChoice_reverse > 1 Then question.RepeatProb_MutipleChoice_reverse = 1
            End If
        ElseIf _current_Type = cls_Question.questionType.fillInBlank Then
            If result Then
                question.RepeatProb_FillInBlank /= 1.5
                If question.RepeatProb_FillInBlank < 0.05 Then question.RepeatProb_FillInBlank = 0.05
            Else
                question.RepeatProb_FillInBlank *= 1.5
                If question.RepeatProb_FillInBlank > 1 Then question.RepeatProb_FillInBlank = 1
            End If
        End If
        _dictionary.AddQuestion(_current_Index, question, True)
    End Sub
    Private Function DrawLots(ByVal probability As Double) As Boolean
        Dim rand As Random = _randomor
        Dim randNum As Double = rand.NextDouble
        If randNum <= probability Then Return True
        Return False
    End Function
End Class
