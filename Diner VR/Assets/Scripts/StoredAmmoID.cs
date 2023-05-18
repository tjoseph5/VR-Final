using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoredAmmoID : MonoBehaviour
{
    public enum ObjectType { c_mug, fork, spoon, knife, ketchup, mustard, fries, plate, syrup, cream }
    public ObjectType type;

    public ItemSpawning originSpawn;

    public bool hasBeenShot = false;

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "surface")
        {
            if (!gameObject.GetComponent<Rigidbody>().useGravity)
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
