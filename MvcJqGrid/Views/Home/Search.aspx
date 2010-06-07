<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search - Toolbar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Search Example</h2>
    <%= Html.Grid("search")
            .setCaption("Toolbar Search")
            .addColumn(new Column("CustomerId")
                .setLabel("Id"))
            .addColumn(new Column("Name"))
            .addColumn(new Column("Company")
                .setSearchType(Searchtype.select)
                .setSearchTerms((string[])ViewData["CompanyNames"]))
            .addColumn(new Column("EmailAddress"))
            .addColumn(new Column("Last Modified")
                .setSearchType(Searchtype.datepicker))
            .addColumn(new Column("Telephone"))
            .setUrl(VirtualPathUtility.ToAbsolute("~/Home/GridDataBasic/"))
            .setAutoWidth(true)
            .setRowNum(10)
            .setRowList(new int[] { 10, 15, 20, 50 })
            .setViewRecords(true)
            .setPager("pager")
            .setSearchToolbar(true)
            .setSearchOnEnter(false)
     %>

<pre>
<b>Source:</b>
&lt;%= Html.Grid("search")
    .setCaption("Toolbar Search")
    .addColumn(new Column("CustomerId")
        .setLabel("Id"))
    .addColumn(new Column("Name"))
    .addColumn(new Column("Company")
        .setSearchType(Searchtype.select)
        .setSearchTerms((string[])ViewData["CompanyNames"]))
    .addColumn(new Column("EmailAddress"))
    .addColumn(new Column("Last Modified")
        .setSearchType(Searchtype.datepicker))
    .addColumn(new Column("Telephone"))
    .setUrl("<%= VirtualPathUtility.ToAbsolute("~/Home/GridDataBasic/")%>")
    .setAutoWidth(true)
    .setRowNum(10)
    .setRowList(new int[] { 10, 15, 20, 50 })
    .setViewRecords(true)
    .setPager("pager")
    .setSearchToolbar(true)
    .setSearchOnEnter(false)
%&gt;

<b>Explanation:</b>
This configuration demonstrates toolbar searching. A searchtype can be specified for each column.

<i>setSearchType</i>: Sets searchtype for a column. Searchtype can be set to input (default), select or 
datepicker.

<i>setSearchTerms</i>: When searchtype is set to select, this function is used to the fill the selectbox.
The function takes a collection of strings as selectoptions.

<i>setSearchToolbar</i>: Enables or disables toolbar searching.

<i>setSearchOnEnter</i>: When set to true, search is executed when the user hits enter. When set to false 
search is executed after the user stops typing.

</pre>
</asp:Content>
