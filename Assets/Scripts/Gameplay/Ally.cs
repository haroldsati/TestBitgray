using UnityEngine;
using System.Collections;
using System;

namespace Gameplay.Detail
{
    public class Ally : Character
    {
        private event Action Died;

        [SerializeField]
        private int maxHealth;

        private float currentHealth;

        public float HealthPercent
        {
            get { return (float)currentHealth / (float)maxHealth; }
        }

        public void Play(Action died)
        {
            Died = died;
            currentHealth = maxHealth;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
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