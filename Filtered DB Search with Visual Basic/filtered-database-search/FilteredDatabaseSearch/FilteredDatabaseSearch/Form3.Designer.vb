<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.ButtonBackForm2 = New System.Windows.Forms.Button
        Me.FieldPanel = New System.Windows.Forms.Panel
        Me.ButtonSelectAllForm3 = New System.Windows.Forms.Button
        Me.LabelDisp = New System.Windows.Forms.Label
        Me.allSelectedFields = New System.Windows.Forms.CheckedListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonResults = New System.Windows.Forms.Button
        Me.ButtonCheck = New System.Windows.Forms.Button
        Me.filesave = New System.Windows.Forms.SaveFileDialog
        Me.FieldPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonBackForm2
        '
        Me.ButtonBackForm2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonBackForm2.Location = New System.Drawing.Point(12, 568)
        Me.ButtonBackForm2.Name = "ButtonBackForm2"
        Me.ButtonBackForm2.Size = New System.Drawing.Size(92, 37)
        Me.ButtonBackForm2.TabIndex = 0
        Me.ButtonBackForm2.Text = "Back"
        Me.ButtonBackForm2.UseVisualStyleBackColor = True
        '
        'FieldPanel
        '
        Me.FieldPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FieldPanel.AutoScroll = True
        Me.FieldPanel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FieldPanel.Controls.Add(Me.ButtonSelectAllForm3)
        Me.FieldPanel.Controls.Add(Me.LabelDisp)
        Me.FieldPanel.Controls.Add(Me.allSelectedFields)
        Me.FieldPanel.Location = New System.Drawing.Point(12, 68)
        Me.FieldPanel.Name = "FieldPanel"
        Me.FieldPanel.Size = New System.Drawing.Size(1365, 471)
        Me.FieldPanel.TabIndex = 1
        '
        'ButtonSelectAllForm3
        '
        Me.ButtonSelectAllForm3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelectAllForm3.Location = New System.Drawing.Point(1189, 341)
        Me.ButtonSelectAllForm3.Name = "ButtonSelectAllForm3"
        Me.ButtonSelectAllForm3.Size = New System.Drawing.Size(92, 37)
        Me.ButtonSelectAllForm3.TabIndex = 5
        Me.ButtonSelectAllForm3.Text = "Select All"
        Me.ButtonSelectAllForm3.UseVisualStyleBackColor = True
        '
        'LabelDisp
        '
        Me.LabelDisp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LabelDisp.Location = New System.Drawing.Point(1186, 21)
        Me.LabelDisp.Name = "LabelDisp"
        Me.LabelDisp.Size = New System.Drawing.Size(173, 42)
        Me.LabelDisp.TabIndex = 1
        Me.LabelDisp.Text = "Select fields to display" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(at least one)"
        '
        'allSelectedFields
        '
        Me.allSelectedFields.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.allSelectedFields.CheckOnClick = True
        Me.allSelectedFields.FormattingEnabled = True
        Me.allSelectedFields.Location = New System.Drawing.Point(1189, 76)
        Me.allSelectedFields.Name = "allSelectedFields"
        Me.allSelectedFields.Size = New System.Drawing.Size(153, 259)
        Me.allSelectedFields.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(531, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Please insert a value for each field"
        '
        'ButtonResults
        '
        Me.ButtonResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonResults.Enabled = False
        Me.ButtonResults.Location = New System.Drawing.Point(1285, 568)
        Me.ButtonResults.Name = "ButtonResults"
        Me.ButtonResults.Size = New System.Drawing.Size(92, 37)
        Me.ButtonResults.TabIndex = 3
        Me.ButtonResults.Text = "Show Results"
        Me.ButtonResults.UseVisualStyleBackColor = True
        '
        'ButtonCheck
        '
        Me.ButtonCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonCheck.Location = New System.Drawing.Point(642, 568)
        Me.ButtonCheck.Name = "ButtonCheck"
        Me.ButtonCheck.Size = New System.Drawing.Size(92, 37)
        Me.ButtonCheck.TabIndex = 4
        Me.ButtonCheck.Text = "Check"
        Me.ButtonCheck.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1389, 626)
        Me.Controls.Add(Me.ButtonCheck)
        Me.Controls.Add(Me.ButtonResults)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FieldPanel)
        Me.Controls.Add(Me.ButtonBackForm2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(320, 23)
        Me.MinimumSize = New System.Drawing.Size(1405, 664)
        Me.Name = "Form3"
        Me.Text = "Filters selection"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.FieldPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonBackForm2 As System.Windows.Forms.Button
    Friend WithEvents FieldPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonResults As System.Windows.Forms.Button
    Friend WithEvents ButtonCheck As System.Windows.Forms.Button
    Friend WithEvents allSelectedFields As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonSelectAllForm3 As System.Windows.Forms.Button
    Friend WithEvents LabelDisp As System.Windows.Forms.Label
    Friend WithEvents filesave As System.Windows.Forms.SaveFileDialog
End Class
