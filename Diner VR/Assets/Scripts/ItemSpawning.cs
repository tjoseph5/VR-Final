using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawning : MonoBehaviour
{
    public ItemPool originalPool;
    public List<GameObject> nonSpawnedItems;

    public GameObject currentItem;

    public int itemRandomID;

    float currentSpawnTime;
    public float currentSpawnDuration;

    public bool canRefresh;

    public bool debugCSA_Trigger;

    void Start()
    {
        ActivateNewSpawn();

        if(currentSpawnDuration == 0)
        {
            currentSpawnDuration = 10;
        }

        currentSpawnTime = 0;
        canRefresh = false;
        debugCSA_Trigger = false;
    }

    private void Update()
    {
        if (SuckZone.instance.WindZoneRbs.Contains(this.currentItem.GetComponent<Rigidbody>()))
        {
            canRefresh = true;
        }

        if (canRefresh)
        {
            currentSpawnTime += Time.deltaTime;
        }

        if(currentSpawnTime >= currentSpawnDuration)
        {
            canRefresh = false;
            currentSpawnTime = 0;
            CurrentSpawnActivation();
        }

        if (debugCSA_Trigger)
        {
            ActivateNewSpawn();
            debugCSA_Trigger = false;
        }
    }

    public void CurrentSpawnActivation()
    {
        GameObject spawnedObject = Instantiate(currentItem, transform.position, currentItem.transform.rotation, null);
        spawnedObject.GetComponent<StoredAmmoID>().originSpawn = this;
    }

    public void ActivateNewSpawn()
    {
        if (nonSpawnedItems.Count > 1)
        {
            nonSpawnedItems.RemoveAt(itemRandomID);
            itemRandomID = Random.Range(0, nonSpawnedItems.Count);

            currentItem = nonSpawnedItems[itemRandomID];

            CurrentSpawnActivation();

            Debug.Log("stuff in here");
        }
        else if(nonSpawnedItems.Count <= 1)
        {
            foreach(GameObject item in originalPool.items)
            {
                if (!nonSpawnedItems.Contains(item))
                {
                    nonSpawnedItems.Add(item);
                }
            }

            itemRandomID = Random.Range(0, nonSpawnedItems.Count);

            currentItem = nonSpawnedItems[itemRandomID];

            CurrentSpawnActivation();

            Debug.Log("nothing to see");
        }
    }
}
