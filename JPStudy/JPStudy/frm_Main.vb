Imports JPStudy

Public Class frm_Main
    Private _UILoader As cls_UILoader
    Private _frmMainLogic As cls_frmMainLogic
    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _frmMainLogic = New cls_frmMainLogic
        _UILoader = New cls_UILoader(Me, _frmMainLogic)
        _frmMainLogic.SetUICls(_UILoader)
        _UILoader.LoadStartupControls()
        _frmMainLogic.Initialize()
    End Sub

    Private Sub frm_Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
