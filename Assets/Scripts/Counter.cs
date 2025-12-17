using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _timeInterval = 0.5f;
    [SerializeField] private TextMeshProUGUI _countDisplay;

    private bool _isActive;
    private int _currentCount;

    private void Start()
    {
        _countDisplay.text = "0";

        if (int.TryParse(_countDisplay.text, out int result))
            _currentCount = result;
        else
            _currentCount = 0;

        _isActive = false;
    }

    private void OnEnable()
    {
        _button.Clicked += ToggleCounter;
    }

    private void OnDisable()
    {
        _button.Clicked -= ToggleCounter;
    }

    private void ToggleCounter()
    {
        _isActive = !_isActive;

        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (_isActive)
        {
            _currentCount++;
            _countDisplay.text = _currentCount.ToString();

            yield return new WaitForSeconds(_timeInterval);
        }

        yield break;
    }
}
