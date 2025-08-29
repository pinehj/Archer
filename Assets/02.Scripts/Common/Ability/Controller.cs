using System;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Dictionary<Type, Ability> _abilityDict;
    private Rigidbody2D _rigidbdoy;
    public Rigidbody2D Rigidbody => _rigidbdoy;
    protected virtual void Awake()
    {
        _abilityDict = new Dictionary<Type, Ability>();
        Ability[] abilityArray = GetComponentsInChildren<Ability>();
        foreach (Ability ability in abilityArray)
        {
            _abilityDict[ability.GetType()] = ability;
        }

        _rigidbdoy = GetComponent<Rigidbody2D>();
    }

    public TAbility GetAbility<TAbility>() where TAbility : Ability
    {
        var type = typeof(TAbility);
        if (_abilityDict.TryGetValue(type, out Ability ability))
        {
            return ability as TAbility;
        }
        ability = GetComponentInChildren<TAbility>();
        if (ability != null)
        {
            _abilityDict[type] = ability;
            return ability as TAbility;
        }
        return null;
    }
}
