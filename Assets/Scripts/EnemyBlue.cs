using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue : MonoBehaviour, IEnemy
{
    public GameObject enemy;

    public void Die()
    {
        Vector3 pos = enemy.transform.position;
        Destroy(enemy);

        SpawnEnemy.totalEnemy--;

        GameObject spawnEnemy = GameObject.Find("SpawnEnemy");
        Gem gemS = spawnEnemy.GetComponent<Gem>();
        gemS.SpawnGem(7, pos);

        GameObject gm = GameObject.Find("GameManager");
        GameManager gmS = gm.GetComponent<GameManager>();
        Gem[] gems = FindObjectsOfType<Gem>();
        foreach (Gem gem in gems)
        {
            if (!gem.isSubscribed)
            {
                gem.OnGemCollected += gmS.UpdateScore;
                gem.isSubscribed = true;
            }
        }
    }
}
