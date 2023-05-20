using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
   [SerializeField] int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetCurrentWeapon();
    }

    void SetCurrentWeapon()
    {
        int weaponIndex = 0;
        foreach( Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
       // ProcessScrollWheel();
        if(previousWeapon != currentWeapon)
        {
            SetCurrentWeapon();
        }
    }

    private void ProcessKeyInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            currentWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            currentWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            currentWeapon = 2;
        }
    }
}
