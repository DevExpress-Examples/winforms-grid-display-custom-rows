Imports DevExpress.XtraGrid.Views.Grid
Imports System.ComponentModel

Namespace GridCustomRows

    Friend Class SummaryItem

        Private Wrapper As DataSourceWrapper

        Private ItemObject As PartContainer

        Private View As GridView

        Public Sub New(ByVal wrapper As DataSourceWrapper, ByVal view As GridView, ByVal id As Integer)
            ItemObject = New PartContainer()
            ItemObject.ID = id
            Me.Wrapper = wrapper
            calcSummary(TryCast(Me.Wrapper.NestedList, BindingList(Of PartContainer)))
            AddHandler wrapper.NestedList.ListChanged, New ListChangedEventHandler(AddressOf list_ListChanged)
            Me.Wrapper.CustomRows.Add(ItemObject)
            Me.View = view
            AddHandler Me.View.ShowingEditor, New CancelEventHandler(AddressOf View_ShowingEditor)
        End Sub

        Private Sub calcSummary(ByVal container As BindingList(Of PartContainer))
            Dim p1 As Integer = 0
            Dim p2 As Integer = 0
            Dim p3 As Integer = 0
            For Each item As PartContainer In container
                p1 += item.Part1
                p2 += item.Part2
                p3 += item.Part3
            Next

            ItemObject.Part1 = p1
            ItemObject.Part2 = p2
            ItemObject.Part3 = p3
        End Sub

        Private Sub list_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
            Dim container As BindingList(Of PartContainer) = TryCast(sender, BindingList(Of PartContainer))
            calcSummary(container)
        End Sub

        Private Function ItemRowHandle() As Integer
            Dim index As Integer = Wrapper.IndexOf(ItemObject)
            Dim nullHandle As Integer = View.GetRowHandle(View.GetRowHandle(index))
            Return nullHandle
        End Function

        Private Sub View_ShowingEditor(ByVal sender As Object, ByVal e As CancelEventArgs)
            If View.FocusedRowHandle = ItemRowHandle() Then
                e.Cancel = True
            End If
        End Sub
    End Class
End Namespace
