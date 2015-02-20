Public Class VideoPokerForm
    Private _manager As VideoPokerManager
    Dim _cardControls(4) As CardControl
    Dim _drawButton As Button
    Dim _creditsDisplay As Label
    Dim _betBox As ComboBox
    Private _phase As GamePhase

    Private Sub VideoPokerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _manager = New VideoPokerManager()
        _phase = GamePhase.GameOver

        'Grab all of the controls we'll use.
        For Each c As Control In Controls
            If c.Name.StartsWith("CardControl") Then
                Dim potentialCard As CardControl = TryCast(c, CardControl)
                If potentialCard IsNot Nothing Then
                    Dim idx As Integer = Asc(potentialCard.Name.Substring(potentialCard.Name.Length - 1)) - 49
                    _cardControls(idx) = potentialCard
                End If
            ElseIf c.Name.Equals("btnDrawCards", StringComparison.OrdinalIgnoreCase) Then
                _drawButton = TryCast(c, Button)
            ElseIf c.Name.Equals("lblCredits", StringComparison.OrdinalIgnoreCase) Then
                _creditsDisplay = TryCast(c, Label)
            ElseIf c.Name.Equals("cbxBet", StringComparison.OrdinalIgnoreCase) Then
                _betBox = TryCast(c, ComboBox)
            End If
        Next
        UpdateDisplays()
    End Sub

    Private Sub UpdateDisplays()
        Select Case _phase
            Case GamePhase.GameOver
                For i As Integer = 0 To _cardControls.Length - 1
                    _cardControls(i).Visible = False
                Next
                _drawButton.Text = "Start Game"
            Case GamePhase.AfterDeal
                _drawButton.Text = "Draw Cards"
                UpdateCardDisplays()
                UpdateCreditsDisplay()
            Case GamePhase.AfterDraw
                _drawButton.Text = "Draw New Hand"
                UpdateCardDisplays()
                UpdateCreditsDisplay()
        End Select
    End Sub

    Private Sub UpdateCardDisplays()
        For i As Integer = 0 To _cardControls.Length - 1
            _cardControls(i).ChangeLabel(_manager.CurrentHand(i).ToString())
            _cardControls(i).UnClickButton()
            _cardControls(i).Visible = True
        Next
    End Sub

    Private Sub UpdateCreditsDisplay()
        _creditsDisplay.Text = _manager.CreditsRemaining.ToString()
    End Sub

    Private Sub btnDrawCards_Click(sender As Object, e As EventArgs) Handles btnDrawCards.Click
        Select Case _phase
            Case GamePhase.GameOver
                _manager.Initialize(100)
                _betBox.SelectedIndex = 0
                NewDraw()
            Case GamePhase.AfterDeal
                For i As Integer = 0 To _cardControls.Length - 1
                    If Not _cardControls(i).Clicked Then
                        _manager.DrawCardForIndex(i)
                    End If
                Next
                Dim handName As String = _manager.GetHandName()

                _manager.CreditsRemaining = _manager.CreditsRemaining + _manager.GetPayout(handName)

                If _manager.CreditsRemaining <= 0 Then
                    _phase = GamePhase.GameOver
                Else
                    _phase = GamePhase.AfterDraw
                End If
            Case GamePhase.AfterDraw
                NewDraw()
        End Select

        UpdateDisplays()
    End Sub

    Private Sub NewDraw()
        If _manager.CanBet(_betBox.SelectedIndex + 1) Then
            _manager.PlaceBet(_betBox.SelectedIndex + 1)
            _manager.DrawNewHand()
            _phase = GamePhase.AfterDeal
        Else
            System.Media.SystemSounds.Asterisk.Play()
        End If
    End Sub
End Class
