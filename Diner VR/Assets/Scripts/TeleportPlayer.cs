using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportPlayer : MonoBehaviour
{
    public InputActionReference rightGripButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rightGripButton.action.triggered)
        {

        }
    }
}