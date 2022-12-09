using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    public void SpawnMenu()
    {
        Instantiate(WavesSystem.instance.menu, transform.position, transform.rotation, null);
    }

    public void SpawnBill()
    {
        Instantiate(WavesSystem.instance.gameOver, transform.position, transform.rotation, null);
    }
}
