<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.ButtonNext = New System.Windows.Forms.Button
        Me.ButtonBrowse = New System.Windows.Forms.Button
        Me.TextPath = New System.Windows.Forms.TextBox
        Me.ButtonConnect = New System.Windows.Forms.Button
        Me.ButoonClearAll = New System.Windows.Forms.Button
        Me.ButtonClear = New System.Windows.Forms.Button
        Me.ButtonSelectAll = New System.Windows.Forms.Button
        Me.ButtonDeselectAll = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Give the path to your database" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(22, 182)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(344, 334)
        Me.CheckedListBox1.TabIndex = 3
        '
        'ButtonNext
        '
        Me.ButtonNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonNext.Enabled = False
        Me.ButtonNext.Location = New System.Drawing.Point(382, 481)
        Me.ButtonNext.Name = "ButtonNext"
        Me.ButtonNext.Size = New System.Drawing.Size(92, 37)
        Me.ButtonNext.TabIndex = 4
        Me.ButtonNext.Text = "Next"
        Me.ButtonNext.UseVisualStyleBackColor = True
        '
        'ButtonBrowse
        '
        Me.ButtonBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonBrowse.Location = New System.Drawing.Point(382, 97)
        Me.ButtonBrowse.Name = "ButtonBrowse"
        Me.ButtonBrowse.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBrowse.TabIndex = 5
        Me.ButtonBrowse.Text = "Browse"
        Me.ButtonBrowse.UseVisualStyleBackColor = True
        '
        'TextPath
        '
        Me.TextPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextPath.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextPath.Location = New System.Drawing.Point(22, 97)
        Me.TextPath.Name = "TextPath"
        Me.TextPath.Size = New System.Drawing.Size(344, 20)
        Me.TextPath.TabIndex = 7
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Location = New System.Drawing.Point(22, 135)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(75, 23)
        Me.ButtonConnect.TabIndex = 8
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'ButoonClearAll
        '
        Me.ButoonClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButoonClearAll.Location = New System.Drawing.Point(22, 540)
        Me.ButoonClearAll.Name = "ButoonClearAll"
        Me.ButoonClearAll.Size = New System.Drawing.Size(75, 23)
        Me.ButoonClearAll.TabIndex = 9
        Me.ButoonClearAll.Text = "Clear All"
        Me.ButoonClearAll.UseVisualStyleBackColor = True
        '
        'ButtonClear
        '
        Me.ButtonClear.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtonClear.Location = New System.Drawing.Point(156, 135)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClear.TabIndex = 10
        Me.ButtonClear.Text = "Clear"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonSelectAll
        '
        Me.ButtonSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelectAll.Location = New System.Drawing.Point(291, 540)
        Me.ButtonSelectAll.Name = "ButtonSelectAll"
        Me.ButtonSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSelectAll.TabIndex = 12
        Me.ButtonSelectAll.Text = "Select All"
        Me.ButtonSelectAll.UseVisualStyleBackColor = True
        '
        'ButtonDeselectAll
        '
        Me.ButtonDeselectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonDeselectAll.Location = New System.Drawing.Point(156, 540)
        Me.ButtonDeselectAll.Name = "ButtonDeselectAll"
        Me.ButtonDeselectAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDeselectAll.TabIndex = 13
        Me.ButtonDeselectAll.Text = "Deselect All"
        Me.ButtonDeselectAll.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 596)
        Me.Controls.Add(Me.ButtonDeselectAll)
        Me.Controls.Add(Me.ButtonSelectAll)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.ButoonClearAll)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Controls.Add(Me.TextPath)
        Me.Controls.Add(Me.ButtonBrowse)
        Me.Controls.Add(Me.ButtonNext)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(675, 634)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database and Tables Selection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonNext As System.Windows.Forms.Button
    Friend WithEvents ButtonBrowse As System.Windows.Forms.Button
    Friend WithEvents TextPath As System.Windows.Forms.TextBox
    Friend WithEvents ButtonConnect As System.Windows.Forms.Button
    Friend WithEvents ButoonClearAll As System.Windows.Forms.Button
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents ButtonSelectAll As System.Windows.Forms.Button
    Friend WithEvents ButtonDeselectAll As System.Windows.Forms.Button

End Class
