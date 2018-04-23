Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils.Drawing
Imports System.Drawing

Namespace GridCustomRows
	Friend Class BlankItem
		Private ItemObject As PartContainer
		Private Wrapper As DataSourceWrapper
		Private View As GridView
		Public Text As String
		Public Sub New(ByVal wrapper As DataSourceWrapper, ByVal view As GridView, ByVal id As Integer)
			ItemObject = New PartContainer()
			ItemObject.ID = id
			Me.Wrapper = wrapper
			Me.Wrapper.CustomRows.Add(ItemObject)
			Me.View = view
			AddHandler Me.View.GridControl.Paint, AddressOf GridControl_Paint
			AddHandler Me.View.ShowingEditor, AddressOf View_ShowingEditor
			Text = "[Empty String]"
		End Sub
		Public Sub New(ByVal wrapper As DataSourceWrapper, ByVal view As GridView, ByVal id As Integer, ByVal text As String)
			Me.New(wrapper, view,id)
			Me.Text = text
		End Sub
		Private Function ItemRowHandle() As Integer
			Dim index As Integer = Wrapper.IndexOf(ItemObject)
			Dim nullHandle As Integer = View.GetRowHandle(View.GetRowHandle(index))
			Return nullHandle
		End Function
		Private Sub GridControl_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)

			Dim gvi As GridViewInfo = TryCast(View.GetViewInfo(), GridViewInfo)
			Dim gri As GridRowInfo = gvi.RowsInfo.FindRow(ItemRowHandle())
			If gri Is Nothing Then
				Return
			End If
			Dim cache As New GraphicsCache(e)
			Dim drawRect As Rectangle = gri.DataBounds
			drawRect.Height -= 1

			e.Graphics.FillRectangle(gri.Appearance.GetBackBrush(cache), drawRect)
			drawRect.Inflate(-3, -3)
			cache.DrawString(Text, gri.Appearance.Font, gri.Appearance.GetForeBrush(cache), drawRect, gri.Appearance.GetStringFormat())
		End Sub

		Private Sub View_ShowingEditor(ByVal sender As Object, ByVal e As CancelEventArgs)
			If View.FocusedRowHandle = ItemRowHandle() Then
				e.Cancel = True
			End If
		End Sub




	End Class
End Namespace
