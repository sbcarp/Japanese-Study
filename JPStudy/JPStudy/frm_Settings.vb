Public Class frm_Settings
    Private dictionaries As List(Of cls_Dictionary)
    Public Delegate Sub LoadEventHandler(ByVal dictionary As cls_Dictionary)

    Public Event LoadEvent As LoadEventHandler


    Private Sub Button_AddQuest_Click(sender As Object, e As EventArgs) Handles Button_AddQuest.Click
        If ListBox_Dict.SelectedIndex >= 0 Then
            Dim newEditWindow As Form
            newEditWindow = New frm_EditDict
            newEditWindow.Tag = CStr(ListBox_Dict.SelectedIndex)
            newEditWindow.ShowDialog(Me)
            newEditWindow.Dispose()
            refreshQuestions()
        End If
    End Sub

    Private Sub frm_Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.Tag = "General" Then
            TabControl_Settings.SelectTab("TabPage_Gen")
        ElseIf Me.Tag = "Dict" Then
            TabControl_Settings.SelectTab("TabPage_Voc")

        End If
    End Sub

    Private Sub CListBox_Quest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CListBox_Quest.SelectedIndexChanged

    End Sub

    Private Sub TabControl_Settings_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl_Settings.Selected
        If e.TabPage.Name = "TabPage_Voc" Then

        End If
    End Sub

    Private Sub frm_Settings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Select Case Settings_General_Mode
            Case cls_Question.questionType.mutipleChoice
                RButton_MC.Checked = True
            Case cls_Question.questionType.fillInBlank
                RButton_FB.Checked = True
            Case cls_Question.questionType.both
                RButton_Both.Checked = True
        End Select

        refreshDicts()
        If ListBox_Dict.Items.Count > 0 Then
            ListBox_Dict.SelectedIndex = 0
        End If
    End Sub
    Private Sub refreshDicts()
        Try
            ListBox_Dict.Items.Clear()
            If GetDictList(dictionaries) Then
                For Each dict As cls_Dictionary In dictionaries
                    ListBox_Dict.Items.Add(dict.Name)
                Next
            End If
        Catch ex As Exception
            MsgBox("Faild to scan vocabulary folder.")
        End Try

    End Sub
    Private Sub refreshQuestions()
        CListBox_Quest.Items.Clear()
        If ListBox_Dict.SelectedIndex >= 0 Then
            If dictionaries(ListBox_Dict.SelectedIndex).QuestionSetHashTable.Count <> 0 Then
                Dim index As Long = 0, count As Long = 0
                While count < dictionaries(ListBox_Dict.SelectedIndex).QuestionSetHashTable.Count
                    If dictionaries(ListBox_Dict.SelectedIndex).QuestionSetHashTable.ContainsKey(index) Then
                        Dim question As cls_Question = dictionaries(ListBox_Dict.SelectedIndex).QuestionSetHashTable.Item(index)
                        CListBox_Quest.Items.Add(CStr(index) + IIf(question.IsActive, "", vbTab + "[Disabled]") + vbTab + question.Context + vbTab + vbTab + vbTab + question.Answers(0))
                        count += 1
                    End If
                    index += 1
                End While
            End If
        End If
    End Sub
    Private Sub ListBox_Dict_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Dict.SelectedIndexChanged
        refreshQuestions()
    End Sub

    Private Sub Button_AddDict_Click(sender As Object, e As EventArgs) Handles Button_AddDict.Click
        Dim newAddDictForm As Form = New frm_AddDict
        newAddDictForm.ShowDialog(Me)
        newAddDictForm.Dispose()
        refreshDicts()
    End Sub

    Private Sub Button_Load_Click(sender As Object, e As EventArgs) Handles Button_Load.Click
        If ListBox_Dict.SelectedIndex >= 0 Then
            RaiseEvent LoadEvent(dictionaries(ListBox_Dict.SelectedIndex))
            Me.Close()
        End If
    End Sub

    Private Sub Button_EditQuest_Click(sender As Object, e As EventArgs) Handles Button_EditQuest.Click
        If ListBox_Dict.SelectedIndex >= 0 And CListBox_Quest.SelectedIndex >= 0 Then
            Dim uniqeIndexStr() As String = CListBox_Quest.Items(CListBox_Quest.SelectedIndex).ToString.Split(vbTab)
            Dim commandArg As String = ListBox_Dict.SelectedIndex & "," & uniqeIndexStr(0)
            Dim newEditWindow As Form
            newEditWindow = New frm_EditDict
            newEditWindow.Tag = commandArg
            newEditWindow.ShowDialog(Me)
            newEditWindow.Dispose()
            refreshQuestions()
        End If
    End Sub

    Private Sub Button_DeleteQuest_Click(sender As Object, e As EventArgs) Handles Button_DeleteQuest.Click
        If ListBox_Dict.SelectedIndex >= 0 Then
            If CListBox_Quest.CheckedItems.Count > 0 Then
                For Each item As String In CListBox_Quest.CheckedItems
                    Dim uniqeIndexStr() As String = item.Split(vbTab)
                    Dim uniqeIndex As Long = CLng(uniqeIndexStr(0))
                    dictionaries(ListBox_Dict.SelectedIndex).DeleteQuestion(uniqeIndex, True)
                Next
                refreshQuestions()
            ElseIf CListBox_Quest.SelectedIndex >= 0 Then
                Dim uniqeIndexStr() As String = CListBox_Quest.Items(CListBox_Quest.SelectedIndex).ToString.Split(vbTab)
                Dim uniqeIndex As Long = CLng(uniqeIndexStr(0))
                dictionaries(ListBox_Dict.SelectedIndex).DeleteQuestion(uniqeIndex, True)
                refreshQuestions()
            End If
        End If
    End Sub

    Private Sub Button_EnableQuest_Click(sender As Object, e As EventArgs) Handles Button_EnableQuest.Click
        If ListBox_Dict.SelectedIndex >= 0 Then
            If CListBox_Quest.CheckedItems.Count > 0 Then
                For Each item As String In CListBox_Quest.CheckedItems
                    Dim uniqeIndexStr() As String = item.Split(vbTab)
                    Dim uniqeIndex As Long = CLng(uniqeIndexStr(0))
                    Dim question As cls_Question = dictionaries(ListBox_Dict.SelectedIndex).QuestionSetHashTable.Item(uniqeIndex)
                    question.IsActive = True
                    dictionaries(ListBox_Dict.SelectedIndex).AddQuestion(uniqeIndex, question, True)
                Next
                refreshQuestions()
            ElseIf CListBox_Quest.SelectedIndex >= 0 Then
                Dim uniqeIndexStr() As String = CListBox_Quest.Items(CListBox_Quest.SelectedIndex).ToString.Split(vbTab)
                Dim uniqeIndex As Long = CLng(uniqeIndexStr(0))
                Dim question As cls_Question = dictionaries(ListBox_Dict.SelectedIndex).QuestionSetHashTable.Item(uniqeIndex)
                question.IsActive = True
                dictionaries(ListBox_Dict.SelectedIndex).AddQuestion(uniqeIndex, question, True)
                refreshQuestions()
            End If
        End If
    End Sub

    Private Sub Button_DisableQuest_Click(sender As Object, e As EventArgs) Handles Button_DisableQuest.Click
        If ListBox_Dict.SelectedIndex >= 0 Then
            If CListBox_Quest.CheckedItems.Count > 0 Then
                For Each item As String In CListBox_Quest.CheckedItems
                    Dim uniqeIndexStr() As String = item.Split(vbTab)
                    Dim uniqeIndex As Long = CLng(uniqeIndexStr(0))
                    Dim question As cls_Question = dictionaries(ListBox_Dict.SelectedIndex).QuestionSetHashTable.Item(uniqeIndex)
                    question.IsActive = False
                    dictionaries(ListBox_Dict.SelectedIndex).AddQuestion(uniqeIndex, question, True)
                Next
                refreshQuestions()
            ElseIf CListBox_Quest.SelectedIndex >= 0 Then
                Dim uniqeIndexStr() As String = CListBox_Quest.Items(CListBox_Quest.SelectedIndex).ToString.Split(vbTab)
                Dim uniqeIndex As Long = CLng(uniqeIndexStr(0))
                Dim question As cls_Question = dictionaries(ListBox_Dict.SelectedIndex).QuestionSetHashTable.Item(uniqeIndex)
                question.IsActive = False
                dictionaries(ListBox_Dict.SelectedIndex).AddQuestion(uniqeIndex, question, True)
                refreshQuestions()
            End If
        End If
    End Sub

    Private Sub Button_DeleteDict_Click(sender As Object, e As EventArgs) Handles Button_DeleteDict.Click
        Dim index As Long = ListBox_Dict.SelectedIndex
        If index >= 0 Then
            DeleteDict(dictionaries(index).Filename)
        End If
        refreshDicts()
        CListBox_Quest.Items.Clear()
        If ListBox_Dict.Items.Count > 0 Then
            If index > 0 Then index -= 1
            ListBox_Dict.SelectedIndex = index
        Else
            ListBox_Dict.Items.Clear()
        End If
    End Sub
    Private Sub SaveModeChange()
        Dim XMLManager As cls_XMLProcessor = New cls_XMLProcessor
        XMLManager.OpenXMLFile(Application.StartupPath + "\" + "Settings.xml", True)
        If RButton_MC.Checked Then
            XMLManager.SaveElement("0", "General", "Mode")
            Settings_General_Mode = cls_Question.questionType.mutipleChoice
        ElseIf RButton_FB.Checked Then
            XMLManager.SaveElement("1", "General", "Mode")
            Settings_General_Mode = cls_Question.questionType.fillInBlank
        ElseIf RButton_Both.Checked Then
            XMLManager.SaveElement("2", "General", "Mode")
            Settings_General_Mode = cls_Question.questionType.both
        End If

    End Sub

    Private Sub RButton_MC_Click(sender As Object, e As EventArgs) Handles RButton_MC.Click
        SaveModeChange()
    End Sub



    Private Sub RButton_FB_Click(sender As Object, e As EventArgs) Handles RButton_FB.Click
        SaveModeChange()
    End Sub



    Private Sub RButton_Both_Click(sender As Object, e As EventArgs) Handles RButton_Both.Click
        SaveModeChange()
    End Sub

    Private Sub RButton_MC_CheckedChanged(sender As Object, e As EventArgs) Handles RButton_MC.CheckedChanged

    End Sub
End Class