using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Slider _healthSlider;

    private float _changeSpeed = 10f;
    private Coroutine _changeHealthUI;

    private void Start()
    {
        _changeHealthUI = StartCoroutine(UIHealthChange());
    }

    private void ChangeVolume()
    {
        StopCoroutine(_changeHealthUI);
        _changeHealthUI = StartCoroutine(UIHealthChange());
    }

    private IEnumerator UIHealthChange()
    {
        bool isWork = true;

        while (isWork)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, _playerHealth.Health, _changeSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
