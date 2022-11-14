using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ArmCannonSuck : MonoBehaviour
{
    public InputActionReference trigger;
    public InputActionReference grip;

    GameObject suckZone;

    // Start is called before the first frame update
    void Start()
    {
        suckZone = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float triggerInt = trigger.action.ReadValue<int>();
        float gripInt = grip.action.ReadValue<int>();
        
        if(gripInt == 0 && triggerInt == 0)
        {
            suckZone.SetActive(false);
        }
        else if(gripInt == 1 && triggerInt == 1)
        {
            suckZone.SetActive(true);
        }

        Debug.Log("Trigger: " + triggerInt);
        Debug.Log("Grip: " + gripInt);
    }

    private void OnEnable()
    {
        trigger.action.Enable();
        grip.action.Enable();
    }

    private void OnDisable()
    {
        trigger.action.Disable();
        grip.action.Disable();
    }
}
