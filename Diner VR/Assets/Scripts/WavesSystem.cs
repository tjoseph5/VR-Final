using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesSystem : MonoBehaviour
{
    public static WavesSystem instance;

    public int waveCounter;
    public bool waveIsActive;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        //waveIsActive = false;
        waveCounter = 1;

        foreach(ItemSpawning item in GameObject.FindObjectsOfType<ItemSpawning>())
        {
            if (!item.canRefresh)
            {
                item.canRefresh = true;
            }
        }
    }

    private void Update()
    {
        if (waveIsActive)
        {
            if(EnemyManager.instance.enemyOrder > 0)
            {
                foreach (EnemySpawning spawner in GameObject.FindObjectsOfType<EnemySpawning>())
                {
                    spawner.canRefresh = true;
                }

                if(!ArmCannonShot.instance.canShoot && !ArmCannonSuck.instance.canSuck)
                {
                    ArmCannonShot.instance.canShoot = true;
                    ArmCannonSuck.instance.canSuck = true;
                }
            }
            else if(EnemyManager.instance.enemyOrder <= 0 && EnemyManager.instance.currentEnemies == 0)
            {
                waveIsActive = false;

                waveCounter++;
                ClearItems_UpdateSpawners();

                if (EnemyManager.instance.enemyCap < EnemyManager.instance.maxOverallEnemiesCap) { EnemyManager.instance.enemyCap += 3; }

                EnemyManager.instance.enemyOrderLimit += 5;
            }
        }
        else
        {
            foreach (EnemySpawning spawner in GameObject.FindObjectsOfType<EnemySpawning>())
            {
                spawner.canRefresh = false;
            }

            if (ArmCannonShot.instance.canShoot && ArmCannonSuck.instance.canSuck)
            {
                ArmCannonShot.instance.canShoot = false;
                ArmCannonSuck.instance.canSuck = false;
            }
        }
    }

    public void ClearItems_UpdateSpawners()
    {
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("Suckable"))
        {
            Destroy(item);
        }

        foreach(ItemSpawning spawner in GameObject.FindObjectsOfType<ItemSpawning>())
        {
            spawner.ActivateNewSpawn();
        }
    }
}
