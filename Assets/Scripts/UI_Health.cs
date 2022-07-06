using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Slider _healthSlider;

    private int _changeSpeed = 10;
    private Coroutine _changeHealthUI;

    private void Start()
    {
        _changeHealthUI = StartCoroutine(UIHealthChange(_playerHealth.Health));
    }

    private void OnEnable()
    {
        _playerHealth.Changed.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _playerHealth.Changed.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume()
    {
        StopCoroutine(_changeHealthUI);
        _changeHealthUI = StartCoroutine(UIHealthChange(_playerHealth.Health));
    }

    private IEnumerator UIHealthChange(int actualHealth)
    {
        while (_healthSlider.value != actualHealth)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, actualHealth, _changeSpeed * Time.deltaTime);

            yield return null;
        }

        yield return null;
    }
}
