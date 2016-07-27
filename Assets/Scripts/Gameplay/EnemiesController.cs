using UnityEngine;
using System.Collections.Generic;
using System;

namespace Gameplay.Detail
{
    public class EnemiesController : MonoBehaviour
    {

        [SerializeField]
        private Transform target;
        [SerializeField]
        private int initialAmountOfEnemies;
        [SerializeField]
        private EnemiesInstantiator instantiator;

        private List<Enemy> enemies;

        public int KilledEnemies
        {
            get;
            private set;
        }

        public void Play()
        {
            KilledEnemies = 0;
            enemies = new List<Enemy>();
            InstantiateAndInitializeEnemies(initialAmountOfEnemies);
        }

        public void Stop()
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
                Destroy(enemies[i].gameObject);
            enemies.Clear();
        }

        private void InstantiateAndInitializeEnemies(int amount)
        {
            List<Enemy> tmp = instantiator.InstantieEnemies(amount);
            foreach (Enemy enemy in tmp)
                enemy.Initialize(target.position, OnEnemyDied);
            enemies.AddRange(tmp);
        }

        private void OnEnemyDied(bool wasKilled, Enemy enemy)
        {
            enemies.Remove(enemy);

            if (wasKilled)
                OnEnemyKilled();
        }

        private void OnEnemyKilled()
        {
            KilledEnemies++;
            if (KilledEnemies / 2 >= 1)
                InstantiateAndInitializeEnemies(KilledEnemies / 2);
        }
    }
}