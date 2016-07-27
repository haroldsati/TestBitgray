using UnityEngine;
using System.Collections;
using System;

namespace Gameplay
{
    public class Ally : MonoBehaviour
    {
        private event Action Died;

        [SerializeField]
        private int maxHealth;

        private float currentHealth;

        public void Play(Action died)
        {
            Died = died;
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                RaiseDied();
            }
        }

        private void RaiseDied()
        {
            if (Died != null)
                Died();

            Died = null;
        }
    }
}