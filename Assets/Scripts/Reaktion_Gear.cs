using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reaktion;

public class Reaktion_Gear : MonoBehaviour
{
    public ReaktorLink reaktor;
    private GameObject fire;
    //public Modifier speed = Modifier.Linear(0, 5);
    public float scale = 10.0f;

    private void Awake()
    {
        reaktor.Initialize(this);
    }

    private void Update()
    {
        //Debug.Log("Reactor Output: " + reaktor.Output + " || Linear: " + toLinear(reaktor.Output * scale));

        fire = GameObject.FindGameObjectWithTag("Fire");
        ParticleSystem.MainModule ps = fire.GetComponent<ParticleSystem>().main;
        ps.simulationSpeed = toLinear(reaktor.Output * scale);
    }

    private float toLinear(float db)
    {
        float linear = Mathf.Pow(10.0f, db / 20.0f);
        return linear;
    }
}


