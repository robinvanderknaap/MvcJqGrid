<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Toolbar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Toolbar</h2>
    <%= Html.Grid("toolbar")
        .setCaption("Toolbar")
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
        .setToolbar(true)
        .setToolbarPosition(ToolbarPosition.bottom)
%>

<script type="text/javascript">
    $(document).ready(function () {
        $('#t_toolbar').append("<input type='button' value='Click Me' style='height:20px;font-size:-3' onclick=\"alert('Hi');\"/>");
    });

</script>

<pre>
<b>Source:</b>
&lt;%= Html.Grid("toolbar")
    .setCaption("Toolbar")
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
    .setToolbar(true)
    .setToolbarPosition(ToolbarPosition.bottom) 
%&gt;

&lt;script type="text/javascript"&gt;
    $(document).ready(function () {
        $('#t_toolbar')
            .append("&lt;input type='button' value='Click Me' onclick=\"alert('Hi');\"/&gt;");
    });
&lt;/script&gt;

<b>Explanation:</b>
A toolbar is added to the grid by using the setToolbar method. The id of the toolbar equals the id of 
the grid, prefixed by t_. You can add buttons easily, or any other html elements for that matter, by
adding some javascript to the page.

<i>setToolbar</i>: Enables or disables toolbar.

<i>setToolparPosition</i>: Sets position of toolbar, top, bottom or both. When set to both, two 
toolbars are generated (id top toolbar: t_ + grid id, id of bottom toolbar: tb_ + grid id).
</pre>
</asp:Content>
