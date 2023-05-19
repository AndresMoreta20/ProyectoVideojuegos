using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI ammoText;

   public void TakeDamage(float damage){
        hitPoints -= damage;

        if(hitPoints <=0)
        {
            GetComponent<DeathHandler>().HandleDeath();

        }
   }

   private void Update() {
        ammoText.text = "Vida: " + hitPoints.ToString();
   }
}
