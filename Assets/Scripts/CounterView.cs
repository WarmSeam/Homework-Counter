using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TextMeshProUGUI _countDisplay;

    private void Awake()
    {
        _countDisplay = GetComponent<TextMeshProUGUI>();
        _countDisplay.text = _counter.InitialCount.ToString();
    }

    private void OnEnable()
    {
        _counter.Changed += OnCounterChanged;
    }

    private void OnDisable()
    {
        _counter.Changed -= OnCounterChanged;
    }

    private void OnCounterChanged(int count)
    {
        _countDisplay.text = count.ToString();
    }
}
