﻿using UnityEngine;
using System;

namespace Gameplay.Detail
{
    public class Ally : Character
    {
        private event Action Died;

        [SerializeField]
        private AllyAnimator animator;
        [SerializeField]
        private ParticleSystem explosion; 
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
            animator.Initialize(transform);
            currentHealth = maxHealth;
        }

        public override void TakeDamage(int damage, Collider hit)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                RaiseDied();
            }
            else
                animator.AnimateHit(hit);
        }

        private void RaiseDied()
        {
            if (Died != null)
                Died();

            Died = null;
            animator.Fall();
        }

        public void Explode()
        {
            explosion.Play();
        }
    }
}