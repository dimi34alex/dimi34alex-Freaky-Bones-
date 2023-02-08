using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerScript_TipE : MonoBehaviour
{
    public GameObject back;
    public TextMeshPro textMeshPro;

    public void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Hand")
        {
            Setup("E - Take item / Interaction"); ;
            back.SetActive(true);
        }
    }

    void OnTriggerExit()
    {
        back.SetActive(false);
    }
}
