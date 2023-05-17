using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
     public float explosionRadius = 5.0f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Prueba");
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {

            EngageTarget();
        }

        else if(distanceToTarget <= chaseRange){
           // navMeshAgent.SetDestination(target.position);
           isProvoked = true;
        }

    }

    private void EngageTarget(){
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }

    }

    private void ChaseTarget(){
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log(name + "is seeking and destroying" + target.name);
    }
   

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
//        Gizmos.DrawSphere(transform.position, explosionRadius);
    }

    
}
