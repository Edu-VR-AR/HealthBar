using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int Health { get; private set; }
    [SerializeField] private UnityEvent _changed;

    private int _maximumHealth = 100;
    private int _minimumHealth = 0;
    private int _healthDelta = 10;
    private int _startHealth = 50;

    public event UnityAction Changed
    {
        add => _changed?.AddListener(value);
        remove => _changed?.RemoveListener(value);
    }

    private void Start()
    {
        Health = _startHealth;
    }

    public void HealthUp()
    {
        Health += _healthDelta;
        Health = HealthRangeControl(Health);
        _changed?.Invoke();
    }

    public void HealthDown()
    {
        Health -= _healthDelta;
        Health = HealthRangeControl(Health);
        _changed?.Invoke();
    }

    private int HealthRangeControl(int health)
    {
        if (health > _maximumHealth)
        {
            return _maximumHealth;
        }
        else if (health < _minimumHealth)
        {
            return _minimumHealth;
        }
        else
        {
            return health;
        }
    }
}
