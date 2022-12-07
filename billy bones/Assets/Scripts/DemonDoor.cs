using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDoor : MonoBehaviour
{
    private bool _isOpened = true;
    [SerializeField] private Animator _animator;


    public void Open()
    {
        _animator.SetBool("isOpened",_isOpened);
        _isOpened = !_isOpened;
    }
}
