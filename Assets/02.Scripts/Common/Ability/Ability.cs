using UnityEngine;

public class Ability : MonoBehaviour
{
    protected Controller _controller;

    protected virtual void Awake()
    {
        _controller = GetComponentInParent<Controller>();
    }
}