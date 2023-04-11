using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExpl : MonoBehaviour
{
    public GameObject bomb;
    public GameObject explosion;

    ParticleSystem explosionPS;
    GameObject bomb_clone;
    void Start()
    {
        bomb_clone = bomb;
        explosionPS = explosion.GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameObject explosion_clone = Instantiate(explosion, bomb.transform.position, Quaternion.identity);
            Destroy(bomb_clone);
            Destroy(explosion_clone, explosionPS.main.duration);       
        }
    }
}
