
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcJqGrid
{
    public static class GridHelper
    {
        public static Grid Grid(this IHtmlHelper helper, string id)
        {
            return new Grid(id);
        }
    }
}
