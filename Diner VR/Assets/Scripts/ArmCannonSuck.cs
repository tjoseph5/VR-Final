using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ArmCannonSuck : MonoBehaviour
{
    public InputActionReference trigger;

    GameObject suckZone;

    public bool canSuck;

    public static ArmCannonSuck instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        suckZone = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSuck)
        {
            if (trigger.action.triggered)
            {
                if (!suckZone.activeSelf)
                {
                    suckZone.SetActive(true);
                }
                else
                {
                    suckZone.SetActive(false);
                }
            }
        }
        
    }

    private void OnEnable()
    {
        trigger.action.Enable();
    }

    private void OnDisable()
    {
        trigger.action.Disable();
    }
}
