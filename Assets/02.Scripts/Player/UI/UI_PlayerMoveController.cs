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

    private void UpdateInput()
    {
        int totalInput = _moveLeftButton.CurrentValue + _moveRightButton.CurrentValue;
        InputManager.Instance.MoveInput = totalInput;
    }
}
