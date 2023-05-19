using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPicker : MonoBehaviour

{[SerializeField] int currentGun = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetCurrentGun();
    }

    void SetCurrentGun()
    {
        int gunIndex = 0;
        foreach( Transform gun in transform)
        {
            if(gunIndex == currentGun)
            {
                gun.gameObject.SetActive(true);
            }
            else
            {
                gun.gameObject.SetActive(false);
            }
            gunIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int previousGun = currentGun;

        ProcessKeyInput();
       // ProcessScrollWheel();
        if(previousGun != currentGun)
        {
            SetCurrentGun();
        }
    }

    private void ProcessKeyInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            currentGun = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            currentGun = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            currentGun = 2;
        }
    }
}
