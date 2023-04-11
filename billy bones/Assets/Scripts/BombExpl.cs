using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExpl : MonoBehaviour
{
    public GameObject bomb;
    public GameObject explosion;
    Rigidbody rb;
    ParticleSystem explosion_PS;
    public float timer = 0;
    public bool is_explosion = false;
    GameObject explosion_clone;
    GameObject bomb_clone;
    // Start is called before the first frame update
    void Start()
    {
        rb = bomb.GetComponent<Rigidbody>();
        explosion_PS = explosion.GetComponent<ParticleSystem>();
        bomb_clone = bomb;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_explosion)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                Destroy(explosion_clone);
                is_explosion = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            explosion_clone = Instantiate(explosion, bomb.transform.position, Quaternion.identity);

            is_explosion = true;
            Debug.Log("лллллллллллллл");
            Destroy(bomb_clone);
                        
        }
    }
}
