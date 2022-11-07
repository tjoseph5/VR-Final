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


    public InputActionReference trigger;

    public GameObject defaultAmmoObject; 

    void Start()
    {
        shotDirection = shotPos.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.action.triggered)
        {
            if(AmmoList.instance.suckedObjects[0] != null)
            {
                GameObject ammo = Instantiate(AmmoList.instance.suckedObjects[0], shotPos.position, shotPos.rotation, null);

                AmmoList.instance.suckedObjects.RemoveAt(0);
            }
            else
            {
                GameObject defaultAmmo = Instantiate(defaultAmmoObject, shotDirection * shotStrength, shotPos.rotation, null);
            }
        }
    }
}
