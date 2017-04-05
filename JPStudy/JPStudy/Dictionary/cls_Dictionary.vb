Imports System.Xml
Imports System.IO
Imports JPStudy.cls_Question
Imports System.Xml.Serialization
Public Class cls_Dictionary
    Private _filename As String
    Private _name As String
    Private _questionQuantity As Long
    Private _questionSetHashTable As Hashtable

    Private Const QuestionSetNodeName As String = "Vocabulary"
    Private Const QuestionNodeName_Index As String = "Index"
    Private Const QuestionNodeName_Question As String = "Question"

    Private Const QuestionNodeName_Index_Prefix As String = "Question"
    Sub New()
        QuestionSetHashTable = New Hashtable
        _questionQuantity = 0
    End Sub
    Private Sub UpdateQuestionToXMLFile(index As Long, question As cls_Question)
        Dim XMLWriter As New cls_XMLProcessor
        Dim stream As New StringWriter
        Dim serializer As New XmlSerializer(question.GetType)
        serializer.Serialize(stream, question)
        XMLWriter.OpenXMLFile(Me.Filename)
        XMLWriter.SaveElement(stream.ToString(), QuestionSetNodeName, QuestionNodeName_Index_Prefix + CStr(index))
        serializer = Nothing
        stream.Close()
        stream.Dispose()
    End Sub
    Public Sub LoadDictFromXMLFile(ByVal filename As String)
        Dim XMLReader As New cls_XMLProcessor
        Try
            XMLReader.OpenXMLFile(filename)
        Catch ex As Exception
            Throw New Exception("OpenFileException")
        End Try
        Dim dictNode As XmlNode, childNodes As XmlNodeList
        Try
            dictNode = XMLReader.GetRootNode
            Me.Name = dictNode.NamespaceURI
            Me.Filename = filename
            childNodes = dictNode.ChildNodes
            If childNodes.Count <= 0 Then Exit Sub
            childNodes = childNodes(0).ChildNodes
            For Each node As XmlNode In childNodes
                Dim questionRecord As New cls_Question
                Dim index As Long = CLng(Replace(node.Name, QuestionNodeName_Index_Prefix, ""))
                Dim question As String = node.InnerText
                Dim streamReader As New StringReader(question)
                Dim serializer As New XmlSerializer(questionRecord.GetType)
                questionRecord = serializer.Deserialize(streamReader)
                serializer = Nothing
                streamReader.Close()
                streamReader.Dispose()
                AddQuestion(index, questionRecord)
                _questionQuantity += 1
            Next
        Catch ex As Exception
            Throw New Exception("ReadDictException")
        End Try
    End Sub
    Private Sub DeleteQuestionFromXMLFile(index As Long)
        Dim XMLWriter As New cls_XMLProcessor
        XMLWriter.OpenXMLFile(Me.Filename)
        XMLWriter.DeleteElement(QuestionSetNodeName, QuestionNodeName_Index_Prefix + CStr(index))
    End Sub
    Public Sub DeleteQuestion(index As Long, Optional ByVal isSave As Boolean = False)
        QuestionSetHashTable.Remove(index)
        If isSave Then DeleteQuestionFromXMLFile(index)
    End Sub
    Public Sub AddQuestion(index As Long, question As cls_Question, Optional ByVal isSave As Boolean = False)
        If QuestionSetHashTable.ContainsKey(index) Then
            QuestionSetHashTable.Item(index) = question
        Else
            QuestionSetHashTable.Add(index, question)
        End If
        _questionQuantity += 1
        If isSave Then UpdateQuestionToXMLFile(index, question)
    End Sub
    Public Function GenerateUniqeKey() As Long
        If QuestionSetHashTable.Count = 0 Then Return 0
        Dim iter As Long = 0
        While QuestionSetHashTable.ContainsKey(iter)
            iter += 1
        End While
        Return iter
    End Function

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public ReadOnly Property QuestionQuantity As Long
        Get
            Return _questionQuantity
        End Get
    End Property

    Public Property Filename As String
        Get
            Return _filename
        End Get
        Set(value As String)
            _filename = value
        End Set
    End Property

    Public Property QuestionSetHashTable As Hashtable
        Get
            Return _questionSetHashTable
        End Get
        Set(value As Hashtable)
            _questionSetHashTable = value
        End Set
    End Property
End Class
