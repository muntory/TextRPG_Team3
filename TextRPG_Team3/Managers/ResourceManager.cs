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

        /// <summary>
        /// <typeparamref name="T"/> 클래스로 json 파일 역직렬화 하는 메서드
        /// </summary>
        /// <typeparam name="T">역직렬화할 클래스</typeparam>
        /// <param name="jsonPath">json파일 저장되어 있는 경로</param>
        /// <returns>역직렬화할 클래스의 List</returns>
        public List<T> LoadJsonData<T>(string jsonPath)
        {
            string json = File.ReadAllText(jsonPath);

            var options = GetJsonSerializerOptions();
            List<T> result = JsonSerializer.Deserialize<List<T>>(json, options);

            return result;
        }

        /// <summary>
        /// <typeparamref name="T"/>직렬화해서 json 파일로 <paramref name="savePath"/>에 저장하는 메서드
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="savePath">저장 경로</param>
        /// <param name="saveData">저장할 클래스</param>
        public void SaveJsonData<T>(string savePath, T saveData)
        {
            string directory = Path.GetDirectoryName(savePath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var options = GetJsonSerializerOptions();

            string json = JsonSerializer.Serialize(saveData, options);
            File.WriteAllText(savePath, json);
            
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
