using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearEvents : MonoBehaviour
{
    public delegate void BearPickedUpDelegate();
    public static event BearPickedUpDelegate OnBearPickedUp;

    public delegate void BearDroppedOutsideDelegate();
    public static event BearDroppedOutsideDelegate OnBearDroppedOutside;

    public delegate void BearDroppedInsideDelegate();
    public static event BearDroppedInsideDelegate OnBearDroppedInside;

    public static void BearPickedUp()
    {
        OnBearPickedUp?.Invoke();
    }

    public static void BearDroppedOutside()
    {
        OnBearDroppedOutside?.Invoke();
    }

    public static void BearDroppedInside()
    {
        OnBearDroppedInside?.Invoke();
    }
}
