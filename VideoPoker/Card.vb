Imports System.Collections
Imports System.Collections.Generic

Public Class Card
    Implements IComparable(Of Card)
    Implements IComparable

    Private cardValue As Integer

    Public Property Suit As CardSuit

    Public ReadOnly Property DisplayValue As Char
        Get
            Dim ret As Char
            Select Case cardValue
                Case 10
                    ret = "T"
                Case 11
                    ret = "J"
                Case 12
                    ret = "Q"
                Case 13
                    ret = "K"
                Case 14
                    ret = "A"
                Case Else
                    ret = Chr(cardValue + 48)
            End Select
            Return ret
        End Get
    End Property

    Public Property Value As Integer
        Get
            Return cardValue
        End Get
        Set(value As Integer)
            If value >= 2 And value <= 14 Then
                cardValue = value
            End If
        End Set
    End Property

    Public Sub New(ByVal cardSuit As CardSuit, ByVal cardValue As Integer)
        Suit = cardSuit
        Value = cardValue
    End Sub

    Public Overrides Function ToString() As String
        Return DisplayValue & Suit.ToString().Substring(0, 1)
    End Function

    Public Overloads Function CompareTo(other As Card) As Integer Implements IComparable(Of Card).CompareTo
        If other Is Nothing Then
            Return 1
        End If

        Dim ret As Integer = cardValue.CompareTo(other.Value)
        If ret = 0 Then
            ret = CType(Suit, Integer).CompareTo(CType(other.Suit, Integer))
        End If

        Return ret
    End Function

    Public Overloads Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing Then
            Return 1
        End If

        Dim other As Card = TryCast(obj, Card)
        If other Is Nothing Then
            Throw New ArgumentException("Object is not a Card")
        End If

        Return Me.CompareTo(other)
    End Function
End Class
