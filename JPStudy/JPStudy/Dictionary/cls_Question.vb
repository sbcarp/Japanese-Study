<Serializable()> Public Class cls_Question
    Public Enum questionType
        mutipleChoice = 0
        fillInBlank = 1
        both = 2
    End Enum
    Private _context As String
    Private _explaination As String
    Private _answers() As String
    Private _mutipleChoiceQuantity As Short
    Private _choices() As String
    Private _type As questionType
    Private _canReverseQuestion As Boolean
    Private _isActive As Boolean

    Private _repeatProb_MutipleChoice As Double
    Private _repeatProb_MutipleChoice_reverse As Double
    Private _repeatProb_FillInBlank As Double

    Sub New()

    End Sub

    Public Property Context As String
        Get
            Return _context
        End Get
        Set(value As String)
            _context = value
        End Set
    End Property

    Public Property Explaination As String
        Get
            Return _explaination
        End Get
        Set(value As String)
            _explaination = value
        End Set
    End Property

    Public Property Answers As String()
        Get
            Return _answers
        End Get
        Set(value As String())
            _answers = value
        End Set
    End Property

    Public Property MutipleChoiceQuantity As Short
        Get
            Return _mutipleChoiceQuantity
        End Get
        Set(value As Short)
            _mutipleChoiceQuantity = value
        End Set
    End Property

    Public Property Choices As String()
        Get
            Return _choices
        End Get
        Set(value As String())
            _choices = value
        End Set
    End Property

    Public Property Type As questionType
        Get
            Return _type
        End Get
        Set(value As questionType)
            _type = value
        End Set
    End Property

    Public Property CanReverseQuestion As Boolean
        Get
            Return _canReverseQuestion
        End Get
        Set(value As Boolean)
            _canReverseQuestion = value
        End Set
    End Property



    Public Property IsActive As Boolean
        Get
            Return _isActive
        End Get
        Set(value As Boolean)
            _isActive = value
        End Set
    End Property

    Public Property RepeatProb_MutipleChoice As Double
        Get
            Return _repeatProb_MutipleChoice
        End Get
        Set(value As Double)
            _repeatProb_MutipleChoice = value
        End Set
    End Property

    Public Property RepeatProb_MutipleChoice_reverse As Double
        Get
            Return _repeatProb_MutipleChoice_reverse
        End Get
        Set(value As Double)
            _repeatProb_MutipleChoice_reverse = value
        End Set
    End Property

    Public Property RepeatProb_FillInBlank As Double
        Get
            Return _repeatProb_FillInBlank
        End Get
        Set(value As Double)
            _repeatProb_FillInBlank = value
        End Set
    End Property
End Class
