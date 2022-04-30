using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementWithAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Open");
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
