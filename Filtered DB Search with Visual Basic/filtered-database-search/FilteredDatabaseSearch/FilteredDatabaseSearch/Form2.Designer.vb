<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.labelForm2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TablePanel = New System.Windows.Forms.Panel
        Me.ButtonBackForm1 = New System.Windows.Forms.Button
        Me.ButtonNextForm3 = New System.Windows.Forms.Button
        Me.ButtonSelectAllForm2 = New System.Windows.Forms.Button
        Me.ButtonDeselectAllForm2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'labelForm2
        '
        Me.labelForm2.AutoSize = True
        Me.labelForm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.labelForm2.Location = New System.Drawing.Point(26, 23)
        Me.labelForm2.Name = "labelForm2"
        Me.labelForm2.Size = New System.Drawing.Size(0, 42)
        Me.labelForm2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(492, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Please select the fields you want"
        '
        'TablePanel
        '
        Me.TablePanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TablePanel.AutoScroll = True
        Me.TablePanel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TablePanel.Location = New System.Drawing.Point(12, 68)
        Me.TablePanel.Name = "TablePanel"
        Me.TablePanel.Size = New System.Drawing.Size(1265, 471)
        Me.TablePanel.TabIndex = 2
        '
        'ButtonBackForm1
        '
        Me.ButtonBackForm1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonBackForm1.Location = New System.Drawing.Point(12, 568)
        Me.ButtonBackForm1.Name = "ButtonBackForm1"
        Me.ButtonBackForm1.Size = New System.Drawing.Size(92, 37)
        Me.ButtonBackForm1.TabIndex = 3
        Me.ButtonBackForm1.Text = "Back"
        Me.ButtonBackForm1.UseVisualStyleBackColor = True
        '
        'ButtonNextForm3
        '
        Me.ButtonNextForm3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonNextForm3.Location = New System.Drawing.Point(1185, 568)
        Me.ButtonNextForm3.Name = "ButtonNextForm3"
        Me.ButtonNextForm3.Size = New System.Drawing.Size(92, 37)
        Me.ButtonNextForm3.TabIndex = 4
        Me.ButtonNextForm3.Text = "Next"
        Me.ButtonNextForm3.UseVisualStyleBackColor = True
        '
        'ButtonSelectAllForm2
        '
        Me.ButtonSelectAllForm2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonSelectAllForm2.Location = New System.Drawing.Point(680, 568)
        Me.ButtonSelectAllForm2.Name = "ButtonSelectAllForm2"
        Me.ButtonSelectAllForm2.Size = New System.Drawing.Size(92, 37)
        Me.ButtonSelectAllForm2.TabIndex = 5
        Me.ButtonSelectAllForm2.Text = "Select All"
        Me.ButtonSelectAllForm2.UseVisualStyleBackColor = True
        '
        'ButtonDeselectAllForm2
        '
        Me.ButtonDeselectAllForm2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonDeselectAllForm2.Location = New System.Drawing.Point(496, 568)
        Me.ButtonDeselectAllForm2.Name = "ButtonDeselectAllForm2"
        Me.ButtonDeselectAllForm2.Size = New System.Drawing.Size(92, 37)
        Me.ButtonDeselectAllForm2.TabIndex = 6
        Me.ButtonDeselectAllForm2.Text = "Deselect All"
        Me.ButtonDeselectAllForm2.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1289, 626)
        Me.Controls.Add(Me.ButtonDeselectAllForm2)
        Me.Controls.Add(Me.ButtonSelectAllForm2)
        Me.Controls.Add(Me.ButtonNextForm3)
        Me.Controls.Add(Me.ButtonBackForm1)
        Me.Controls.Add(Me.TablePanel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.labelForm2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(130, 150)
        Me.MinimumSize = New System.Drawing.Size(1305, 664)
        Me.Name = "Form2"
        Me.Text = "Field Selection"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelForm2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TablePanel As System.Windows.Forms.Panel
    Friend WithEvents ButtonBackForm1 As System.Windows.Forms.Button
    Friend WithEvents ButtonNextForm3 As System.Windows.Forms.Button
    Friend WithEvents ButtonSelectAllForm2 As System.Windows.Forms.Button
    Friend WithEvents ButtonDeselectAllForm2 As System.Windows.Forms.Button
End Class
