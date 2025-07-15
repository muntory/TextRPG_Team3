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

        public static string GAME_ROOT_DIR = $"{AppDomain.CurrentDomain.BaseDirectory}/../../..";
        public static string SAVE_DIR = $"{GAME_ROOT_DIR}/Save";


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

        public void SaveJsonData<T>(string path, T saveData)
        {
            string directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var options = GetJsonSerializerOptions();

            string json = JsonSerializer.Serialize(saveData, options);
            File.WriteAllText(path, json);
            
        }

        public JsonSerializerOptions GetJsonSerializerOptions()
        {
            if (options == null)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };
            }
            return options;
        }
    }
}
