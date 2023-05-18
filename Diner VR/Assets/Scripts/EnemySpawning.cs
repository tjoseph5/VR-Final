using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public ItemPool originalPool;

    public GameObject currentEnemy;

    public int itemRandomID;
    int numberCycle;

    float currentSpawnTime;
    public float currentSpawnDuration;

    public bool canRefresh;

    public bool debugCSA_Trigger;

    private void Start()
    {
        currentSpawnTime = 0;

        currentSpawnDuration = Random.Range(3, 10);

        currentEnemy = null;

    }

    private void Update()
    {
        if (canRefresh)
        {
            currentSpawnTime += Time.deltaTime;

            if(currentSpawnTime >= currentSpawnDuration)
            {
                if(EnemyManager.instance.currentEnemies < EnemyManager.instance.enemyCap)
                {
                    SpawnEnemies();
                }
                else
                {
                    currentSpawnTime = 0;
                    Debug.Log("cannot spawn until enemies are defeated");
                }
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

        currentSpawnDuration = Random.Range(3, 15);
    }

    int GiveMeANumber()
    {
        switch (numberCycle)
        {
            case 0:
                if (EnemyManager.instance.friesEnemyAmt >= 1)
                {
                    numberCycle = 1;
                }

                if(EnemyManager.instance.friesEnemyAmt <= 0 && EnemyManager.instance.milkshakeEnemyAmt >= 1)
                {
                    numberCycle = 2;
                }

                if(EnemyManager.instance.friesEnemyAmt <= 0 && EnemyManager.instance.milkshakeEnemyAmt <= 0)
                {
                    numberCycle = 0;
                }

                break;

            case 1:
                if (EnemyManager.instance.milkshakeEnemyAmt >= 1)
                {
                    numberCycle = 2;
                }

                if (EnemyManager.instance.milkshakeEnemyAmt <= 0 && EnemyManager.instance.waffleEnemyAmt >= 1)
                {
                    numberCycle = 0;
                }

                if (EnemyManager.instance.milkshakeEnemyAmt <= 0 && EnemyManager.instance.waffleEnemyAmt <= 0)
                {
                    numberCycle = 1;
                }
                break;

            case 2:
                if (EnemyManager.instance.waffleEnemyAmt >= 1)
                {
                    numberCycle = 0;
                }

                if (EnemyManager.instance.waffleEnemyAmt <= 0 && EnemyManager.instance.friesEnemyAmt >= 1)
                {
                    numberCycle = 1;
                }

                if (EnemyManager.instance.waffleEnemyAmt <= 0 && EnemyManager.instance.friesEnemyAmt <= 0)
                {
                    numberCycle = 2;
                }
                break;
        }

        return numberCycle;
    }
}