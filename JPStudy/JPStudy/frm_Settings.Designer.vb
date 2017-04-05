<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Settings))
        Me.TabControl_Settings = New System.Windows.Forms.TabControl()
        Me.TabPage_Gen = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RButton_Both = New System.Windows.Forms.RadioButton()
        Me.RButton_FB = New System.Windows.Forms.RadioButton()
        Me.RButton_MC = New System.Windows.Forms.RadioButton()
        Me.TabPage_Voc = New System.Windows.Forms.TabPage()
        Me.SplitC_Voc = New System.Windows.Forms.SplitContainer()
        Me.Button_Load = New System.Windows.Forms.Button()
        Me.Button_DeleteDict = New System.Windows.Forms.Button()
        Me.Button_AddDict = New System.Windows.Forms.Button()
        Me.ListBox_Dict = New System.Windows.Forms.ListBox()
        Me.Button_DisableQuest = New System.Windows.Forms.Button()
        Me.Button_EnableQuest = New System.Windows.Forms.Button()
        Me.Button_DeleteQuest = New System.Windows.Forms.Button()
        Me.Button_EditQuest = New System.Windows.Forms.Button()
        Me.Button_AddQuest = New System.Windows.Forms.Button()
        Me.CListBox_Quest = New System.Windows.Forms.CheckedListBox()
        Me.TabControl_Settings.SuspendLayout()
        Me.TabPage_Gen.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage_Voc.SuspendLayout()
        Me.SplitC_Voc.Panel1.SuspendLayout()
        Me.SplitC_Voc.Panel2.SuspendLayout()
        Me.SplitC_Voc.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl_Settings
        '
        Me.TabControl_Settings.Controls.Add(Me.TabPage_Gen)
        Me.TabControl_Settings.Controls.Add(Me.TabPage_Voc)
        Me.TabControl_Settings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl_Settings.Location = New System.Drawing.Point(0, 0)
        Me.TabControl_Settings.Name = "TabControl_Settings"
        Me.TabControl_Settings.SelectedIndex = 0
        Me.TabControl_Settings.Size = New System.Drawing.Size(917, 549)
        Me.TabControl_Settings.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl_Settings.TabIndex = 0
        '
        'TabPage_Gen
        '
        Me.TabPage_Gen.Controls.Add(Me.GroupBox1)
        Me.TabPage_Gen.Location = New System.Drawing.Point(4, 25)
        Me.TabPage_Gen.Name = "TabPage_Gen"
        Me.TabPage_Gen.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Gen.Size = New System.Drawing.Size(909, 520)
        Me.TabPage_Gen.TabIndex = 0
        Me.TabPage_Gen.Text = "General"
        Me.TabPage_Gen.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RButton_Both)
        Me.GroupBox1.Controls.Add(Me.RButton_FB)
        Me.GroupBox1.Controls.Add(Me.RButton_MC)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 104)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mode"
        '
        'RButton_Both
        '
        Me.RButton_Both.AutoSize = True
        Me.RButton_Both.Location = New System.Drawing.Point(6, 74)
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
        Me.RButton_FB.Location = New System.Drawing.Point(6, 49)
        Me.RButton_FB.Name = "RButton_FB"
        Me.RButton_FB.Size = New System.Drawing.Size(164, 19)
        Me.RButton_FB.TabIndex = 1
        Me.RButton_FB.TabStop = True
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
        Me.RButton_MC.TabStop = True
        Me.RButton_MC.Text = "Mutiple Choice"
        Me.RButton_MC.UseVisualStyleBackColor = True
        '
        'TabPage_Voc
        '
        Me.TabPage_Voc.Controls.Add(Me.SplitC_Voc)
        Me.TabPage_Voc.Location = New System.Drawing.Point(4, 25)
        Me.TabPage_Voc.Name = "TabPage_Voc"
        Me.TabPage_Voc.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Voc.Size = New System.Drawing.Size(909, 520)
        Me.TabPage_Voc.TabIndex = 1
        Me.TabPage_Voc.Text = "Vocabularies"
        Me.TabPage_Voc.UseVisualStyleBackColor = True
        '
        'SplitC_Voc
        '
        Me.SplitC_Voc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitC_Voc.Location = New System.Drawing.Point(3, 3)
        Me.SplitC_Voc.Name = "SplitC_Voc"
        '
        'SplitC_Voc.Panel1
        '
        Me.SplitC_Voc.Panel1.AutoScroll = True
        Me.SplitC_Voc.Panel1.Controls.Add(Me.Button_Load)
        Me.SplitC_Voc.Panel1.Controls.Add(Me.Button_DeleteDict)
        Me.SplitC_Voc.Panel1.Controls.Add(Me.Button_AddDict)
        Me.SplitC_Voc.Panel1.Controls.Add(Me.ListBox_Dict)
        '
        'SplitC_Voc.Panel2
        '
        Me.SplitC_Voc.Panel2.AutoScroll = True
        Me.SplitC_Voc.Panel2.Controls.Add(Me.Button_DisableQuest)
        Me.SplitC_Voc.Panel2.Controls.Add(Me.Button_EnableQuest)
        Me.SplitC_Voc.Panel2.Controls.Add(Me.Button_DeleteQuest)
        Me.SplitC_Voc.Panel2.Controls.Add(Me.Button_EditQuest)
        Me.SplitC_Voc.Panel2.Controls.Add(Me.Button_AddQuest)
        Me.SplitC_Voc.Panel2.Controls.Add(Me.CListBox_Quest)
        Me.SplitC_Voc.Size = New System.Drawing.Size(903, 514)
        Me.SplitC_Voc.SplitterDistance = 234
        Me.SplitC_Voc.TabIndex = 0
        '
        'Button_Load
        '
        Me.Button_Load.Location = New System.Drawing.Point(5, 425)
        Me.Button_Load.Name = "Button_Load"
        Me.Button_Load.Size = New System.Drawing.Size(222, 39)
        Me.Button_Load.TabIndex = 4
        Me.Button_Load.Text = "Load"
        Me.Button_Load.UseVisualStyleBackColor = True
        '
        'Button_DeleteDict
        '
        Me.Button_DeleteDict.Location = New System.Drawing.Point(120, 470)
        Me.Button_DeleteDict.Name = "Button_DeleteDict"
        Me.Button_DeleteDict.Size = New System.Drawing.Size(107, 39)
        Me.Button_DeleteDict.TabIndex = 3
        Me.Button_DeleteDict.Text = "Delete"
        Me.Button_DeleteDict.UseVisualStyleBackColor = True
        '
        'Button_AddDict
        '
        Me.Button_AddDict.Location = New System.Drawing.Point(5, 470)
        Me.Button_AddDict.Name = "Button_AddDict"
        Me.Button_AddDict.Size = New System.Drawing.Size(109, 39)
        Me.Button_AddDict.TabIndex = 2
        Me.Button_AddDict.Text = "Add"
        Me.Button_AddDict.UseVisualStyleBackColor = True
        '
        'ListBox_Dict
        '
        Me.ListBox_Dict.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListBox_Dict.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListBox_Dict.FormattingEnabled = True
        Me.ListBox_Dict.ItemHeight = 20
        Me.ListBox_Dict.Location = New System.Drawing.Point(0, 0)
        Me.ListBox_Dict.Name = "ListBox_Dict"
        Me.ListBox_Dict.Size = New System.Drawing.Size(234, 404)
        Me.ListBox_Dict.TabIndex = 0
        '
        'Button_DisableQuest
        '
        Me.Button_DisableQuest.Location = New System.Drawing.Point(372, 470)
        Me.Button_DisableQuest.Name = "Button_DisableQuest"
        Me.Button_DisableQuest.Size = New System.Drawing.Size(117, 39)
        Me.Button_DisableQuest.TabIndex = 5
        Me.Button_DisableQuest.Text = "Disable"
        Me.Button_DisableQuest.UseVisualStyleBackColor = True
        '
        'Button_EnableQuest
        '
        Me.Button_EnableQuest.Location = New System.Drawing.Point(249, 470)
        Me.Button_EnableQuest.Name = "Button_EnableQuest"
        Me.Button_EnableQuest.Size = New System.Drawing.Size(117, 39)
        Me.Button_EnableQuest.TabIndex = 4
        Me.Button_EnableQuest.Text = "Enable"
        Me.Button_EnableQuest.UseVisualStyleBackColor = True
        '
        'Button_DeleteQuest
        '
        Me.Button_DeleteQuest.Location = New System.Drawing.Point(547, 470)
        Me.Button_DeleteQuest.Name = "Button_DeleteQuest"
        Me.Button_DeleteQuest.Size = New System.Drawing.Size(117, 39)
        Me.Button_DeleteQuest.TabIndex = 3
        Me.Button_DeleteQuest.Text = "Delete"
        Me.Button_DeleteQuest.UseVisualStyleBackColor = True
        '
        'Button_EditQuest
        '
        Me.Button_EditQuest.Location = New System.Drawing.Point(126, 470)
        Me.Button_EditQuest.Name = "Button_EditQuest"
        Me.Button_EditQuest.Size = New System.Drawing.Size(117, 39)
        Me.Button_EditQuest.TabIndex = 2
        Me.Button_EditQuest.Text = "Edit"
        Me.Button_EditQuest.UseVisualStyleBackColor = True
        '
        'Button_AddQuest
        '
        Me.Button_AddQuest.Location = New System.Drawing.Point(3, 470)
        Me.Button_AddQuest.Name = "Button_AddQuest"
        Me.Button_AddQuest.Size = New System.Drawing.Size(117, 39)
        Me.Button_AddQuest.TabIndex = 1
        Me.Button_AddQuest.Text = "Add"
        Me.Button_AddQuest.UseVisualStyleBackColor = True
        '
        'CListBox_Quest
        '
        Me.CListBox_Quest.Dock = System.Windows.Forms.DockStyle.Top
        Me.CListBox_Quest.FormattingEnabled = True
        Me.CListBox_Quest.Location = New System.Drawing.Point(0, 0)
        Me.CListBox_Quest.Name = "CListBox_Quest"
        Me.CListBox_Quest.Size = New System.Drawing.Size(665, 464)
        Me.CListBox_Quest.TabIndex = 0
        '
        'frm_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 549)
        Me.Controls.Add(Me.TabControl_Settings)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Settings"
        Me.Opacity = 0.8R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TabControl_Settings.ResumeLayout(False)
        Me.TabPage_Gen.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage_Voc.ResumeLayout(False)
        Me.SplitC_Voc.Panel1.ResumeLayout(False)
        Me.SplitC_Voc.Panel2.ResumeLayout(False)
        Me.SplitC_Voc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl_Settings As TabControl
    Friend WithEvents TabPage_Gen As TabPage
    Friend WithEvents TabPage_Voc As TabPage
    Friend WithEvents SplitC_Voc As SplitContainer
    Friend WithEvents Button_DeleteQuest As Button
    Friend WithEvents Button_EditQuest As Button
    Friend WithEvents Button_AddQuest As Button
    Friend WithEvents CListBox_Quest As CheckedListBox
    Friend WithEvents Button_DisableQuest As Button
    Friend WithEvents Button_EnableQuest As Button
    Friend WithEvents Button_DeleteDict As Button
    Friend WithEvents Button_AddDict As Button
    Friend WithEvents ListBox_Dict As ListBox
    Friend WithEvents Button_Load As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RButton_Both As RadioButton
    Friend WithEvents RButton_FB As RadioButton
    Friend WithEvents RButton_MC As RadioButton
End Class
