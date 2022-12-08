using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Management;
using UnityEngine.XR.Interaction.Toolkit;

public class WavesSystem : MonoBehaviour
{
    public static WavesSystem instance;

    public int waveCounter;
    public bool waveIsActive;

    public GameObject menu;
    public GameObject gameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        waveIsActive = false; //make this false at the start
        waveCounter = 1;

        foreach (MenuSpawner spawner in GameObject.FindObjectsOfType<MenuSpawner>())
        {
            spawner.SpawnMenu();
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

                PlayerHead.instance.playerHealth = 10;
            }

            //GameObject.Find("RightHand Controller").GetComponent<XRInteractorLineVisual>().enabled = false;
            GameObject.Find("LeftHand Controller").GetComponent<XRInteractorLineVisual>().enabled = false;

            //GameObject.Find("RightHand Controller").GetComponent<LineRenderer>().enabled = false;
            GameObject.Find("LeftHand Controller").GetComponent<LineRenderer>().enabled = false;

            foreach(Button button in GameObject.FindObjectsOfType<Button>())
            {
                if (button.interactable)
                {
                    button.interactable = false;
                }
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

            ArmCannonSuck.instance.suckZone.SetActive(false);

            //GameObject.Find("RightHand Controller").GetComponent<XRInteractorLineVisual>().enabled = true;
            GameObject.Find("LeftHand Controller").GetComponent<XRInteractorLineVisual>().enabled = true;

            //GameObject.Find("RightHand Controller").GetComponent<LineRenderer>().enabled = true;
            GameObject.Find("LeftHand Controller").GetComponent<LineRenderer>().enabled = true;
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
            spawner.canRefresh = false;
            spawner.ActivateNewSpawn();
        }

        foreach(MenuSpawner spawner in GameObject.FindObjectsOfType<MenuSpawner>())
        {
            spawner.SpawnMenu();
        }
    }
}
