using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public ItemPool originalPool;
    public GameObject[] enemyPool;

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

        itemRandomID = Random.Range(minimumIndexID, enemyPool.Length);

        enemyPool = originalPool.items;

        currentEnemy = enemyPool[itemRandomID];
    }

    private void Update()
    {
        if (canRefresh)
        {
            IndexUpdater();
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
    }

    public void SpawnEnemies()
    {
        currentSpawnTime = 0;

        itemRandomID = Random.Range(minimumIndexID, enemyPool.Length);
        currentEnemy = enemyPool[itemRandomID];

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

    public void IndexUpdater()
    {
        if(EnemyManager.instance.waffleEnemyAmt == 0)
        {
            minimumIndexID = 1;
        }

        if(EnemyManager.instance.waffleEnemyAmt == 0 && EnemyManager.instance.friesEnemyAmt == 0)
        {
            minimumIndexID = 2;
        }

        if (EnemyManager.instance.waffleEnemyAmt == 0 && EnemyManager.instance.friesEnemyAmt == 0 && EnemyManager.instance.waffleEnemyAmt == 0)
        {
            canRefresh = false;
        }

        if(EnemyManager.instance.waffleEnemyAmt >= 1 && EnemyManager.instance.friesEnemyAmt >= 1 && EnemyManager.instance.waffleEnemyAmt >= 1)
        {
            canRefresh = true;

            minimumIndexID = 0;
        }
    }
}