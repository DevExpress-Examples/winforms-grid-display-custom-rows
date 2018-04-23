using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Drawing;

namespace GridCustomRows
{
    class BlankItem
    {
        PartContainer ItemObject;
        DataSourceWrapper Wrapper;
        GridView View;
        public string Text;
        public BlankItem(DataSourceWrapper wrapper, GridView view, int id)
        {
            ItemObject = new PartContainer();
            ItemObject.ID = id;
            Wrapper = wrapper;
            Wrapper.CustomRows.Add(ItemObject);
            View = view;
            View.GridControl.Paint+=new System.Windows.Forms.PaintEventHandler(GridControl_Paint);
            View.ShowingEditor+=new CancelEventHandler(View_ShowingEditor);
            Text = "[Empty String]";
        }
        public BlankItem(DataSourceWrapper wrapper, GridView view, int id, string text)
            : this(wrapper, view,id)
        {
            Text = text;
        }
        int ItemRowHandle()
        {
            int index = Wrapper.IndexOf(ItemObject);
            int nullHandle = View.GetRowHandle(View.GetRowHandle(index));
            return nullHandle;
        }
        private void GridControl_Paint(object sender, PaintEventArgs e)
        {

            GridViewInfo gvi = View.GetViewInfo() as GridViewInfo;
            GridRowInfo gri = gvi.RowsInfo.FindRow(ItemRowHandle());
            if (gri == null) return;
            GraphicsCache cache = new GraphicsCache(e);
            Rectangle drawRect = gri.DataBounds;
            drawRect.Height--;

            e.Graphics.FillRectangle(gri.Appearance.GetBackBrush(cache), drawRect);
            drawRect.Inflate(-3, -3);
            cache.DrawString(Text, gri.Appearance.Font, gri.Appearance.GetForeBrush(cache), drawRect, gri.Appearance.GetStringFormat());
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
