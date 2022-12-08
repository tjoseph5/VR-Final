using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoredAmmoID : MonoBehaviour
{
    public enum ObjectType { c_mug, fork, spoon, knife, ketchup, mustard, fries, plate, syrup }
    public ObjectType type;

    public ItemSpawning originSpawn;

    public bool hasBeenShot = false;
}
