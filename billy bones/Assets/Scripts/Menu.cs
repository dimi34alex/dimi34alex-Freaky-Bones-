using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu, Settings, Loading;
    public bool Quit_Press = false, Pause_Press = false;
    private Animator anim;

    public void MainMenu_f()
    {
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        Loading.SetActive(false);
        anim.SetBool("IsRunning", false);
    }

    public void Settings_f()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(true);
        Loading.SetActive(false);
    }

    public void Loading_f()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(false);
        Loading.SetActive(true);
        anim.SetBool("IsRunning", true);
        Invoke("ActivationMainScene", 5f);
    }

    public void ActivationMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit_Button()
    {
        Quit_Press = true;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Quit_Press)
        {
            Application.Quit();
        }
    }
}
