using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public GameObject dialog;
    public int x1, x2, count = 0;
    public float time;

    public SpriteRenderer backgroundSprite;
    public TextMeshPro textMeshPro;

    public void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
    }

    void OnTriggerEnter()
    {
        dialog.SetActive(true);
        x1 = Random.Range(1, 4);
        switch(x1)
        {
            case 1:
                Setup("Эй, парень! Подожди!");
                break;
            case 2:
                Setup("Друже! Постой!");
                break;
            case 3:
                Setup("Брат по смерти, выслушай!");
                break;
            case 4:
                Setup("Эй БЛЯ УРОД СУКА ГНИДА");
                break;
            default:
                break;
        }
    }

    void OnTriggerStay()
    {
        if (count == 0)
        {
            count = 1;
            Invoke("Choice", 3f);
        }
    }

    void Choice()
    {
        x2 = Random.Range(1, 3);
        switch (x2)
        {
            case 1:
                Setup("Те, кто строили эту темницу, явно ничего не смыслили в архитектуре. Взять хотя бы тот неровный каменный столп. Из него же торчит камень! КАМЕНЬ! Из каменного столба! Зачем там камень?! Ха-ха-ха!");
                Invoke("PanelOff", 15f);
                break;
            case 2:
                Setup("Знаешь, на твоем месте я бы не стал общаться с тем парнем с оружием в руках, в зале, полном трупов. Я эмпат, и мне кажется, от него веет негативной энергетикой");
                Invoke("PanelOff", 10f);
                break;
            case 3:
                Setup("Иногда думаю о том, как было бы славно если бы нашу с тобой историю увековечили какие-нибудь консерваторы, а на экзамене за нее поставили бы высший балл. История про скелетов, черт возьми! Ну и чушь!");
                Invoke("PanelOff", 14f);
                break;
        }
    }

    void PanelOff()
    {
        dialog.SetActive(false);
    }

    void OnTriggerExit()
    {
        x1 = x2 = 0;
        count = 0;
        dialog.SetActive(false);
/*        PanelOff();*/
    }
}
