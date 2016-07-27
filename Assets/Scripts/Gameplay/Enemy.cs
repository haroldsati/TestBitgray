using UnityEngine;
using System;

namespace Gameplay.Detail
{
    public class Enemy : Character
    {
        private event Action<bool/*wasKilled*/,Enemy> Died;

        [SerializeField]
        private int damage;

        private NavMeshAgent agent;
        private Collider myCollider;
        private bool isAlive;

        public void Initialize(Vector3 target, Action<bool, Enemy> died)
        {
            agent = GetComponent<NavMeshAgent>();
            myCollider = GetComponent<Collider>();

            Died = died;
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
            if(isAlive)
                ProcessInput();
        }

        private void ProcessInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (myCollider.Raycast(ray, out hit, 100.0F))
                    RaiseDestroyed(true);
            }
        }        

        private void OnCollisionEnter(Collision collision)
        {
            if (isAlive && collision.gameObject.tag == "Target")
            {
                RaiseDestroyed(false);
                MakeDamage(collision.gameObject);
            }
        }

        private void RaiseDestroyed(bool wasKilled)
        {
            if (Died != null)
                Died(wasKilled, this);

            Explode();
        }

        private void MakeDamage(GameObject go)
        {
            Character character = go.GetComponentInChildren<Character>(true);
            character.TakeDamage(damage);
        }

        private void Explode()
        {
            isAlive = false;
            agent.Stop();
            Destroy(gameObject);
        }
    }
}
