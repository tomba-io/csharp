using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Tomba
{
    public static class ExtensionMethods
    {
        public static string ToJson(this Dictionary<string, object> dict)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() }
            };

            return JsonConvert.SerializeObject(dict, settings);
        }

        public static string ToQueryString(this Dictionary<string, object> parameters)
        {
            List<string> query = new List<string>();

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                if (parameter.Value != null)
                {
                    if (parameter.Value is List<object>)
                    {
                        foreach (object entry in (dynamic)parameter.Value)
                        {
                            query.Add(parameter.Key + "[]=" + Uri.EscapeDataString(entry.ToString()));
                        }
                    }
                    else
                    {
                        query.Add(parameter.Key + "=" + Uri.EscapeDataString(parameter.Value.ToString()));
                    }
                }
            }
            return string.Join("&", query);
        }
    }
}
