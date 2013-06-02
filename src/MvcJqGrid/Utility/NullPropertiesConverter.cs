///
/// Source: http://stackoverflow.com/questions/1387755/can-javascriptserializer-exclude-properties-with-null-default-values
///
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Reflection;

namespace MvcJqGrid.Utility
{
    public class NullPropertiesConverter 
        : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var propertiesToBeSerialized = new Dictionary<string, object>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                var value = prop.GetValue(obj, BindingFlags.Public, null, null, null);
               
                if (value != null)
                {
                    propertiesToBeSerialized.Add(LowercaseFirst(prop.Name), value);
                }
            }

            return propertiesToBeSerialized;
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get { return GetType().Assembly.GetTypes(); }
        }

        private string LowercaseFirst(string s)
        {
            return char.ToLower(s[0]) + s.Substring(1);
        }

    }
}
