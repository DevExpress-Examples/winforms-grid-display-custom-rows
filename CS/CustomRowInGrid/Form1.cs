using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;

namespace GridCustomRows
{
    public partial class Form1 : Form
    {

        DataSourceWrapper dsw;
        BindingList<PartContainer> DataList;
        BindingList<PartContainer> CustomRows;
        public Form1()
        {
            InitializeComponent();
            DataList = new BindingList<PartContainer>();
            CustomRows = new BindingList<PartContainer>();

        }





        private void Form1_Load(object sender, EventArgs e)
        {
            dsw = new DataSourceWrapper(DataList, CustomRows);
            new BlankItem(dsw, gridView1, -1, "Only Custom Rows are placed under this Row");
            dsw.CustomRows.Add(new PartContainer(-2, 5, 5, 5));
            new BlankItem(dsw, gridView1, int.MinValue + 1, "The Summary Row calculates only Nested Data Row Values");
            new SummaryItem(dsw, gridView1, int.MinValue);
            for (int i = 0; i < 10; i++)
                DataList.Add(new PartContainer(i,i,i*2,i*3));

            gridControl1.DataSource = dsw;

        }


        private void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            PartContainer row1 = e.RowObject1 as PartContainer;
            PartContainer row2 = e.RowObject2 as PartContainer;
            if ((row1.ID < 0) && (row2.ID >= 0))
            {
                if (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending)
                    e.Result = 1;
                if (e.SortOrder == DevExpress.Data.ColumnSortOrder.Descending)
                    e.Result = -1;
                e.Handled = true;
            }
            if ((row1.ID >= 0) && (row2.ID < 0))
            {
                if (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending)
                    e.Result = -1;
                if (e.SortOrder == DevExpress.Data.ColumnSortOrder.Descending)
                    e.Result = 1;
                e.Handled = true;
            }
            if ((row1.ID < 0) && (row2.ID < 0))
            {
                if (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending)
                if (row1.ID < row2.ID)
                    e.Result = 1;
                else
                    e.Result = -1;
                if (e.SortOrder == DevExpress.Data.ColumnSortOrder.Descending)
                    if (row1.ID < row2.ID)
                        e.Result = -1;
                    else
                        e.Result = 1;

                e.Handled = true;
            }

        }

        private void gridView1_CustomColumnGroup(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            PartContainer row1 = e.RowObject1 as PartContainer;
            PartContainer row2 = e.RowObject2 as PartContainer;
            if ((row1.ID < 0) && (row2.ID < 0))
            {
                if (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending)
                    if (row1.ID < row2.ID)
                        e.Result = 1;
                    else
                        e.Result = -1;
                if (e.SortOrder == DevExpress.Data.ColumnSortOrder.Descending)
                    if (row1.ID < row2.ID)
                        e.Result = -1;
                    else
                        e.Result = 1;

                e.Handled = true;
            }

        }

        private void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            int index = gridView1.GetDataRowHandleByGroupRowHandle(e.RowHandle);

            if (dsw.IsCustomItemIndex(index))
            {
                GridGroupRowInfo info = e.Info as GridGroupRowInfo;
                info.GroupText = "Custom Rows";
            }

        }






    }

}
