using System.Web.Mvc;

namespace MvcJqGrid
{
    public static class GridHelper
    {
        public static Grid Grid(this HtmlHelper helper, string id)
        {
            return new Grid(id);
        }
    }
}
