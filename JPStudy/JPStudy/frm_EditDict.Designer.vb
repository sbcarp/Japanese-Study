<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_EditDict
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_EditDict))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TBox_Answer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBox_Question = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBox_Explain = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBox_Choices = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RButton_Both = New System.Windows.Forms.RadioButton()
        Me.RButton_FB = New System.Windows.Forms.RadioButton()
        Me.RButton_MC = New System.Windows.Forms.RadioButton()
        Me.CBox_Reverse = New System.Windows.Forms.CheckBox()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.27284!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 596.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TBox_Answer, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TBox_Question, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TBox_Explain, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TBox_Choices, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CBox_Reverse, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_Save, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_Cancel, 0, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(745, 556)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 390)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Reverse Mode"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(55, 332)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Type"
        '
        'TBox_Answer
        '
        Me.TBox_Answer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TBox_Answer.Location = New System.Drawing.Point(152, 82)
        Me.TBox_Answer.Multiline = True
        Me.TBox_Answer.Name = "TBox_Answer"
        Me.TBox_Answer.Size = New System.Drawing.Size(590, 87)
        Me.TBox_Answer.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "* Answer"
        '
        'TBox_Question
        '
        Me.TBox_Question.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TBox_Question.Location = New System.Drawing.Point(152, 6)
        Me.TBox_Question.Name = "TBox_Question"
        Me.TBox_Question.Size = New System.Drawing.Size(590, 25)
        Me.TBox_Question.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "* Question"
        '
        'TBox_Explain
        '
        Me.TBox_Explain.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TBox_Explain.Location = New System.Drawing.Point(152, 45)
        Me.TBox_Explain.Name = "TBox_Explain"
        Me.TBox_Explain.Size = New System.Drawing.Size(590, 25)
        Me.TBox_Explain.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Explaination"
        '
        'TBox_Choices
        '
        Me.TBox_Choices.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TBox_Choices.Location = New System.Drawing.Point(152, 179)
        Me.TBox_Choices.Multiline = True
        Me.TBox_Choices.Name = "TBox_Choices"
        Me.TBox_Choices.Size = New System.Drawing.Size(590, 125)
        Me.TBox_Choices.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Choices"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RButton_Both)
        Me.GroupBox1.Controls.Add(Me.RButton_FB)
        Me.GroupBox1.Controls.Add(Me.RButton_MC)
        Me.GroupBox1.Location = New System.Drawing.Point(152, 312)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(590, 56)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'RButton_Both
        '
        Me.RButton_Both.AutoSize = True
        Me.RButton_Both.Checked = True
        Me.RButton_Both.Location = New System.Drawing.Point(457, 24)
        Me.RButton_Both.Name = "RButton_Both"
        Me.RButton_Both.Size = New System.Drawing.Size(60, 19)
        Me.RButton_Both.TabIndex = 2
        Me.RButton_Both.TabStop = True
        Me.RButton_Both.Text = "Both"
        Me.RButton_Both.UseVisualStyleBackColor = True
        '
        'RButton_FB
        '
        Me.RButton_FB.AutoSize = True
        Me.RButton_FB.Location = New System.Drawing.Point(223, 24)
        Me.RButton_FB.Name = "RButton_FB"
        Me.RButton_FB.Size = New System.Drawing.Size(164, 19)
        Me.RButton_FB.TabIndex = 1
        Me.RButton_FB.Text = "Fill in the blank"
        Me.RButton_FB.UseVisualStyleBackColor = True
        '
        'RButton_MC
        '
        Me.RButton_MC.AutoSize = True
        Me.RButton_MC.Location = New System.Drawing.Point(6, 24)
        Me.RButton_MC.Name = "RButton_MC"
        Me.RButton_MC.Size = New System.Drawing.Size(140, 19)
        Me.RButton_MC.TabIndex = 0
        Me.RButton_MC.Text = "Mutiple Choice"
        Me.RButton_MC.UseVisualStyleBackColor = True
        '
        'CBox_Reverse
        '
        Me.CBox_Reverse.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CBox_Reverse.AutoSize = True
        Me.CBox_Reverse.Checked = True
        Me.CBox_Reverse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBox_Reverse.Location = New System.Drawing.Point(204, 388)
        Me.CBox_Reverse.Name = "CBox_Reverse"
        Me.CBox_Reverse.Size = New System.Drawing.Size(485, 19)
        Me.CBox_Reverse.TabIndex = 11
        Me.CBox_Reverse.Text = "The question can be reversed if it is mutiple choice type"
        Me.CBox_Reverse.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        Me.Button_Save.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_Save.Location = New System.Drawing.Point(237, 456)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(419, 69)
        Me.Button_Save.TabIndex = 12
        Me.Button_Save.Text = "Save"
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_Cancel.Location = New System.Drawing.Point(35, 456)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(79, 68)
        Me.Button_Cancel.TabIndex = 13
        Me.Button_Cancel.Text = "Cancel"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'frm_EditDict
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 556)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_EditDict"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_EditDict"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TBox_Answer As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TBox_Question As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TBox_Explain As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TBox_Choices As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RButton_Both As RadioButton
    Friend WithEvents RButton_FB As RadioButton
    Friend WithEvents RButton_MC As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents CBox_Reverse As CheckBox
    Friend WithEvents Button_Save As Button
    Friend WithEvents Button_Cancel As Button
End Class
