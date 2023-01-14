using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeathRes : MonoBehaviour
{
    public GameObject gameOver;
    public Button button;
    public PlayerDeathRes instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameOver.SetActive(false);
    }

    public void Death()
    {

    }
    public void Respawn()
    {

    }
}
