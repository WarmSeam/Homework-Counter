using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private Animator _buttonAnimator;
    [SerializeField] private AnimationClip _clickAnimation;

    public event UnityAction Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayClickAnimation();
            Clicked?.Invoke();
        }
    }

    public void PlayClickAnimation()
    {
        _buttonAnimator.Play(_clickAnimation.name);
    }
}
