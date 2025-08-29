using System;
using UnityEngine;

public class UI_PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private UI_PlayerMoveButton _moveLeftButton;
    [SerializeField]
    private UI_PlayerMoveButton _moveRightButton;

    private void Start()
    {
        _moveLeftButton.OnDataChanged += UpdateInput;
        _moveRightButton.OnDataChanged += UpdateInput;
    }
    private void OnDestroy()
    {
        if (_moveLeftButton != null)
        {
            _moveLeftButton.OnDataChanged -= UpdateInput;
        }
        if (_moveRightButton != null)
        {
            _moveRightButton.OnDataChanged -= UpdateInput;
        }
    }
    private void UpdateInput()
    {
        int totalInput = _moveLeftButton.CurrentValue + _moveRightButton.CurrentValue;
        InputManager.Instance.MoveInput = totalInput;
    }
}
