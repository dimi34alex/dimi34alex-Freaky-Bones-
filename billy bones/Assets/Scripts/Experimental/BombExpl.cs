using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExpl : MonoBehaviour
{
    public GameObject bomb;
    public GameObject explosion;
    public float radius;
    public float force;


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
            Explode();
            Destroy(bomb_clone);
            Destroy(explosion_clone, explosionPS.main.duration);       
        }
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Player" || colliders[i].gameObject.tag == "Enemy")
            {

            }
            Rigidbody rigidbody = colliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
