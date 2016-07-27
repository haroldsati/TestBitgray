namespace Gameplay
{
    public interface IGameController
    {
        GameState State { get; }
        int Points { get; }
        void Play();
    }
}