﻿using System;
using UnityEngine;

namespace Gameplay.Detail
{
    public class GameController : MonoBehaviour, IGameController
    {
        [SerializeField]
        private EnemyController enemyController;
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

        public void Play()
        {
            State = GameState.Playing;
            ally.Play(OnAllyDied);
            enemyController.Spawn();
        }

        private void OnAllyDied()
        {
            enemyController.Stop();
            State = GameState.Over;
        }
    }
}