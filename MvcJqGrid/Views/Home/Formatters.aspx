<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Formatters
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Formatters</h2>
    
<%= Html.Grid("formatters")
        .setCaption("Formatters")
        .addColumn(new Column("CustomerId")
            .setLabel("Id")
            .setCustomFormatter("buttonize"))
        .addColumn(new Column("Name"))
        .addColumn(new Column("Company"))
        .addColumn(new Column("EmailAddress")
            .setFormatter(Formatters.email))
        .addColumn(new Column("Last Modified"))
        .addColumn(new Column("Telephone"))
        .setUrl(VirtualPathUtility.ToAbsolute("~/Home/GridDataBasic/"))
        .setAutoWidth(true)
        .setRowNum(10)
        .setRowList(new int[] { 10, 15, 20, 50 })
        .setViewRecords(true)
        .setPager("pager")
        
        
%>

<script type="text/javascript">
    function buttonize(cellvalue, options, rowobject) {
        return '<input type="button" value="'+ cellvalue +'" onclick="alert('+ cellvalue + ')">';
    }
</script>

<pre>
<b>Source:</b>
&lt;%=  Html.Grid("formatters")
    .setCaption("Formatters")
    .addColumn(new Column("CustomerId")
        .setLabel("Id")
        .setCustomFormatter("buttonize"))
    .addColumn(new Column("Name"))
    .addColumn(new Column("Company"))
    .addColumn(new Column("EmailAddress")
        .setFormatter(Formatters.email))
    .addColumn(new Column("Last Modified"))
    .addColumn(new Column("Telephone"))
    .setUrl("<%= VirtualPathUtility.ToAbsolute("~/Home/GridDataBasic/")%>")
    .setAutoWidth(true)
    .setRowNum(10)
    .setRowList(new int[] { 10, 15, 20, 50 })
    .setViewRecords(true)
    .setPager("pager")
%&gt;

&lt;script type="text/javascript"&gt;
    function buttonize(cellvalue, options, rowobject) {
        return '&lt;input type="button" value="' + cellvalue + '" onclick="alert(' + cellvalue + ')"&gt;';
    }
&lt;/script&gt;

<b>Explanation:</b>
Formatters can attached to each individual column to easily format the content of the column. JqGrid 
supports a number of predefined formtters, also custom formatters can be set.

<i>setFormatter</i>: Sets predefined formatter for individual column. Available formatters: integer, number,
currency, date, email, link, showlink, checkbox, select

<i>setCustomFormatter</i>: Use this method to attach a custom formatter to a column. The method expects the 
name of the function which will handle the custom formatting. The following variables are passed to 
the function:
    'cellvalue': The value to be formated (pure text).
    'options': Object { rowId: rid, colModel: cm} where rowId - is the id of the row and colModel is 
               the object of the properties for this column retrieved from colModel array of jqGrid
    'rowobject': Row data represented in the format determined from datatype option.
</pre>
</asp:Content>
