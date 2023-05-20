using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkParticleSystem : MonoBehaviour
{
    //private ParticleSystem ps;
    GameObject bear;

    void Start()
    {
        Debug.Log("dsadS");
        bear = GameObject.FindGameObjectWithTag("Bear");

        ParticleSystem.MainModule psMain = bear.GetComponent<ParticleSystem>().main;
        // Set up the initial parameters of the particle system
        psMain.startLifetime = 2f;
        psMain.startSpeed = 10f;
        psMain.startSize = 1f;
        psMain.startColor = Color.white;

        // Add force to simulate movement and spread
        ParticleSystem.ForceOverLifetimeModule psForceLifetime = bear.GetComponent<ParticleSystem>().forceOverLifetime;
        psForceLifetime.enabled = true;
        psForceLifetime.x = new ParticleSystem.MinMaxCurve(0f, 5f);
        psForceLifetime.y = new ParticleSystem.MinMaxCurve(0f, 5f);
        psForceLifetime.z = new ParticleSystem.MinMaxCurve(0f, 5f);

        // Create trails behind the fireworks
        ParticleSystem.TrailModule psTrails = bear.GetComponent<ParticleSystem>().trails;
        psTrails.enabled = true;
        psTrails.lifetime = new ParticleSystem.MinMaxCurve(0.2f, 1f);
        //trails.sizeMultiplier = 0.5f;
        psTrails.colorOverLifetime = new ParticleSystem.MinMaxGradient(Color.white, Color.clear);

        // Emit the fireworks particles
        GetComponent<ParticleSystem>().Emit(100);
        //ps.Emit(100);
    }
}
