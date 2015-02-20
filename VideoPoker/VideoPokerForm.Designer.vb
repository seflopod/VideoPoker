<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoPokerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VideoPokerForm))
        Me.btnDrawCards = New System.Windows.Forms.Button()
        Me.cbxBet = New System.Windows.Forms.ComboBox()
        Me.lblBet = New System.Windows.Forms.Label()
        Me.lblCreditsRemaining = New System.Windows.Forms.Label()
        Me.lblCredits = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CardControl5 = New VideoPoker.CardControl()
        Me.CardControl4 = New VideoPoker.CardControl()
        Me.CardControl3 = New VideoPoker.CardControl()
        Me.CardControl2 = New VideoPoker.CardControl()
        Me.CardControl1 = New VideoPoker.CardControl()
        Me.lblLastHand = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDrawCards
        '
        Me.btnDrawCards.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDrawCards.Location = New System.Drawing.Point(36, 591)
        Me.btnDrawCards.Name = "btnDrawCards"
        Me.btnDrawCards.Size = New System.Drawing.Size(188, 47)
        Me.btnDrawCards.TabIndex = 10
        Me.btnDrawCards.Text = "Start Game"
        Me.btnDrawCards.UseVisualStyleBackColor = True
        '
        'cbxBet
        '
        Me.cbxBet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxBet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxBet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBet.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxBet.FormattingEnabled = True
        Me.cbxBet.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cbxBet.Location = New System.Drawing.Point(302, 589)
        Me.cbxBet.Name = "cbxBet"
        Me.cbxBet.Size = New System.Drawing.Size(58, 33)
        Me.cbxBet.TabIndex = 16
        '
        'lblBet
        '
        Me.lblBet.AutoSize = True
        Me.lblBet.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBet.Location = New System.Drawing.Point(251, 591)
        Me.lblBet.Name = "lblBet"
        Me.lblBet.Size = New System.Drawing.Size(45, 26)
        Me.lblBet.TabIndex = 17
        Me.lblBet.Text = "Bet"
        Me.lblBet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCreditsRemaining
        '
        Me.lblCreditsRemaining.AutoSize = True
        Me.lblCreditsRemaining.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditsRemaining.Location = New System.Drawing.Point(383, 591)
        Me.lblCreditsRemaining.Name = "lblCreditsRemaining"
        Me.lblCreditsRemaining.Size = New System.Drawing.Size(87, 26)
        Me.lblCreditsRemaining.TabIndex = 18
        Me.lblCreditsRemaining.Text = "Credits:"
        Me.lblCreditsRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCredits
        '
        Me.lblCredits.AutoSize = True
        Me.lblCredits.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredits.Location = New System.Drawing.Point(476, 591)
        Me.lblCredits.Name = "lblCredits"
        Me.lblCredits.Size = New System.Drawing.Size(0, 26)
        Me.lblCredits.TabIndex = 19
        Me.lblCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(46, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(507, 452)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'CardControl5
        '
        Me.CardControl5.Location = New System.Drawing.Point(476, 481)
        Me.CardControl5.Name = "CardControl5"
        Me.CardControl5.Size = New System.Drawing.Size(104, 104)
        Me.CardControl5.TabIndex = 15
        Me.CardControl5.Visible = False
        '
        'CardControl4
        '
        Me.CardControl4.Location = New System.Drawing.Point(366, 481)
        Me.CardControl4.Name = "CardControl4"
        Me.CardControl4.Size = New System.Drawing.Size(104, 104)
        Me.CardControl4.TabIndex = 14
        Me.CardControl4.Visible = False
        '
        'CardControl3
        '
        Me.CardControl3.Location = New System.Drawing.Point(256, 481)
        Me.CardControl3.Name = "CardControl3"
        Me.CardControl3.Size = New System.Drawing.Size(104, 104)
        Me.CardControl3.TabIndex = 13
        Me.CardControl3.Visible = False
        '
        'CardControl2
        '
        Me.CardControl2.Location = New System.Drawing.Point(146, 481)
        Me.CardControl2.Name = "CardControl2"
        Me.CardControl2.Size = New System.Drawing.Size(104, 104)
        Me.CardControl2.TabIndex = 12
        Me.CardControl2.Visible = False
        '
        'CardControl1
        '
        Me.CardControl1.Location = New System.Drawing.Point(36, 481)
        Me.CardControl1.Name = "CardControl1"
        Me.CardControl1.Size = New System.Drawing.Size(104, 104)
        Me.CardControl1.TabIndex = 11
        Me.CardControl1.Visible = False
        '
        'lblLastHand
        '
        Me.lblLastHand.AutoSize = True
        Me.lblLastHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastHand.Location = New System.Drawing.Point(31, 641)
        Me.lblLastHand.Name = "lblLastHand"
        Me.lblLastHand.Size = New System.Drawing.Size(120, 26)
        Me.lblLastHand.TabIndex = 21
        Me.lblLastHand.Text = "Last Hand"
        '
        'VideoPokerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 687)
        Me.Controls.Add(Me.lblLastHand)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblCredits)
        Me.Controls.Add(Me.lblCreditsRemaining)
        Me.Controls.Add(Me.lblBet)
        Me.Controls.Add(Me.cbxBet)
        Me.Controls.Add(Me.CardControl5)
        Me.Controls.Add(Me.CardControl4)
        Me.Controls.Add(Me.CardControl3)
        Me.Controls.Add(Me.CardControl2)
        Me.Controls.Add(Me.CardControl1)
        Me.Controls.Add(Me.btnDrawCards)
        Me.Name = "VideoPokerForm"
        Me.Text = "Video Poker"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDrawCards As System.Windows.Forms.Button
    Friend WithEvents CardControl1 As VideoPoker.CardControl
    Friend WithEvents CardControl2 As VideoPoker.CardControl
    Friend WithEvents CardControl3 As VideoPoker.CardControl
    Friend WithEvents CardControl4 As VideoPoker.CardControl
    Friend WithEvents CardControl5 As VideoPoker.CardControl
    Friend WithEvents cbxBet As System.Windows.Forms.ComboBox
    Friend WithEvents lblBet As System.Windows.Forms.Label
    Friend WithEvents lblCreditsRemaining As System.Windows.Forms.Label
    Friend WithEvents lblCredits As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblLastHand As System.Windows.Forms.Label

End Class
