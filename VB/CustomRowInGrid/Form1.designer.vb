Imports Microsoft.VisualBasic
Imports System
Namespace GridCustomRows
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(472, 262)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.gridColumn1, Me.gridColumn2, Me.gridColumn3})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
'			Me.gridView1.CustomDrawGroupRow += New DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(Me.gridView1_CustomDrawGroupRow);
'			Me.gridView1.CustomColumnGroup += New DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(Me.gridView1_CustomColumnGroup);
'			Me.gridView1.CustomColumnSort += New DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(Me.gridView1_CustomColumnSort);
			' 
			' gridColumn1
			' 
			Me.gridColumn1.Caption = "Part1"
			Me.gridColumn1.FieldName = "Part1"
			Me.gridColumn1.Name = "gridColumn1"
			Me.gridColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
			Me.gridColumn1.Visible = True
			Me.gridColumn1.VisibleIndex = 0
			' 
			' gridColumn2
			' 
			Me.gridColumn2.Caption = "Part2"
			Me.gridColumn2.FieldName = "Part2"
			Me.gridColumn2.Name = "gridColumn2"
			Me.gridColumn2.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
			Me.gridColumn2.Visible = True
			Me.gridColumn2.VisibleIndex = 1
			' 
			' gridColumn3
			' 
			Me.gridColumn3.Caption = "Part3"
			Me.gridColumn3.FieldName = "Part3"
			Me.gridColumn3.Name = "gridColumn3"
			Me.gridColumn3.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
			Me.gridColumn3.Visible = True
			Me.gridColumn3.VisibleIndex = 2
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(472, 262)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace

