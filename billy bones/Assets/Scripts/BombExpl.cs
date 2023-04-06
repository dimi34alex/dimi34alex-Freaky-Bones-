using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExpl : MonoBehaviour
{
    public GameObject bomb;
    public GameObject explosion;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = bomb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(explosion, bomb.transform);
            Debug.Log("лллллллллллллл");
            Destroy(bomb);

        }
    }
}
