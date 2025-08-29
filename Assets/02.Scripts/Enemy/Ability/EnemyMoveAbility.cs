using UnityEngine;

public class EnemyMoveAbility : Ability<EnemyController>
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _moveSpeed;

    private float _changeDirectionTimer;
    [SerializeField]
    private float _changeDirectionInterval;

    private int _direction;
    private void Start()
    {
        _rigidbody = _controller.Rigidbody;
    }

    private void Update()
    {
        ChangeDirection();
    }
    private void FixedUpdate()
    {
        _rigidbody.linearVelocityX = _direction * _moveSpeed;
    }

    private void ChangeDirection()
    {
        if(_changeDirectionTimer <= 0)
        {
            _changeDirectionTimer = Random.Range(0, _changeDirectionInterval);
            _direction = Random.Range(-1, 2);
        }
        else
        {
            _changeDirectionTimer -= Time.deltaTime;
        }
    }
}
