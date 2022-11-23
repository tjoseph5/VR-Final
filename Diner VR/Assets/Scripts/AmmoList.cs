using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoList : MonoBehaviour
{
    public List<GameObject> suckedObjects = new List<GameObject>();

    public ItemPool prefabSuckables;

    SuckZone zone;

    public static AmmoList instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    private void Start()
    {
        zone = GetComponentInParent<SuckZone>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Suckable")
        {
            zone.WindZoneRbs.Remove(other.gameObject.GetComponent<Rigidbody>());
            Destroy(other.gameObject);

            switch (other.GetComponent<StoredAmmoID>().type)
            {
                case StoredAmmoID.ObjectType.fork:
                    suckedObjects.Add(prefabSuckables.items[2]);
                    break;

                case StoredAmmoID.ObjectType.sphere:
                    suckedObjects.Add(prefabSuckables.items[0]);
                    break;

                case StoredAmmoID.ObjectType.ketchup:
                    suckedObjects.Add(prefabSuckables.items[4]);
                    break;

                case StoredAmmoID.ObjectType.mustard:
                    suckedObjects.Add(prefabSuckables.items[5]);
                    break;

                case StoredAmmoID.ObjectType.spoon:
                    suckedObjects.Add(prefabSuckables.items[1]);
                    break;

                case StoredAmmoID.ObjectType.knife:
                    suckedObjects.Add(prefabSuckables.items[3]);
                    break;

                case StoredAmmoID.ObjectType.fries:
                    suckedObjects.Add(prefabSuckables.items[6]);
                    break;
            }

            if(other.gameObject.GetComponent<StoredAmmoID>() && other.gameObject.GetComponent<StoredAmmoID>().originSpawn != null)
            {
                other.gameObject.GetComponent<StoredAmmoID>().originSpawn.canRefresh = true;
            }
        }
    }
}
