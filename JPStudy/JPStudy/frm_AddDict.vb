Public Class frm_AddDict
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = Trim(TextBox1.Text)
        If CreateDict(TextBox1.Text) = False Then
            MsgBox("Faild to create vocabulary book.")
        End If
        Me.Close()
    End Sub
End Class