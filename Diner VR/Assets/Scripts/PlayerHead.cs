using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public static PlayerHead instance;

    public int playerHealth;

    [SerializeField] Animator hurtEffectAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        playerHealth = 10;
    }

    private void Update()
    {
        if(playerHealth < 0)
        {
            playerHealth = 0;
        }

        if(playerHealth > 10)
        {
            playerHealth = 10;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<StoredAmmoID>())
        {
            if (!other.gameObject.GetComponent<StoredAmmoID>().hasBeenShot)
            {
                Destroy(other.gameObject);
                playerHealth -= 1;
                HurtEffect();
            }
        }
    }

    public void HurtEffect()
    {
        hurtEffectAnim.Play("HE");
    }
}
