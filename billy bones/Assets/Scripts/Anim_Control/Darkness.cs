using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private GameObject _object;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _object = transform.GetChild(i).gameObject;
            _object.SetActive(true);
        }
    }

    public void Dark()
    {
        _animator.SetBool("PlayerIN",true);
    }

    public void DeDark()
    {
        _animator.SetBool("PlayerIN",false);
    }
}
