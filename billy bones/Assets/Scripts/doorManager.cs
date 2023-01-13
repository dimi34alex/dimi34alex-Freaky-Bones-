using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
    private bool _isOpened = false;
    [SerializeField] private Animator _animator;


    public void Open()
    {
        _isOpened = true;
        _animator.SetBool("isOpened",_isOpened);
    }
}
