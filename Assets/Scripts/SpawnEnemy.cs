using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyRed;
    public GameObject enemyBlue;

    public int maxEnemy = 10;
    public static int totalEnemy = 0;
    private LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxEnemy; i++)
        {
            GenerateEnemy();
        }
    }

    private void Update()
    {
        if (totalEnemy < maxEnemy)
        {
            GenerateEnemy();
        }
    }

    private void GenerateEnemy()
    {
        float x = Random.Range(20, 80);
        float z = Random.Range(10, 65);
        ground = LayerMask.GetMask("Ground");
        RaycastHit hit;
        Physics.Raycast(new Vector3(x, 100f, z), Vector3.down, out hit, Mathf.Infinity, ground);

        if (Random.value > 0.5)
        {
            Instantiate(enemyRed, new Vector3(x, hit.point.y, z), Quaternion.identity);
            totalEnemy++;
        }
        else
        {
            Instantiate(enemyBlue, new Vector3(x, hit.point.y, z), Quaternion.identity);
            totalEnemy++;
        }
    } 
}
