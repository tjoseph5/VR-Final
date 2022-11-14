using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyType { projectile, charger };
    public EnemyType enemyType = EnemyType.charger;

    Rigidbody rb;

    [Header("Variables")]
    public GameObject ammo;
    public Transform shotPos;
    public float shotRate;
    public float shotStrength;

    public float moveSpeed; //multiple movement x1.5 for chargers
    public float distanceThreshold;
    float distanceFromPlayer;

    float shotTimer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        shotTimer = shotRate;
    }

    private void Update()
    {
        this.transform.LookAt(GameObject.FindWithTag("MainCamera").transform, Vector3.up);
        distanceFromPlayer = Vector3.Distance(this.transform.position, GameObject.FindWithTag("MainCamera").transform.position);
    }

    void FixedUpdate()
    {
        switch (enemyType)
        {
            case EnemyType.projectile:

                if(distanceFromPlayer > distanceThreshold)
                {
                    rb.MovePosition(Vector3.MoveTowards(this.transform.position, GameObject.FindWithTag("MainCamera").transform.position, Time.deltaTime * moveSpeed));
                }
                else if(distanceFromPlayer <= distanceThreshold)
                {
                    if(shotTimer > 0)
                    {
                        shotTimer -= Time.deltaTime;
                    }
                    else if(shotTimer <= 0)
                    {
                        GameObject shotAmmo = Instantiate(ammo, shotPos.position, Quaternion.Euler(-90, 0, 0), null);


                        Vector3 shotDirection = (GameObject.FindWithTag("MainCamera").transform.position - shotAmmo.transform.position).normalized;
                        shotAmmo.GetComponent<Rigidbody>().velocity = shotDirection * shotStrength * Time.deltaTime;
                        shotTimer = shotRate;
                    }
                }
                break;

            case EnemyType.charger:
                shotPos = null;
                ammo = null;
                rb.MovePosition(Vector3.MoveTowards(this.transform.position, GameObject.FindWithTag("MainCamera").transform.position, Time.deltaTime * moveSpeed));
                break;
        }
    }
}
