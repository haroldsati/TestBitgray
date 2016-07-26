using UnityEngine;

namespace Gameplay.Detail
{
    public class GameController : MonoBehaviour, IGameController
    {
        [SerializeField]
        private EnemySpawner enemySpawner;

        public static GameController Instance
        {
            get;
            private set;
        }

        public GameState State
        {
            get;
            private set;
        }

        private void Awake()
        {
            Instance = this;
        }

        public int Points
        {
            get { return enemySpawner.KilledEnemies; }
        }

        public void Play()
        {
            State = GameState.Playing;
            enemySpawner.Spawn();
        }
    }
}