using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRPG_Team3.Managers
{
    // Enemy Data
    internal class ResourceManager
    {
        private static ResourceManager instance;
        public static ResourceManager Instance { get { return instance; } }

        public static string GameRootDir = $"{AppDomain.CurrentDomain.BaseDirectory}/../../..";

        private JsonSerializerOptions options;
        public ResourceManager()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public List<T> LoadJsonData<T>(string jsonPath)
        {
            string json = File.ReadAllText(jsonPath);

            var options = GetJsonSerializerOptions();
            List<T> result = JsonSerializer.Deserialize<List<T>>(json, options);

            return result;
        }

        public JsonSerializerOptions GetJsonSerializerOptions()
        {
            if (options == null)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };
            }
            return options;
        }
    }
}
