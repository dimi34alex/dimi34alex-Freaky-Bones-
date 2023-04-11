using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_preferens : MonoBehaviour
{
    public ParticleSystem explosion_PS;

    private void Start()
    {
        //explosion_PS = this.GetComponent<ParticleSystem>();
    }
    public void IsExplosion(GameObject explosion)
    {
        Destroy(explosion, explosion_PS.main.duration);
    }
}
