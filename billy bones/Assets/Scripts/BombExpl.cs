using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExpl : MonoBehaviour
{
    public GameObject bomb;
    public GameObject explosion;
    readonly Explosion_preferens exp_pr;
    
    public bool is_explosion = false;
    GameObject bomb_clone;
    GameObject explosion_clone;
    // Start is called before the first frame update
    void Start()
    {
        bomb_clone = bomb;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            explosion_clone = Instantiate(explosion, bomb.transform.position, Quaternion.identity);
            exp_pr.IsExplosion(explosion_clone);
            Destroy(bomb_clone);
            Debug.Log("Дошел до конца");
                        
        }
    }
}
