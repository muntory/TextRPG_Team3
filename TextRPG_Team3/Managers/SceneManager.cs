using System;
using TextRPG_Team3.Interfaces;
using TextRPG_Team3.Scenes;

public class SceneManager
{
    /*private static SceneManager instance = new();
    public static SceneManager Instance => instance ?? (instance = new());

    private static Dictionary<string, IScene> scenes = new();
    private static IScene currentScene;

    public static void AddScene(string name, IScene scene)
    {
        scenes[name] = scene;
    }
    public static void LoadScene(string name)
    {
        if(name == "")
        {
            AddScene("Intro", new IntroScene());
        }
        else if(name == "Intro")
        {
            AddScene("Battle", new BattleScene());
            AddScene("Stat", new BattleScene());
        }
    }
    public static void ChangeScene(string name, IScene scene)
    {
        if (scenes.ContainsKey(name))
        {
            currentScene = scene;
        }
        else
        {
            Console.WriteLine($"{name} 씬이 없습니다!");
        }
        scenes.Clear();
    }
    public SceneManager()
    {

    }*/
}
