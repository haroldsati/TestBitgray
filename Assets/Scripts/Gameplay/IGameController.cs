namespace Gameplay
{
    public interface IGameController
    {
        float AllyHealth { get; }
        GameState State { get; }
        int Points { get; }
        void Play();
    }
}