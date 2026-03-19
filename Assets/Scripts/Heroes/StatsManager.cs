using UnityEngine;

public class StatsManager : Singleton<StatsManager>
{
    [SerializeField] private float playerHealth = 0f;
    [SerializeField] private float playerDamages = 0f;
    [SerializeField] private float playerRange = 0f;
    [SerializeField] private float playerAttackSpeed = 0f;
    [SerializeField] private float playerCritChance = 0f;
    [SerializeField] private float playerSpeed = 0f;

    [SerializeField] private float maxStatValue = 100f;

    public float PlayerHealth => playerHealth;
    public float PlayerDamage => playerDamages;
    public float PlayerRange => playerRange;
    public float PlayerAttackSpeed => playerAttackSpeed;
    public float PlayerCritChance => playerCritChance;
    public float PlayerSpeed => playerSpeed;

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
                tempStat *= 1 + (_modifierValue / 100);
                break;
        }
        return CheckIfStatMaxxed(tempStat, maxStatValue);
    }

    public float CheckIfStatMaxxed(float _statValue, float _maxValue)
    {
        if (_statValue > _maxValue) _statValue = _maxValue;
        return _statValue;
    }
}