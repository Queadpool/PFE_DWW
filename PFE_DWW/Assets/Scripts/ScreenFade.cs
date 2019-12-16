using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            FadeToDeath();
        }
    }

    public void FadeToDeath()
    {
        _animator.SetTrigger("FadeOut");
        _animator.ResetTrigger("FadeIn");
    }

    public void OnFadeComplete()
    {
        _animator.SetTrigger("FadeIn");
        _animator.ResetTrigger("FadeOut");
    }
}
