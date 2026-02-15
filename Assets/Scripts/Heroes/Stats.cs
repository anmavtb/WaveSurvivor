using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

public class Stats : Singleton<Stats>
{
    [SerializeField] private float health = 0f;
    [SerializeField] private float damages = 0f;
    [SerializeField] private float range = 0f;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float critChance = 0f;
    [SerializeField] private float speed = 0f;

    public float Health => health;
    public float Damage => damages;
    public float Range => range;
    public float AttackSpeed => attackSpeed;
    public float CritChance => critChance;
    public float Speed => speed;

    public enum ModifierType
    {
        ADD, // + and -
        MUL, // x and /
        PER  // %
    }

    public float StatModifier(float _statValue, ModifierType _modifierType, float _modifierValue)
    {
        float tempStat = _statValue;
        switch (_modifierType)
        {
            case ModifierType.ADD:
                tempStat += _modifierValue;
                break;

            case ModifierType.MUL:
                tempStat *= _modifierValue;
                break;

            case ModifierType.PER:
                tempStat *= 1 + _modifierValue / 100;
                break;
        }
        float maxValue = 100;
        _statValue = CheckIfStatMaxxed(maxValue, tempStat);
        return _statValue;
    }

    public float CheckIfStatMaxxed(float _maxValue, float _statValue)
    {
        if (_statValue > _maxValue) _statValue = _maxValue;
        float stat = _statValue;
        return stat;
    }
}