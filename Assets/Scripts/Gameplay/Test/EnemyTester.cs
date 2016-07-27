using UnityEngine;
using System.Collections;

namespace Gameplay.Detail
{
    public class EnemyTester : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private Enemy enemy;

        private void Start()
        {
            enemy.Initialize(target.position, null);
        }
    }
}