# MvcJQGrid
MvcJqGrid is a html helper for ASP.NET MVC which eases the implementation of jqGrid in your website or webapplication.
The helper contains a fluent interface providing for a clean and readable view. Most of the properties, events and methods from the base classes of jqGrid are implemented in the helper, including paging, sorting and toolbar searching. At this point, editing, treegrids and subgrids are not yet supported.

A modelbinder for handling ajax requests from the grid is also included in the library, you can use your own if you want to. The modelbinder and the helper don't depend on each other.

## Sample Application
To showcase the helper a sample application was created which demonstrates various grids with different configurations. The source code from the view is displayed below every grid, which should make it easy to get started. The sample application is included in the source code, you can find a live version [here](http://playground.webpirates.nl/mvcjqgrid).

##NuGet

	Install-Package MvcJqGrid
	
## License
All source code is licensed under the [GNU Lesser General Public License](http://www.gnu.org/licenses/lgpl.html)

## Requirements
You need jQuery, jqGrid and the MvcJqGrid helper to get started, all three are available through NuGet. The helper will work with jqGrid v3.65 or later. If you're using the [Download Builder](http://www.trirand.com/blog/?page_id=6) to create your own custom jqGrid package, make sure you select all three base modules (Grid base, Formatter and Custom).

## Get started
After installing jqGrid and the helper you can start using the helper in your views. Make sure to include an using/import statement to the top of the viewpage that will use the helper:

	Razor:
	@using MvcJqGrid

	WebForms:
	<%@ Import Namespace=" MvcJqGrid" %>
	
If you're planning on using the grid on multiple pages in your project, it's possible to add the reference to your web.config, which enables the helper in all your views. For the Razor view engine use the web.config file located in the Views folder, for the WebForms view engine you can use the web.config located in the root of your application:

Creating a basic grid with the Razor view engine:

	@(Html.Grid("basic")
		.SetCaption("Basic Grid")
		.AddColumn(new Column("CustomerId")
			.SetLabel("Id"))
		.AddColumn(new Column("Name"))
		.AddColumn(new Column("Company"))
		.AddColumn(new Column("EmailAddress"))
		.AddColumn(new Column("Last Modified"))
		.AddColumn(new Column("Telephone"))
		.SetUrl("/Home/GridData/")
		.SetAutoWidth(true)
		.SetRowNum(10)
		.SetRowList(new int[]{10,15,20,50})
		.SetViewRecords(true)
		.SetPager("pager"))

Creating a basic grid with the WebForms view engine:

	<%= Html.Grid("basic")
		.SetCaption("Basic Grid")
		.AddColumn(new Column("CustomerId")
			.SetLabel("Id"))
		.AddColumn(new Column("Name"))
		.AddColumn(new Column("Company"))
		.AddColumn(new Column("EmailAddress"))
		.AddColumn(new Column("Last Modified"))
		.AddColumn(new Column("Telephone"))
		.SetUrl("/Home/GridData/")
		.SetAutoWidth(true)
		.SetRowNum(10)
		.SetRowList(new int[]{10,15,20,50})
		.SetViewRecords(true)
		.SetPager("pager")
    %>
	
For more information on creating grids, take a look at the sample application hosted [here](http://playground.webpirates.nl/mvcjqgrid).

## Modelbinder
A custom modelbinder is included in the library (created by [Ilya Builuk](http://www.codeproject.com/KB/aspnet/AspNetMVCandJqGrid.aspx)) to catch all the request parameters jqGrid sends to the controller. This modelbinder parses all arguments send by jqGrid into a strongly typed object called GridSettings. The definition of the action inside your controller when using this modelbinder would look something like this.

	public JsonResult GridData(GridSettings gridSettings)
	{
		...
	}
