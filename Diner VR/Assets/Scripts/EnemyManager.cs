using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [HideInInspector] public int enemyCap;        //Caps how many enemies can spawn in the scene
    [HideInInspector] public int enemyOrder;      //The equal amount of enemies that the player orders. The player needs to order the max order limit in order to start the round

    [HideInInspector] public int enemyOrderLimit; //The order limit for each wave. increases by a certain level each round
    [HideInInspector] public int currentEnemies;  //Tracks how many enemies are currently in scene

    [Header("Enemy Amount")]
    public int waffleEnemyAmt;  //Waffle amount the player order ups for
    public int friesEnemyAmt;   //Fry amount the player order ups for
    public int milkshakeEnemyAmt; //Milkshake amount the player order ups for

    [Header("Wave Properties")]
    public int startingCap; //The starting cap for the enemyCap variable
    public int startingOrderLimit; //The starting limit for the enemyOrderLimit variable
    public int maxOverallEnemiesCap; //Makes sure enemy cap doesn't exceed an unplayable amount for the player

    void Start()
    {
        enemyCap = startingCap;
    }

    void Update()
    {
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyOrder = waffleEnemyAmt + friesEnemyAmt + milkshakeEnemyAmt;

        if(waffleEnemyAmt <= 0 && friesEnemyAmt <= 0 && milkshakeEnemyAmt <= 0)
        {
            foreach(EnemySpawning spawn in GameObject.FindObjectsOfType<EnemySpawning>())
            {
                spawn.canRefresh = false;
            }
        }

        if(enemyCap > maxOverallEnemiesCap)
        {
            enemyCap = maxOverallEnemiesCap;
        }
    }
}
