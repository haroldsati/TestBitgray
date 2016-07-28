using UnityEngine;
using System;
using Vuforia;

namespace Gameplay.Detail
{
    public class Enemy : Character
    {
        private event Action<bool/*wasKilled*/,Enemy> Died;
        
        [SerializeField]
        private ParticleSystem explosion;
        [SerializeField]
        private GameObject model;
        [SerializeField]
        private EnemyAnimator animator;
        [SerializeField]
        private int damage;

        private bool isAlive;
        private EnemyInput input = new EnemyInput();

        public void Initialize(Vector3 target, Action<bool, Enemy> died)
        {
            Died = died;
            isAlive = true;
            animator.Initialize(transform, target);
            input.Initialize(GetComponent<Collider>());
        }

        public void SetParent(Transform parent, Vector3 position, float scale)
        {
            transform.SetParent(parent);
            transform.localScale = new Vector3 (scale, scale, scale);
            transform.localPosition = position;
        }

        private void Update()
        {
            if(isAlive)
            {
                ProcessInput();
                animator.Update();
            }
        }

        private void ProcessInput()
        {
            if (input.WasTouched())
                RaiseDestroyed(true);
        }        

        private void OnCollisionEnter(Collision collision)
        {
            if (isAlive && collision.gameObject.tag == "Target")
            {
                RaiseDestroyed(false);
                MakeDamage(collision.gameObject, collision.collider);
            }
        }

        private void RaiseDestroyed(bool wasKilled)
        {
            if (Died != null)
                Died(wasKilled, this);

            Explode();
        }

        private void MakeDamage(GameObject go, Collider col)
        {
            Character character = go.GetComponentInParent<Character>();
            if (character != null)
                character.TakeDamage(damage, col);
            else
                Debug.LogWarning("There is not a Character component in the target");
        }

        private void Explode()
        {
            isAlive = false;
            explosion.Play(true);
            animator.Stop();
            Invoke("OnExplosionFinished", explosion.duration);
            model.SetActive(false);
        }

        private void OnExplosionFinished()
        {
            Destroy(gameObject);
        }        
    }
}
