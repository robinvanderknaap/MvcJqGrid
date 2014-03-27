using System;
using System.Collections.Generic;
using System.Web;
using MvcJqGrid.Tests.JavascriptCompiler;
using NUnit.Framework;
using MvcJqGrid.DataReaders;
using MvcJqGrid.Enums;

namespace MvcJqGrid.Tests
{
    [TestFixture]
    class GridTests
    {
        [Test]
        public void CanConstructGrid()
        {
            var grid = new Grid("testGrid");

            StringAssert.Contains("jQuery('#testGrid').jqGrid", grid.ToString());
            StringAssert.Contains(@"<table id=""testGrid""></table>", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CannotConstructGridWithEmptyId()
        {
            Assert.Throws<ArgumentException>(() => new Grid(""));
        }

        [Test]
        public void CanAddColumn()
        {
            var grid = new Grid("testGrid");
            grid.AddColumn(new Column("testColumn1"));

            StringAssert.Contains("name:'testColumn1',", grid.ToString());
            StringAssert.Contains("index:'testColumn1'", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }


        [Test]
        public void CanAddColumnFromList()
        {
            var grid = new Grid("testGrid");
            IList<Column> column = new List<Column>
                                       {
                                           new Column("testColumn1")
                                       };
            grid.AddColumns(column);

            StringAssert.Contains("name:'testColumn1',", grid.ToString());
            StringAssert.Contains("index:'testColumn1'", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanAddMultipleColumns()
        {
            var grid = new Grid("testGrid");
            IList<Column> columns = new List<Column>
                                       {
                                            new Column("testColumn1"),
                                            new Column("testColumn2")
                                       };
            grid.AddColumns(columns);

            StringAssert.Contains("name:'testColumn1',", grid.ToString());
            StringAssert.Contains("index:'testColumn1'", grid.ToString());
            StringAssert.Contains("name:'testColumn2',", grid.ToString());
            StringAssert.Contains("index:'testColumn2'", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanAddMultipleColumnsFromList()
        {
            var grid = new Grid("testGrid");
            grid.AddColumn(new Column("testColumn1"));
            grid.AddColumn(new Column("testColumn2"));

            StringAssert.Contains("name:'testColumn1',", grid.ToString());
            StringAssert.Contains("index:'testColumn1'", grid.ToString());
            StringAssert.Contains("name:'testColumn2',", grid.ToString());
            StringAssert.Contains("index:'testColumn2'", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetAlternateClass()
        {
            var grid = new Grid("testGrid");
            grid.SetAltClass("testClass");

            StringAssert.Contains("altclass:'testClass',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetAlternateRows()
        {
            var grid = new Grid("testGrid");
            grid.SetAltRows(true);

            StringAssert.Contains("altRows:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetAutoEncode()
        {
            var grid = new Grid("testGrid");
            grid.SetAutoEncode(true);

            StringAssert.Contains("autoencode:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetAutoWidth()
        {
            var grid = new Grid("testGrid");
            grid.SetAutoWidth(true);

            StringAssert.Contains("autowidth:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetCaption()
        {
            var grid = new Grid("testGrid");
            grid.SetCaption("testCaption");

            StringAssert.Contains("caption:'testCaption',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetDataType()
        {
            var grid = new Grid("testGrid");
            grid.SetDataType(DataType.Xml);

            StringAssert.Contains("datatype:'xml',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetEmptyRecords()
        {
            var grid = new Grid("testGrid");
            grid.SetEmptyRecords("No Records available!");

            StringAssert.Contains("emptyrecords:'No Records available!',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetFooterRow()
        {
            var grid = new Grid("testGrid");
            grid.SetFooterRow(true);

            StringAssert.Contains("footerrow:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetForceFit()
        {
            var grid = new Grid("testGrid");
            grid.SetForceFit(true);

            StringAssert.Contains("forceFit:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetGridView()
        {
            var grid = new Grid("testGrid");
            grid.SetGridView(true);

            StringAssert.Contains("gridview:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetHeaderTitles()
        {
            var grid = new Grid("testGrid");
            grid.SetHeaderTitles(true);

            StringAssert.Contains("headertitles:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetHeight()
        {
            var grid = new Grid("testGrid");
            grid.SetHeight(300);

            StringAssert.Contains("height:300,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetHiddenGrid()
        {
            var grid = new Grid("testGrid");
            grid.SetHiddenGrid(true);

            StringAssert.Contains("hiddengrid:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetHideGrid()
        {
            var grid = new Grid("testGrid");
            grid.SetHideGrid(true);

            StringAssert.Contains("hidegrid:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetHoverRows()
        {
            var grid = new Grid("testGrid");
            grid.SetHoverRows(true);

            StringAssert.Contains("hoverrows:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetLoadOnce()
        {
            var grid = new Grid("testGrid");
            grid.SetLoadOnce(true);

            StringAssert.Contains("loadonce:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetLoadText()
        {
            var grid = new Grid("testGrid");
            grid.SetLoadText("loadinggg");

            StringAssert.Contains("loadtext:'loadinggg',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetLoadUiToEnable()
        {
            var grid = new Grid("testGrid");
            grid.SetLoadUi(LoadUi.Enable);

            StringAssert.Contains("loadui:'enable',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetLoadUiToDisable()
        {
            var grid = new Grid("testGrid");
            grid.SetLoadUi(LoadUi.Disable);

            StringAssert.Contains("loadui:'disable',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetLoadUiToBlock()
        {
            var grid = new Grid("testGrid");
            grid.SetLoadUi(LoadUi.Block);

            StringAssert.Contains("loadui:'block',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetMultiBoxOnly()
        {
            var grid = new Grid("testGrid");
            grid.SetMultiBoxOnly(true);

            StringAssert.Contains("multiboxonly:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetMultiKeyToAltKey()
        {
            var grid = new Grid("testGrid");
            grid.SetMultiKey(MultiKey.AltKey);

            StringAssert.Contains("multikey:'altkey',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetMultiKeyToCtrlKey()
        {
            var grid = new Grid("testGrid");
            grid.SetMultiKey(MultiKey.CtrlKey);

            StringAssert.Contains("multikey:'ctrlkey',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetMultiKeyToShiftKey()
        {
            var grid = new Grid("testGrid");
            grid.SetMultiKey(MultiKey.ShiftKey);

            StringAssert.Contains("multikey:'shiftkey',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetMultiSelect()
        {
            var grid = new Grid("testGrid");
            grid.SetMultiSelect(true);

            StringAssert.Contains("multiselect:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetMultiSelectWidth()
        {
            var grid = new Grid("testGrid");
            grid.SetMultiSelectWidth(399);

            StringAssert.Contains("multiselectWidth:399,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetPage()
        {
            var grid = new Grid("testGrid");
            grid.SetPage(399);

            StringAssert.Contains("page:399,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetPager()
        {
            var grid = new Grid("testGrid");
            grid.SetPager("testPager");

            StringAssert.Contains("pager:'#testPager',", grid.ToString());
            StringAssert.Contains(@"<div id=""testPager""></div>", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetPagerPosCenter()
        {
            var grid = new Grid("testGrid");
            grid.SetPagerPos(PagerPos.Center);

            StringAssert.Contains("pagerpos:'center',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetPagerPosLeft()
        {
            var grid = new Grid("testGrid");
            grid.SetPagerPos(PagerPos.Left);

            StringAssert.Contains("pagerpos:'left',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetPagerPosRight()
        {
            var grid = new Grid("testGrid");
            grid.SetPagerPos(PagerPos.Right);

            StringAssert.Contains("pagerpos:'right',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetPgButtons()
        {
            var grid = new Grid("testGrid");
            grid.SetPgButtons(true);

            StringAssert.Contains("pgbuttons:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetPgInput()
        {
            var grid = new Grid("testGrid");
            grid.SetPgInput(true);

            StringAssert.Contains("pginput:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetPgText()
        {
            var grid = new Grid("testGrid");
            grid.SetPgText("test pager text");

            StringAssert.Contains("pgtext:'test pager text',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRecordPosCenter()
        {
            var grid = new Grid("testGrid");
            grid.SetRecordPos(RecordPos.Center);

            StringAssert.Contains("recordpos:'center',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRecordPosLeft()
        {
            var grid = new Grid("testGrid");
            grid.SetRecordPos(RecordPos.Left);

            StringAssert.Contains("recordpos:'left',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRecordPosRight()
        {
            var grid = new Grid("testGrid");
            grid.SetRecordPos(RecordPos.Right);

            StringAssert.Contains("recordpos:'right',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRecordText()
        {
            var grid = new Grid("testGrid");
            grid.SetRecordText("testRecordText");

            StringAssert.Contains("recordtext:'testRecordText',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRequestTypeGet()
        {
            var grid = new Grid("testGrid");
            grid.SetRequestType(RequestType.Get);

            StringAssert.Contains("mtype:'get',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRequestTypePost()
        {
            var grid = new Grid("testGrid");
            grid.SetRequestType(RequestType.Post);

            StringAssert.Contains("mtype:'post',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetResizeClass()
        {
            var grid = new Grid("testGrid");
            grid.SetResizeClass("testResizeClass");

            StringAssert.Contains("resizeclass:'testResizeClass',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRowList()
        {
            var grid = new Grid("testGrid");
            grid.SetRowList(new[] { 10, 30, 300 });

            StringAssert.Contains("rowList:[10,30,300],", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRowNumbers()
        {
            var grid = new Grid("testGrid");
            grid.SetRowNumbers(true);

            StringAssert.Contains("rownumbers:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRowNumWidth()
        {
            var grid = new Grid("testGrid");
            grid.SetRowNumWidth(300);

            StringAssert.Contains("rownumWidth:300,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetScrollBool()
        {
            var grid = new Grid("testGrid");
            grid.SetScroll(true);

            StringAssert.Contains("scroll:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetScrollInt()
        {
            var grid = new Grid("testGrid");
            grid.SetScroll(30);

            StringAssert.Contains("scroll:30,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetScrollOffset()
        {
            var grid = new Grid("testGrid");
            grid.SetScrollOffset(39);

            StringAssert.Contains("scrollOffset:39,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetScrollRows()
        {
            var grid = new Grid("testGrid");
            grid.SetScrollRows(true);

            StringAssert.Contains("scrollrows:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetScrollTimeout()
        {
            var grid = new Grid("testGrid");
            grid.SetScrollTimeout(20);

            StringAssert.Contains("scrollTimeout:20,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetShrinkToFit()
        {
            var grid = new Grid("testGrid");
            grid.SetShrinkToFit(true);

            StringAssert.Contains("shrinkToFit:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSearchOnEnter()
        {
            var grid = new Grid("testGrid");
            grid.SetSearchToolbar(true);
            grid.SetSearchOnEnter(true);

            StringAssert.Contains("jQuery('#testGrid').jqGrid('filterToolbar', {stringResult:true, searchOnEnter:true});", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSearchToolbar()
        {
            var grid = new Grid("testGrid");
            grid.SetSearchToolbar(true);

            StringAssert.Contains("jQuery('#testGrid').jqGrid('filterToolbar', {stringResult:true});", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSearchClearButton()
        {
            var grid = new Grid("testGrid");
            grid.SetSearchToolbar(true);
            grid.SetPager("Pager");
            grid.SetSearchClearButton(true);

            StringAssert.Contains(@"jQuery('#testGrid').jqGrid('navGrid',""#Pager"",{edit:false,add:false,del:false,search:false,refresh:false});", grid.ToString());
            StringAssert.Contains(@"jQuery('#testGrid').jqGrid('navButtonAdd',""#Pager"",{caption:""Clear"",title:""Clear Search"",buttonicon :'ui-icon-refresh', onClickButton:function(){jQuery('#testGrid')[0].clearToolbar(); }});", grid.ToString());
            StringAssert.Contains(@"jQuery('#testGrid').jqGrid('filterToolbar', {stringResult:true});", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSearchToggleButton()
        {
            var grid = new Grid("testGrid");
            grid.SetSearchToolbar(true);
            grid.SetPager("Pager");
            grid.SetSearchToggleButton(true);

            StringAssert.Contains(@"jQuery('#testGrid').jqGrid('navGrid',""#Pager"",{edit:false,add:false,del:false,search:false,refresh:false});", grid.ToString());
            StringAssert.Contains(@"jQuery('#testGrid').jqGrid('navButtonAdd',""#Pager"",{caption:""Toggle Search"",title:""Toggle Search"",buttonicon :'ui-icon-refresh', onClickButton:function(){jQuery('#testGrid')[0].toggleToolbar(); }});", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetShowAllSortIcons()
        {
            var grid = new Grid("testGrid");
            grid.SetShowAllSortIcons(true);

            StringAssert.Contains("viewsortcols:[true,'vertical',true],", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSortIconDirectionHorizontal()
        {
            var grid = new Grid("testGrid");
            grid.SetSortIconDirection(Direction.Horizontal);

            StringAssert.Contains("viewsortcols:[false,'horizontal',true],", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSortIconDirectionVertical()
        {
            var grid = new Grid("testGrid");
            grid.SetSortIconDirection(Direction.Vertical);

            StringAssert.Contains("viewsortcols:[false,'vertical',true],", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSortIconDirectionVerticalToFalse()
        {
            var grid = new Grid("testGrid");
            grid.SetSortOnHeaderClick(false);

            StringAssert.Contains("viewsortcols:[false,'vertical',false],", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSortName()
        {
            var grid = new Grid("testGrid");
            grid.SetSortName("testSortName");

            StringAssert.Contains("sortname:'testSortName',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSortOrderAsc()
        {
            var grid = new Grid("testGrid");
            grid.SetSortOrder(SortOrder.Asc);

            StringAssert.Contains("sortorder:'asc',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetSortOrderDesc()
        {
            var grid = new Grid("testGrid");
            grid.SetSortOrder(SortOrder.Desc);

            StringAssert.Contains("sortorder:'desc',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetToolbar()
        {
            var grid = new Grid("testGrid");
            grid.SetToolbar(true);

            StringAssert.Contains("toolbar:[true,'top'],", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetToolbarPositionBoth()
        {
            var grid = new Grid("testGrid");
            grid.SetToolbar(true);
            grid.SetToolbarPosition(ToolbarPosition.Both);

            StringAssert.Contains("toolbar:[true,'both'],", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetToolbarPositionTop()
        {
            var grid = new Grid("testGrid");
            grid.SetToolbar(true);
            grid.SetToolbarPosition(ToolbarPosition.Top);

            StringAssert.Contains("toolbar:[true,'top'],", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetToolbarPositionBottom()
        {
            var grid = new Grid("testGrid");
            grid.SetToolbar(true);
            grid.SetToolbarPosition(ToolbarPosition.Bottom);

            StringAssert.Contains("toolbar:[true,'bottom'],", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetTopPager()
        {
            var grid = new Grid("testGrid");
            grid.SetTopPager(true);

            StringAssert.Contains("toppager:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetUrl()
        {
            var grid = new Grid("testGrid");
            grid.SetUrl("http://test.test.test/testing?test=true");

            StringAssert.Contains(@"url:'http://test.test.test/testing?test=true',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetViewRecords()
        {
            var grid = new Grid("testGrid");
            grid.SetViewRecords(true);

            StringAssert.Contains("viewrecords:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetWidth()
        {
            var grid = new Grid("testGrid");
            grid.SetWidth(300);

            StringAssert.Contains("width:'300',", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnAfterInsertRow()
        {
            var grid = new Grid("testGrid");
            grid.OnAfterInsertRow("someJavascriptFunction()");

            StringAssert.Contains("afterInsertRow: function(rowid, rowdata, rowelem) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnBeforeRequest()
        {
            var grid = new Grid("testGrid");
            grid.OnBeforeRequest("someJavascriptFunction()");

            StringAssert.Contains("beforeRequest: function() {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnBeforeSelectRow()
        {
            var grid = new Grid("testGrid");
            grid.OnBeforeSelectRow("someJavascriptFunction()");

            StringAssert.Contains("beforeSelectRow: function(rowid, e) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnGridComplete()
        {
            var grid = new Grid("testGrid");
            grid.OnGridComplete("someJavascriptFunction()");

            StringAssert.Contains("gridComplete: function() {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnLoadBeforeSend()
        {
            var grid = new Grid("testGrid");
            grid.OnLoadBeforeSend("someJavascriptFunction()");

            StringAssert.Contains("loadBeforeSend: function(xhr, settings) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnLoadComplete()
        {
            var grid = new Grid("testGrid");
            grid.OnLoadComplete("someJavascriptFunction()");

            StringAssert.Contains("loadComplete: function(xhr) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnLoadError()
        {
            var grid = new Grid("testGrid");
            grid.OnLoadError("someJavascriptFunction()");

            StringAssert.Contains("loadError: function(xhr, status, error) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnCellSelect()
        {
            var grid = new Grid("testGrid");
            grid.OnCellSelect("someJavascriptFunction()");

            StringAssert.Contains("onCellSelect: function(rowid, iCol, cellcontent, e) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnDblClickRow()
        {
            var grid = new Grid("testGrid");
            grid.OnDblClickRow("someJavascriptFunction()");

            StringAssert.Contains("ondblClickRow: function(rowid, iRow, iCol, e) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnHeaderClick()
        {
            var grid = new Grid("testGrid");
            grid.OnHeaderClick("someJavascriptFunction()");

            StringAssert.Contains("onHeaderClick: function(gridstate) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnPaging()
        {
            var grid = new Grid("testGrid");
            grid.OnPaging("someJavascriptFunction()");

            StringAssert.Contains("onPaging: function(pgButton) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnRightClickRow()
        {
            var grid = new Grid("testGrid");
            grid.OnRightClickRow("someJavascriptFunction()");

            StringAssert.Contains("onRightClickRow: function(rowid, iRow, iCol, e) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnSelectAll()
        {
            var grid = new Grid("testGrid");
            grid.OnSelectAll("someJavascriptFunction()");

            StringAssert.Contains("onSelectAll: function(aRowids, status) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnSelectRow()
        {
            var grid = new Grid("testGrid");
            grid.OnSelectRow("someJavascriptFunction()");

            StringAssert.Contains("onSelectRow: function(rowid, status) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnSortCol()
        {
            var grid = new Grid("testGrid");
            grid.OnSortCol("someJavascriptFunction()");

            StringAssert.Contains("onSortCol: function(index, iCol, sortorder) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnResizeStart()
        {
            var grid = new Grid("testGrid");
            grid.OnResizeStart("someJavascriptFunction()");

            StringAssert.Contains("resizeStart: function(jqGridEvent, index) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnResizeStop()
        {
            var grid = new Grid("testGrid");
            grid.OnResizeStop("someJavascriptFunction()");

            StringAssert.Contains("resizeStop: function(newwidth, index) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetOnSerializeGridData()
        {
            var grid = new Grid("testGrid");
            grid.OnSerializeGridData("someJavascriptFunction()");

            StringAssert.Contains("serializeGridData: function(postData) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetJsonReader()
        {
            var grid = new Grid("testGrid");
            grid.SetJsonReader(new JsonReader { Id = "MyColumn", RepeatItems = false });

            StringAssert.Contains("jsonReader:{'repeatitems':false, 'id': 'MyColumn' },", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRowNum()
        {
            var grid = new Grid("testGrid");
            grid.SetRowNum(3);

            StringAssert.Contains("rowNum:3,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanConstructGridWithALotOfStuff()
        {

            #region LotOfJavascript

            var grid = new Grid("Test")
                .AddColumn(new Column("testColimn")
                               .AddClass("TestClass")
                               .SetAlign(Align.Center)
                               .SetCustomFormatter("formatter")
                               .SetFirstSortOrder(SortOrder.Asc)
                               .SetFixedWidth(true)
                               .SetHidden(true)
                               .SetIndex("flase")
                               .SetKey(true)
                               .SetLabel("truee")
                               .SetResizeable(true)
                               .SetSearch(true)
                               .SetSearchDateFormat("dd-mm")
                               .SetSearchTerms(new[] { "abdd", "asdfasf" })
                               .SetSearchType(Searchtype.Select)
                               .SetSortable(true)
                               .SetTitle(true)
                               .SetWidth(300))
                .OnAfterInsertRow("SomeScript();")
                .OnBeforeRequest("SomeScript();")
                .OnBeforeSelectRow("SomeScript();")
                .OnCellSelect("SomeScript();")
                .OnDblClickRow("SomeScript();")
                .OnGridComplete("SomeScript();")
                .OnHeaderClick("SomeScript();")
                .OnLoadBeforeSend("SomeScript();")
                .OnLoadComplete("SomeScript();")
                .OnLoadError("SomeScript();")
                .OnPaging("SomeScript();")
                .OnResizeStart("SomeScript();")
                .OnResizeStop("SomeScript();")
                .OnRightClickRow("SomeScript();")
                .OnSelectAll("SomeScript();")
                .OnSelectRow("SomeScript();")
                .OnSerializeGridData("SomeScript();")
                .OnSortCol("SomeScript();")
                .SetAltClass("class")
                .SetAltRows(true)
                .SetAutoEncode(true)
                .SetAutoWidth(true)
                .SetCaption("Caption")
                .SetDataType(DataType.Xml)
                .SetEmptyRecords("empaasdf")
                .SetFooterRow(true)
                .SetForceFit(true)
                .SetGridView(true)
                .SetHeaderTitles(true)
                .SetHeight(300)
                .SetHiddenGrid(true)
                .SetHideGrid(true)
                .SetHoverRows(true)
                .SetLoadOnce(true)
                .SetLoadText("loaddingg")
                .SetLoadUi(LoadUi.Enable)
                .SetMultiBoxOnly(true)
                .SetMultiKey(MultiKey.AltKey)
                .SetMultiSelect(true)
                .SetMultiSelectWidth(300)
                .SetPage(3)
                .SetPager("paggerrr")
                .SetPagerPos(PagerPos.Left)
                .SetPgButtons(true)
                .SetTopPager(true)
                .SetPgInput(true)
                .SetPgText("inpuasdfsaf")
                .SetRecordPos(RecordPos.Left)
                .SetRecordText("Recordafasfd")
                .SetRequestType(RequestType.Get)
                .SetResizeClass("Resdafasd")
                .SetRowList(new[] { 10, 20, 30 })
                .SetRowNum(3)
                .SetRowNumWidth(300)
                .SetRowNumbers(true)
                .SetScroll(true)
                .SetScrollOffset(300)
                .SetScrollRows(true)
                .SetScrollTimeout(12)
                .SetSearchClearButton(true)
                .SetSearchOnEnter(true)
                .SetSearchToggleButton(true)
                .SetSearchToolbar(true)
                .SetShowAllSortIcons(true)
                .SetShrinkToFit(true)
                .SetSortIconDirection(Direction.Vertical)
                .SetSortName("Gert")
                .SetSortOnHeaderClick(true)
                .SetSortOrder(SortOrder.Asc)
                .SetToolbar(true)
                .SetToolbarPosition(ToolbarPosition.Bottom)
                .SetTopPager(true)
                .SetUrl("urlasdfasd")
                .SetViewRecords(true)
                .SetWidth(300);

            #endregion

            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        /// <summary>
        /// Issues #3: extra comma at end of column list
        /// </summary>
        [Test]
        public void ColModelDoesNotHaveTrailingComma()
        {
            var grid = new Grid("testGrid");
            StringAssert.Contains("colModel: []}", grid.ToString().Replace("\r\n", ""));
        }

        [Test]
        public void GridImplementsIHtmlString()
        {
            var grid = new Grid("testGrid");

            Assert.IsInstanceOf<IHtmlString>(grid);
        }

        [Test]
        public void CanSetIgnoreCase()
        {
            var grid = new Grid("testGrid");
            grid.SetIgnoreCase(true);
            StringAssert.Contains("ignoreCase:true,", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

        [Test]
        public void CanSetRowAttr()
        {
            var grid = new Grid("testGrid");
            grid.SetRowAttr("someJavascriptFunction()");

            StringAssert.Contains("rowattr: function(rd) {someJavascriptFunction()},", grid.ToString());
            JavascriptAssert.IsValid(grid.RenderJavascript());
        }

    }
}
