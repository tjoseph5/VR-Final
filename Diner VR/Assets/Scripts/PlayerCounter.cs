using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    void OnTirggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<EnemyAI>().enemyType == EnemyAI.EnemyType.charger)
        {
            Destroy(other.gameObject);
            PlayerHead.instance.playerHealth -= 1;
            PlayerHead.instance.HurtEffect();
        }
    }
}
