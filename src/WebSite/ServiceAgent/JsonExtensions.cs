using System;
using Newtonsoft.Json.Linq;

namespace NNUG.WebSite.ServiceAgent
{
    public static class JsonExtensions
    {
        public static T FirstOrDefault<T>(this JObject jObject, string propertyName)
        {
            if (jObject[propertyName] != null)
            {
                return jObject[propertyName].Value<T>();
            }
            
            return default(T);
        }

        public static DateTime FirstOrDefault(this JObject jObject, string propertyName)
        {
            if (jObject[propertyName] != null)
            {
                return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(jObject[propertyName].Value<long>()));
            }

            return DateTime.MinValue;
        }
    }
}