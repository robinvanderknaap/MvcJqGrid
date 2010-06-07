<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Events
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Events</h2>
   <%= Html.Grid("events")
        .setCaption("Events")
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
        .setRowList(new int[]{10,15,20,50})
        .setViewRecords(true)
        .setPager("pager")
        .onSortCol("alert('Sort direction: ' + sortorder)")
        .onSelectRow("onRowSelected(rowid, status)")
%>
<script type="text/javascript">
   function onRowSelected(rowid, status) {
        alert('This row has id: ' + rowid);
    }
</script>

<pre>
<b>Source:</b>
&lt;%= Html.Grid("events")
    .setCaption("Basic Grid")
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
    .setRowList(new int[]{10,15,20,50})
    .setViewRecords(true)
    .setPager("pager")
    .onSortCol("alert('Sort direction: ' + sortorder)")
    .onSelectRow("onRowSelected(rowid, status)")
%&gt;
&lt;script type="text/javascript"&gt;
    function onRowSelected(rowid, status) {
        alert('This row has id: ' + rowid);
    }
&lt;/script&gt;

<b>Explanation:</b>
The jqGrid helper supports all kinds of events. You can call a function or add any kind of javascript 
to the event. Most events pass some arguments along, read the intellisense for each event to see which 
variables are available during the event.

<i>onSortCol</i>: Triggered when sortbutton is clicked. Available variables are 'index' and 'sortorder'

<i>onSelectRow</i>: Triggered when row is selected. Available variables during the event are 'rowid' and
'status'. Status indicates if row is selected or unselected (only if multiselect is enabled) 
</pre>
</asp:Content>
