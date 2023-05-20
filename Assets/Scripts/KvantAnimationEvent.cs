using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kvant;

public class KvantAnimationEvent : MonoBehaviour
{
    public GameObject sprayObject;
    Spray spray;

    private void Start()
    {
        spray = sprayObject.GetComponent<Spray>();
    }

    public void AdjustThrottle(float dur)
    {
        while (dur > 0)
        {
            spray.throttle = 1f;
            dur -= Time.deltaTime;
        }
        spray.throttle = 0f;
    }
}
