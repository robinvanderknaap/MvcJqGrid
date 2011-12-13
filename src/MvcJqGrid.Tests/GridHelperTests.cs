using System.Web.Mvc;
using NUnit.Framework;

namespace MvcJqGrid.Tests
{
    [TestFixture]
    public class GridHelperTests
    {
        [Test]
        public void CanConstructGridFromGridHelper()
        {
            var viewContext = new ViewContext();
            var viewDataContainer = new FakeViewDataContainer();
            var htmlHelper = new HtmlHelper(viewContext, viewDataContainer);

            var grid = htmlHelper.Grid("test");

            Assert.IsInstanceOf<Grid>(grid);
        }

        private class FakeViewDataContainer : IViewDataContainer
        {
            public ViewDataDictionary ViewData { get; set; }
        }
    }
}
