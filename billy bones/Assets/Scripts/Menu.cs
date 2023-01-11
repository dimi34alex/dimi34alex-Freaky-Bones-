using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu, Settings, Loading, LogoFront, Logo, LogoBack;
    public bool Quit_Press = false, Pause_Press = false;
    public int count = 0;
    private Animator anim;

    public void Logo_f()
    {
        Logo.SetActive(true);
        Invoke("MainMenu_f", 5f);
    }

    public void MainMenu_f()
    {
        Logo.SetActive(false);
        LogoBack.SetActive(false);
        Invoke("LogoFront_off", 1f);
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        Loading.SetActive(false);
        anim.SetBool("IsRunning", false);
    }

    public void LogoFront_off()
    {
        LogoFront.SetActive(false);
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
        Logo_f();
    }

    void FixedUpdate()
    {
        if (LogoBack.GetComponent<Image>().color.a <= 1 && LogoBack.GetComponent<Image>().color.a > 0)
        {
            var tempColor = LogoBack.GetComponent<Image>().color;
            tempColor.a -= Time.fixedDeltaTime / 3;
            LogoBack.GetComponent<Image>().color = tempColor;
        }

        if (LogoBack.GetComponent<Image>().color.a < 0.001)
        {
            var tempColor = Logo.GetComponent<Image>().color;
            tempColor.a -= Time.fixedDeltaTime / 2;
            Logo.GetComponent<Image>().color = tempColor;
        }

        if (Logo.GetComponent<Image>().color.a < 0.001)
        {
            var tempColor = LogoFront.GetComponent<Image>().color;
            tempColor.a -= Time.fixedDeltaTime;
            LogoFront.GetComponent<Image>().color = tempColor;
        }

        if (Quit_Press)
        {
            Application.Quit();
        }
    }
}
