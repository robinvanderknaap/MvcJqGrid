using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MvcJqGrid.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJSON(this object obj)
        {
            var serializationSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(obj, serializationSettings);
        }
    }
}
