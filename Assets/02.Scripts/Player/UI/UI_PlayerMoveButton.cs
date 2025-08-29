using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_PlayerMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event Action OnDataChanged;

    [SerializeField]
    private int _direction;

    private int _currentValue;
    public int CurrentValue => _currentValue;

    public void OnPointerDown(PointerEventData eventData)
    {
        _currentValue = _direction;
        OnDataChanged?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _currentValue = 0;
        OnDataChanged?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            eventData.pointerPress = gameObject;
            OnPointerDown(eventData);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.pointerPress = null;
        OnPointerUp(eventData);
    }
}
