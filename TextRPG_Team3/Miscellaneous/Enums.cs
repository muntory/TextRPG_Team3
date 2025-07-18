public class Enums
{
    public enum StatType
    {
        Level,
        Attack,
        Defense,
        Health,
    }

    public enum AttackType
    {
        NormalAttack,
        Skill,
    }

    public enum IntroMenu
    {
        Stat = 1,
        Battle = 2, 
        Quest = 3,
        Potion = 4,
    }

    public enum CenterMenu
    {
        Out = 0,
        Confirm = 1,
        
    }

    public enum StatMenu
    {
        Out = 0,
        Inventory = 1,
    }

    // 배틀 메뉴 업데이트 해야됨
    public enum BattleMenu
    {
        Out,
        Attack,
        Skill,
        Item,

    }

    public enum PlayerPhaseMenu
    {
        Out = 0
    }

    public enum AttackResultMenu
    {
        Next = 0
    }

    public enum EnemyPhaseMenuE
    {
        Next = 0
    }
    
    public enum VictoryScene
    {
        Next = 0
    }

    public enum LoseScene
    {
        Next = 0
    }

    public enum Job
    {
        Warrior = 1, 
        Mage = 2, 
        Assassin = 3
    }
    public enum QuestMenuE
    {
        Out = 0,
        Accept,
        Refuse
    }

    public enum InventoryMenu
    {
        Back = 0,
        Set = 1,
    }

    public enum PotionSceneMenu
    {
        Back = 0,
        use = 1,
    }
}