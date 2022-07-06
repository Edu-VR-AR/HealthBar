using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int Health { get; private set; }

    private int _maximumHealth = 100;
    private int _minimumHealth = 0;
    private int _healthDelta = 10;
    private int _startHealth = 50;

    private void Start()
    {
        Health = _startHealth;
    }

    public void HealthUp()
    {
        Health += _healthDelta;
        Health = Mathf.Clamp(Health, _minimumHealth, _maximumHealth);
    }

    public void HealthDown()
    {
        Health -= _healthDelta;
        Health = Mathf.Clamp(Health, _minimumHealth, _maximumHealth);
    }
}
