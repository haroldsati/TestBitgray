using Gameplay.Detail;

namespace Gameplay
{
    public static class GameControllerAcess
    {
        public static IGameController Access
        {
            get { return GameController.Instance; }
        }
    }
}