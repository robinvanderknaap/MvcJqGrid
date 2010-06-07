<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Multiselect
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Multiselect</h2>
    <%= Html.Grid("multiselect")
        .setCaption("Multiselect Grid")
        .addColumn(new Column("CustomerId")
            .setLabel("Id"))
        .addColumn(new Column("Name"))
        .addColumn(new Column("Company"))
        .addColumn(new Column("EmailAddress"))
        .addColumn(new Column("Last Modified"))
        .addColumn(new Column("Telephone"))
        .setUrl(VirtualPathUtility.ToAbsolute("~/Home/GridDataBasic/"))
        .setAutoWidth(true)
        .setRowNum(10)
        .setRowList(new int[] { 10, 15, 20, 50 })
        .setViewRecords(true)
        .setPager("pager")
        .setMultiSelect(true)
        .setMultiBoxOnly(false)
        .setMultiSelectWidth(20)       
%>

<pre>
<b>Source:</b>
&lt;%= Html.Grid("multiselect")
    .setCaption("Multiselect Grid")
    .addColumn(new Column("CustomerId")
        .setLabel("Id"))
    .addColumn(new Column("Name"))
    .addColumn(new Column("Company"))
    .addColumn(new Column("EmailAddress"))
    .addColumn(new Column("Last Modified"))
    .addColumn(new Column("Telephone"))
    .setUrl("<%= VirtualPathUtility.ToAbsolute("~/Home/GridDataBasic/")%>")
    .setAutoWidth(true)
    .setRowNum(10)
    .setRowList(new int[] { 10, 15, 20, 50 })
    .setViewRecords(true)
    .setPager("pager")
    .setMultiSelect(true)
    .setMultiBoxOnly(false)
    .setMultiSelectWidth(20)       
%&gt;

<b>Explanation</b>
JqGrid supports selecting multiple selection of rows. By using the setMultiSelect method multiselect
is enabled. A column containing checkboxes is automatically added.

<i>setMultiSelect</i>: Enables or disables multiple selection of rows (default: false).

<i>setMultiBoxOnly</i>: By enabling this option, users can only select rows by using the checkbox.
When set to false (default), the entire row can be clicked to select the row.

<i>setMultiSelectWidth</i>: Sets the width of the column containing the checkboxes (default: 20).
</pre>


</asp:Content>
