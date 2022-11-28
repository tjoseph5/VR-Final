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

    [Header("Enemy Limits")]
    public int enemyCap;
    public int enemyOrder;

    public int enemyLimit;
    public int currentEnemies;

    public int maxOverallEnemies;

    [Header("Enemy Amount")]
    public int waffleEnemyAmt;
    public int friesEnemyAmt;
    public int milkshakeEnemyAmt;

    [Header("Wave Properties")]
    public int startingCap;

    void Start()
    {
        enemyCap = startingCap;
    }

    void Update()
    {
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyOrder = waffleEnemyAmt + friesEnemyAmt + milkshakeEnemyAmt;
    }
}
