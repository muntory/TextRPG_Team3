public class Enums
{
    public enum StatType
    {
        Level,
        Attack,
        Defense,
        Health,
    }

    public enum IntroMenu
    {
        Stat = 1,
        Battle = 2
    }
    
    public enum StatMenu
    {
        Out = 0
    }

    // 배틀 메뉴 업데이트 해야됨
    public enum BattleMenu
    {
        Attack = 1,
        Out = 0
    }

    public enum PlayerPhaseMenu
    {
        Out = 0
    }

    public enum EnemyPhaseMenuE
    {
        Next = 0
    }
}