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
        int triggerInt = (int) trigger.action.ReadValue<float>();
        int gripInt = (int) grip.action.ReadValue<float>();
        
        if(gripInt == 0 && triggerInt == 0)
        {
            suckZone.SetActive(false);
        }
        else if(gripInt == 1 && triggerInt == 1)
        {
            suckZone.SetActive(true);
        }
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
