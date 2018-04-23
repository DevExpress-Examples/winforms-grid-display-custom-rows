using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;

namespace GridCustomRows
{
    class SummaryItem
    {
        DataSourceWrapper Wrapper;
        PartContainer ItemObject;
        GridView View;
        public SummaryItem(DataSourceWrapper wrapper,GridView view, int id)
        {
            ItemObject = new PartContainer();
            ItemObject.ID = id;
            Wrapper = wrapper;

            calcSummary(Wrapper.NestedList as BindingList<PartContainer>);
            wrapper.NestedList.ListChanged += new ListChangedEventHandler(list_ListChanged);
            Wrapper.CustomRows.Add(ItemObject);
            View = view;
            View.ShowingEditor += new CancelEventHandler(View_ShowingEditor);

        }
        void calcSummary(BindingList<PartContainer> container)
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            foreach (PartContainer item in container)
            {
                p1 += item.Part1;
                p2 += item.Part2;
                p3 += item.Part3;
            }
            ItemObject.Part1 = p1;
            ItemObject.Part2 = p2;
            ItemObject.Part3 = p3;
        }
        void list_ListChanged(object sender, ListChangedEventArgs e)
        {
            BindingList<PartContainer> container = sender as BindingList<PartContainer>;
            calcSummary(container);
        }

        int ItemRowHandle()
        {
            int index = Wrapper.IndexOf(ItemObject);
            int nullHandle = View.GetRowHandle(View.GetRowHandle(index));
            return nullHandle;
        }

        private void View_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (View.FocusedRowHandle == ItemRowHandle())
            {
                e.Cancel = true;
            }
        }


    }
}
