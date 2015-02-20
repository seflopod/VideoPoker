Public Class CardControl
    Const _fixedWidth As Integer = 104
    Const _fixedHeight As Integer = 104

    Private _clicked As Boolean = False

    'Keep constant size
    Protected Overrides Sub SetBoundsCore(x As Integer, y As Integer, width As Integer, height As Integer, specified As BoundsSpecified)
        MyBase.SetBoundsCore(x, y, _fixedWidth, _fixedHeight, specified)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _clicked = False
        btnCard.BackColor = Color.Lime
    End Sub

    Public Property Clicked As Boolean
        Get
            Return _clicked
        End Get
        Private Set(value As Boolean)
            _clicked = value
        End Set
    End Property

    Public Sub ChangeLabel(lblText As String)
        lblCard.Text = lblText
    End Sub

    Public Sub UnClickButton()
        btnCard.BackColor = Color.Lime
        btnCard.Text = ""
        Clicked = False
    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        If Clicked Then
            btnCard.BackColor = Color.Lime
            btnCard.Text = ""
            Clicked = False
        Else
            btnCard.BackColor = Color.Red
            btnCard.Text = "Keep"
            Clicked = True
        End If
    End Sub
End Class
