using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour
{
    [SerializeField] Transform target;
     [SerializeField] float turnSpeed = 5f;
    [SerializeField] float chaseRange = 5f;
     public float explosionRadius = 5.0f;
     public float damage = 20f;

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

    private void EngageTarget()
    {
        TurnToTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }

    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
      //  target.GetComponent<PlayerHealth>().TakeDamage(damage);
        
    }

    private void TurnToTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation  = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
   

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
//        Gizmos.DrawSphere(transform.position, explosionRadius);
    }

    
}
