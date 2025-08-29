using System.Linq;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private LayerMask _targetLayerMask;

    private float _yOffset;
    private float _speed;
    private float _moveProgress;
    private Rigidbody2D _rigidbody;

    private Vector2 _startPos;
    private Vector2 _targetPos;


    private void FixedUpdate()
    {
        _moveProgress += Time.deltaTime * _speed;
        Vector2 nextPos = BezierCurve.CalcPosition(_startPos, _targetPos, _moveProgress, _yOffset);
        float rad = Mathf.Atan2(nextPos.y - transform.position.y, nextPos.x - transform.position.x);
        float degree = rad * Mathf.Rad2Deg;
        _rigidbody.MovePositionAndRotation(nextPos, degree);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _targetLayerMask.value) != 0)
        {
            Destroy(gameObject);
        }
    }

    public void InitArrow(Vector2 targetPos, float speed, float yOffset)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
        _targetPos = targetPos;
        _speed = (1 / (_targetPos - _startPos).magnitude) / speed;
        _yOffset = yOffset;
    }
}
