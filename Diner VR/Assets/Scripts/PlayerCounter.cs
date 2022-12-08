using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && col.gameObject.GetComponent<EnemyAI>())
        {
            if (col.gameObject.GetComponent<EnemyAI>().enemyType == EnemyAI.EnemyType.charger)
            {
                Destroy(col.gameObject);
                PlayerHead.instance.playerHealth -= 1;
                PlayerHead.instance.HurtEffect();
            }
        }
    }
}
