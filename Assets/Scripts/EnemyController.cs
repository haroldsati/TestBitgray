using UnityEngine;
using System.Collections.Generic;

namespace Gameplay.Detail
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private Transform enemiesParent;
        [SerializeField]
        private List<GameObject> enemyPrefabs;
        [SerializeField]
        private Vector2 minRangeToDeploy;
        [SerializeField]
        private Vector2 maxRangeToDeploy;
        [SerializeField]
        private int initialAmountOfEnemies;

        private List<Enemy> enemies;

        public int KilledEnemies
        {
            get;
            private set;
        }

        public void Spawn()
        {
            KilledEnemies = 0;
            enemies = new List<Enemy>();
            InstantieEnemies(initialAmountOfEnemies);
        }

        public void Stop()
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
                Destroy(enemies[i].gameObject);
            enemies.Clear();
        }

        private void InstantieEnemies(int amountOfEnemies)
        {
            for (int i = 0; i < amountOfEnemies; i++)
                InstantiateEnemy();
        }

        private void InstantiateEnemy()
        {
            int index = Random.Range(0, enemyPrefabs.Count - 1);
            GameObject instance = Instantiate(enemyPrefabs[index]);
            Enemy enemy = instance.GetComponent<Enemy>();
            enemies.Add(enemy);
            enemy.SetParent(enemiesParent, GetInitialPosition());
            enemy.Initialize(target.position, OnEnemyKilled);
        }

        private Vector3 GetInitialPosition()
        {
            Vector3 position = Vector3.zero;

            if (GetRandomBool())
                position = SetUpXFirst(position);
            else
                position = SetUpZFirst(position);

            return position;
        }

        private Vector3 SetUpXFirst(Vector3 position)
        {
            position.x = Random.Range(minRangeToDeploy.x, maxRangeToDeploy.x);
            position.x *= GetRandomBool() ? 1 : -1;
            position.z = Random.Range(-maxRangeToDeploy.y, maxRangeToDeploy.y);
            return position;
        }

        private Vector3 SetUpZFirst(Vector3 position)
        {
            position.z = Random.Range(minRangeToDeploy.y, maxRangeToDeploy.y);
            position.z *= GetRandomBool() ? 1 : -1;
            position.x = Random.Range(-maxRangeToDeploy.x, maxRangeToDeploy.x);
            return position;
        }

        private bool GetRandomBool()
        {
            return Random.Range(0, 100) < 50 ? false : true;
        }

        private void OnEnemyKilled(bool wasKilled, Enemy enemy)
        {
            enemies.Remove(enemy);

            if (wasKilled)
            {
                KilledEnemies++;
                if (KilledEnemies / 2 >= 1)
                    InstantieEnemies(KilledEnemies / 2);
            }
        }
    }
}