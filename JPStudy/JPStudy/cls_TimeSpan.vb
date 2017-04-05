Public Class cls_TimeSpan
    Private Declare Function QueryPerformanceCounter Lib "Kernel32" (ByRef Time_Stamp As Long) As Boolean
    Private Declare Function QueryPerformanceFrequency Lib "kernel32" (ByRef lpFrequency As Long) As Long
    Dim Clock_Frequency As Long, Time_Old As Long, Time_New As Long
    Sub New()
        QueryPerformanceFrequency(Clock_Frequency)
    End Sub
    Public Function Get_Time() As Long
        Dim Tmp_Time As Long
        QueryPerformanceCounter(Tmp_Time)
        Return Tmp_Time
    End Function
    Public Sub Start()
        QueryPerformanceCounter(Time_Old)
    End Sub
    Public Function ReStart() As Long
        QueryPerformanceCounter(Time_New)
        ReStart = (Time_New - Time_Old) / Clock_Frequency * 1000
        Start()
    End Function
    Public Function Stop_Time() As Long
        QueryPerformanceCounter(Time_New)
        Stop_Time = (Time_New - Time_Old) / Clock_Frequency * 1000
    End Function
End Class
