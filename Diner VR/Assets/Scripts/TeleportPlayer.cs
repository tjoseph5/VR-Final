using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportPlayer : MonoBehaviour
{
    private GameObject player;
    public InputActionReference rightGripButton;
    public Transform teleportTo;
    private Vector3 offset = new Vector3(0, 2, 0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Origin");
    }

    // Update is called once per frame
    void Update()
    {
        if (rightGripButton.action.triggered)
        {
            player.transform.position = teleportTo.transform.position + offset;
            player.transform.rotation = teleportTo.transform.rotation;
        }
    }
}