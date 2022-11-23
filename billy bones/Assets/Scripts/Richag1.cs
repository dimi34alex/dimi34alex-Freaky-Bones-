using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Richag1 : MonoBehaviour
{
    private bool _RichOpened;
    [SerializeField] private Animator _animator;


    public void Open()
    {
        _animator.SetBool("RichOpened",_RichOpened);
        _RichOpened = !_RichOpened;
    }
}
