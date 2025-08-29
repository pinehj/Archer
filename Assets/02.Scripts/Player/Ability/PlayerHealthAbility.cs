using UnityEngine;

public class PlayerHealthAbility : Ability<PlayerController>, IDamageable
{
    [SerializeField]
    private int _currentHealth;
    [SerializeField]
    private int _maxHealth;

    protected override void Awake()
    {
        base.Awake();
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(Damage damage)
    {
        _currentHealth -= damage.Value;
        if(_currentHealth <= 0)
        {
            Destroy(_controller.gameObject);
        }
    }
}
