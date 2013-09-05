Option Explicit On
Option Strict On

Public Class CBallotBox

    Private _name As String
    Private _pname As String
    Private _counter As Integer
    Private _pcounter As String
    Private _ID As String

    Public Sub New(ByVal name As String, ByVal pname As String, _
        ByVal counter As Integer, ByVal pcounter As String, ByVal id As String)
        _ID = id
        _name = name
        _pname = pname
        _counter = counter
        _pcounter = pcounter
    End Sub

    Public Property Name() As String
        Get
            Return _name
        End Get

        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property PName() As String
        Get
            Return _pname
        End Get

        Set(ByVal value As String)
            _pname = value
        End Set
    End Property

    Public Property Counter() As Integer
        Get
            Return _counter
        End Get

        Set(ByVal value As Integer)
            _counter = value
        End Set
    End Property

    Public Property PCounter() As String
        Get
            Return _pcounter
        End Get

        Set(ByVal value As String)
            _pcounter = value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return _ID
        End Get

        Set(ByVal value As String)
            _ID = value
        End Set
    End Property

End Class
