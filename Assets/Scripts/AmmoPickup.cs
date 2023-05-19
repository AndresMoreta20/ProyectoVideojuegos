using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] int ammoAmmount = 5;
    //[SerializeField] AmmType ammotype;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoAmmount);
           // Debug.Log("Player did");
            Destroy(gameObject);
        }
    }
}
