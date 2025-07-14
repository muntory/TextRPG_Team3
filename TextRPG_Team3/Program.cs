using TextRPG_Team3.Others;
using TextRPG_Team3.Scenes;
using TextRPG_Team3.Interfaces;

namespace TextRPG_Team3
{
    internal class Program
    {
        SceneManager sceneManager;
        int menuMin = 0;
        int menuMax = 0;
        static void Main(string[] args)
        {
    {   
        static void Main(string[] args)
        {
            int menuMin = 0;
            int menuMax = 0;

            Program program = new();
            program.Init();

            while (true)
            {
                program.Render(ref menuMin, ref menuMax);
                program.Update(menuMin, menuMax);
            }
        }

        void Init()
        {
            SceneManager sceneManager = new SceneManager();
            SceneManager.Instance.CurrentScene = new IntroScene();
        }

        void Render(ref int menuMin, ref int menuMax)
        {
            Console.Clear();
            SceneManager.Instance.CurrentScene.Render(ref menuMin, ref menuMax);
        }

        void Update(int menuMin, int menuMax)
        {
            GetNumber numberGetter = new();
            int selectedNumber = numberGetter.GetMenuNumber(menuMin, menuMax);
            SceneManager.Instance.CurrentScene.SelectMenu(selectedNumber);
        }
    }
}
