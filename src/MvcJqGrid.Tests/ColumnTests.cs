using System;
using System.Collections.Generic;
using MvcJqGrid.Enums;
using MvcJqGrid.Tests.JavascriptCompiler;
using NUnit.Framework;

namespace MvcJqGrid.Tests
{
    [TestFixture]
    public class ColumnTests
    {
        [Test]
        public void CanCreateColumnAndSetsProperties()
        {                                                                                                                                       
            var column = new Column("testColumn");

            StringAssert.Contains("name:'testColumn'", column.ToString());
            StringAssert.Contains("index:'testColumn'", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CannotCreateColumnIfColumnNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Column(""));
        }

        [Test]
        public void CannotCreateColumnIfEnterdColumnNameIsReserverdName()
        {
            Assert.Throws<ArgumentException>(() => new Column("subgrid"));

            Assert.Throws<ArgumentException>(() => new Column("cb"));

            Assert.Throws<ArgumentException>(() => new Column("rn"));
        }

        [Test]
        public void CanAddClass()
        {
            var column = GetTestableColumn();
            column.AddClass("testClass");

            StringAssert.Contains("classes:'testClass',", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanAddMultipleClasses()
        {
            var column = GetTestableColumn();
            column.AddClass("testClass1");
            column.AddClass("testClass2");

            StringAssert.Contains("classes:'testClass1 testClass2',", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetSearchDateFormat()
        {
            var column = GetTestableColumn();
            column.SetSearchType(Searchtype.Datepicker);
            column.SetSearchDateFormat("yy-mm-dd");

            StringAssert.Contains("searchoptions: {sopt:['bw'], dataInit:function(el){$(el).datepicker({changeYear:true, onSelect: function() {var sgrid = $('###gridid##')[0]; sgrid.triggerToolbar();},dateFormat:'yy-mm-dd'});}},", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void IfNoSearchDateFormatHasBeenSetDefaultSearchDateFormatWillBeSet()
        {
            var column = GetTestableColumn();
            column.SetSearchType(Searchtype.Datepicker);

            StringAssert.Contains("searchoptions: {sopt:['bw'], dataInit:function(el){$(el).datepicker({changeYear:true, onSelect: function() {var sgrid = $('###gridid##')[0]; sgrid.triggerToolbar();},dateFormat:'dd-mm-yy'});}},", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }
        
        [Test]
        public void CanSetSearchTermsWithStringArray()
        {
            var terms = new[] {"term1", "term2"};
            var column = GetTestableColumn();
            column.SetSearchType(Searchtype.Select);
            column.SetSearchTerms(terms);

            StringAssert.Contains("stype:'select',", column.ToString());
            StringAssert.Contains(@"searchoptions: {sopt:['bw'], value: "":;term1:term1;term2:term2""},", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetSearchTermsWithDictionary()
        {
            var terms = new Dictionary<string, string>
                            {
                                { "1", "term1"},
                                { "200", "term2"}
                            };
            var column = GetTestableColumn();
            column.SetSearchType(Searchtype.Select);
            column.SetSearchTerms(terms);

            StringAssert.Contains("stype:'select',", column.ToString());
            StringAssert.Contains(@"searchoptions: {sopt:['bw'], value: "":;1:term1;200:term2""},", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetSearchTypeWithoutAnySearchTerms()
        {
            var column = GetTestableColumn();
            column.SetSearchType(Searchtype.Select);

            StringAssert.Contains("stype:'select',", column.ToString());
            StringAssert.Contains("searchoptions: {sopt:['bw'], value: ':'},", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetAlignment()
        {
            var column = GetTestableColumn();
            column.SetAlign(Align.Center);

            StringAssert.Contains("align:'center',", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetFirstSortOrder()
        {
            var column = GetTestableColumn();
            column.SetFirstSortOrder(SortOrder.Asc);

            StringAssert.Contains("firstsortorder:'asc',", column.ToString());
        }

        [Test]
        public void CanSetFixedWidth()
        {
            var column = GetTestableColumn();
            column.SetFixedWidth(true);

            StringAssert.Contains("fixed:true,", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetFormatterWithOutFormatOptions()
        {
            var column = GetTestableColumn();
            column.SetFormatter(Formatters.Currency);

            StringAssert.Contains("formatter:'currency',", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetFormatterWithFormatOptions()
        {
            var column = GetTestableColumn();
            column.SetFormatter(Formatters.Currency, "test: true");

            StringAssert.Contains("formatter:'currency', formatoptions: {test: true},", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CannotSetFormatterWithOutOptionsIfCustomFormatterAlreadyHasBeenSet()
        {
            var column = GetTestableColumn();
            column.SetCustomFormatter("testCustomFormatter");

            Assert.Throws<Exception>(() => column.SetFormatter(Formatters.Currency));
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CannotSetFormatterWithOptionsIfCustomFormatterAlreadyHasBeenSet()
        {
            var column = GetTestableColumn();
            column.SetCustomFormatter("testCustomFormatter");

            Assert.Throws<Exception>(() => column.SetFormatter(Formatters.Currency, "test=test"));
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetCustomerFormatter()
        {
            var column = GetTestableColumn();
            column.SetCustomFormatter("testCustomFormatter");

            StringAssert.Contains("formatter:testCustomFormatter,", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CannotSetCustomerFormatterOfFormatterAlreadyHasBeenSet()
        {
            var column = GetTestableColumn();
            column.SetFormatter(Formatters.Currency);
            
            Assert.Throws<Exception>(() => column.SetCustomFormatter("testCustomFormatter"));
            JavascriptAssertColumn.IsValid(column);
        } 

        [Test]
        public void CanSetToHidden()
        {
            var column = GetTestableColumn();
            column.SetHidden(true);

            StringAssert.Contains("hidden:true,", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetIndex()
        {
            var column = GetTestableColumn();
            column.SetIndex("testIndex");

            StringAssert.Contains("index:'testIndex'", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetKey()
        {
            var column = GetTestableColumn();
            column.SetKey(true);

            StringAssert.Contains("key:true,", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetLabel()
        {
            var column = GetTestableColumn();
            column.SetLabel("testLabel");

            StringAssert.Contains("label:'testLabel',", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetResizeable()
        {
            var column = GetTestableColumn();
            column.SetResizeable(true);

            StringAssert.Contains("resizable:true", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetSearchToFalse()
        {
            var column = GetTestableColumn();
            column.SetSearch(false);  // default is true

            StringAssert.Contains("search:false,", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetSearchTypeText()
        {
            var column = GetTestableColumn();
            column.SetSearchType(Searchtype.Text);

            StringAssert.Contains("stype:'text',", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetSearchTypeSelect()
        {
            var column = GetTestableColumn();
            column.SetSearchType(Searchtype.Select);

            StringAssert.Contains("stype:'select',", column.ToString());
            StringAssert.Contains("searchoptions: {sopt:['bw'], value: ':'},", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetSearchTypeDatePicker()
        {
            var column = GetTestableColumn();
            column.SetSearchType(Searchtype.Datepicker);

            StringAssert.Contains("searchoptions: {sopt:['bw'], dataInit:function(el){$(el).datepicker({changeYear:true, onSelect: function() {var sgrid = $('###gridid##')[0]; sgrid.triggerToolbar();},dateFormat:'dd-mm-yy'});}},", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }
        
        [Test]
        public void CanSetSortable()
        {
            var column = GetTestableColumn();
            column.SetSortable(true);

            StringAssert.Contains("sortable:true,", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetTitle()
        {
            var column = GetTestableColumn();
            column.SetTitle(true);

            StringAssert.Contains("title:true,", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetWidth()
        {
            var column = GetTestableColumn();
            column.SetWidth(300);

            StringAssert.Contains("width:300,", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        /// <summary>
        /// Issue #4: Formatoptions where accidently lower cased, causing some options to break (like baseLinkUrl)
        /// </summary>
        [Test]
        public void CanSetFormatOptions()
        {
            var column = GetTestableColumn();
            column.SetFormatter(Formatters.Showlink, "baseLinkUrl:'test.php'");

            StringAssert.Contains("baseLinkUrl:'test.php'", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetDefaultSearchValue()
        {
            var column = GetTestableColumn();
            column.SetDefaultSearchValue("test");
            column.SetSearchType(Searchtype.Text);

            StringAssert.Contains("defaultValue: 'test'", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void ReportsIfIsKeyCorrectly()
        {
            var column = GetTestableColumn();
            column.SetKey(true);

            Assert.AreEqual(column.IsKey, true);
        }

        [Test]
        public void ReportsIfIsExpandableCorrectly()
        {
            var column = GetTestableColumn();
            column.SetAsExpandable();

            Assert.AreEqual(column.IsExpandable, true);
        }

        [Test]
        public void CanSetEditable()
        {
            var column = GetTestableColumn();
            column.SetEditable(true);

            StringAssert.Contains("editable:true", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetEditTypes()
        {
            var column = GetTestableColumn();
            column.SetEditable(true);
            
            column.SetEditType(EditType.Text);
            StringAssert.Contains("edittype:'text'", column.ToString());

            column.SetEditType(EditType.Checkbox);
            StringAssert.Contains("edittype:'checkbox'", column.ToString());

            column.SetEditType(EditType.Custom);
            StringAssert.Contains("edittype:'custom'", column.ToString());

            column.SetEditType(EditType.File);
            StringAssert.Contains("edittype:'file'", column.ToString());

            column.SetEditType(EditType.Image);
            StringAssert.Contains("edittype:'image'", column.ToString());

            column.SetEditType(EditType.Password);
            StringAssert.Contains("edittype:'password'", column.ToString());

            column.SetEditType(EditType.Select);
            StringAssert.Contains("edittype:'select'", column.ToString());

            column.SetEditType(EditType.TextArea);
            StringAssert.Contains("edittype:'textarea'", column.ToString());

            column.SetEditType(EditType.Button);
            StringAssert.Contains("edittype:'button'", column.ToString());


            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetEditOptions()
        {
            var column = GetTestableColumn();
            column.SetEditable(true);

            column.SetEditOptions(new EditOptions { 
                     BuildSelect = "bs",
                     DataEvents = "ds",
                     DataInit = "di",
                     DataUrl = "du",
                     DefaultValue = "dv",
                     NullIfEmpty = true,
                     OtherOptions = "ot",
                     Value = "v"
                });

            StringAssert.Contains("\"buildSelect\":\"bs\"", column.ToString());
            StringAssert.Contains("\"dataEvents\":\"ds\"", column.ToString());
            StringAssert.Contains("\"dataInit\":\"di\"", column.ToString());
            StringAssert.Contains("\"dataUrl\":\"du\"", column.ToString());
            StringAssert.Contains("\"defaultValue\":\"dv\"", column.ToString());
            StringAssert.Contains("\"nullIfEmpty\":true", column.ToString());
            StringAssert.Contains("\"otherOptions\":\"ot\"", column.ToString());
            StringAssert.Contains("\"value\":\"v\"", column.ToString());

            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetRules()
        {

            var column = GetTestableColumn();
            column.SetEditable(true);

            column.SetEditRules(new EditRules
            { 
                 Custom = true,
                 CustomFunc = "function(){}",
                 Date = true,
                 EditHidden = true,
                 Email = true,
                 Integer = true,
                 MaxValue = 5,
                 MinValue = 1,
                 Number = true,
                 Required = true,
                 Time = true,
                 Url = true
            });

            StringAssert.Contains("\"custom\":true", column.ToString());
            StringAssert.Contains("\"customFunc\":\"function(){}\"", column.ToString());
            StringAssert.Contains("\"date\":true", column.ToString());
            StringAssert.Contains("\"editHidden\":true", column.ToString());
            StringAssert.Contains("\"email\":true", column.ToString());
            StringAssert.Contains("\"integer\":true", column.ToString());
            StringAssert.Contains("\"maxValue\":5", column.ToString());
            StringAssert.Contains("\"minValue\":1", column.ToString());
            StringAssert.Contains("\"number\":true", column.ToString());
            StringAssert.Contains("\"required\":true", column.ToString());
            StringAssert.Contains("\"time\":true", column.ToString());
            StringAssert.Contains("\"url\":true", column.ToString());

            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanSetSortType()
        {
            var column = GetTestableColumn();

            column.SetSortType(SortType.Currency);
            StringAssert.Contains("sorttype:'currency'", column.ToString());

            column.SetSortType(SortType.Date);
            StringAssert.Contains("sorttype:'date'", column.ToString());

            column.SetSortType(SortType.Float);
            StringAssert.Contains("sorttype:'floate'", column.ToString());

            column.SetSortType(SortType.Integer);
            StringAssert.Contains("sorttype:'integer'", column.ToString());

            column.SetSortType(SortType.Number);
            StringAssert.Contains("sorttype:'number'", column.ToString());

            column.SetSortType(SortType.Text);
            StringAssert.Contains("sorttype:'text'", column.ToString());

            JavascriptAssertColumn.IsValid(column);
        }

        private static Column GetTestableColumn()
        {
            return new Column("testColumn");    
        }

        private static class JavascriptAssertColumn
        {
            public static void IsValid(Column column)
            {
                var grid = new Grid("test");
                grid.AddColumn(column);

                JavascriptAssert.IsValid(grid.RenderJavascript());
            }
        }

        [Test]
        public void CanSetMultipleSearchOptions()
        {
            var column = GetTestableColumn();
            var multipleSearchOptions = SearchOptions.Equal | SearchOptions.Greater | SearchOptions.Less;
            column.SetSearchOption(multipleSearchOptions);

            StringAssert.Contains(@"searchoptions: { sopt:['eq', 'lt', 'gt'] }", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void CanHaveDefaultSearchOption()
        {
            var column = GetTestableColumn();
            column.SetSearchType(Searchtype.Text);

            StringAssert.Contains(@"searchoptions: {sopt:['bw']}", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }

        [Test]
        public void ClearSearchIsSetToTrue()
        {
            var column = GetTestableColumn();
            column.SetClearSearch(true);

            StringAssert.Contains(@"clearSearch:true", column.ToString());
            JavascriptAssertColumn.IsValid(column);
        }
    }
}
