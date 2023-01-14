using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    public void Dark()
    {
        _animator.SetBool("PlayerIN",true);
    }

    public void DeDark()
    {
        _animator.SetBool("PlayerIN",false);
    }
}
