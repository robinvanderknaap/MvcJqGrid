using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using NUnit.Framework;

namespace MvcJqGrid.Tests
{
    [TestFixture]
    public class GridHelperTests
    {
        [Test]
        public void CanConstructGridFromGridHelper()
        {
            var htmlHelper = new Mock<IHtmlHelper>().Object;

            var grid = htmlHelper.Grid("test");

            Assert.IsInstanceOf<Grid>(grid);
        }
    }
}
