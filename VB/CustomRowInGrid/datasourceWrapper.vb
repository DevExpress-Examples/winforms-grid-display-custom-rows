Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel

Namespace GridCustomRows
	Friend Class DataSourceWrapper
		Implements IBindingList
		Private _neastedList As IBindingList
		Private _customRows As IBindingList

		Public Property NestedList() As IBindingList
			Get
				Return _neastedList
			End Get
			Set(ByVal value As IBindingList)
				If _neastedList Is value Then
					Return
				End If
				_neastedList = value
				RaiseEvent ListChanged(Me, New ListChangedEventArgs(ListChangedType.Reset, 0))
			End Set
		End Property
		Public Property CustomRows() As IBindingList
			Get
				Return _customRows
			End Get
			Set(ByVal value As IBindingList)
				If _customRows Is value Then
					Return
				End If
				_customRows = value
				RaiseEvent ListChanged(Me, New ListChangedEventArgs(ListChangedType.Reset, NestedList.Count))
			End Set
		End Property

		Public Sub New(ByVal target As IBindingList, ByVal custom As IBindingList)
			MyBase.New()
			_neastedList = target
			_customRows = custom
			AddHandler NestedList.ListChanged, AddressOf NeastedListChanged
			AddHandler CustomRows.ListChanged, AddressOf NeastedListChanged
		End Sub

		Private Sub NeastedListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
			If ListChangedEvent IsNot Nothing Then
				If sender Is NestedList Then
					RaiseEvent ListChanged(Me, New ListChangedEventArgs(e.ListChangedType, e.NewIndex, e.OldIndex))
				Else
					RaiseEvent ListChanged(Me, New ListChangedEventArgs(e.ListChangedType, e.NewIndex + NestedList.Count, e.OldIndex + NestedList.Count))
				End If
			End If
		End Sub

		Public Sub AddIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.AddIndex
			Throw New NotImplementedException()
		End Sub

		Public Function AddNew() As Object Implements IBindingList.AddNew
			Throw New NotImplementedException()
		End Function

		Public ReadOnly Property AllowEdit() As Boolean Implements IBindingList.AllowEdit
			Get
				Return True
			End Get
		End Property

		Public ReadOnly Property AllowNew() As Boolean Implements IBindingList.AllowNew
			Get
				Return True
			End Get
		End Property

		Public ReadOnly Property AllowRemove() As Boolean Implements IBindingList.AllowRemove
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Sub ApplySort(ByVal [property] As PropertyDescriptor, ByVal direction As ListSortDirection) Implements IBindingList.ApplySort
			Throw New NotImplementedException()
		End Sub

		Public Function Find(ByVal [property] As PropertyDescriptor, ByVal key As Object) As Integer Implements IBindingList.Find
			Throw New NotImplementedException()
		End Function

		Public ReadOnly Property IsSorted() As Boolean Implements IBindingList.IsSorted
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Event ListChanged As ListChangedEventHandler Implements IBindingList.ListChanged

		Public Sub RemoveIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.RemoveIndex
			Throw New NotImplementedException()
		End Sub

		Public Sub RemoveSort() Implements IBindingList.RemoveSort
			Throw New NotImplementedException()
		End Sub

		Public ReadOnly Property SortDirection() As ListSortDirection Implements IBindingList.SortDirection
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public ReadOnly Property SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public ReadOnly Property SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
			Get
				Return True
			End Get
		End Property

		Public ReadOnly Property SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public ReadOnly Property SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Function Add(ByVal value As Object) As Integer Implements System.Collections.IList.Add
			Throw New NotImplementedException()
		End Function

		Public Sub Clear() Implements System.Collections.IList.Clear
			Throw New NotImplementedException()
		End Sub

		Public Function Contains(ByVal value As Object) As Boolean Implements System.Collections.IList.Contains
			Throw New NotImplementedException()
		End Function

		Public Function IndexOf(ByVal value As Object) As Integer Implements System.Collections.IList.IndexOf

			Dim index As Integer = CustomRows.IndexOf(value)
			If index = -1 Then
				Return NestedList.IndexOf(value)
			End If
			Return index + NestedList.Count
		End Function

		Public Sub Insert(ByVal index As Integer, ByVal value As Object) Implements System.Collections.IList.Insert
			Throw New NotImplementedException()
		End Sub

		Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Sub Remove(ByVal value As Object) Implements System.Collections.IList.Remove
			Throw New NotImplementedException()
		End Sub

		Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.IList.RemoveAt
			Throw New NotImplementedException()
		End Sub

		Default Public Property Item(ByVal index As Integer) As Object Implements System.Collections.IList.Item
			Get
				If index >= NestedList.Count Then
					Return CustomRows(index - NestedList.Count)
				End If
				Return NestedList(index)
			End Get
			Set(ByVal value As Object)
				If index < CustomRows.Count Then
					CustomRows(index) = value
				End If
				NestedList(index) = value
			End Set
		End Property

		Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
			Throw New NotImplementedException()
		End Sub

		Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
			Get
				Return NestedList.Count + CustomRows.Count
			End Get
		End Property

		Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
			Throw New NotImplementedException()
		End Function
		Public Function IsCustomItem(ByVal value As Object) As Boolean
			Return CustomRows.Contains(value)
		End Function
		Public Function IsCustomItemIndex(ByVal index As Integer) As Boolean

			Return ((index >= NestedList.Count) AndAlso (index < CustomRows.Count + NestedList.Count))
		End Function
	End Class
End Namespace
