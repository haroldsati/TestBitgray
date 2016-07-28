using UnityEngine;
using System.Collections.Generic;

namespace Gameplay.Detail
{
    [System.Serializable]
    public class EnemiesInstantiator
    {
        [SerializeField]
        private Transform enemiesParent;
        [SerializeField]
        private List<GameObject> enemyPrefabs;
        [SerializeField]
        private float scale;
        [SerializeField]
        private Vector2 minRangeToDeploy;
        [SerializeField]
        private Vector2 maxRangeToDeploy;
        [SerializeField]
        private float yOffset = 3;

        public List<Enemy> InstantieEnemies(int amountOfEnemies)
        {
            List<Enemy> enemies = new List<Enemy>();

            for (int i = 0; i < amountOfEnemies; i++)
                enemies.Add(InstantiateEnemy());

            return enemies;
        }

        private Enemy InstantiateEnemy()
        {
            int index = Random.Range(0, enemyPrefabs.Count - 1);
            GameObject instance = GameObject.Instantiate(enemyPrefabs[index]);
            Enemy enemy = instance.GetComponent<Enemy>();
            enemy.SetParent(enemiesParent, GetInitialPosition(), scale);
            return enemy;
        }

        private Vector3 GetInitialPosition()
        {
            Vector3 position = Vector3.zero;
            position.y = yOffset;

            if (ChooseSide())
                position = SetUpXSide(position);
            else
                position = SetUpZSide(position);

            return position;
        }

        private Vector3 SetUpXSide(Vector3 position)
        {
            position.x = Random.Range(minRangeToDeploy.x, maxRangeToDeploy.x);
            position.x *= ChooseSide() ? 1 : -1;
            position.z = Random.Range(-maxRangeToDeploy.y, maxRangeToDeploy.y);
            return position;
        }

        private Vector3 SetUpZSide(Vector3 position)
        {
            position.z = Random.Range(minRangeToDeploy.y, maxRangeToDeploy.y);
            position.z *= ChooseSide() ? 1 : -1;
            position.x = Random.Range(-maxRangeToDeploy.x, maxRangeToDeploy.x);
            return position;
        }

        private bool ChooseSide()
        {
            return Random.Range(0, 100) < 50 ? false : true;
        }
    }
}