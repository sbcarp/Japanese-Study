Imports System.IO
Imports System.Text

Public Class cls_FileManager
    Public Enum Path_Type
        Root = 0
        Folder = 1
        File = 2
    End Enum
    Public Function Check_File_Name(File_Name As String) As Boolean
        File_Name = Trim(File_Name)
        If File_Name = "" Then Return False
        If Left(File_Name, 1) = "." Then Return False
        If Right(File_Name, 1) = "." Then Return False
        For Each Part In Path.GetInvalidFileNameChars()
            For Each Letter In File_Name.ToCharArray
                If Part = Letter Then Return False
            Next
        Next
        Return True
    End Function
    Public Function Check_Folder_Existence(ByVal Folder_Path As String) As Boolean
        Return Directory.Exists(Folder_Path)
    End Function
    Public Function Check_File_Existence(ByVal File_Path As String) As Boolean
        Return File.Exists(File_Path)
    End Function
    Public Function Create_TXT_File(File_TXT_Path As String, Optional File_TXT_Content As String = "", Optional Mode_Is_Append As Boolean = False) As Boolean
        Dim SaveFileName As String = File_TXT_Path
        Try
            Dim myStreamWriter As StreamWriter
            'Application.StartupPath + "\1.txt"
            If Mode_Is_Append = False Then
                myStreamWriter = File.CreateText(SaveFileName)
            Else
                myStreamWriter = File.AppendText(SaveFileName)
            End If
            If File_TXT_Content <> "" Then myStreamWriter.Write(File_TXT_Content)
            myStreamWriter.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Read_TXT_File(File_TXT_Path As String, ByRef Content As String) As Boolean
        Dim ReadFileName As String = File_TXT_Path
        Try
            Dim myStreamRead As New StreamReader(ReadFileName, Encoding.Default)
            Content = myStreamRead.ReadToEnd
            myStreamRead.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Create_File(ByVal File_Path As String) As Boolean
        Try
            If Check_Folder_Existence(Get_PathOfFullPath(File_Path)) Then
                File.Create(File_Path).Dispose()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Delete_File(ByVal File_Path As String) As Boolean
        Try
            If Check_Folder_Existence(Get_PathOfFullPath(File_Path)) Then
                File.Delete(File_Path)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Create_Folder(ByVal Folder_Path As String) As Boolean
        Try
            If (Folder_Path(Folder_Path.Length - 1) <> Path.DirectorySeparatorChar) Then
                Folder_Path += Path.DirectorySeparatorChar
            End If
            Directory.CreateDirectory(Folder_Path)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Delete_Folder(ByVal aimPath As String) As Boolean
        Try
            If (aimPath(aimPath.Length - 1) <> Path.DirectorySeparatorChar) Then
                aimPath += Path.DirectorySeparatorChar
            End If
            If (Not Directory.Exists(aimPath)) Then
                Return False
            End If

            Dim fileList() As String = Directory.GetFileSystemEntries(aimPath)
            For Each FileName As String In fileList
                If (Directory.Exists(FileName)) Then
                    Delete_Folder(aimPath + Path.GetFileName(FileName))
                Else
                    File.Delete(aimPath + Path.GetFileName(FileName))
                End If
            Next
            System.IO.Directory.Delete(aimPath, True)
            Return True
        Catch ex As Exception
            'MessageBox.Show(ex.ToString())
            Return False
        End Try
    End Function
    Public Function Get_FileType(Filename As String) As String
        Dim Split_Str() As String
        Split_Str = Split(Filename, ".")
        Return Trim(Split_Str(Split_Str.Length - 1))
    End Function
    Public Function Get_PrefixOfName(Str As String) As String
        Dim Index As Long
        Index = InStrRev(Str, ".", , CompareMethod.Text)
        If Index > 0 Then
            Return Left(Str, Index - 1)
        End If
        Return ""
    End Function
    Public Function Copy_File(From_Path As String, To_Path As String, Overwrite As Boolean)
        If Check_File_Existence(From_Path) = False Then Return False
        If Check_File_Existence(To_Path) = False Then
            File.Copy(From_Path, To_Path, False)
        Else
            If Overwrite Then File.Copy(From_Path, To_Path, True)
        End If
        Return True
    End Function
    Public Function Get_NameOfPath(Path As String) As String
        Dim Position As Integer = InStrRev(Path, "\")
        Return Mid(Path, Position + 1, Path.Length - Position)
    End Function
    Public Function Get_PathOnly(Path As String) As String
        Dim Position As Integer = InStrRev(Path, "\")
        Return Mid(Path, 1, Position)
    End Function
    Public Function Get_FileTree(Root_Path As String, ByRef Files() As String) As Boolean
        Dim Folders_Tree As New TreeNode
        Get_Folders_Tree(Root_Path, Folders_Tree)
        If Folders_Tree.Nodes.Count = 0 Then Return False
        ReDim Files(Folders_Tree.Nodes.Count - 1)
        Dim Count As Long = -1
        For Each Node In Folders_Tree.Nodes
            If Node.tag = "f" Then
                Count += 1
                Files(Count) = Node.text
            End If
        Next
        ReDim Preserve Files(Count)
        Return True
    End Function
    Public Sub Get_Folders_Tree(Root_Path As String, ByRef Folders_Tree As TreeNode, Optional ByVal Scan_Subfolders As Boolean = False)
        'Folders_Tree.Nodes.Add()\
        If Root_Path = "" Then Exit Sub
        If (Root_Path(Root_Path.Length - 1) <> Path.DirectorySeparatorChar) Then
            Root_Path += Path.DirectorySeparatorChar
        End If
        Dim Foler_Names() As String, File_Names() As String
        Foler_Names = Directory.GetDirectories(Root_Path)
        For Each Folder In Foler_Names
            Folders_Tree.Nodes.Add(Get_NameOfPath(Folder)).Tag = "d"
        Next
        File_Names = Directory.GetFiles(Root_Path)
        For Each File In File_Names
            Folders_Tree.Nodes.Add(Get_NameOfPath(File)).Tag = "f"
        Next
        If Scan_Subfolders Then
            For Each Folder In Folders_Tree.Nodes
                If Folder.tag = "d" Then
                    Get_Folders_Tree(Root_Path + Folder.text + "\", Folder, Scan_Subfolders)
                End If
            Next
        End If
        Foler_Names = Nothing : File_Names = Nothing
    End Sub
    Function Get_PathOfFullPath(FullPath As String) As String
        Dim Position As Integer = InStrRev(FullPath, "\")
        Return Mid(FullPath, 1, Position)
    End Function
End Class
