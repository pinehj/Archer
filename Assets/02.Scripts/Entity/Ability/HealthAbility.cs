using System;
using UnityEngine;

public class HealthAbility : Ability, IDamageable
{
    public event Action OnDataChanged;
    [SerializeField]
    private int _currentHealth;
    public int CurrentHealth => _currentHealth;
    [SerializeField]
    private int _maxHealth;
    public int MaxHealth => _maxHealth;

    protected override void Awake()
    {
        base.Awake();
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(Damage damage)
    {
        _currentHealth -= damage.Value;
        OnDataChanged?.Invoke();
        if(_currentHealth <= 0)
        {
            Destroy(_controller.gameObject);
        }
    }
}
