using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
   // [SerializeField] Transform target;
    [SerializeField] float damage = 5f;

    void Start()
    {
       target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent(){
        if(target == null)
         {
            return;
            
        }
        target.TakeDamage(damage);
        //target.GetComponent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("bang");
    }
}
