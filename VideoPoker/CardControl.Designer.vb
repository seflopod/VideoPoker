<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.lblCard = New System.Windows.Forms.Label()
        Me.btnCard = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCard
        '
        Me.lblCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCard.Location = New System.Drawing.Point(4, 4)
        Me.lblCard.Margin = New System.Windows.Forms.Padding(4)
        Me.lblCard.Name = "lblCard"
        Me.lblCard.Size = New System.Drawing.Size(96, 64)
        Me.lblCard.TabIndex = 0
        Me.lblCard.Text = "0W"
        Me.lblCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCard
        '
        Me.btnCard.BackColor = System.Drawing.Color.Lime
        Me.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCard.Location = New System.Drawing.Point(4, 76)
        Me.btnCard.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCard.Name = "btnCard"
        Me.btnCard.Size = New System.Drawing.Size(96, 24)
        Me.btnCard.TabIndex = 1
        Me.btnCard.UseVisualStyleBackColor = False
        '
        'CardControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCard)
        Me.Controls.Add(Me.lblCard)
        Me.Name = "CardControl"
        Me.Size = New System.Drawing.Size(104, 104)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCard As System.Windows.Forms.Label
    Friend WithEvents btnCard As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource

End Class
