using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tet_a_tet : MonoBehaviour
{
    public SpriteRenderer backgroundSprite;
    public TextMeshPro textMeshPro;

    private void Awake()
    {
        backgroundSprite = transform.Find("SpriteBack").GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Setup("NOT RANDOM TEXT A TEXT SETUP");
    }

    public void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
    }
}
