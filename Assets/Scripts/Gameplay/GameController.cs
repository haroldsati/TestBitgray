using System;
using UnityEngine;

namespace Gameplay.Detail
{
    public class GameController : MonoBehaviour, IGameController
    {
        [SerializeField]
        private EnemiesController enemyController;
        [SerializeField]
        private Ally ally;

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
            get { return enemyController.KilledEnemies; }
        }

        public float AllyHealth
        {
            get { return ally.HealthPercent; }
        }

        public void Play()
        {
            State = GameState.Playing;
            ally.Play(OnAllyDied);
            enemyController.Play();
        }

        private void OnAllyDied()
        {
            enemyController.Stop();
            State = GameState.Over;
        }
    }
}