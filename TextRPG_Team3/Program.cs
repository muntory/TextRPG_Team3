using TextRPG_Team3.Scenes;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3
{
    internal class Program
    {
        GameManager gameManager;
        ResourceManager resourceManager;
        SceneManager sceneManager;
        InputManager inputManager;
        SpawnManager spawnManager;
        QuestManager questManager;
        ItemManager itemManager;

        static void Main(string[] args)
        {

            Program program = new();
            program.Init();

            while (true)
            {
                program.Render();
                program.Update();
            }
        }

        void Init()
        {
            string savePath = $"{AppDomain.CurrentDomain.BaseDirectory}/../../../Save/";
            gameManager = new GameManager();
            resourceManager = new ResourceManager();
            spawnManager = new SpawnManager();
            sceneManager = new SceneManager();
            inputManager = new InputManager();
            questManager = new QuestManager();
            itemManager = new ItemManager();
            if (File.Exists(savePath + "PlayerSave.json") || File.Exists(savePath + "ItemSave.json") || File.Exists(savePath + "QuestSave.json"))
            {
                SceneManager.Instance.LoadScene(new LoadDataScene());
            }
            else
            {
                SceneManager.Instance.LoadScene(new ChooseScene());
            }
        }

        void Render()
        {
            SceneManager.Instance.CurrentScene.Render();
        }

        void Update()
        {
            int selectedNumber = InputManager.Instance.GetPlayerInput();

            SceneManager.Instance.CurrentScene.SelectMenu(selectedNumber);
        }
    }
}
