using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Slider _healthSlider;

    private float _changeSpeed = 0.5f;

    private void OnEnable()
    {
        _playerHealth.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= OnHealthChanged;
    }

    private void FixedUpdate()
    {
        OnHealthChanged();
    }

    private void OnHealthChanged()
    {
        _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, _playerHealth.Health, _changeSpeed);
    }
}
