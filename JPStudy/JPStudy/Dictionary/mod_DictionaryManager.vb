Imports JPStudy

Module mod_DictionaryManager
    Private _dictionaries As New List(Of cls_Dictionary)
    Private fileManager As New cls_FileManager

    Public Property Dictionaries As List(Of cls_Dictionary)
        Get
            Return _dictionaries
        End Get
        Set(value As List(Of cls_Dictionary))
            _dictionaries = value
        End Set
    End Property

    Public Sub CreateDictFolder()
        Try
            If fileManager.Check_Folder_Existence(Application.StartupPath + "\Dictionaries") = False Then
                fileManager.Create_Folder(Application.StartupPath + "\Dictionaries")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function CreateDict(dictName As String) As Boolean
        Dim XMLWriter As New cls_XMLProcessor
        Dim filename As String = ReplaceBadCharOfFileName(dictName, "_")
        Try
            XMLWriter.OpenXMLFile(Application.StartupPath + "\Dictionaries\" + filename + ".xml", True)
            XMLWriter.CreateRootNode("root", dictName)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Function DeleteDict(filename As String) As Boolean
        Try
            fileManager.Delete_File(filename)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GetDictList(ByRef dicts As List(Of cls_Dictionary)) As Boolean
        If ScanDictionaries() Then
            dicts = Dictionaries
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ScanDictionaries() As Boolean
        Dim dictFiles() As String = Nothing
        Dictionaries.Clear()
        If fileManager.Get_FileTree(Application.StartupPath + "\Dictionaries", dictFiles) Then
            If dictFiles IsNot Nothing Then
                For Each filename As String In dictFiles
                    Dim dict As New cls_Dictionary
                    dict.LoadDictFromXMLFile(Application.StartupPath + "\Dictionaries" + "\" + filename)
                    Dictionaries.Add(dict)
                Next
            Else
                Return False
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Private Function ReplaceBadCharOfFileName(fileName As String, Optional ByVal replaceWith As String = "") As String
        Dim str As String = fileName
        str = str.Replace("\", replaceWith)
        str = str.Replace("/", replaceWith)
        str = str.Replace(":", replaceWith)
        str = str.Replace("*", replaceWith)
        str = str.Replace("?", replaceWith)
        str = str.Replace("""", replaceWith)
        str = str.Replace("<", replaceWith)
        str = str.Replace(">", replaceWith)
        str = str.Replace("|", replaceWith)
        str = str.Replace(" ", replaceWith)
        Return str
    End Function
End Module
