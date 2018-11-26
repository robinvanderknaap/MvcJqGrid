using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MvcJqGrid
{
    [ModelBinder(typeof(GridModelBinder))]
    public class GridSettings
    {
        public bool IsSearch { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public Filter Where { get; set; }
    }

    public class Filter
    {
        public string groupOp { get; set; }

        public Rule[] rules { get; set; }

        public static Filter Create(string jsonData)
        {
            try
            {
                return JsonConvert.DeserializeObject<Filter>(jsonData) ?? new Filter();
            }
            catch
            {
                return null;
            }
        }
    }

    public class Rule
    {
        public string field { get; set; }
        public string op { get; set; }
        public string data { get; set; }
    }

    public class GridModelBinder : IModelBinder
    {
        private readonly ILogger<GridModelBinder> _logger;

        public GridModelBinder(ILogger<GridModelBinder> logger)
        {
            _logger = logger;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                var request = bindingContext.HttpContext.Request;

                var search = !string.IsNullOrWhiteSpace(request.Query["_search"]) ? (string)request.Query["_search"] : "false";
                var page = !string.IsNullOrWhiteSpace(request.Query["page"]) ? (string)request.Query["page"] : "1";
                var rows = !string.IsNullOrWhiteSpace(request.Query["rows"]) ? (string)request.Query["rows"] : "10";
                var sortColumn = !string.IsNullOrWhiteSpace(request.Query["sidx"]) ? (string)request.Query["sidx"] : "";
                var sortOrder = !string.IsNullOrWhiteSpace(request.Query["sord"]) ? (string)request.Query["sord"] : "asc";
                var filters = !string.IsNullOrWhiteSpace(request.Query["filters"]) ? (string)request.Query["filters"] : "";

                var gridSettings = new GridSettings
                {
                    IsSearch = bool.Parse(search),
                    PageIndex = int.Parse(page),
                    PageSize = int.Parse(rows),
                    SortColumn = sortColumn,
                    SortOrder = sortOrder,
                    Where = Filter.Create(filters)
                };

                bindingContext.Result = ModelBindingResult.Success(gridSettings);

                return Task.FromResult<object>(null);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to bind grid model");

                return Task.FromResult<object>(null);
            }
        }
    }
}