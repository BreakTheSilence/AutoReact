using AutoReact.Entities;
using Newtonsoft.Json;

namespace AutoReact.Helpers
{
    public static class JsonConverter
    {
        public static string ConvertToJson(object toConvert)
        {
            var output = JsonConvert.SerializeObject(toConvert);
            return output;
        }

        public static object ConvertFromJson<T>(string jsonString, T type) where T : class
        {
            var output = JsonConvert.DeserializeObject<T>(jsonString);

            return output;
        }
    }
}
