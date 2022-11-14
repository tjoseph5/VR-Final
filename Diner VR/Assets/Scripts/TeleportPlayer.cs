using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportPlayer : MonoBehaviour
{
    private GameObject player;
    //public InputActionReference rightGripButton;
    public Transform teleportTo;
    private Vector3 offset = new Vector3(0, 0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Origin");
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//rightGripButton.action.triggered
        {
            Teleport();
        }
    }*/

    // Teleports the player to above the teleport location.
    public void Teleport()
    {
        player.transform.position = teleportTo.transform.position + offset;
        //player.transform.rotation = teleportTo.transform.rotation;
    }
}