using UnityEngine;
using System.Collections;
using System;

namespace Gameplay
{
    public class Enemy : MonoBehaviour
    {
        private event Action<bool/*wasKilled*/,Enemy> Destroyed;

        [SerializeField]
        private int damage;

        private NavMeshAgent agent;
        private Collider myCollider;
        private bool isAlive;

        public void Initialize(Vector3 target, Action<bool, Enemy> destroyed)
        {
            agent = GetComponent<NavMeshAgent>();
            myCollider = GetComponent<Collider>();

            Destroyed = destroyed;
            isAlive = true;
            agent.SetDestination(target);
        }

        public void SetParent(Transform parent, Vector3 position)
        {
            transform.SetParent(parent);
            transform.position = position;
        }

        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            if (isAlive && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (myCollider.Raycast(ray, out hit, 100.0F))
                    RaiseDestroyed(true);
            }
        }

        private void RaiseDestroyed(bool wasKilled)
        {
            if (Destroyed != null)
                Destroyed(wasKilled, this);

            Explode();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (isAlive && collision.gameObject.tag == "Target")
            {
                RaiseDestroyed(false);
                MakeDamage(collision.gameObject);
            }
        }

        private void MakeDamage(GameObject go)
        {
            Ally ally = go.GetComponentInChildren<Ally>(true);
            ally.TakeDamage(damage);
        }

        private void Explode()
        {
            isAlive = false;
            agent.Stop();
            Destroy(gameObject);
        }
    }
}
