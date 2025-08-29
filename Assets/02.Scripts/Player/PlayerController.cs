using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Controller<PlayerController>
{
    private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody => _rigidbody;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
