using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActionReferences : MonoBehaviour
{
    public void StartWave()
    {
        WavesSystem.instance.waveIsActive = true;

        foreach(MenuOrderSystem menus in GameObject.FindObjectsOfType<MenuOrderSystem>())
        {
            Destroy(menus.gameObject, 1.5f);
        }
    }

    public void Substract(int enemy)
    {
        switch (enemy)
        {
            case 1:
                EnemyManager.instance.waffleEnemyAmt -= 1;
                break;

            case 2:
                EnemyManager.instance.friesEnemyAmt -= 1;
                break;

            case 3:
                EnemyManager.instance.milkshakeEnemyAmt -= 1;
                break;
        }
    }

    public void Addition(int enemy)
    {
        switch (enemy)
        {
            case 1:
                EnemyManager.instance.waffleEnemyAmt += 1;
                break;

            case 2:
                EnemyManager.instance.friesEnemyAmt += 1;
                break;

            case 3:
                EnemyManager.instance.milkshakeEnemyAmt += 1;
                break;
        }
    }
}
