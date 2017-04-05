Imports System.Xml
Public Class cls_XMLProcessor
    Private XMLProcessor As XmlDocument
    Private FileManager As cls_FileManager
    Private XMLFilename As String
    'Private Structure WritingXMLBufferStructure
    '    Dim Content As String
    '    Dim NodeName As String
    '    Dim ElementName As String
    'End Structure
    Private Const BufferingTime As Integer = 3000
    Public Delegate Function BufferedSaveElementInvokerType(ByVal Content As String, ByVal NodeName As String, ByVal ElementName As String)
    Public BufferedSaveElementInvoker As BufferedSaveElementInvokerType
    Sub New()
        FileManager = New cls_FileManager
        XMLProcessor = New XmlDocument
        BufferedSaveElementInvoker = New BufferedSaveElementInvokerType(AddressOf BufferedSaveElement)
    End Sub
    Public Function BufferedSaveElement(ByVal Content As String, ByVal NodeName As String, ByVal ElementName As String) As Integer
        '=========Need more safety way to process asynchronous calling
        Static IsBuffering As Boolean = False
        Static BufferContent As String = ""
        BufferContent = Content
        If IsBuffering Then Return -7
        IsBuffering = True
        Console.WriteLine("Start Buffering")
        Delay(BufferingTime)
        Try
            BufferedSaveElement = SaveElement(BufferContent, NodeName, ElementName)
        Catch ex As Exception
            Throw
        End Try
        IsBuffering = False
    End Function
    Public Function OpenXMLFile(ByVal Filename As String, Optional Create As Boolean = False) As Integer
        Try
            XMLFilename = Filename
            If FileManager.Check_File_Existence(Filename) Then

                XMLProcessor.Load(Filename)
                Return 0
            ElseIf Create = True Then
                If FileManager.Create_File(Filename) = False Then
                    Throw New System.IO.IOException
                Else
                    Return 0
                End If
            Else
                Throw New System.IO.FileNotFoundException
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ReadElement(ByRef Content As String, ByVal NodeName As String, ByVal ElementName As String) As Integer
        Dim RootNode As XmlNode = XMLProcessor.DocumentElement
        Dim Node As XmlNode, Element As XmlNode
        If RootNode Is Nothing Then Return -9
        Node = RootNode.SelectSingleNode("//" + NodeName)
        If Node Is Nothing Then Return -5
        Element = Node.SelectSingleNode(ElementName)
        If Element Is Nothing Then Return -6
        Content = Element.InnerText.ToString
        Return 0
    End Function
    Public Function GetRootNode() As XmlNode
        Return XMLProcessor.DocumentElement
    End Function
    Public Function DeleteElement(ByVal NodeName As String, ByVal ElementName As String) As Integer
        Try
            Dim RootNode As XmlNode = XMLProcessor.DocumentElement
            Dim Node As XmlNode, Element As XmlNode
            If RootNode Is Nothing Then Return -9
            Node = RootNode.SelectSingleNode("//" + NodeName)
            If Node Is Nothing Then Return -5
            Element = Node.SelectSingleNode(ElementName)
            If Element Is Nothing Then Return -6
            'Element.RemoveAll()
            Node.RemoveChild(Element)
            XMLProcessor.Save(XMLFilename)
            Return 0
        Catch ex As System.IO.IOException
            Throw
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub CreateRootNode(rootName As String, URI As String)
        Try
            Dim InitialNode As XmlNode = XMLProcessor.CreateElement("", rootName, URI)
            XMLProcessor.AppendChild(InitialNode)
            XMLProcessor.Save(XMLFilename)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function SaveElement(ByVal Content As String, ByVal NodeName As String, ByVal ElementName As String, ByVal Optional localName As String = "root", ByVal Optional saveNow As Boolean = True) As Integer
        Try
            If XMLProcessor.HasChildNodes = False Then
                Dim InitialNode As XmlNode = XMLProcessor.CreateElement("", localName, "")
                XMLProcessor.AppendChild(InitialNode)
            End If
            Dim RootNode As XmlNode = XMLProcessor.DocumentElement
            Dim Node As XmlNode, Element As XmlNode

            Node = RootNode.SelectSingleNode("//" + NodeName)
            If Node Is Nothing Then
                Dim FatherNode As XmlNode
                FatherNode = XMLProcessor.CreateNode(XmlNodeType.Element, NodeName, Nothing)
                Node = RootNode.AppendChild(FatherNode)
            End If
            Element = Node.SelectSingleNode(ElementName)
            If Element Is Nothing Then
                Dim ChileNode As XmlNode
                ChileNode = XMLProcessor.CreateNode(XmlNodeType.Element, ElementName, Nothing)
                Element = Node.AppendChild(ChileNode)
            End If
            Element.InnerText = Content
            If saveNow Then XMLProcessor.Save(XMLFilename)
            Return 0
        Catch ex As System.IO.IOException
            Throw
        Catch ex As Exception
            Throw
        End Try
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
End Class
