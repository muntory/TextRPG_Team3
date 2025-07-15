using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG_Team3.Character;

namespace TextRPG_Team3.Data
{

    public enum ItemType
    {
        Weapon,
        Armor,
        Shield,
    }
    internal class ItemData
    {
        private static ItemData instance;
        private JsonSerializerOptions options;

        static ItemData()
        {
            instance = new ItemData();
        }


        public static ItemData Instance { get { return instance; } }
        public static string Game_Root_Dir = $"{AppDomain.CurrentDomain.BaseDirectory}/../../..";
        public static string SAVE_DIR = $"{Game_Root_Dir}/Save";


        public ItemData()
        {
            if (instance == null)
            {
                instance = this;
                instance = new ItemData();
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public CharacterStatComponent.CharacterStatType CharacterBaseStat { get; set; }
        public int Value { get; set; }

        public string Description { get; set; }
    
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
                options = new JsonSerializerOptions
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
