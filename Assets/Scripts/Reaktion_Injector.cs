using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reaktion;
using UnityEngine.UI;



public class Reaktion_Injector : InjectorBase
{
    public Slider slider;

    private void Update()
    {
        dbLevel = slider.value;

    }
}
