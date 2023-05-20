using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EnemyRed redEnemy = other.GetComponent<EnemyRed>();

        if (redEnemy != null)
        {
            redEnemy.Die();
        }

        EnemyBlue blueEnemy = other.GetComponent<EnemyBlue>();

        if (blueEnemy != null)
        {
            blueEnemy.Die();
        }
    }
}
