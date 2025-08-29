using UnityEngine;

public class PlayerMoveAbility : Ability<PlayerController>
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _moveSpeed;

    private void Start()
    {
        _rigidbody = _controller.Rigidbody;
    }
    private void FixedUpdate()
    {
        _rigidbody.linearVelocityX = InputManager.Instance.MoveInput * _moveSpeed * Time.fixedDeltaTime;
    }
}
