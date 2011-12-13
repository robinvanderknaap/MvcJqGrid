using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MvcJqGrid.DataReaders;
using MvcJqGrid.Enums;

namespace MvcJqGrid
{
    /// <summary>
    ///     Grid class, used to render JqGrid
    /// </summary>
    public class Grid : IHtmlString
    {
        private readonly List<Column> _columns = new List<Column>();
        private readonly string _id;
        private string _altClass;
        private bool? _altRows;
        private bool? _autoEncode;
        private bool? _autoWidth;
        private string _caption;
        private DataType _dataType = DataType.Json;
        private string _emptyRecords;
        private bool? _footerRow;
        private bool? _forceFit;
        private bool? _gridView;
        private bool? _headerTitles;
        private int? _height;
        private bool? _hiddenGrid;
        private bool? _hideGrid;
        private bool? _hoverRows;
        private bool? _loadOnce;
        private string _loadText;
        private LoadUi? _loadUi;
        private bool? _multiBoxOnly;
        private MultiKey? _multiKey;
        private bool? _multiSelect;
        private int? _multiSelectWidth;
        private string _onAfterInsertRow;
        private string _onBeforeRequest;
        private string _onBeforeSelectRow;
        private string _onCellSelect;
        private string _onDblClickRow;
        private string _onGridComplete;
        private string _onHeaderClick;
        private string _onLoadBeforeSend;
        private string _onLoadComplete;
        private string _onLoadError;
        private string _onPaging;
        private string _onResizeStart;
        private string _onResizeStop;
        private string _onRightClickRow;
        private string _onSelectAll;
        private string _onSelectRow;
        private string _onSerializeGridData;
        private string _onSortCol;
        private int? _page;
        private string _pager;
        private PagerPos? _pagerPos;
        private bool? _pgButtons;
        private bool? _pgInput;
        private string _pgText;
        private RecordPos? _recordPos;
        private string _recordText;
        private RequestType? _requestType;
        private string _resizeClass;
        private int[] _rowList;
        private int? _rowNum;
        private int? _rowNumWidth;
        private bool? _rowNumbers;
        private bool? _scroll;
        private int? _scrollInt;
        private int? _scrollOffset;
        private bool? _scrollRows;
        private int? _scrollTimeout;
        private bool? _searchClearButton;
        private bool? _searchOnEnter;
        private bool? _searchToolbar;
        private bool? _showAllSortIcons;
        private bool? _shrinkToFit;
        private Direction? _sortIconDirection;
        private string _sortName;
        private bool? _sortOnHeaderClick;
        private SortOrder? _sortOrder;
        private bool? _toolbar;
        private ToolbarPosition _toolbarPosition = ToolbarPosition.Top;
        private bool? _topPager;
        private string _url;
        private bool? _viewRecords;
        private int? _width;
        private JsonReader _jsonReader;
        private bool? _searchToggleButton;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name = "id">Id of grid</param>
        public Grid(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Id must contain a value to identify the grid");
            }
            _id = id;
        }

        /// <summary>
        ///     Adds columns to grid
        /// </summary>
        /// <param name = "column">Colomn object</param>
        public Grid AddColumn(Column column)
        {
            _columns.Add(column);
            return this;
        }

        /// <summary>
        ///     The class that is used for alternate rows. You can construct your own class and replace this value. 
        ///     This option is valid only if altRows options is set to true (default: ui-priority-secondary)
        /// </summary>
        /// <param name = "altClass">Classname for alternate rows</param>
        public Grid SetAltClass(string altClass)
        {
            _altClass = altClass;
            return this;
        }

        /// <summary>
        ///     Set a zebra-striped grid (default: false)
        /// </summary>
        /// <param name = "altRows">Boolean indicating if zebra-striped grid is used</param>
        public Grid SetAltRows(Boolean altRows)
        {
            _altRows = altRows;
            return this;
        }

        /// <summary>
        ///     When set to true encodes (html encode) the incoming (from server) and posted 
        ///     data (from editing modules). (default: false)
        /// </summary>
        /// <param name = "autoEncode">Boolean indicating if autoencode is used</param>
        public Grid SetAutoEncode(bool autoEncode)
        {
            _autoEncode = autoEncode;
            return this;
        }

        /// <summary>
        ///     When set to true, the grid width is recalculated automatically to the width of the 
        ///     parent element. This is done only initially when the grid is created. In order to 
        ///     resize the grid when the parent element changes width you should apply custom code 
        ///     and use a setGridWidth method for this purpose. (default: false)
        /// </summary>
        /// <param name = "autoWidth">Boolean indicating if autowidth is used</param>
        public Grid SetAutoWidth(bool autoWidth)
        {
            _autoWidth = autoWidth;
            return this;
        }

        /// <summary>
        ///     Defines the caption layer for the grid. This caption appears above the header layer. 
        ///     If the string is empty the caption does not appear. (default: empty)
        /// </summary>
        /// <param name = "caption">Caption of grid</param>
        public Grid SetCaption(string caption)
        {
            _caption = caption;
            return this;
        }

        /// <summary>
        ///     Defines what type of information to expect to represent data in the grid. Valid 
        ///     options are json (default) and xml
        /// </summary>
        /// <param name = "dataType">Data type</param>
        public Grid SetDataType(DataType dataType)
        {
            _dataType = dataType;
            return this;
        }

        /// <summary>
        ///     Displayed when the returned (or the current) number of records is zero. 
        ///     This option is valid only if viewrecords option is set to true. (default value is 
        ///     set in language file)
        /// </summary>
        /// <param name = "emptyRecords">Display string</param>
        public Grid SetEmptyRecords(string emptyRecords)
        {
            _emptyRecords = emptyRecords;
            return this;
        }

        /// <summary>
        ///     If set to true this will place a footer table with one row below the grid records 
        ///     and above the pager. The number of columns equal to the number of columns in the colModel 
        ///     (default: false)
        /// </summary>
        /// <param name = "footerRow">Boolean indicating whether footerrow is displayed</param>
        public Grid SetFooterRow(bool footerRow)
        {
            _footerRow = footerRow;
            return this;
        }

        /// <summary>
        ///     If set to true, when resizing the width of a column, the adjacent column (to the right) 
        ///     will resize so that the overall grid width is maintained (e.g., reducing the width of 
        ///     column 2 by 30px will increase the size of column 3 by 30px). 
        ///     In this case there is no horizontal scrolbar. 
        ///     Warning: this option is not compatible with shrinkToFit option - i.e if 
        ///     shrinkToFit is set to false, forceFit is ignored.
        /// </summary>
        /// <param name = "forceFit">Boolean indicating if forcefit is enforced</param>
        public Grid SetForceFit(bool forceFit)
        {
            _forceFit = forceFit;
            return this;
        }

        /// <summary>
        ///     In the previous versions of jqGrid including 3.4.X,reading relatively big data sets 
        ///     (Rows >=100 ) caused speed problems. The reason for this was that as every cell was 
        ///     inserted into the grid we applied about 5-6 jQuery calls to it. Now this problem has 
        ///     been resolved; we now insert the entry row at once with a jQuery append. The result is 
        ///     impressive - about 3-5 times faster. What will be the result if we insert all the 
        ///     data at once? Yes, this can be done with help of the gridview option. When set to true, 
        ///     the result is a grid that is 5 to 10 times faster. Of course when this option is set 
        ///     to true we have some limitations. If set to true we can not use treeGrid, subGrid, 
        ///     or afterInsertRow event. If you do not use these three options in the grid you can 
        ///     set this option to true and enjoy the speed. (default: false)
        /// </summary>
        /// <param name = "gridView">Boolean indicating gridview is enabled</param>
        public Grid SetGridView(bool gridView)
        {
            _gridView = gridView;
            return this;
        }

        /// <summary>
        ///     If the option is set to true the title attribute is added to the column headers (default: false)
        /// </summary>
        /// <param name = "headerTitles">Boolean indicating if headertitles are enabled</param>
        public Grid SetHeaderTitles(bool headerTitles)
        {
            _headerTitles = headerTitles;
            return this;
        }

        /// <summary>
        ///     The height of the grid in pixels (default: 100%, which is the only acceptable percentage for jqGrid)
        /// </summary>
        /// <param name = "height">Height in pixels</param>
        public Grid SetHeight(int height)
        {
            _height = height;
            return this;
        }

        /// <summary>
        ///     If set to true the grid initially is hidden. The data is not loaded (no request is sent) and only the 
        ///     caption layer is shown. When the show/hide button is clicked for the first time to show the grid, the request 
        ///     is sent to the server, the data is loaded, and the grid is shown. From this point on we have a regular grid. 
        ///     This option has effect only if the caption property is not empty. (default: false)
        /// </summary>
        /// <param name = "hiddenGrid">Boolean indicating if hiddengrid is enforced</param>
        public Grid SetHiddenGrid(bool hiddenGrid)
        {
            _hiddenGrid = hiddenGrid;
            return this;
        }

        /// <summary>
        ///     Enables or disables the show/hide grid button, which appears on the right side of the caption layer. 
        ///     Takes effect only if the caption property is not an empty string. (default: true)
        /// </summary>
        /// <param name = "hideGrid">Boolean indicating if show/hide button is enabled</param>
        public Grid SetHideGrid(bool hideGrid)
        {
            _hideGrid = hideGrid;
            return this;
        }

        /// <summary>
        ///     When set to false the mouse hovering is disabled in the grid data rows. (default: true)
        /// </summary>
        /// <param name = "hoverRows">Indicates whether hoverrows is enabled</param>
        public Grid SetHoverRows(bool hoverRows)
        {
            _hoverRows = hoverRows;
            return this;
        }

        /// <summary>
        ///     If this flag is set to true, the grid loads the data from the server only once (using the 
        ///     appropriate datatype). After the first request the datatype parameter is automatically 
        ///     changed to local and all further manipulations are done on the client side. The functions 
        ///     of the pager (if present) are disabled. (default: false)
        /// </summary>
        /// <param name = "loadOnce">Boolean indicating if loadonce is enforced</param>
        public Grid SetLoadOnce(bool loadOnce)
        {
            _loadOnce = loadOnce;
            return this;
        }

        /// <summary>
        ///     The text which appears when requesting and sorting data. This parameter override the value located 
        ///     in the language file
        /// </summary>
        /// <param name = "loadText">Loadtext</param>
        public Grid SetLoadText(string loadText)
        {
            _loadText = loadText;
            return this;
        }

        /// <summary>
        ///     This option controls what to do when an ajax operation is in progress.
        ///     'disable' - disables the jqGrid progress indicator. This way you can use your own indicator.
        ///     'enable' (default) - enables “Loading” message in the center of the grid. 
        ///     'block' - enables the “Loading” message and blocks all actions in the grid until the ajax request 
        ///     is finished. Be aware that this disables paging, sorting and all actions on toolbar, if any.
        /// </summary>
        /// <param name = "loadUi">Load ui mode</param>
        public Grid SetLoadUi(LoadUi loadUi)
        {
            _loadUi = loadUi;
            return this;
        }

        /// <summary>
        ///     This parameter makes sense only when multiselect option is set to true. 
        ///     Defines the key which will be pressed 
        ///     when we make a multiselection. The possible values are: 
        ///     'shiftKey' - the user should press Shift Key 
        ///     'altKey' - the user should press Alt Key 
        ///     'ctrlKey' - the user should press Ctrl Key
        /// </summary>
        /// <param name = "multiKey">Key to multiselect</param>
        public Grid SetMultiKey(MultiKey multiKey)
        {
            _multiKey = multiKey;
            return this;
        }

        /// <summary>
        ///     This option works only when multiselect = true. When multiselect is set to true, clicking anywhere 
        ///     on a row selects that row; when multiboxonly is also set to true, the multiselection is done only 
        ///     when the checkbox is clicked (Yahoo style). Clicking in any other row (suppose the checkbox is 
        ///     not clicked) deselects all rows and the current row is selected. (default: false)
        /// </summary>
        /// <param name = "multiBoxOnly">Boolean indicating if multiboxonly is enforced</param>
        public Grid SetMultiBoxOnly(bool multiBoxOnly)
        {
            _multiBoxOnly = multiBoxOnly;
            return this;
        }

        /// <summary>
        ///     If this flag is set to true a multi selection of rows is enabled. A new column 
        ///     at the left side is added. Can be used with any datatype option. (default: false)
        /// </summary>
        /// <param name = "multiSelect">Boolean indicating if multiselect is enabled</param>
        public Grid SetMultiSelect(bool multiSelect)
        {
            _multiSelect = multiSelect;
            return this;
        }

        /// <summary>
        ///     Determines the width of the multiselect column if multiselect is set to true. (default: 20)
        /// </summary>
        /// <param name = "multiSelectWidth"></param>
        public Grid SetMultiSelectWidth(int multiSelectWidth)
        {
            _multiSelectWidth = multiSelectWidth;
            return this;
        }

        /// <summary>
        ///     Set the initial number of selected page when we make the request.This parameter is passed to the url 
        ///     for use by the server routine retrieving the data (default: 1)
        /// </summary>
        /// <param name = "page">Number of page</param>
        public Grid SetPage(int page)
        {
            _page = page;
            return this;
        }

        /// <summary>
        ///     If pagername is specified a pagerelement is automatically added to the grid
        /// </summary>
        /// <param name = "pager">Id/name of pager</param>
        public Grid SetPager(string pager)
        {
            _pager = pager;
            return this;
        }

        /// <summary>
        ///     Determines the position of the pager in the grid. By default the pager element
        ///     when created is divided in 3 parts (one part for pager, one part for navigator 
        ///     buttons and one part for record information) (default: center)
        /// </summary>
        /// <param name = "pagerPos">Position of pager</param>
        public Grid SetPagerPos(PagerPos pagerPos)
        {
            _pagerPos = pagerPos;
            return this;
        }

        /// <summary>
        ///     Determines if the pager buttons should be displayed if pager is available. Valid 
        ///     only if pager is set correctly. The buttons are placed in the pager bar. (default: true)
        /// </summary>
        /// <param name = "pgButtons">Boolean indicating if pager buttons are displayed</param>
        public Grid SetPgButtons(bool pgButtons)
        {
            _pgButtons = pgButtons;
            return this;
        }

        /// <summary>
        ///     Determines if the input box, where the user can change the number of the requested page, 
        ///     should be available. The input box appears in the pager bar. (default: true)
        /// </summary>
        /// <param name = "pgInput">Boolean indicating if pager input is available</param>
        public Grid SetPgInput(bool pgInput)
        {
            _pgInput = pgInput;
            return this;
        }

        /// <summary>
        ///     Show information about current page status. The first value is the current loaded page. 
        ///     The second value is the total number of pages (default is set in language file)
        ///     Example: "Page {0} of {1}"
        /// </summary>
        /// <param name = "pgText">Current page status text</param>
        public Grid SetPgText(string pgText)
        {
            _pgText = pgText;
            return this;
        }

        /// <summary>
        ///     Determines the position of the record information in the pager. Can be left, center, right 
        ///     (default: right)
        ///     Warning: When pagerpos en recordpos are equally set, pager is hidden.
        /// </summary>
        /// <param name = "recordPos">Position of record information</param>
        public Grid SetRecordPos(RecordPos recordPos)
        {
            _recordPos = recordPos;
            return this;
        }

        /// <summary>
        ///     Represent information that can be shown in the pager. This option is valid if viewrecords 
        ///     option is set to true. This text appears only if the total number of records is greater then 
        ///     zero.
        ///     In order to show or hide information the items between {} mean the following: {0} the 
        ///     start position of the records depending on page number and number of requested records; 
        ///     {1} - the end position {2} - total records returned from the data (default defined in language file)
        /// </summary>
        /// <param name = "recordText">Record Text</param>
        public Grid SetRecordText(string recordText)
        {
            _recordText = recordText;
            return this;
        }

        /// <summary>
        ///     Defines the type of request to make (“POST” or “GET”) (default: GET)
        /// </summary>
        /// <param name = "requestType">Request type</param>
        public Grid SetRequestType(RequestType requestType)
        {
            _requestType = requestType;
            return this;
        }

        /// <summary>
        ///     Assigns a class to columns that are resizable so that we can show a resize 
        ///     handle (default: empty string)
        /// </summary>
        /// <param name = "resizeClass"></param>
        /// <returns></returns>
        public Grid SetResizeClass(string resizeClass)
        {
            _resizeClass = resizeClass;
            return this;
        }

        /// <summary>
        ///     An array to construct a select box element in the pager in which we can change the number 
        ///     of the visible rows. When changed during the execution, this parameter replaces the rowNum 
        ///     parameter that is passed to the url. If the array is empty the element does not appear 
        ///     in the pager. Typical you can set this like [10,20,30]. If the rowNum parameter is set to 
        ///     30 then the selected value in the select box is 30.
        /// </summary>
        /// <example>
        ///     setRowList(new int[]{10,20,50})
        /// </example>
        /// <param name = "rowList">List of rows per page</param>
        public Grid SetRowList(int[] rowList)
        {
            _rowList = rowList;
            return this;
        }

        /// <summary>
        ///     Sets how many records we want to view in the grid. This parameter is passed to the url 
        ///     for use by the server routine retrieving the data. Be aware that if you set this parameter 
        ///     to 10 (i.e. retrieve 10 records) and your server return 15 then only 10 records will be 
        ///     loaded. Set this parameter to -1 (unlimited) to disable this checking. (default: 20)
        /// </summary>
        /// <param name = "rowNum">Number of rows per page</param>
        public Grid SetRowNum(int rowNum)
        {
            _rowNum = rowNum;
            return this;
        }

        /// <summary>
        ///     If this option is set to true, a new column at the leftside of the grid is added. The purpose of 
        ///     this column is to count the number of available rows, beginning from 1. In this case 
        ///     colModel is extended automatically with a new element with name - 'rn'. Also, be careful 
        ///     not to use the name 'rn' in colModel
        /// </summary>
        /// <param name = "rowNumbers">Boolean indicating if rownumbers are enabled</param>
        public Grid SetRowNumbers(bool rowNumbers)
        {
            _rowNumbers = rowNumbers;
            return this;
        }

        /// <summary>
        ///     Determines the width of the row number column if rownumbers option is set to true. (default: 25)
        /// </summary>
        /// <param name = "rowNumWidth">Width of rownumbers column</param>
        public Grid SetRowNumWidth(int rowNumWidth)
        {
            _rowNumWidth = rowNumWidth;
            return this;
        }

        /// <summary>
        ///     Creates dynamic scrolling grids. When enabled, the pager elements are disabled and we can use the 
        ///     vertical scrollbar to load data. When set to true the grid will always hold all the items from the 
        ///     start through to the latest point ever visited. 
        ///     When scroll is set to an integer value (eg 1), the grid will just hold the visible lines. This allow us to 
        ///     load the data at portions whitout to care about the memory leaks. (default: false)
        /// </summary>
        /// <param name = "scroll">Boolean indicating if scroll is enforced</param>
        public Grid SetScroll(bool scroll)
        {
            _scroll = scroll;
            if (_scrollInt.HasValue)
            {
                throw new InvalidOperationException(
                    "You can't set scroll to both a boolean and an integer at the same time, please choose one.");
            }
            return this;
        }

        /// <summary>
        ///     Creates dynamic scrolling grids. When enabled, the pager elements are disabled and we can use the 
        ///     vertical scrollbar to load data. When set to true the grid will always hold all the items from the 
        ///     start through to the latest point ever visited. 
        ///     When scroll is set to an integer value (eg 1), the grid will just hold the visible lines. This allow us to 
        ///     load the data at portions whitout to care about the memory leaks. (default: false)
        /// </summary>
        /// <param name = "scroll">When integer value is set (eg 1) scroll is enforced</param>
        public Grid SetScroll(int scroll)
        {
            _scrollInt = scroll;
            if (_scroll.HasValue)
            {
                throw new InvalidOperationException(
                    "You can't set scroll to both a boolean and an integer at the same time, please choose one.");
            }
            return this;
        }

        /// <summary>
        ///     Determines the width of the vertical scrollbar. Since different browsers interpret this width 
        ///     differently (and it is difficult to calculate it in all browsers) this can be changed. (default: 18)
        /// </summary>
        /// <param name = "scrollOffset">Scroll offset</param>
        public Grid SetScrollOffset(int scrollOffset)
        {
            _scrollOffset = scrollOffset;
            return this;
        }

        /// <summary>
        ///     When enabled, selecting a row with setSelection scrolls the grid so that the selected row is visible. 
        ///     This is especially useful when we have a verticall scrolling grid and we use form editing with 
        ///     navigation buttons (next or previous row). On navigating to a hidden row, the grid scrolls so the 
        ///     selected row becomes visible. (default: false)
        /// </summary>
        /// <param name = "scrollRows">Boolean indicating if scrollrows is enabled</param>
        public Grid SetScrollRows(bool scrollRows)
        {
            _scrollRows = scrollRows;
            return this;
        }

        /// <summary>
        ///     This controls the timeout handler when scroll is set to 1. (default: 200 milliseconds)
        /// </summary>
        /// <param name = "scrollTimeout">Scroll timeout in milliseconds</param>
        /// <returns></returns>
        public Grid SetScrollTimeout(int scrollTimeout)
        {
            _scrollTimeout = scrollTimeout;
            return this;
        }

        /// <summary>
        ///     This option describes the type of calculation of the initial width of each column 
        ///     against the width of the grid. If the value is true and the value in width option 
        ///     is set then: Every column width is scaled according to the defined option width. 
        ///     Example: if we define two columns with a width of 80 and 120 pixels, but want the 
        ///     grid to have a 300 pixels - then the columns are recalculated as follow: 
        ///     1- column = 300(new width)/200(sum of all width)*80(column width) = 120 and 2 column = 300/200*120 = 180. 
        ///     The grid width is 300px. If the value is false and the value in width option is set then: 
        ///     The width of the grid is the width set in option. 
        ///     The column width are not recalculated and have the values defined in colModel. (default: true)
        /// </summary>
        /// <param name = "shrinkToFit">Boolean indicating if shrink to fit is enforced</param>
        public Grid SetShrinkToFit(bool shrinkToFit)
        {
            _shrinkToFit = shrinkToFit;
            return this;
        }

        /// <summary>
        ///     Determines how the search should be applied. If this option is set to true search is started when 
        ///     the user hits the enter key. If the option is false then the search is performed immediately after 
        ///     the user presses some character. (default: true
        /// </summary>
        /// <param name = "searchOnEnter">Indicates if search is started on enter</param>
        public Grid SetSearchOnEnter(bool searchOnEnter)
        {
            _searchOnEnter = searchOnEnter;
            return this;
        }

        /// <summary>
        ///     Enables toolbar searching / filtering
        /// </summary>
        /// <param name = "searchToolbar">Indicates if toolbar searching is enabled</param>
        public Grid SetSearchToolbar(bool searchToolbar)
        {
            _searchToolbar = searchToolbar;
            return this;
        }

        /// <summary>
        ///     When set to true adds clear button to clear all search entries (default: false)
        /// </summary>
        /// <param name = "searchClearButton"></param>
        /// <returns></returns>
        public Grid SetSearchClearButton(bool searchClearButton)
        {
            _searchClearButton = searchClearButton;
            return this;
        }

        /// <summary>
        ///     When set to true adds toggle button to toggle search toolbar (default: false)
        /// </summary>
        /// <param name = "searchToggleButton">Indicates if toggle button is displayed</param>
        public Grid SetSearchToggleButton(bool searchToggleButton)
        {
            _searchToggleButton = searchToggleButton;
            return this;
        }

        /// <summary>
        ///     If enabled all sort icons are visible for all columns which are sortable (default: false)
        /// </summary>
        /// <param name = "showAllSortIcons">Boolean indicating if all sorting icons should be displayed</param>
        public Grid SetShowAllSortIcons(bool showAllSortIcons)
        {
            _showAllSortIcons = showAllSortIcons;
            return this;
        }

        /// <summary>
        ///     Sets direction in which sort icons are displayed (default: vertical)
        /// </summary>
        /// <param name = "sortIconDirection">Direction in which sort icons are displayed</param>
        public Grid SetSortIconDirection(Direction sortIconDirection)
        {
            _sortIconDirection = sortIconDirection;
            return this;
        }

        /// <summary>
        ///     If enabled columns are sorted when header is clicked (default: true)
        ///     Warning, if disabled and setShowAllSortIcons is set to false, sorting will
        ///     be effectively disabled
        /// </summary>
        /// <param name = "sortOnHeaderClick">Boolean indicating if columns will sort on headerclick</param>
        /// <returns></returns>
        public Grid SetSortOnHeaderClick(bool sortOnHeaderClick)
        {
            _sortOnHeaderClick = sortOnHeaderClick;
            return this;
        }

        /// <summary>
        ///     The initial sorting name when we use datatypes xml or json (data returned from server). 
        ///     This parameter is added to the url. If set and the index (name) matches the name from the
        ///     colModel then by default an image sorting icon is added to the column, according to 
        ///     the parameter sortorder.
        /// </summary>
        /// <param name = "sortName"></param>
        public Grid SetSortName(string sortName)
        {
            _sortName = sortName;
            return this;
        }

        /// <summary>
        ///     The initial sorting order when we use datatypes xml or json (data returned from server).
        ///     This parameter is added to the url. Two possible values - asc or desc. (default: asc)
        /// </summary>
        /// <param name = "sortOrder">Sortorder</param>
        public Grid SetSortOrder(SortOrder sortOrder)
        {
            _sortOrder = sortOrder;
            return this;
        }

        /// <summary>
        ///     This option enabled the toolbar of the grid.  When we have two toolbars (can be set using setToolbarPosition)
        ///     then two elements (div) are automatically created. The id of the top bar is constructed like 
        ///     “t_”+id of the grid and the bottom toolbar the id is “tb_”+id of the grid. In case when 
        ///     only one toolbar is created we have the id as “t_” + id of the grid, independent of where 
        ///     this toolbar is created (top or bottom). You can use jquery to add elements to the toolbars.
        /// </summary>
        /// <param name = "toolbar">Boolean indicating if toolbar is enabled</param>
        public Grid SetToolbar(bool toolbar)
        {
            _toolbar = toolbar;
            return this;
        }

        /// <summary>
        ///     Sets toolbarposition (default: top)
        /// </summary>
        /// <param name = "toolbarPosition">Position of toolbar</param>
        public Grid SetToolbarPosition(ToolbarPosition toolbarPosition)
        {
            _toolbarPosition = toolbarPosition;
            return this;
        }

        /// <summary>
        ///     When enabled this option place a pager element at top of the grid below the caption 
        ///     (if available). If another pager is defined both can coexists and are refreshed in sync. 
        ///     (default: false)
        /// </summary>
        /// <param name = "topPager">Boolean indicating if toppager is enabled</param>
        public Grid SetTopPager(bool topPager)
        {
            _topPager = topPager;
            return this;
        }

        /// <summary>
        ///     The url of the file that holds the request
        /// </summary>
        /// <param name = "url">Data url</param>
        public Grid SetUrl(string url)
        {
            _url = url;
            return this;
        }

        /// <summary>
        ///     If true, jqGrid displays the beginning and ending record number in the grid, 
        ///     out of the total number of records in the query. 
        ///     This information is shown in the pager bar (bottom right by default)in this format: 
        ///     “View X to Y out of Z”. 
        ///     If this value is true, there are other parameters that can be adjusted, 
        ///     including 'emptyrecords' and 'recordtext'. (default: false)
        /// </summary>
        /// <param name = "viewRecords">Boolean indicating if recordnumbers are shown in grid</param>
        public Grid SetViewRecords(bool viewRecords)
        {
            _viewRecords = viewRecords;
            return this;
        }

        /// <summary>
        ///     If this option is not set, the width of the grid is a sum of the widths of the columns 
        ///     defined in the colModel (in pixels). If this option is set, the initial width of each 
        ///     column is set according to the value of shrinkToFit option.
        /// </summary>
        /// <param name = "width">Width in pixels</param>
        public Grid SetWidth(int width)
        {
            _width = width;
            return this;
        }

        /// <summary>
        ///     This event fires after each inserted row.
        ///     Variables available in call:
        ///     'rowid': Id of the inserted row 
        ///     'rowdata': An array of the data to be inserted into the row. This is array of type name- 
        ///     value, where the name is a name from colModel 
        ///     'rowelem': The element from the response. If the data is xml this is the xml element of the row; 
        ///     if the data is json this is array containing all the data for the row 
        ///     Warning: this event does not fire if gridview option is set to true
        /// </summary>
        /// <param name = "onAfterInsertRow">Script to be executed</param>
        public Grid OnAfterInsertRow(string onAfterInsertRow)
        {
            _onAfterInsertRow = onAfterInsertRow;
            return this;
        }

        /// <summary>
        ///     This event fires before requesting any data. Does not fire if datatype is function
        ///     Variables available in call: None
        /// </summary>
        /// <param name = "onBeforeRequest">Script to be executed</param>
        public Grid OnBeforeRequest(string onBeforeRequest)
        {
            _onBeforeRequest = onBeforeRequest;
            return this;
        }

        /// <summary>
        ///     This event fires when the user clicks on the row, but before selecting it.
        ///     Variables available in call:
        ///     'rowid': The id of the row. 
        ///     'e': The event object 
        ///     This event should return boolean true or false. If the event returns true the selection 
        ///     is done. If the event returns false the row is not selected and any other action if defined 
        ///     does not occur.
        /// </summary>
        /// <param name = "onBeforeSelectRow">Script to be executed</param>
        public Grid OnBeforeSelectRow(string onBeforeSelectRow)
        {
            _onBeforeSelectRow = onBeforeSelectRow;
            return this;
        }

        /// <summary>
        ///     This fires after all the data is loaded into the grid and all the other processes are complete. 
        ///     Also the event fires independent from the datatype parameter and after sorting paging and etc.
        ///     Variables available in call: None
        /// </summary>
        /// <param name = "onGridComplete">Script to be executed</param>
        public Grid OnGridComplete(string onGridComplete)
        {
            _onGridComplete = onGridComplete;
            return this;
        }

        /// <summary>
        ///     A pre-callback to modify the XMLHttpRequest object (xhr) before it is sent. Use this to set 
        ///     custom headers etc. The XMLHttpRequest is passed as the only argument.
        ///     Variables available in call:
        ///     'xhr': The XMLHttpRequest
        /// </summary>
        /// <param name = "onLoadBeforeSend">Script to be executed</param>
        public Grid OnLoadBeforeSend(string onLoadBeforeSend)
        {
            _onLoadBeforeSend = onLoadBeforeSend;
            return this;
        }

        /// <summary>
        ///     This event is executed immediately after every server request. 
        ///     Variables available in call:
        ///     'xhr': The XMLHttpRequest
        /// </summary>
        /// <param name = "onLoadComplete">Script to be executed</param>
        public Grid OnLoadComplete(string onLoadComplete)
        {
            _onLoadComplete = onLoadComplete;
            return this;
        }

        /// <summary>
        ///     A function to be called if the request fails.
        ///     Variables available in call:
        ///     'xhr': The XMLHttpRequest
        ///     'status': String describing the type of error
        ///     'error': Optional exception object, if one occurred
        /// </summary>
        /// <param name = "onLoadError">Script to be executed</param>
        public Grid OnLoadError(string onLoadError)
        {
            _onLoadError = onLoadError;
            return this;
        }

        /// <summary>
        ///     Fires when we click on a particular cell in the grid.
        ///     Variables available in call:
        ///     'rowid': The id of the row 
        ///     'iCol': The index of the cell,
        ///     'cellcontent': The content of the cell,
        ///     'e': The event object element where we click.
        ///     (Be aware that this available when we are not using cell editing module 
        ///     and is disabled when using cell editing).
        /// </summary>
        /// <param name = "onCellSelect">Script to be executed</param>
        public Grid OnCellSelect(string onCellSelect)
        {
            _onCellSelect = onCellSelect;
            return this;
        }

        /// <summary>
        ///     Raised immediately after row was double clicked. 
        ///     Variables available in call:
        ///     'rowid': The id of the row, 
        ///     'iRow': The index of the row (do not mix this with the rowid),
        ///     'iCol': The index of the cell. 
        ///     'e': The event object
        /// </summary>
        /// <param name = "onDblClickRow">Script to be executed</param>
        public Grid OnDblClickRow(string onDblClickRow)
        {
            _onDblClickRow = onDblClickRow;
            return this;
        }

        /// <summary>
        ///     Fires after clicking hide or show grid (hidegrid:true)
        ///     Variables available in call:
        ///     'gridstate': The state of the grid - can have two values - visible or hidden
        /// </summary>
        /// <param name = "onHeaderClick">Script to be executed</param>
        public Grid OnHeaderClick(string onHeaderClick)
        {
            _onHeaderClick = onHeaderClick;
            return this;
        }

        /// <summary>
        ///     This event fires after click on [page button] and before populating the data. 
        ///     Also works when the user enters a new page number in the page input box 
        ///     (and presses [Enter]) and when the number of requested records is changed via 
        ///     the select box.
        ///     If this event returns 'stop' the processing is stopped and you can define your 
        ///     own custom paging
        ///     Variables available in call:
        ///     'pgButton': first,last,prev,next in case of button click, records in case when 
        ///     a number of requested rows is changed and user when the user change the number of the requested page
        /// </summary>
        /// <param name = "onPaging">Script to be executed</param>
        public Grid OnPaging(string onPaging)
        {
            _onPaging = onPaging;
            return this;
        }

        /// <summary>
        ///     Raised immediately after row was right clicked. 
        ///     Variables available in call:
        ///     'rowid': The id of the row, 
        ///     'iRow': The index of the row (do not mix this with the rowid),
        ///     'iCol': The index of the cell. 
        ///     'e': The event object
        ///     Warning - this event does not work in Opera browsers, since Opera does not support oncontextmenu event
        /// </summary>
        /// <param name = "onRightClickRow">Script to be executed</param>
        public Grid OnRightClickRow(string onRightClickRow)
        {
            _onRightClickRow = onRightClickRow;
            return this;
        }

        /// <summary>
        ///     This event fires when multiselect option is true and you click on the header checkbox. 
        ///     Variables available in call:
        ///     'aRowids':  Array of the selected rows (rowid's). 
        ///     'status': Boolean variable determining the status of the header check box - true if checked, false if not checked. 
        ///     Be awareS that the aRowids alway contain the ids when header checkbox is checked or unchecked.
        /// </summary>
        /// <param name = "onSelectAll">Script to be executed</param>
        public Grid OnSelectAll(string onSelectAll)
        {
            _onSelectAll = onSelectAll;
            return this;
        }


        /// <summary>
        ///     Raised immediately when row is clicked. 
        ///     Variables available in function call:
        ///     'rowid': The id of the row,
        ///     'status': Tthe status of the selection. Can be used when multiselect is set to true. 
        ///     true if the row is selected, false if the row is deselected.
        ///     <param name = "onSelectRow">Script to be executed</param>
        /// </summary>
        public Grid OnSelectRow(string onSelectRow)
        {
            _onSelectRow = onSelectRow;
            return this;
        }


        /// <summary>
        ///     Raised immediately after sortable column was clicked and before sorting the data.
        ///     Variables available in call:
        ///     'index': The index name from colModel
        ///     'iCol': The index of column, 
        ///     'sortorder': The new sorting order - can be 'asc' or 'desc'. 
        ///     If this event returns 'stop' the sort processing is stopped and you can define your own custom sorting
        /// </summary>
        /// <param name = "onSortCol">Script to be executed</param>
        public Grid OnSortCol(string onSortCol)
        {
            _onSortCol = onSortCol;
            return this;
        }

        /// <summary>
        ///     Event which is called when we start resizing a column. 
        ///     Variables available in call:
        ///     'event':  The event object
        ///     'index': The index of the column in colModel.
        /// </summary>
        /// <param name = "onResizeStart">Script to be executed</param>
        public Grid OnResizeStart(string onResizeStart)
        {
            _onResizeStart = onResizeStart;
            return this;
        }

        /// <summary>
        ///     Event which is called after the column is resized.
        ///     Variables available in call:
        ///     'newwidth': The new width of the column
        ///     'index': The index of the column in colModel.
        /// </summary>
        /// <param name = "onResizeStop">Script to be executed</param>
        public Grid OnResizeStop(string onResizeStop)
        {
            _onResizeStop = onResizeStop;
            return this;
        }

        /// <summary>
        ///     If this event is set it can serialize the data passed to the ajax request. 
        ///     The function should return the serialized data. This event can be used when 
        ///     custom data should be passed to the server - e.g - JSON string, XML string and etc. 
        ///     Variables available in call:
        ///     'postData': Posted data
        /// </summary>
        /// <param name = "onSerializeGridData">Script to be executed</param>
        public Grid OnSerializeGridData(string onSerializeGridData)
        {
            _onSerializeGridData = onSerializeGridData;
            return this;
        }

        /// <summary>
        /// JSON data is handled in a fashion very similar to that of xml data. What is important is that the definition of the jsonReader matches the data being received 
        /// </summary>
        /// <param name="jsonReader"></param>
        /// <returns></returns>
        public Grid SetJsonReader(JsonReader jsonReader)
        {
            _jsonReader = jsonReader;
            return this;
        }

        public string RenderJavascript()
        {
            // Create javascript
            var script = new StringBuilder();

            // Start script
           script.AppendLine("jQuery(document).ready(function () {");
            script.AppendLine("jQuery('#" + _id + "').jqGrid({");

            // Altrows
            if (_altRows.HasValue)
                script.AppendFormat("altRows:{0},", _altRows.ToString().ToLower()).AppendLine();

            // Altclass
            if (!string.IsNullOrWhiteSpace(_altClass)) script.AppendFormat("altclass:'{0}',", _altClass).AppendLine();

            // Autoencode
            if (_autoEncode.HasValue)
                script.AppendFormat("autoencode:{0},", _autoEncode.ToString().ToLower()).AppendLine();

            // Autowidth
            if (_autoWidth.HasValue)
                script.AppendFormat("autowidth:{0},", _autoWidth.ToString().ToLower()).AppendLine();

            // Caption
            if (!string.IsNullOrWhiteSpace(_caption)) script.AppendFormat("caption:'{0}',", _caption).AppendLine();

            // Datatype
            script.AppendLine(string.Format("datatype:'{0}',", _dataType.ToString().ToLower()));

            if (_dataType == DataType.Json && _jsonReader != null)
            {
                script.AppendLine("jsonReader:{'repeatitems':" + _jsonReader.RepeatItems.ToString().ToLower() + ", 'id': '" + _jsonReader.Id + "' },");
            }

            // Emptyrecords
            if (!string.IsNullOrWhiteSpace(_emptyRecords))
                script.AppendFormat("emptyrecords:'{0}',", _emptyRecords).AppendLine();

            // FooterRow
            if (_footerRow.HasValue)
                script.AppendFormat("footerrow:{0},", _footerRow.ToString().ToLower()).AppendLine();

            // Forcefit
            if (_forceFit.HasValue)
                script.AppendFormat("forceFit:{0},", _forceFit.ToString().ToLower()).AppendLine();

            // Gridview
            if (_gridView.HasValue)
                script.AppendFormat("gridview:{0},", _gridView.ToString().ToLower()).AppendLine();

            // HeaderTitles
            if (_headerTitles.HasValue)
                script.AppendFormat("headertitles:{0},", _headerTitles.ToString().ToLower()).AppendLine();

            // Height (set 100% if no value is specified except when scroll is set to true otherwise layout is not as it is supposed to be)
            if (!_height.HasValue)
            {
                if ((!_scroll.HasValue || _scroll == false) && !_scrollInt.HasValue)
                    script.AppendFormat("height:'{0}',", "100%").AppendLine();
            }
            else script.AppendFormat("height:{0},", _height).AppendLine();

            // Hiddengrid
            if (_hiddenGrid.HasValue)
                script.AppendFormat("hiddengrid:{0},", _hiddenGrid.ToString().ToLower()).AppendLine();

            // Hidegrid
            if (_hideGrid.HasValue)
                script.AppendFormat("hidegrid:{0},", _hideGrid.ToString().ToLower()).AppendLine();

            // HoverRows
            if (_hoverRows.HasValue)
                script.AppendFormat("hoverrows:{0},", _hoverRows.ToString().ToLower()).AppendLine();

            // Loadonce
            if (_loadOnce.HasValue)
                script.AppendFormat("loadonce:{0},", _loadOnce.ToString().ToLower()).AppendLine();

            // Loadtext
            if (!string.IsNullOrWhiteSpace(_loadText)) script.AppendFormat("loadtext:'{0}',", _loadText).AppendLine();

            // LoadUi
            if (_loadUi.HasValue) script.AppendFormat("loadui:'{0}',", _loadUi.ToString().ToLower()).AppendLine();

            // MultiBoxOnly
            if (_multiBoxOnly.HasValue)
                script.AppendFormat("multiboxonly:{0},", _multiBoxOnly.ToString().ToLower()).AppendLine();

            // MultiKey
            if (_multiKey.HasValue) script.AppendFormat("multikey:'{0}',", _multiKey.ToString().ToLower()).AppendLine();

            // MultiSelect
            if (_multiSelect.HasValue)
                script.AppendFormat("multiselect:{0},", _multiSelect.ToString().ToLower()).AppendLine();

            // MultiSelectWidth
            if (_multiSelectWidth.HasValue)
                script.AppendFormat("multiselectWidth:{0},", _multiSelectWidth).AppendLine();

            // Page
            if (_page.HasValue) script.AppendFormat("page:{0},", _page).AppendLine();

            // Pager
            if (!string.IsNullOrWhiteSpace(_pager)) script.AppendFormat("pager:'#{0}',", _pager).AppendLine();

            // PagerPos
            if (_pagerPos.HasValue) script.AppendFormat("pagerpos:'{0}',", _pagerPos.ToString().ToLower()).AppendLine();

            // PgButtons
            if (_pgButtons.HasValue)
                script.AppendFormat("pgbuttons:{0},", _pgButtons.ToString().ToLower()).AppendLine();

            // PgInput
            if (_pgInput.HasValue)
                script.AppendFormat("pginput:{0},", _pgInput.ToString().ToLower()).AppendLine();

            // PGText
            if (!string.IsNullOrWhiteSpace(_pgText)) script.AppendFormat("pgtext:'{0}',", _pgText).AppendLine();

            // RecordPos
            if (_recordPos.HasValue) script.AppendFormat("recordpos:'{0}',", _recordPos.ToString().ToLower()).AppendLine();

            // RecordText
            if (!string.IsNullOrWhiteSpace(_recordText))
                script.AppendFormat("recordtext:'{0}',", _recordText).AppendLine();

            // Request Type
            if (_requestType.HasValue) script.AppendFormat("mtype:'{0}',", _requestType.ToString().ToLower()).AppendLine();

            // ResizeClass
            if (!string.IsNullOrWhiteSpace(_resizeClass))
                script.AppendFormat("resizeclass:'{0}',", _resizeClass).AppendLine();

            // Rowlist
            if (_rowList != null)
                script.AppendFormat("rowList:[{0}],",
                                    string.Join(",", ((from p in _rowList select p.ToString()).ToArray()))).AppendLine();

            // Rownum
            if (_rowNum.HasValue) script.AppendFormat("rowNum:{0},", _rowNum).AppendLine();

            // Rownumbers
            if (_rowNumbers.HasValue)
                script.AppendFormat("rownumbers:{0},", _rowNumbers.ToString().ToLower()).AppendLine();

            // RowNumWidth
            if (_rowNumWidth.HasValue) script.AppendFormat("rownumWidth:{0},", _rowNumWidth).AppendLine();

            // Scroll (setters make sure either scroll or scrollint is set, never both)
            if (_scroll.HasValue) script.AppendFormat("scroll:{0},", _scroll.ToString().ToLower()).AppendLine();
            if (_scrollInt.HasValue) script.AppendFormat("scroll:{0},", _scrollInt).AppendLine();

            // ScrollOffset
            if (_scrollOffset.HasValue) script.AppendFormat("scrollOffset:{0},", _scrollOffset).AppendLine();

            // ScrollRows
            if (_scrollRows.HasValue)
                script.AppendFormat("scrollrows:{0},", _scrollRows.ToString().ToLower()).AppendLine();

            // ScrollTimeout
            if (_scrollTimeout.HasValue) script.AppendFormat("scrollTimeout:{0},", _scrollTimeout).AppendLine();

            // Sortname
            if (!string.IsNullOrWhiteSpace(_sortName)) script.AppendFormat("sortname:'{0}',", _sortName).AppendLine();

            // Sorticons
            if (_showAllSortIcons.HasValue || _sortIconDirection.HasValue || _sortOnHeaderClick.HasValue)
            {
                // Set defaults
                if (!_showAllSortIcons.HasValue) _showAllSortIcons = false;
                if (!_sortIconDirection.HasValue) _sortIconDirection = Direction.Vertical;
                if (!_sortOnHeaderClick.HasValue) _sortOnHeaderClick = true;

                script.AppendFormat("viewsortcols:[{0},'{1}',{2}],", _showAllSortIcons.ToString().ToLower(),
                                    _sortIconDirection.ToString().ToLower(), _sortOnHeaderClick.ToString().ToLower()).AppendLine();
            }

            // Shrink to fit
            if (_shrinkToFit.HasValue)
                script.AppendFormat("shrinkToFit:{0},", _shrinkToFit.ToString().ToLower()).AppendLine();

            // Sortorder
            if (_sortOrder.HasValue) script.AppendFormat("sortorder:'{0}',", _sortOrder.ToString().ToLower()).AppendLine();

            // Toolbar
            if (_toolbar.HasValue)
                script.AppendFormat("toolbar:[{0},'{1}'],", _toolbar.ToString().ToLower(), _toolbarPosition.ToString().ToLower()).
                    AppendLine();

            // Toppager
            if (_topPager.HasValue)
                script.AppendFormat("toppager:{0},", _topPager.ToString().ToLower()).AppendLine();

            // Url
            if (!string.IsNullOrWhiteSpace(_url)) script.AppendFormat("url:'{0}',", _url).AppendLine();

            // View records
            if (_viewRecords.HasValue)
                script.AppendFormat("viewrecords:{0},", _viewRecords.ToString().ToLower()).AppendLine();

            // Width
            if (_width.HasValue) script.AppendFormat("width:'{0}',", _width).AppendLine();

            // onAfterInsertRow
            if (!string.IsNullOrWhiteSpace(_onAfterInsertRow))
                script.AppendFormat("afterInsertRow: function(rowid, rowdata, rowelem) {{{0}}},", _onAfterInsertRow).
                    AppendLine();

            // onBeforeRequest
            if (!string.IsNullOrWhiteSpace(_onBeforeRequest))
                script.AppendFormat("beforeRequest: function() {{{0}}},", _onBeforeRequest).AppendLine();

            // onBeforeSelectRow
            if (!string.IsNullOrWhiteSpace(_onBeforeSelectRow))
                script.AppendFormat("beforeSelectRow: function(rowid, e) {{{0}}},", _onBeforeSelectRow).AppendLine();

            // onGridComplete
            if (!string.IsNullOrWhiteSpace(_onGridComplete))
                script.AppendFormat("gridComplete: function() {{{0}}},", _onGridComplete).AppendLine();

            // onLoadBeforeSend
            if (!string.IsNullOrWhiteSpace(_onLoadBeforeSend))
                script.AppendFormat("loadBeforeSend: function(xhr) {{{0}}},", _onLoadBeforeSend).AppendLine();

            // onLoadComplete
            if (!string.IsNullOrWhiteSpace(_onLoadComplete))
                script.AppendFormat("loadComplete: function(xhr) {{{0}}},", _onLoadComplete).AppendLine();

            // onLoadError
            if (!string.IsNullOrWhiteSpace(_onLoadError))
                script.AppendFormat("loadError: function(xhr, status, error) {{{0}}},", _onLoadError).AppendLine();

            // onCellSelect
            if (!string.IsNullOrWhiteSpace(_onCellSelect))
                script.AppendFormat("onCellSelect: function(rowid, iCol, cellcontent, e) {{{0}}},", _onCellSelect).
                    AppendLine();

            // onDblClickRow
            if (!string.IsNullOrWhiteSpace(_onDblClickRow))
                script.AppendFormat("ondblClickRow: function(rowid, iRow, iCol, e) {{{0}}},", _onDblClickRow).AppendLine
                    ();

            // onHeaderClick
            if (!string.IsNullOrWhiteSpace(_onHeaderClick))
                script.AppendFormat("onHeaderClick: function(gridstate) {{{0}}},", _onHeaderClick).AppendLine();

            // onPaging
            if (!string.IsNullOrWhiteSpace(_onPaging))
                script.AppendFormat("onPaging: function(pgButton) {{{0}}},", _onPaging).AppendLine();

            // onRightClickRow
            if (!string.IsNullOrWhiteSpace(_onRightClickRow))
                script.AppendFormat("onRightClickRow: function(rowid, iRow, iCol, e) {{{0}}},", _onRightClickRow).
                    AppendLine();

            // onSelectAll
            if (!string.IsNullOrWhiteSpace(_onSelectAll))
                script.AppendFormat("onSelectAll: function(aRowids, status) {{{0}}},", _onSelectAll).AppendLine();

            // onSelectRow event
            if (!string.IsNullOrWhiteSpace(_onSelectRow))
                script.AppendFormat("onSelectRow: function(rowid, status) {{{0}}},", _onSelectRow).AppendLine();

            // onSortCol
            if (!string.IsNullOrWhiteSpace(_onSortCol))
                script.AppendFormat("onSortCol: function(index, iCol, sortorder) {{{0}}},", _onSortCol).AppendLine();

            // onResizeStart
            if (!string.IsNullOrWhiteSpace(_onResizeStart))
                script.AppendFormat("resizeStart: function(jqGridEvent, index) {{{0}}},", _onResizeStart).AppendLine();

            // onResizeStop
            if (!string.IsNullOrWhiteSpace(_onResizeStop))
                script.AppendFormat("resizeStop: function(newwidth, index) {{{0}}},", _onResizeStop).AppendLine();

            // onSerializeGridData
            if (!string.IsNullOrWhiteSpace(_onSerializeGridData))
                script.AppendFormat("serializeGridData: function(postData) {{{0}}},", _onSerializeGridData).AppendLine();

            // Colmodel
            script.AppendLine("colModel: [");
            var colModel = string.Join(",", ((from c in _columns select c.ToString()).ToArray()));
            script.AppendLine(colModel);
            script.AppendLine("],");

            // End jqGrid call
            script.AppendLine("});");

            if (_searchToolbar == true && !string.IsNullOrWhiteSpace(_pager) &&
                (_searchClearButton.HasValue && _searchClearButton == true || _searchToggleButton.HasValue && _searchToggleButton == true))
            {
                script.AppendLine("jQuery('#" + _id + "').jqGrid('navGrid',\"#" + _pager +
                                                 "\",{edit:false,add:false,del:false,search:false,refresh:false}); ");
            }

            // Search clear button
            if (_searchToolbar == true && _searchClearButton.HasValue && !string.IsNullOrWhiteSpace(_pager) &&
                _searchClearButton == true)
            {
                script.AppendLine("jQuery('#" + _id + "').jqGrid('navButtonAdd',\"#" + _pager +
                                 "\",{caption:\"Clear\",title:\"Clear Search\",buttonicon :'ui-icon-refresh', onClickButton:function(){mygrid[0].clearToolbar(); }}); ");
            }

            if (_searchToolbar == true && _searchToggleButton.HasValue && !string.IsNullOrWhiteSpace(_pager) && _searchToggleButton == true)
            {
                script.AppendLine("jQuery('#" + _id + "').jqGrid('navButtonAdd',\"#" + _pager +
                              "\",{caption:\"Toggle Search\",title:\"Toggle Search\",buttonicon :'ui-icon-refresh', onClickButton:function(){mygrid[0].toggleToolbar(); }}); ");

            }

            // Search toolbar
            if (_searchToolbar == true)
            {
                script.Append("jQuery('#" + _id + "').jqGrid('filterToolbar', {stringResult:true");
                if (_searchOnEnter.HasValue)
                    script.AppendFormat(", searchOnEnter:{0}", _searchOnEnter.ToString().ToLower());
                script.AppendLine("});");
            }


            // End script
            script.AppendLine("});");
      
            // Insert grid id where needed (in columns)
            script.Replace("##gridid##", _id);

            return script.ToString();
        }

        /// <summary>
        ///     Creates and returns javascript + required html elements to render grid
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Create javascript
            var script = new StringBuilder();

            // Start script
            script.AppendLine("<script type=\"text/javascript\">");
            script.Append(RenderJavascript());
            script.AppendLine("</script>");

            // Create table which is used to render grid
            var table = new StringBuilder();
            table.AppendFormat("<table id=\"{0}\"></table>", _id);

            // Create pager element if is set
            var pager = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(_pager))
            {
                pager.AppendFormat("<div id=\"{0}\"></div>", _pager);
            }

            // Create toppager element if is set
            var topPager = new StringBuilder();
            if (_topPager == true)
            {
                topPager.AppendFormat("<div id=\"{0}_toppager\"></div>", _id);
            }

            // Insert grid id where needed (in columns)
            script.Replace("##gridid##", _id);

            // Return script + required elements
            return script + table.ToString() + pager + topPager;
        }

        public string ToHtmlString()
        {
            return ToString();
        }
    }
}