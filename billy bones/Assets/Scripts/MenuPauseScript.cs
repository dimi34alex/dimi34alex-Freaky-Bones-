using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPauseScript : MonoBehaviour
{
    public GameObject PauseMenu, PauseSettings, PauseButton;
    public bool Quit_Press = false, Pause_Press = false;
    public float timespeed;

    public void PauseMenu_f()
    {
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
        PauseSettings.SetActive(false);
        Pause_Press = true;
    }

    public void PauseSettings_f()
    {
        PauseButton.SetActive(false);
        PauseMenu.SetActive(false);
        PauseSettings.SetActive(true);
    }

    public void PauseContinue_f()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        PauseSettings.SetActive(false);
        Pause_Press = false;
    }

    public void Quit_Button()
    {
        Quit_Press = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Time.timeScale = timespeed;
        if (Pause_Press)
        {
            timespeed = 0f;
        }
        else
        {
            timespeed = 1f;
        }

        if (Quit_Press)
        {
            Application.Quit();
        }
    }
}
