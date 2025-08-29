using UnityEngine;

public class AttackAbility : Ability
{
    [SerializeField]
    private string _targetTag;
    [SerializeField]
    private Arrow _arrowPrefab;
    private float _shootTimer = 0;
    [SerializeField]
    private float _shootInterval;
    [SerializeField]
    private Transform _shootPos;
    [SerializeField]
    private float _arrowSpeed;
    [SerializeField]
    private int _arrowDamage;
    [SerializeField]
    private float _arrowYOffset;
    private Rigidbody2D _rigidbody;

    private GameObject _target;

    private void Start()
    {
        _rigidbody = _controller.Rigidbody;
    }
    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(_shootTimer <= 0 && _rigidbody.linearVelocityX == 0)
        {
            if(_target == null && !TryFindTarget())
            {
                return;
            }

            _shootTimer = _shootInterval;
            Arrow arrow = Instantiate(_arrowPrefab, _shootPos.position, Quaternion.identity);
            arrow.InitArrow(_target.transform.position, _arrowSpeed, _arrowDamage, _arrowYOffset);
        }
        else
        {
            _shootTimer -= Time.deltaTime;
        }
    }

    private bool TryFindTarget()
    {
        _target = GameObject.FindGameObjectWithTag(_targetTag);
        if(_target == null)
        {
            return false;
        }
        return true;
    }
}
