using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GridCustomRows
{
    class DataSourceWrapper : IBindingList
    {
        IBindingList _neastedList;
        IBindingList _customRows;

        public IBindingList NestedList
        {
            get { return _neastedList; }
            set {
                if (_neastedList == value)
                    return;
                _neastedList = value;
                ListChanged(this, new ListChangedEventArgs(ListChangedType.Reset, 0));
            }
        }
        public IBindingList CustomRows
        {
            get { return _customRows; }
            set
            {
                if (_customRows == value)
                    return;
                _customRows = value;
                ListChanged(this, new ListChangedEventArgs(ListChangedType.Reset, NestedList.Count));
            }
        }

        public DataSourceWrapper(IBindingList target,IBindingList custom)
            : base()
        {
            _neastedList = target;
            _customRows = custom;
            NestedList.ListChanged+=new ListChangedEventHandler(NeastedListChanged);
            CustomRows.ListChanged += new ListChangedEventHandler(NeastedListChanged);
        }

        void NeastedListChanged(object sender, ListChangedEventArgs e)
        {
            if (ListChanged != null)
                if (sender == NestedList)
                    ListChanged(this, new ListChangedEventArgs(e.ListChangedType, e.NewIndex, e.OldIndex));        
                else
                    ListChanged(this, new ListChangedEventArgs(e.ListChangedType, e.NewIndex + NestedList.Count, e.OldIndex + NestedList.Count));
        }

        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public object AddNew()
        {
            throw new NotImplementedException();
        }

        public bool AllowEdit
        {
            get { return true; }
        }

        public bool AllowNew
        {
            get { return true; }
        }

        public bool AllowRemove
        {
            get { throw new NotImplementedException(); }
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotImplementedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted
        {
            get { throw new NotImplementedException(); }
        }

        public event ListChangedEventHandler ListChanged;

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public void RemoveSort()
        {
            throw new NotImplementedException();
        }

        public ListSortDirection SortDirection
        {
            get { throw new NotImplementedException(); }
        }

        public PropertyDescriptor SortProperty
        {
            get { throw new NotImplementedException(); }
        }

        public bool SupportsChangeNotification
        {
            get { return true; }
        }

        public bool SupportsSearching
        {
            get { throw new NotImplementedException(); }
        }

        public bool SupportsSorting
        {
            get { throw new NotImplementedException(); }
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {

            int index = CustomRows.IndexOf(value);
            if (index == -1)
                return NestedList.IndexOf(value);
            return index + NestedList.Count;
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public object this[int index]
        {
            get
            {
                if (index >= NestedList.Count)
                {
                    return CustomRows[index - NestedList.Count];
                }
                return NestedList[index];
            }
            set
            {
                if (index < CustomRows.Count)
                {
                    CustomRows[index] = value;
                }
                NestedList[index] = value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return NestedList.Count + CustomRows.Count; }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public bool IsCustomItem(object value)
        {
            return CustomRows.Contains(value);
        }
        public bool IsCustomItemIndex(int index)
        {

            return ((index >= NestedList.Count) && (index < CustomRows.Count + NestedList.Count));
        }
    }
}
