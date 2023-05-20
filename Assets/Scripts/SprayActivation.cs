using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kvant;

public class SprayActivation : MonoBehaviour
{
    GameObject firefly;
    Spray spray;

    // Start is called before the first frame update
    void Start()
    {
        firefly = GameObject.FindGameObjectWithTag("Firefly");
        spray = firefly.GetComponent<Spray>();
        BearEvents.OnBearDroppedInside += GoalComplete;
    }

    private void GoalComplete()
    {
        spray.transform.position = SpawnTarget.currentTarget.transform.position;
        spray.throttle = 1;
        StartCoroutine(ResetThrottleAfterDelay(3f));
    }

    private IEnumerator ResetThrottleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spray.throttle = 0;
    }

}
