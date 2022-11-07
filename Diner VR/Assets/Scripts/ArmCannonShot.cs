using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmCannonShot : MonoBehaviour
{
    public Transform shotPos;
    public float shotRate;
    public float shotStrength;
    Vector3 shotDirection;

    public bool ammoEmpty;


    public InputActionReference trigger;

    public GameObject defaultAmmoObject; 

    void Start()
    {
        shotDirection = shotPos.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(AmmoList.instance.suckedObjects.Count > 0)
        {
            ammoEmpty = false;
        }
        else
        {
            ammoEmpty = true;
        }


        if (trigger.action.triggered)
        {
            if(!ammoEmpty)
            {
                GameObject ammo = Instantiate(AmmoList.instance.suckedObjects[0], shotPos.position, shotPos.rotation, null);
                ammo.GetComponent<Rigidbody>().velocity = shotStrength * shotDirection;

                AmmoList.instance.suckedObjects.RemoveAt(0);
            }
            else
            {
                GameObject defaultAmmo = Instantiate(defaultAmmoObject, shotPos.position, shotPos.rotation, null);
                defaultAmmo.GetComponent<Rigidbody>().velocity = shotStrength * shotDirection;

                Debug.Log("bruh");
            }
        }
    }
}
