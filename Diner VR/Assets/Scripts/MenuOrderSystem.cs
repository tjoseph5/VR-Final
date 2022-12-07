using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuOrderSystem : MonoBehaviour
{
    [Header("Order Up Button")]

    public Button orderUpButton;

    [Header("Subtract Buttons")]

    public Button waffleSub;
    public Button friesSub;
    public Button milkshakeSub;

    [Header("Addition Buttons")]

    public Button waffleAdd;
    public Button friesAdd;
    public Button milkshakeAdd;

    [Header("Counters")]
    public TextMeshProUGUI waffleCounter;
    public TextMeshProUGUI friesCounter;
    public TextMeshProUGUI milkshakeCounter;

    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (!WavesSystem.instance.waveIsActive)
        {
            waffleCounter.text = EnemyManager.instance.waffleEnemyAmt.ToString();
            friesCounter.text = EnemyManager.instance.friesEnemyAmt.ToString();
            milkshakeCounter.text = EnemyManager.instance.milkshakeEnemyAmt.ToString();

            if (EnemyManager.instance.waffleEnemyAmt <= 0)
            {
                waffleSub.interactable = false;
            }
            else
            {
                waffleSub.interactable = true;
            }

            if (EnemyManager.instance.friesEnemyAmt <= 0)
            {
                friesSub.interactable = false;
            }
            else
            {
                friesSub.interactable = true;
            }

            if (EnemyManager.instance.milkshakeEnemyAmt <= 0)
            {
                milkshakeSub.interactable = false;
            }
            else
            {
                milkshakeSub.interactable = true;
            }


            if (EnemyManager.instance.enemyOrder == EnemyManager.instance.enemyOrderLimit)
            {
                waffleAdd.interactable = false;
                friesAdd.interactable = false;
                milkshakeAdd.interactable = false;

                orderUpButton.interactable = true;
            }
            else if (EnemyManager.instance.enemyOrder < EnemyManager.instance.enemyOrderLimit)
            {
                waffleAdd.interactable = true;
                friesAdd.interactable = true;
                milkshakeAdd.interactable = true;

                orderUpButton.interactable = false;
            }

            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            if(gameObject.tag != "Suckable")
            {
                gameObject.tag = "Suckable";
            }

            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
