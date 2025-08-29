using UnityEngine;

public class PlayerAttackAbility : Ability<PlayerController>
{
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
    private float _arrowYOffset;
    private Rigidbody2D _rigidbdoy;

    private GameObject _target;

    private void Start()
    {
        _rigidbdoy = _controller.Rigidbody;
    }
    private void FixedUpdate()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(_shootTimer <= 0 && _rigidbdoy.linearVelocityX == 0)
        {
            if(_target == null && !TryFindTarget())
            {
                return;
            }

            _shootTimer = _shootInterval;
            Arrow arrow = Instantiate(_arrowPrefab, _shootPos.position, Quaternion.identity);
            arrow.InitArrow(_target.transform.position, _arrowSpeed, _arrowYOffset);
        }
        else
        {
            _shootTimer -= Time.deltaTime;
        }
    }

    private bool TryFindTarget()
    {
        _target = GameObject.FindGameObjectWithTag("Enemy");
        if(_target == null)
        {
            return false;
        }
        return true;
    }
}
