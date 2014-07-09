using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcJqGrid.Enums;
using MvcJqGrid.Extensions;

namespace MvcJqGrid
{
    public class Column
    {
        private readonly List<string> _classes = new List<string>();
        private readonly string _columnName;
        private Align? _align;
        private string _customFormatter;
        private SortOrder? _firstSortOrder;
        private bool? _fixedWidth;
        private KeyValuePair<Formatters, string>? _formatter;
        private bool? _hidden;
        private string _index;
        private bool? _key;
        private string _label;
        private bool? _resizeable;
        private bool? _search;
        private bool? _clearSearch;
        private string _searchDateFormat;
        private IDictionary<string, string> _searchTerms;
        private Searchtype? _searchType;
        private bool? _sortable;
        private bool? _title;
        private int? _width;
        private string _defaultSearchValue;
        private bool? _expandableInTree;
        private List<string> _searchOptions = new List<string>();

        private bool? _editable;
        private EditType? _editType;
        private EditOptions _editOptions;
        private EditRules _editRules;
        private EditFormOptions _editFormOptions;
        private SortType? _sortType;
                
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name = "columnName">Name of column, cannot be blank or set to 'subgrid', 'cb', and 'rn'</param>
        public Column(string columnName)
        {
            // Make sure columnname is not left blank
            if (columnName.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("No columnname specified");
            }

            // Make sure columnname is not part of the reserved names collection
            var reservedNames = new[] {"subgrid", "cb", "rn"};

            if (reservedNames.Contains(columnName))
            {
                throw new ArgumentException("Columnname '" + columnName + "' is reserved");
            }

            // Set columnname
            _columnName = columnName;

            // Set index equal to columnname by default, can be overriden by setter
            _index = columnName;
        }

        /// <summary>
        ///     This option allow to add a class to to every cell on that column. In the grid css 
        ///     there is a predefined class ui-ellipsis which allow to attach ellipsis to a 
        ///     particular row. Also this will work in FireFox too.
        ///     Multiple calls to this function are allowed to set multiple classes
        /// </summary>
        /// <param name = "className">Classname</param>
        public Column AddClass(string className)
        {
            _classes.Add(className);
            return this;
        }

        /// <summary>
        ///     Set dateformat of datepicker when SearchType is set to datepicker (default: dd-mm-yy)
        /// </summary>
        /// <param name = "searchDateFormat">Dateformat</param>
        public Column SetSearchDateFormat(string searchDateFormat)
        {
            _searchDateFormat = searchDateFormat;
            return this;
        }

        /// <summary>
        ///     Set searchterms if search type of this column is set to type select
        /// </summary>
        /// <param name = "searchTerms">Searchterm to add to dropdownlist</param>
        public Column SetSearchTerms(string[] searchTerms)
        {
            _searchTerms = searchTerms.ToDictionary(searchterm => searchterm);

            return this;
        }

        /// <summary>
        ///     When set to false the X icon at end of search field which is responsible to clear the search data is disabled. the default value is true
        /// </summary>
        /// <param name = "clearSearch">Clear search (x) on or off</param>
        public Column SetClearSearch(bool clearSearch)
        {
            _clearSearch = clearSearch;

            return this;
        }

        /// <summary>
        ///     Set searchterms if search type of this column is set to type select
        /// </summary>
        /// <param name = "searchTerms">Searchterm to add to dropdownlist</param>
        public Column SetSearchTerms(IDictionary<string, string> searchTerms)
        {
            _searchTerms = searchTerms;
            return this;
        }

        /// <summary>
        ///     Defines the alignment of the cell in the Body layer, not in header cell. 
        ///     Possible values: left, center, right. (default: left)
        /// </summary>
        /// <param name = "align">Alignment of column (center, right, left</param>
        public Column SetAlign(Align align)
        {
            _align = align;
            return this;
        }

        /// <summary>
        ///     If set to asc or desc, the column will be sorted in that direction on first 
        ///     sort.Subsequent sorts of the column will toggle as usual (default: null)
        /// </summary>
        /// <param name = "firstSortOrder">First sort order</param>
        public Column SetFirstSortOrder(SortOrder firstSortOrder)
        {
            _firstSortOrder = firstSortOrder;
            return this;
        }

        /// <summary>
        ///     If set to true this option does not allow recalculation of the width of the 
        ///     column if shrinkToFit option is set to true. Also the width does not change 
        ///     if a setGridWidth method is used to change the grid width. (default: false)
        /// </summary>
        /// <param name = "fixedWidth">Indicates if width of column is fixed</param>
        public Column SetFixedWidth(bool fixedWidth)
        {
            _fixedWidth = fixedWidth;
            return this;
        }

        /// <summary>
        ///     Sets formatter with default formatoptions (as set in language file)
        /// </summary>
        /// <param name = "formatter">Formatter</param>
        public Column SetFormatter(Formatters formatter)
        {
            if (!_customFormatter.IsNullOrWhiteSpace())
            {
                throw new Exception(
                    "You cannot set a formatter and a customformatter at the same time, please choose one.");
            }
            _formatter = new KeyValuePair<Formatters, string>(formatter, "");
            return this;
        }

        /// <summary>
        ///     Sets formatter with formatoptions (see jqGrid documentation for more info on formatoptions)
        /// </summary>
        /// <param name = "formatter">Formatter</param>
        /// <param name = "formatOptions">Formatoptions</param>
        public Column SetFormatter(Formatters formatter, string formatOptions)
        {
            if (!_customFormatter.IsNullOrWhiteSpace())
            {
                throw new Exception(
                    "You cannot set a formatter and a customformatter at the same time, please choose one.");
            }
            _formatter = new KeyValuePair<Formatters, string>(formatter, formatOptions);
            return this;
        }

        /// <summary>
        ///     Sets custom formatter. Usually this is a function. When set in the formatter option 
        ///     this should not be enclosed in quotes and not entered with () - 
        ///     just specify the name of the function
        ///     The following variables are passed to the function:
        ///     'cellvalue': The value to be formated (pure text).
        ///     'options': Object { rowId: rid, colModel: cm} where rowId - is the id of the row colModel is 
        ///     the object of the properties for this column getted from colModel array of jqGrid
        ///     'rowobject': Row data represented in the format determined from datatype option. 
        ///     If we have datatype: xml/xmlstring - the rowObject is xml node,provided according to the rules 
        ///     from xmlReader If we have datatype: json/jsonstring - the rowObject is array, provided according to 
        ///     the rules from jsonReader
        /// </summary>
        /// <param name = "customFormatter"></param>
        /// <returns></returns>
        public Column SetCustomFormatter(string customFormatter)
        {
            if (_formatter.HasValue)
            {
                throw new Exception(
                    "You cannot set a formatter and a customformatter at the same time, please choose one.");
            }
            _customFormatter = customFormatter;
            return this;
        }

        /// <summary>
        ///     Defines if this column is hidden at initialization. (default: false)
        /// </summary>
        /// <param name = "hidden">Boolean indicating if column is hidden</param>
        public Column SetHidden(bool hidden)
        {
            _hidden = hidden;
            return this;
        }

        /// <summary>
        ///     Set the index name when sorting. Passed as sidx parameter. (default: Same as columnname)
        /// </summary>
        /// <param name = "index">Name of index</param>
        public Column SetIndex(string index)
        {
            _index = index;
            return this;
        }

        /// <summary>
        /// Gets index of column
        /// </summary>
        internal string Index
        {
            get { return _index; }
        }

        /// <summary>
        ///     In case if there is no id from server, this can be set as as id for the unique row id. 
        ///     Only one column can have this property. If there are more than one key the grid finds 
        ///     the first one and the second is ignored. (default: false)
        /// </summary>
        /// <param name = "key">Indicates if key is set</param>
        public Column SetKey(bool key)
        {
            _key = key;
            return this;
        }

        /// <summary>
        ///     Defines the heading for this column. If empty, the heading for this column comes from the name property.
        /// </summary>
        /// <param name = "label">Label name of column</param>
        public Column SetLabel(string label)
        {
            _label = label;
            return this;
        }

        /// <summary>
        ///     Defines if the column can be resized (default: true)
        /// </summary>
        /// <param name = "resizeable">Indicates if the column is resizable</param>
        public Column SetResizeable(bool resizeable)
        {
            _resizeable = resizeable;
            return this;
        }

        /// <summary>
        ///     When used in search modules, disables or enables searching on that column. (default: true)
        /// </summary>
        /// <param name = "search">Indicates if searching for this column is enabled</param>
        public Column SetSearch(bool search)
        {
            _search = search;
            return this;
        }

        /// <summary>
        ///     Sets the SearchType of this column (text, select or datepicker) (default: text)
        ///     WarningSS: To use datepicker jQueryUI javascript should be included
        /// </summary>
        /// <param name = "searchType">Search type</param>
        public Column SetSearchType(Searchtype searchType)
        {
            _searchType = searchType;
            return this;
        }

        /// <summary>
        ///     Indicates if column is sortable (default: true)
        /// </summary>
        /// <param name = "sortable">Indicates if column is sortable</param>
        public Column SetSortable(bool sortable)
        {
            _sortable = sortable;
            return this;
        }

        /// <summary>
        ///     If this option is false the title is not displayed in that column when we hover over a cell (default: true)
        /// </summary>
        /// <param name = "title">Indicates if title is displayed when hovering over cell</param>
        public Column SetTitle(bool title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        ///     Set the initial width of the column, in pixels. This value currently can not be set as percentage (default: 150)
        /// </summary>
        /// <param name = "width">Width in pixels</param>
        public Column SetWidth(int width)
        {
            _width = width;
            return this;
        }

        /// <summary>
        /// Sets default search value
        /// </summary>
        /// <param name="defaultSearchValue">Default serach value</param>
        /// <returns>Column</returns>
        public Column SetDefaultSearchValue(string defaultSearchValue)
        {
            _defaultSearchValue = defaultSearchValue;
            return this;
        }

        /// <summary>
        /// Sets the column as expandable when using TreeGrid
        /// </summary>
        /// <returns></returns>
        public Column SetAsExpandable()
        {
            _expandableInTree = true;
            return this;
        }

        /// <summary>
        /// Returns if there is an default search value set
        /// </summary>
        internal bool HasDefaultSearchValue
        {
            get { return !_defaultSearchValue.IsNullOrWhiteSpace(); }
        }

        /// <summary>
        /// Gets default search value
        /// </summary>
        internal string DefaultSearchValue { get { return _defaultSearchValue; } }

        /// <summary>
        /// Identify if a column is set as key column
        /// </summary>
        public bool IsKey
        {
            get { return _key ?? false; }
        }

        /// <summary>
        /// Identify a column if set as expandable in tree grid
        /// </summary>
        public bool IsExpandable
        {
            get { return _expandableInTree ?? false; }
        }

        public string Name
        {
            get { return _columnName; }
        }

        /// <summary>
        /// Sets search option for column
        /// </summary>
        /// <param name="searchOption">Search option</param>
        public Column SetSearchOption(SearchOptions searchOption)
        {
            var searchOptionValues = Enum.GetValues(typeof(SearchOptions));
            foreach (SearchOptions value in searchOptionValues)
            {
                if ((searchOption & value) == value)
                {
                    switch (value)
                    {
                        case SearchOptions.Equal:
                            _searchOptions.Add("eq");
                            break;
                        case SearchOptions.NotEqual:
                            _searchOptions.Add("ne");
                            break;
                        case SearchOptions.Less:
                            _searchOptions.Add("lt");
                            break;
                        case SearchOptions.LessOrEqual:
                            _searchOptions.Add("le");
                            break;
                        case SearchOptions.Greater:
                            _searchOptions.Add("gt");
                            break;
                        case SearchOptions.GreaterOrEqual:
                            _searchOptions.Add("ge");
                            break;
                        case SearchOptions.BeginsWith:
                            _searchOptions.Add("bw");
                            break;
                        case SearchOptions.DoesNotBeginWith:
                            _searchOptions.Add("bn");
                            break;
                        case SearchOptions.IsIn:
                            _searchOptions.Add("in");
                            break;
                        case SearchOptions.IsNotIn:
                            _searchOptions.Add("ni");
                            break;
                        case SearchOptions.EndsWith:
                            _searchOptions.Add("ew");
                            break;
                        case SearchOptions.DoesNotEndWith:
                            _searchOptions.Add("en");
                            break;
                        case SearchOptions.Contains:
                            _searchOptions.Add("cn");
                            break;
                        case SearchOptions.DoesNotContain:
                            _searchOptions.Add("nc");
                            break;
                    }
                }
            }

            
            return this;
        }

        internal string SearchOption
        {
            get {
                return _searchOptions.Any() 
                    ? _searchOptions.First()
                    : "bw";
            }
        }

        /// <summary>
        /// Sets whether column can be edited
        /// </summary>
        /// <param name="editable"></param>
        /// <returns></returns>
        public Column SetEditable(bool editable)
        {
            _editable = editable;
            return this;
        }

        /// <summary>
        /// Sets the type of html element to render when column is in edit mode,
        /// SetEditable(true) must be called for this to be respected.
        /// </summary>
        /// <param name="editType"></param>
        /// <returns></returns>
        public Column SetEditType(EditType editType)
        {
            _editType = editType;
            return this;
        }

        /// <summary>
        /// Sets the edit options for the column
        /// SetEditable(true) must be called for this to be respected.
        /// </summary>
        /// <param name="editOptions"></param>
        /// <returns></returns>
        public Column SetEditOptions(EditOptions editOptions)
        {
            _editOptions = editOptions;
            return this;
        }

        /// <summary>
        /// Sets the columns edit rules
        /// SetEditable(true) must be called for this to be respected.
        /// </summary>
        /// <param name="editRules"></param>
        /// <returns></returns>
        public Column SetEditRules(EditRules editRules)
        {
            _editRules = editRules;
            return this;
        }

        /// <summary>
        /// Sets the columns edit form options
        /// SetEditable(true) must be called for this to be respected.
        /// </summary>
        /// <param name="editFormOptions"></param>
        /// <returns></returns>
        public Column SetEditFormOptions(EditFormOptions editFormOptions)
        {
            _editFormOptions = editFormOptions;
            return this;
        }

        public Column SetSortType(SortType sortType)
        {
            _sortType = sortType;
            return this;
        }

        /// <summary>
        ///     Creates javascript string from column to be included in grid javascript
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var script = new StringBuilder();

            // Start column
            script.Append("{").AppendLine();

            // Align
            if (_align.HasValue) script.AppendFormat("align:'{0}',", _align.ToString().ToLower()).AppendLine();

            // Classes
            if (_classes.Count > 0)
                script.AppendFormat("classes:'{0}',", string.Join(" ", (from c in _classes select c).ToArray())).
                    AppendLine();

            // Columnname
            script.AppendFormat("name:'{0}',", _columnName).AppendLine();

            // FirstSortOrder
            if (_firstSortOrder.HasValue) script.AppendFormat("firstsortorder:'{0}',", _firstSortOrder.ToString().ToLower()).AppendLine();

            // FixedWidth
            if (_fixedWidth.HasValue)
                script.AppendFormat("fixed:{0},", _fixedWidth.Value.ToString().ToLower()).AppendLine();

            // Formatters
            if (_formatter.HasValue && _formatter.Value.Value.IsNullOrWhiteSpace())
                script.AppendFormat("formatter:'{0}',", _formatter.Value.Key.ToString().ToLower()).AppendLine();

            if (_formatter.HasValue && !_formatter.Value.Value.IsNullOrWhiteSpace())
                script.AppendLine("formatter:'" + _formatter.Value.Key.ToString().ToLower() + "', formatoptions: {" + _formatter.Value.Value + "},"); 

            // Custom formatter
            if (!_customFormatter.IsNullOrWhiteSpace())
                script.AppendFormat("formatter:{0},", _customFormatter).AppendLine();

            // Hidden
            if (_hidden.HasValue) script.AppendFormat("hidden:{0},", _hidden.Value.ToString().ToLower()).AppendLine();

            // Key
            if (_key.HasValue) script.AppendFormat("key:{0},", _key.Value.ToString().ToLower()).AppendLine();

            // Label
            if (!_label.IsNullOrWhiteSpace()) script.AppendFormat("label:'{0}',", _label).AppendLine();

            // Resizable
            if (_resizeable.HasValue)
                script.AppendFormat("resizable:{0},", _resizeable.Value.ToString().ToLower()).AppendLine();

            // Search
            if (_search.HasValue) script.AppendFormat("search:{0},", _search.Value.ToString().ToLower()).AppendLine();


            // Sortable
            if (_sortable.HasValue)
                script.AppendFormat("sortable:{0},", _sortable.Value.ToString().ToLower()).AppendLine();

            // Title
            if (_title.HasValue) script.AppendFormat("title:{0},", _title.Value.ToString().ToLower()).AppendLine();

            // Width
            if (_width.HasValue) script.AppendFormat("width:{0},", _width.Value).AppendLine();
                        
            // Editable
            if (_editable.HasValue)
                script.AppendFormat("editable:{0},",_editable.Value.ToString().ToLower()).AppendLine();

            // Setup search options
            var searchOptions = new Dictionary<string, string>();

            // SearchType
            if (_searchType.HasValue)
            {
                if (_searchType.Value == Searchtype.Text)
                {
                    script.AppendLine("stype:'text',");
                }

                if (_searchType.Value == Searchtype.Select)
                {
                    script.AppendLine("stype:'select',");
                }

                if (_searchOptions.Any())
                {
                    searchOptions.Add("sopt", string.Format("['{0}']", _searchOptions.Aggregate((current, next) => current + "',  '" + next)));
                }
                else
                {
                    searchOptions.Add("sopt", "['bw']");
                }
            }

            // Searchoptions
            if (_searchType == Searchtype.Select || _searchType == Searchtype.Datepicker)
            {
                // SearchType select
                if (_searchType == Searchtype.Select)
                {
                    if (_searchTerms != null)
                    {
                        var emtpyOption = (_searchTerms.Any()) ? ":;" : ":";
                        searchOptions.Add("value", "\"" + string.Format("{0}{1}", emtpyOption, string.Join(";", _searchTerms.Select(s => s.Key + ":" + s.Value).ToArray())) + "\"");
                    }
                    else
                    {
                        searchOptions.Add("value", "':'");
                    }
                }

                // SearchType datepicker
                if (_searchType == Searchtype.Datepicker)
                {
                    if (_searchDateFormat.IsNullOrWhiteSpace())
                    {
                        searchOptions.Add("dataInit", "function(el){$(el).datepicker({changeYear:true, onSelect: function() {var sgrid = $('###gridid##')[0]; sgrid.triggerToolbar();},dateFormat:'dd-mm-yy'});}");
                    }
                    else
                    {
                        searchOptions.Add("dataInit", "function(el){$(el).datepicker({changeYear:true, onSelect: function() {var sgrid = $('###gridid##')[0]; sgrid.triggerToolbar();},dateFormat:'" + _searchDateFormat + "'});}");
                    }
                }
            }

            // SearchType
            if (_searchType.HasValue && !_defaultSearchValue.IsNullOrWhiteSpace())
            {
                searchOptions.Add("defaultValue", "'" + _defaultSearchValue + "'");
            }

            // Default value when no search type is set
            if ((!_searchType.HasValue && !_defaultSearchValue.IsNullOrWhiteSpace()))
                searchOptions.Add("defaultValue", "'" + _defaultSearchValue + "'");

            // Clear search
            if (_clearSearch.HasValue)
                searchOptions.Add("clearSearch", _clearSearch.Value.ToString().ToLower());
            
            // Search Option: sopt
            if (_searchOptions.Any() && !_searchType.HasValue) // When searchtype is set, searchoptions is already added
                searchOptions.Add("sopt", "['" + _searchOptions.Aggregate((current, next) => current + "', '" + next) + "']");

            if (searchOptions.Any())
                script.AppendLine("searchoptions: { " + string.Join(", ", searchOptions.Select(x => x.Key + ":" + x.Value)) + " },");

            //edit type
            if(_editType.HasValue)
                script.AppendFormat("edittype:'{0}',", _editType.Value.ToString().ToLower()).AppendLine();

            //edit options
            if (_editOptions != null)
                script.AppendFormat("editoptions:{0},", _editOptions.ToString()).AppendLine();

            //edit rules
            if(_editRules != null)
                script.AppendFormat("editrules:{0},", _editRules.ToString()).AppendLine();
                
            //edit form options
            if(_editFormOptions != null)
                script.AppendFormat("formoptions:{0},", _editFormOptions.ToString()).AppendLine();

           if (_sortType.HasValue)
                script.AppendFormat("sorttype:'{0}',", _sortType.ToString().ToLower()).AppendLine();

           // Index
           script.AppendFormat("index:'{0}'", _index).AppendLine();
          
            // End column
            script.Append("}");

            return script.ToString();
        }
    }
}
