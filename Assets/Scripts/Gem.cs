using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public event System.Action<int> OnGemCollected;

    public int gemValue = 1;
    public GameObject gem;
    public bool isSubscribed = false;

    public void Collect()
    {
        OnGemCollected?.Invoke(gemValue);

        Destroy(gameObject);
    }

    public void SpawnGem(int num, Vector3 loc)
    {
        for (int i = 0; i < num; i++)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-2f, 2f), Random.Range(2f, 5f), Random.Range(2f, 2f));
            Instantiate(gem, loc + randomOffset, Quaternion.identity);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (gem != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Collect();
                Debug.Log("collected");
            }
        }
    }
}
