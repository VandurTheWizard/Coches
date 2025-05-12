using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAI : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    private Rigidbody rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("caminando", true);
        }
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}