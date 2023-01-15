using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeathRes : MonoBehaviour
{
    public GameObject spawnPoint, Dead;
    
    public bool isDeath = false;
    //public Button button;
    public static PlayerDeathRes gameOver;
    [SerializeField] float timer = 3;
    [SerializeField] float timerClone = 3;
    private void Awake()
    {
        gameOver = this;
    }
    void Start()
    {
        
    }

    public void Death()
    {
        isDeath = true;
    }
    private void Update()
    {
        if (isDeath == true)
        {
            timer -= Time.fixedDeltaTime;
            Dead.SetActive(true);
            if (timer <= 0)
            {
                transform.position = spawnPoint.transform.position;
                isDeath = false;
                timer = timerClone;
                Dead.SetActive(false);
            }
        }
    }
}
