using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health { get; private set; }
    public UnityEvent Changed = new UnityEvent();

    private int _maximumHealth = 100;
    private int _minimumHealth = 0;
    private int _healthDelta = 10;
    private int _startHealth = 50;

    private void Start()
    {
        Health = _startHealth;
        Changed?.Invoke();
    }

    public void HealthUp()
    {
        Health += _healthDelta;
        Health = Mathf.Clamp(Health, _minimumHealth, _maximumHealth);
        Changed?.Invoke();
    }

    public void HealthDown()
    {
        Health -= _healthDelta;
        Health = Mathf.Clamp(Health, _minimumHealth, _maximumHealth);
        Changed?.Invoke();
    }
}
