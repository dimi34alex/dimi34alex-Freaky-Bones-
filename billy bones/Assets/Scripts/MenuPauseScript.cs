using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseScript : MonoBehaviour
{
    public GameObject PauseMenu, PauseSettings, Stamina;
    public bool Quit_Press = false;
    public float timespeed = 1f;

    public void PauseMenu_f()
    {
        PauseMenu.SetActive(true);
        PauseSettings.SetActive(false);
    }

    public void PauseSettings_f()
    {
        PauseMenu.SetActive(false);
        PauseSettings.SetActive(true);
    }

    public void PauseContinue_f()
    {
        PauseMenu.SetActive(false);
        PauseSettings.SetActive(false);
        Stamina.SetActive(true);
        timespeed = 1f;
    }

/*    public void PauseToMainMenu_f()
    {
        SceneManager.LoadScene("StartMenu");
    }*/

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            Stamina.SetActive(false);
            timespeed = 0f;
        }

        if (Quit_Press)
        {
            Application.Quit();
        }
    }
}
