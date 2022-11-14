using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyType { projectile, charger };
    public EnemyType enemyType = EnemyType.charger;

    [Header("Variables")]
    public GameObject ammo;
    public Transform shotPos;
    public float shotRate;
    public float shotStrength;

    public float moveSpeed; //multiple movement x1.5 for chargers

    void Start()
    {
        
    }

    private void Update()
    {
        this.transform.LookAt(GameObject.FindWithTag("MainCamera").transform, Vector3.up);
    }

    void FixedUpdate()
    {
        switch (enemyType)
        {
            case EnemyType.projectile:

                break;

            case EnemyType.charger:

                break;
        }
    }
}
