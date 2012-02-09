using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MvcJqGrid.Tests
{
    [TestFixture]
    public class GridModelBinderTests
    {
        [Test]
        public void CanFilterI18nCharacters()
        {
            var jsonFilter = "{\"groupOp\":\"AND\",\"rules\":[{\"field\":\"i18n\",\"op\":\"bw\",\"data\":\"árvíztűrőtükörfúrógépq\"}]}";
            var filter = Filter.Create(jsonFilter);

            Assert.IsInstanceOf<Filter>(filter);
        }
    }
}
