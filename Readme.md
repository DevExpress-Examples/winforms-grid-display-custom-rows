<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128631069/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3367)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# WinForms Data Grid - Add custom data rows

This example demonstrates how to display custom rows (ordinal, blank/group, and summary) in the WinForms Data Grid. Custom rows do not exist in the grid's data source. Custom rows support data editing, sorting, and grouping.

The example creates a data source wrapper and handles the following events:

* The [CustomColumnSort](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.ColumnView.CustomColumnSort) event is handled to display custom rows at the specified position regardless of sorting.
* The [ShowingEditor](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.ColumnView.ShowingEditor) event is handled to prevent editing blank and summary custom rows.
* The [CustomColumnGroup](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.CustomColumnGroup) event is handled to group custom rows. The [CustomDrawGroupRow](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.CustomDrawGroupRow) event is handled to display text within a custom group row.
                                                                        

## See Also

* [WinForms Lookup - Add an empty item to the dropdown list](https://supportcenter.devexpress.com/ticket/details/e1180/how-to-create-a-data-source-wrapper-that-adds-an-empty-item-to-the-lookup-list)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-display-custom-rows&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-display-custom-rows&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
