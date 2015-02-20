Imports System.Collections.Generic

Public Enum GamePhase
    GameOver
    AfterDeal
    AfterDraw
End Enum

Public Class VideoPokerManager
    Private Delegate Function HandCheckFunc(ByRef sortedCards As Card()) As Boolean
    Private _handCheckingFunctions = New Dictionary(Of String, HandCheckFunc) From {
        {"Jacks or Better", AddressOf HasJacksOrBetter},
        {"Two Pair", AddressOf HasTwoPair},
        {"Three of a Kind", AddressOf HasTrips},
        {"Straight", AddressOf HasStraight},
        {"Flush", AddressOf HasFlush},
        {"Full House", AddressOf HasFullHouse},
        {"Straight Flush", AddressOf HasStraightFlush},
        {"Four of a Kind 5-K", AddressOf HasFourOfAKind5K},
        {"Four of a Kind 2-4", AddressOf HasFourOfAKind24},
        {"Four of a Kind A", AddressOf HasFourOfAKindA},
        {"Royal Flush", AddressOf HasRoyalFlush}
    }

    Private _basePayouts = New Dictionary(Of String, Integer) From {
        {"Nothing", 0},
        {"Jacks or Better", 1},
        {"Two Pair", 1},
        {"Three of a Kind", 3},
        {"Straight", 5},
        {"Flush", 7},
        {"Full House", 10},
        {"Straight Flush", 50},
        {"Four of a Kind 5-K", 50},
        {"Four of a Kind 2-4", 80},
        {"Four of a Kind A", 160},
        {"Royal Flush", 250}
    }

    Private _deck As Deck
    Private _hand(4) As Card
    Private _creditsBet As Integer
    Private _creditsRemaining As Integer
    Private _isInitialized As Boolean = False

    Public ReadOnly Property CurrentHand As Card()
        Get
            Return _hand
        End Get
    End Property

    Public Property IsInitialized As Boolean
        Get
            Return _isInitialized
        End Get
        Private Set(value As Boolean)
            _isInitialized = value
        End Set
    End Property

    Public Property CreditsRemaining As Integer
        Get
            Return _creditsRemaining
        End Get
        Set(value As Integer)
            If value >= 0 Then
                _creditsRemaining = value
            End If
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub Initialize(startCredits As Integer)
        _deck = New Deck()
        _creditsRemaining = startCredits
        DrawNewHand()
        IsInitialized = True
    End Sub

    Public Sub DrawCardForIndex(idx As Integer)
        If idx < 0 Or idx > 4 Then
            Return
        End If

        Dim prev As String = _hand(idx).ToString()
        _hand(idx) = _deck.NextCard()
    End Sub

    Public Sub DrawNewHand()
        For i As Integer = 0 To _hand.Length - 1
            _hand(i) = _deck.NextCard()
        Next
    End Sub

    Public Sub PlaceBet(bet As Integer)
        If bet < 1 Or bet > 5 Then
            _creditsBet = 1
        Else
            _creditsBet = bet
        End If
        _creditsRemaining = _creditsRemaining - _creditsBet
    End Sub

    Public Function CanBet(bet As Integer)
        Return bet <= _creditsRemaining And bet > 0 And bet <= 5
    End Function

    Public Function GetHandName() As String
        Dim ret As String = "Nothing"
        Dim cards(4) As Card
        Array.Copy(_hand, cards, 5)
        Array.Sort(cards)
        For Each kvp As KeyValuePair(Of String, HandCheckFunc) In _handCheckingFunctions
            If kvp.Value(cards) Then
                ret = kvp.Key
                Exit For
            End If
        Next
        Return ret
    End Function

    Public Function GetPayout(handName As String) As Integer
        Dim ret As Integer = 0
        If handName = "Royal Flush" And _creditsBet = 5 Then
            ret = 800 * _creditsBet
        Else
            ret = _creditsBet * _basePayouts(handName)
        End If
        Return ret
    End Function

#Region "Hand checking functions"
    Private Function HasJacksOrBetter(ByRef sortedCards As Card()) As Boolean
        For i As Integer = 11 To 14
            Dim checkVal As Integer = i
            Dim cards() As Card = Array.FindAll(sortedCards, Function(x) x.Value = checkVal)
            If cards.Length >= 2 Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function HasTrips(ByRef sortedCards As Card()) As Boolean
        For i As Integer = 2 To 14
            Dim checkVal As Integer = i
            Dim cards() As Card = Array.FindAll(sortedCards, Function(x) x.Value = checkVal)
            If cards.Length >= 3 Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function HasFourOfAKind5K(ByRef sortedCards As Card()) As Boolean
        For i As Integer = 5 To 13
            Dim checkVal As Integer = i
            Dim cards() As Card = Array.FindAll(sortedCards, Function(x) x.Value = checkVal)
            If cards.Length >= 4 Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function HasFourOfAKind24(ByRef sortedCards As Card()) As Boolean
        For i As Integer = 2 To 4
            Dim checkVal As Integer = i
            Dim cards() As Card = Array.FindAll(sortedCards, Function(x) x.Value = checkVal)
            If cards.Length >= 4 Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function HasFourOfAKindA(ByRef sortedCards As Card()) As Boolean
        Dim checkVal As Integer = 14
        Dim cards() As Card = Array.FindAll(sortedCards, Function(x) x.Value = checkVal)
        If cards.Length >= 4 Then
            Return True
        End If
        Return False
    End Function

    Private Function HasTwoPair(ByRef sortedCards As Card()) As Boolean
        Dim val1 As Integer = 0
        Dim val2 As Integer = 0
        For i As Integer = 2 To 14
            Dim checkVal As Integer = i
            Dim cards() As Card = Array.FindAll(sortedCards, Function(x) x.Value = checkVal)
            If cards.Length >= 2 Then
                If val1 = 0 Then
                    val1 = checkVal
                ElseIf val2 = 0 Then
                    val2 = checkVal
                End If
            End If

            If val1 <> 0 And val2 <> 0 Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function HasFullHouse(ByRef sortedCards As Card()) As Boolean
        Dim pairVal As Integer = 0
        Dim tripsVal As Integer = 0
        For i As Integer = 2 To 14
            Dim checkVal As Integer = i
            Dim cards() As Card = Array.FindAll(sortedCards, Function(x) x.Value = checkVal)
            If cards.Length = 2 And pairVal = 0 Then
                pairVal = checkVal
            End If
            If cards.Length = 3 And tripsVal = 0 Then
                tripsVal = checkVal
            End If

            If pairVal <> 0 And tripsVal <> 0 Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function HasFlush(ByRef sortedCards As Card()) As Boolean
        Dim ret As Boolean = True
        For i As Integer = 1 To sortedCards.Length - 1
            ret = ret And (sortedCards(i - 1).Suit = sortedCards(i).Suit)
        Next
        Return ret
    End Function

    Private Function HasStraight(ByRef sortedCards As Card()) As Boolean
        Dim ret As Boolean = True
        For i As Integer = 1 To sortedCards.Length - 1
            ret = ret And (sortedCards(i - 1).Value + 1 = sortedCards(i).Value)
        Next
        Return ret
    End Function

    Private Function HasStraightFlush(ByRef sortedCards As Card()) As Boolean
        Return HasFlush(sortedCards) And HasStraight(sortedCards)
    End Function

    Private Function HasRoyalFlush(ByRef sortedCards As Card()) As Boolean
        Return sortedCards(0).Value = 11 And HasStraightFlush(sortedCards)
    End Function
#End Region
End Class
