Public Class VideoPokerForm
    Private _manager As VideoPokerManager
    Dim _cardControls(4) As CardControl
    Dim _drawButton As Button
    Private _phase As HandPhase

    Private Sub VideoPokerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _manager = New VideoPokerManager()
        _manager.Initialize(100)
        _phase = HandPhase.AfterDeal
        'Grab all of the controls we'll use.
        For Each c As Control In Controls
            If c.Name.StartsWith("CardControl") Then
                Dim potentialCard As CardControl = TryCast(c, CardControl)
                If potentialCard IsNot Nothing Then
                    Dim idx As Integer = Asc(potentialCard.Name.Substring(potentialCard.Name.Length - 1)) - 49
                    System.Console.WriteLine(idx & ": " & potentialCard.Name)
                    _cardControls(idx) = potentialCard
                End If
            ElseIf c.Name.Equals("btnDrawCards", StringComparison.OrdinalIgnoreCase) Then
                _drawButton = TryCast(c, Button)
            End If
        Next

        UpdateCardDisplays()

    End Sub

    Private Sub UpdateCardDisplays()
        For i As Integer = 0 To _cardControls.Length - 1
            _cardControls(i).ChangeLabel(_manager.CurrentHand(i).ToString())
            _cardControls(i).UnClickButton()
        Next

        If _phase = HandPhase.AfterDeal Then
            _drawButton.Text = "Draw Cards"
        Else
            _drawButton.Text = "Draw New Hand"
        End If
    End Sub

    Private Sub btnDrawCards_Click(sender As Object, e As EventArgs) Handles btnDrawCards.Click
        If _phase = HandPhase.AfterDeal Then
            For i As Integer = 0 To _cardControls.Length - 1
                If Not _cardControls(i).Clicked Then
                    System.Console.WriteLine("Draw " & _cardControls(i).Name & " (index: " & i & " value: " & _cardControls(i).lblCard.Text & ")")
                    _manager.DrawCardForIndex(i)
                Else
                    System.Console.WriteLine("Keep " & _cardControls(i).Name & " (index: " & i & ")")

                End If
            Next
            _phase = HandPhase.AfterDraw
        Else
            _manager.DrawNewHand()
            _phase = HandPhase.AfterDeal
        End If
        UpdateCardDisplays()
        System.Console.WriteLine(_manager.GetHandName())
    End Sub
End Class
