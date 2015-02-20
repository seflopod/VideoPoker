''' <summary>
''' A very simplistic Deck of cards.
''' </summary>
Public Class Deck
    Dim _cards(51) As Card
    Dim _curIdx As Integer

    Public Sub New()
        Reset()
        Shuffle()
    End Sub

    ''' <summary>
    ''' (Re)Initialize the cards in the deck
    ''' </summary>
    ''' <remarks>Adds cards from 0 to the size of the deck.  Useful for standard playing deck (52 cards, 4 suits, 13 values)
    ''' but not all that useful beyound that.
    ''' </remarks>
    Public Sub Reset()
        For i As Integer = 0 To _cards.Length - 1
            _cards(i) = New Card(CType((i Mod 4) + 1, CardSuit), (i Mod 13) + 2)
        Next
        _curIdx = 0
    End Sub

    ''' <summary>
    ''' Shuffles the Deck
    ''' </summary>
    ''' <remarks>Uses a simple Fisher-Yates shuffle</remarks>
    Public Sub Shuffle()
        Dim rnd As Random = New Random()
        For i As Integer = 0 To _cards.Length - 1
            Dim randIdx As Integer = rnd.Next(i, _cards.Length)
            Dim tmp As Card = _cards(randIdx)
            _cards(randIdx) = _cards(i)
            _cards(i) = tmp
        Next
    End Sub

    ''' <summary>
    ''' Gets the next card in the deck
    ''' </summary>
    ''' <returns>A Card from the Deck</returns>
    ''' <remarks>If the next index is out of bounds, then this shuffles the deck and resets the index.
    ''' This could cause some odd behavior as regarding which cards are in the deck and should not be
    ''' used if that matters.  For instance, if a card must be returned to the deck before showing back
    ''' up, then this function is not useable due to that behavior.
    ''' </remarks>
    Public Function NextCard() As Card
        Dim ret As Card = _cards(_curIdx)
        _curIdx = _curIdx + 1
        If _curIdx = _cards.Length Then
            Shuffle()
            _curIdx = 0
        End If
        Return ret
    End Function
End Class
