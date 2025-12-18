using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private float _countingInterval = 0.5f;
    [NonSerialized] public int InitialCount;

    private Coroutine _countingCoroutine;
    private WaitForSeconds _intervalWait;

    private int _count = 0;


    public event UnityAction<int> Changed;

    private void Awake()
    {
        _intervalWait = new WaitForSeconds(_countingInterval);
        InitialCount = _count;
    }

    private void OnEnable()
    {
       _mouseInput.Clicked += Toggle;
    }

    private void OnDisable()
    {
       _mouseInput.Clicked -= Toggle;
    }

    private void Toggle()
    {
        if (_countingCoroutine == null)
        {
            _countingCoroutine = StartCoroutine(Counting());
        }
        else
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private IEnumerator Counting()
    {
        while (true)
        {
            _count++;
            Changed?.Invoke(_count);
            yield return _intervalWait;
        }
    }
}
