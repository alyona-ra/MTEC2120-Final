using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public GameObject target;
    LayerMask ground;

    public static GameObject currentTarget;

    private void Start()
    {

        BearEvents.OnBearPickedUp += Spawn;
        BearEvents.OnBearDroppedOutside += DestroyCurrentTarget;
        BearEvents.OnBearDroppedInside += GoalComplete;

    }


    private void OnDestroy()
    {
        BearEvents.OnBearPickedUp -= Spawn;
        BearEvents.OnBearDroppedOutside -= DestroyCurrentTarget;
        BearEvents.OnBearDroppedInside -= GoalComplete;
    }

    private void Spawn()
    {
        if (currentTarget == null)
        {
            float x = Random.Range(40, 60);
            float z = Random.Range(30, 35);
            ground = LayerMask.GetMask("Ground");
            RaycastHit hit;
            Physics.Raycast(new Vector3(x, 100f, z), Vector3.down, out hit, Mathf.Infinity, ground);
            currentTarget = Instantiate(target, new Vector3(x, hit.point.y, z), Quaternion.identity);
            currentTarget.transform.Rotate(90f, 0, 0);
        }
    }

    private void DestroyCurrentTarget()
    {
        if (currentTarget != null)
        {
            Destroy(currentTarget);
            currentTarget = null;
        }
    }

    private void GoalComplete()
    {
        Debug.Log("Bear is inside the target");
    }
}
