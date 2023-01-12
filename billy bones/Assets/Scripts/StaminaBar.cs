using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    public float resetStaminaTimer = 3;
    public int resetStaminaValue = 2;

    private static int maxStamina = 100;
    private int currentStamina = maxStamina;

    public static StaminaBar instance;

    public bool isUsingStamina = false;

    float timer = 0.0f;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;
    }

    private void FixedUpdate()
    {
        if (timer >= resetStaminaTimer && currentStamina <= 100)
        {
            ResetStamina();
        }
        timer += Time.fixedDeltaTime;
    }
    public void UseStamina(int cost)
    {

        if (CanUseStamina(cost))
        {
            if (Input.GetMouseButtonDown(1)) { isUsingStamina = true; }
            else if (Input.GetMouseButtonUp(1)) { isUsingStamina = false; }

            currentStamina -= cost;
            staminaBar.value = currentStamina;
            timer = 0.0f;
        }
        else
        {
            Debug.Log("Не хватает энергии");
        }
    }
    public bool CanUseStamina(int cost)
    {
        if (currentStamina - cost >= 0)
            return true;
        else
            return false;
    }
    public void ResetStamina()
    {
        currentStamina += resetStaminaValue;
        staminaBar.value = currentStamina;
    }
}
