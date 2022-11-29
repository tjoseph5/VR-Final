using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawning : MonoBehaviour
{
    public ItemPool originalPool;

    public GameObject currentEnemy;

    public int minimumIndexID;
    public int itemRandomID;

    float currentSpawnTime;
    public float currentSpawnDuration;

    public bool canRefresh;

    public bool debugCSA_Trigger;

    private void Start()
    {
        currentSpawnTime = 0;

        itemRandomID = GiveMeANumber();

        currentEnemy = originalPool.items[itemRandomID];


    }

    private void Update()
    {
        if (canRefresh)
        {
            currentSpawnTime += Time.deltaTime;

            if(currentSpawnTime >= currentSpawnDuration)
            {
                SpawnEnemies();
            }
        }
        else
        {
            currentSpawnTime = 0;
        }

        if (debugCSA_Trigger)
        {
            itemRandomID = GiveMeANumber();
            debugCSA_Trigger = false;
        }
    }

    public void SpawnEnemies()
    {
        currentSpawnTime = 0;

        itemRandomID = GiveMeANumber();
        currentEnemy = originalPool.items[itemRandomID];

        GameObject spawnedEnemy = Instantiate(currentEnemy, transform.position, transform.rotation, null);

        switch(itemRandomID)
        {
            case 0:
                EnemyManager.instance.waffleEnemyAmt -= 1;
                Debug.Log("Subtracted from Waffle");
                break;

            case 1:
                EnemyManager.instance.friesEnemyAmt -= 1;
                Debug.Log("Subtracted from Fries");
                break;

            case 2:
                EnemyManager.instance.milkshakeEnemyAmt -= 1;
                Debug.Log("Subtracted from Milkshake");
                break;
        }
    }

    private int GiveMeANumber()
    {
        var exclude = new HashSet<int>();
        var range = Enumerable.Range(0, originalPool.items.Count()).Where(i => !exclude.Contains(i));

        var rand = new System.Random();
        int index = rand.Next(0, originalPool.items.Count() - exclude.Count);


        if(EnemyManager.instance.waffleEnemyAmt == 0)
        {
            exclude.Add(0);
        }

        if (EnemyManager.instance.friesEnemyAmt == 0)
        {
            exclude.Add(1);
        }

        if (EnemyManager.instance.milkshakeEnemyAmt == 0)
        {
            exclude.Add(2);
        }

        return range.ElementAt(index);
    }
}