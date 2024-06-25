<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128631069/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3367)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to put custom rows in grid control


<p>This example demonstrates how to place a custom row (ordinal, blank and summary) to GridView. By default, GridView does not provide the capability to add custom rows. It just displays rows provided by its DataSourse. This functionality can be accomplished by creating a wrapper for the datasource to pass  additional rows to GridControl. Actually, this will be  regular editable rows and it is necessary to customize their behavior: <br />
1. Force this row to be always displayed on the required position regardless of the current sorting. This can be done via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_CustomColumnSorttopic"><u>ColumnView.CustomColumnSort</u></a>  event.<br />
2.Prevent editing in non-editable rows such as summary rows and blank rows with the text. This can be done via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_ShowingEditortopic"><u>ColumnView.ShowingEditor</u></a>  event.<br />
3. Create grouping logic for custom rows and implement it in the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsGridGridView_CustomColumnGrouptopic"><u>GridView.CustomColumnGroup</u></a> event handler. Handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsGridGridView_CustomDrawGroupRowtopic"><u>CustomDrawGroupRow</u></a> event to display a correct custom group text.</p><p>This example is based on the <a href="https://www.devexpress.com/Support/Center/p/E1180">How to create a data source wrapper that adds an empty item to the lookup list</a> example.</p><br />


<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-display-custom-rows&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-display-custom-rows&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
