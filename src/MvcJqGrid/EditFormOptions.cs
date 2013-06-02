using MvcJqGrid.Extensions;

namespace MvcJqGrid
{
    public class EditFormOptions
    {
        public string ElmPrefix { get; set; }
        public string ElmSuffix { get; set; }
        public string Label { get; set; }
        public int? RowPos { get; set; }
        public int? ColPos { get; set; }

        public override string ToString()
        {
            return this.ToJSON();
        }
    }
}
