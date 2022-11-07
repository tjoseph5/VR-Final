using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ArmCannonSuck : MonoBehaviour
{
    public InputActionReference trigger;
    public InputActionReference grip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
