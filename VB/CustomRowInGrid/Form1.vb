Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils.Drawing

Namespace GridCustomRows

    Public Partial Class Form1
        Inherits Form

        Private dsw As DataSourceWrapper

        Private DataList As BindingList(Of PartContainer)

        Private CustomRows As BindingList(Of PartContainer)

        Public Sub New()
            InitializeComponent()
            DataList = New BindingList(Of PartContainer)()
            CustomRows = New BindingList(Of PartContainer)()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            dsw = New DataSourceWrapper(DataList, CustomRows)
            Dim tmp_BlankItem = New BlankItem(dsw, gridView1, -1, "Only Custom Rows are placed under this Row")
            dsw.CustomRows.Add(New PartContainer(-2, 5, 5, 5))
            Dim tmp_BlankItem = New BlankItem(dsw, gridView1, Integer.MinValue + 1, "The Summary Row calculates only Nested Data Row Values")
            Dim tmp_SummaryItem = New SummaryItem(dsw, gridView1, Integer.MinValue)
            For i As Integer = 0 To 10 - 1
                DataList.Add(New PartContainer(i, i, i * 2, i * 3))
            Next

            gridControl1.DataSource = dsw
        End Sub

        Private Sub gridView1_CustomColumnSort(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs)
            Dim row1 As PartContainer = TryCast(e.RowObject1, PartContainer)
            Dim row2 As PartContainer = TryCast(e.RowObject2, PartContainer)
            If row1.ID < 0 AndAlso row2.ID >= 0 Then
                If e.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending Then e.Result = 1
                If e.SortOrder = DevExpress.Data.ColumnSortOrder.Descending Then e.Result = -1
                e.Handled = True
            End If

            If row1.ID >= 0 AndAlso row2.ID < 0 Then
                If e.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending Then e.Result = -1
                If e.SortOrder = DevExpress.Data.ColumnSortOrder.Descending Then e.Result = 1
                e.Handled = True
            End If

            If row1.ID < 0 AndAlso row2.ID < 0 Then
                If e.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending Then
                    If row1.ID < row2.ID Then
                        e.Result = 1
                    Else
                        e.Result = -1
                    End If
                End If

                If e.SortOrder = DevExpress.Data.ColumnSortOrder.Descending Then
                    If row1.ID < row2.ID Then
                        e.Result = -1
                    Else
                        e.Result = 1
                    End If
                End If

                e.Handled = True
            End If
        End Sub

        Private Sub gridView1_CustomColumnGroup(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs)
            Dim row1 As PartContainer = TryCast(e.RowObject1, PartContainer)
            Dim row2 As PartContainer = TryCast(e.RowObject2, PartContainer)
            If row1.ID < 0 AndAlso row2.ID < 0 Then
                If e.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending Then
                    If row1.ID < row2.ID Then
                        e.Result = 1
                    Else
                        e.Result = -1
                    End If
                End If

                If e.SortOrder = DevExpress.Data.ColumnSortOrder.Descending Then
                    If row1.ID < row2.ID Then
                        e.Result = -1
                    Else
                        e.Result = 1
                    End If
                End If

                e.Handled = True
            End If
        End Sub

        Private Sub gridView1_CustomDrawGroupRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs)
            Dim index As Integer = gridView1.GetDataRowHandleByGroupRowHandle(e.RowHandle)
            If dsw.IsCustomItemIndex(index) Then
                Dim info As GridGroupRowInfo = TryCast(e.Info, GridGroupRowInfo)
                info.GroupText = "Custom Rows"
            End If
        End Sub
    End Class
End Namespace
