using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] GameObject hitEffect ;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] TextMeshProUGUI ammoText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo();
        ammoText.text = "Balas: " + currentAmmo.ToString();
    }

    private void Shoot()
    {
        
       
        if(ammoSlot.GetCurrentAmmo() > 0){
            GetComponent<AudioSource>().Play();
            RaycastHit hit;
        
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            
            //DECREASE ENEMY HEALTH
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            ammoSlot.ReduceCurrentAmmo();
            if(target == null){
                return;
            }
            target.TakeDamage(damage);
            
        }
        else
        {
            return;
        }
        
       

        }
        
        
        

    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }

}
