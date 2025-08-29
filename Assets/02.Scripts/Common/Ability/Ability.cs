using UnityEngine;

public class Ability<TController> : MonoBehaviour where TController : Controller<TController>
{
    protected TController _controller;

    protected virtual void Awake()
    {
        _controller = GetComponentInParent<TController>();
    }
}