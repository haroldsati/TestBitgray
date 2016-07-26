using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    private event Action Killed;
    private NavMeshAgent agent;
    private Collider myCollider;

    public void Initialize(Vector3 target, Action killed)
    {
        agent = GetComponent<NavMeshAgent>();
        myCollider = GetComponent<Collider>();

        Killed = killed;
        SetTarget(target);
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (myCollider.Raycast(ray, out hit, 100.0F))
                RaiseKilled();
        }
    }

    private void RaiseKilled()
    {
        if (Killed != null)
            Killed();

        agent.Stop();
        Destroy(gameObject);
    }

    public void SetTarget(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
            agent.Stop();
    }

}
