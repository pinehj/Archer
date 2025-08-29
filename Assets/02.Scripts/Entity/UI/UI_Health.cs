using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    [SerializeField]
    private HealthAbility _healthAbility;
    [SerializeField]
    private Slider _healthSlider;
    private void Start()
    {
        _healthAbility.OnDataChanged += Refresh;
    }

    private void Refresh()
    {
        _healthSlider.value = (float)_healthAbility.CurrentHealth / _healthAbility.MaxHealth;
    }
}
