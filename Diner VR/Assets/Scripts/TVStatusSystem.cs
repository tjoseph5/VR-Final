using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TVStatusSystem : MonoBehaviour
{
    [Header("Health Bar")]
    [SerializeField] Slider healthBar;

    [Header("Counters")]
    public TextMeshProUGUI waffleCounter;
    public TextMeshProUGUI friesCounter;
    public TextMeshProUGUI milkshakeCounter;

    [Header("UI Text")]
    public TextMeshProUGUI waveUI;
    public TextMeshProUGUI menuOrder;
    public TextMeshProUGUI statusUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = PlayerHead.instance.playerHealth;

        waffleCounter.text = EnemyManager.instance.waffleEnemyAmt.ToString();
        friesCounter.text = EnemyManager.instance.friesEnemyAmt.ToString();
        milkshakeCounter.text = EnemyManager.instance.milkshakeEnemyAmt.ToString();

        waveUI.text = "Wave " + WavesSystem.instance.waveCounter.ToString();

        switch (WavesSystem.instance.waveIsActive)
        {
            case true:
                statusUI.text = "Status: Active";
                menuOrder.text = "Remaining Orders: " + EnemyManager.instance.enemyOrder;
                break;

            case false:
                statusUI.text = "Status: Standby";
                menuOrder.text = "Order Queue: " + EnemyManager.instance.enemyOrder.ToString() + " / " + EnemyManager.instance.enemyOrderLimit.ToString();
                break;
        }
    }
}
