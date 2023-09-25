Imports System.ComponentModel

Namespace GridCustomRows

    Friend Class PartContainer
        Implements INotifyPropertyChanged

        Private _id As Integer

        Private _part1 As Integer

        Private _part2 As Integer

        Private _part3 As Integer

        Public Sub New()
            _id = 0
            _part1 = 0
            _part2 = 0
            _part3 = 0
        End Sub

        Public Sub New(ByVal id As Integer, ByVal part1 As Integer, ByVal part2 As Integer, ByVal part3 As Integer)
            _id = id
            _part1 = part1
            _part2 = part2
            _part3 = part3
        End Sub

        Public Property ID As Integer
            Get
                Return _id
            End Get

            Set(ByVal value As Integer)
                If _id = value Then Return
                _id = value
                RisePropertyChanged("ID")
            End Set
        End Property

        Public Property Part1 As Integer
            Get
                Return _part1
            End Get

            Set(ByVal value As Integer)
                If _part1 = value Then Return
                _part1 = value
                RisePropertyChanged("Part1")
            End Set
        End Property

        Public Property Part2 As Integer
            Get
                Return _part2
            End Get

            Set(ByVal value As Integer)
                If _part2 = value Then Return
                _part2 = value
                RisePropertyChanged("Part2")
            End Set
        End Property

        Public Property Part3 As Integer
            Get
                Return _part3
            End Get

            Set(ByVal value As Integer)
                If _part3 = value Then Return
                _part3 = value
                RisePropertyChanged("Part3")
            End Set
        End Property

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Private Sub RisePropertyChanged(ByVal name As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
        End Sub
    End Class
End Namespace
