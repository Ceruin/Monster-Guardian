namespace Assets.Scripts
{
    public enum FeelStatus
    {
        Sad,
        Happy,
    }

    public enum HungerStatus
    {
        Dead = 0,
        Starving = 15,
        Hungry = 30,
        Satisfied = 60,
        Full = 100
    }

    public enum MovementType
    {
        Sit,
        Idle,
        Crawl,
        Walk,
        Run,
        Swim,
        Fly,
        Follow
    }

    public enum TeamStatus
    {
        Friendly,
        Enemy
    }
}