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

    bool canRefresh;

    void Start()
    {
        ActivateNewSpawn();

        if(currentSpawnDuration == 0)
        {
            currentSpawnDuration = 10;
        }

        currentSpawnTime = 0;
        canRefresh = false;
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
    }

    public void CurrentSpawnActivation()
    {
        GameObject spawnedObject = Instantiate(currentItem, transform.position, transform.rotation, null);
    }

    public void ActivateNewSpawn()
    {
        if (nonSpawnedItems.Capacity > 0)
        {
            nonSpawnedItems.RemoveAt(itemRandomID);
            itemRandomID = Random.Range(0, nonSpawnedItems.Capacity);

            currentItem = nonSpawnedItems[itemRandomID];

            GameObject spawnedObject = Instantiate(currentItem, transform.position, transform.rotation, null);
        }
        else if(nonSpawnedItems.Capacity == 0)
        {
            nonSpawnedItems = originalPool.items;

            currentItem = nonSpawnedItems[itemRandomID];

            itemRandomID = Random.Range(0, nonSpawnedItems.Capacity);

            GameObject spawnedObject = Instantiate(currentItem, transform.position, transform.rotation, null);

            nonSpawnedItems.RemoveAt(itemRandomID);
        }
    }
}
