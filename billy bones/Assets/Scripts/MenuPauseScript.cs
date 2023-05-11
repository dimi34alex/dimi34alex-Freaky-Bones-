using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseScript : MonoBehaviour
{
    public GameObject PauseMenu, PauseSettings, Stamina, Tip;
    public bool Quit_Press, Esc_Press = false;
    public float timespeed = 1f;
    public int count = 0;

    public void PauseMenu_f()
    {
        PauseMenu.SetActive(true);
        Tip.SetActive(false);
        PauseSettings.SetActive(false);
    }

    public void PauseSettings_f()
    {
        PauseMenu.SetActive(false);
        PauseSettings.SetActive(true);
    }

    public void PauseContinue_f()
    {
        Esc_Press = false;
        count = 0;
        PauseMenu.SetActive(false);
        PauseSettings.SetActive(false);
        Stamina.SetActive(true);
        Tip.SetActive(true);
        timespeed = 1f;
    }

    public void Quit_Button()
    {
        Quit_Press = true;
    }

    public void Esc_Func()
    {
        Tip.SetActive(false);
        PauseMenu.SetActive(true);
        Stamina.SetActive(false);
        timespeed = 0f;
    }

    void Update()
    {
        Time.timeScale = timespeed;

        if ((Input.GetKeyDown(KeyCode.Escape)) && (count % 2 == 0))
        {
            Esc_Press = true;
            count++;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && (count % 2 == 1))
        {
            Esc_Press = false;
            count--;
        }

        if (Esc_Press)
        {
            Esc_Func();
        }
        else if (!Esc_Press)
        {
            PauseContinue_f();
        }

        if (Quit_Press)
        {
            Application.Quit();
        }
    }
}
