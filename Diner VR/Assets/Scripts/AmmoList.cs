using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoList : MonoBehaviour
{
    public List<GameObject> suckedObjects = new List<GameObject>();

    public List<GameObject> prefabSuckables;

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
        prefabSuckables = new List<GameObject>(Resources.LoadAll<GameObject>("Suckables"));

        zone = GetComponentInParent<SuckZone>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    suckedObjects.Add(prefabSuckables[0]);
                    break;

                case StoredAmmoID.ObjectType.sphere:
                    suckedObjects.Add(prefabSuckables[2]);
                    break;

                case StoredAmmoID.ObjectType.ketchup:
                    suckedObjects.Add(prefabSuckables[2]);
                    break;
            }
        }
    }
}
