using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Richag1 : MonoBehaviour
{
    public GameObject Open_Door;
    private bool _RichOpened = false;
    [SerializeField] private Animator _animator;


    public void Open()
    {
        _RichOpened = true;
        _animator.SetBool("RichOpened",_RichOpened);
        Open_Door.GetComponent<doorManager>().Open();

    }
    
}
