using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeathRes : MonoBehaviour
{
    public GameObject spawnPoint, DeadScreen;
    
    //public Button button;
    public static PlayerDeathRes gameOver;
    public float timerDead = 3;
    public float timer = 0;
    private void Start()
    {
        gameOver = this;
    }
    public void Death()
    {
        timer += Time.fixedDeltaTime;
        DeadScreen.SetActive(true);
        if (timer >= timerDead)
        {
            transform.position = spawnPoint.transform.position;
            timer = 0;
            DeadScreen.SetActive(false);
        }
    }
}
