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

    public enum FoodType { waffles, fries, milkshake };
    public FoodType foodType = FoodType.waffles;

    public int enemyHealth;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        shotTimer = shotRate;
        enemyHealth = 4;
    }

    private void Update()
    {
        this.transform.LookAt(GameObject.FindWithTag("MainCamera").transform, Vector3.up);
        distanceFromPlayer = Vector3.Distance(this.transform.position, GameObject.FindWithTag("MainCamera").transform.position);

        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
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

    private void OnCollisionEnter(Collision col)
    {
       if(col.gameObject.tag == "Suckable" && col.gameObject.GetComponent<StoredAmmoID>())
        {
            if (col.gameObject.GetComponent<StoredAmmoID>().hasBeenShot)
            {
                switch (foodType)
                {
                    case FoodType.waffles:
                        switch (col.gameObject.GetComponent<StoredAmmoID>().type)
                        {
                            case StoredAmmoID.ObjectType.fork:
                                enemyHealth -= enemyHealth;
                                break;

                            case StoredAmmoID.ObjectType.knife:
                                enemyHealth -= enemyHealth;
                                break;

                            case StoredAmmoID.ObjectType.cream:
                                enemyHealth -= enemyHealth;
                                break;

                            case StoredAmmoID.ObjectType.plate:
                                enemyHealth -= enemyHealth;
                                break;

                            case StoredAmmoID.ObjectType.syrup:
                                enemyHealth -= enemyHealth;
                                break;

                            default:
                                enemyHealth -= 1;
                                break;
                        }
                        break;

                    case FoodType.fries:
                        switch (col.gameObject.GetComponent<StoredAmmoID>().type)
                        {
                            case StoredAmmoID.ObjectType.ketchup:
                                enemyHealth -= enemyHealth;
                                break;

                            case StoredAmmoID.ObjectType.cream:
                                enemyHealth -= enemyHealth;
                                break;
                        }
                        break;

                    case FoodType.milkshake:
                        switch (col.gameObject.GetComponent<StoredAmmoID>().type)
                        {
                            case StoredAmmoID.ObjectType.spoon:
                                enemyHealth -= enemyHealth;
                                break;

                            case StoredAmmoID.ObjectType.fries:
                                enemyHealth -= enemyHealth;
                                break;

                            case StoredAmmoID.ObjectType.c_mug:
                                enemyHealth -= enemyHealth;
                                break;

                            default:
                                enemyHealth -= 1;
                                break;
                        }
                        break;
                }

                Destroy(col.gameObject);
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player Ammo")
        {
            Destroy(other.gameObject);
            enemyHealth -= 1;
        }
    }

    private void OnDestroy()
    {
        
    }
}
