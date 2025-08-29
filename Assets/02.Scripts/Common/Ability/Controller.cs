using System;
using System.Collections.Generic;
using UnityEngine;

public class Controller<TSelf> : MonoBehaviour where TSelf : Controller<TSelf>
{
    private Dictionary<Type, Ability<TSelf>> _abilityDict;
    protected virtual void Awake()
    {
        _abilityDict = new Dictionary<Type, Ability<TSelf>>();
        Ability<TSelf>[] abilityArray = GetComponentsInChildren<Ability<TSelf>>();
        foreach (Ability<TSelf> ability in abilityArray)
        {
            _abilityDict[ability.GetType()] = ability;
        }
    }

    public TAbility GetAbility<TAbility>() where TAbility : Ability<TSelf>
    {
        var type = typeof(TAbility);
        if (_abilityDict.TryGetValue(type, out Ability<TSelf> ability))
        {
            return ability as TAbility;
        }
        ability = GetComponentInChildren<TAbility>();
        if (ability != null)
        {
            _abilityDict[type] = ability;
            return ability as TAbility;
        }
        throw new Exception($"어빌리티 {type.Name}을 찾을 수 없습니다.");
    }
}
