using UnityEngine;

public class StatsManager : Singleton<StatsManager>
{
    // new Stat(Base Value, Minimum Value, Maximum Value)
    [SerializeField] private Stat health = new Stat(0, 1, 999);
    [SerializeField] private Stat damages = new Stat(0, -999, 999);
    [SerializeField] private Stat range = new Stat(0, -999, 999);
    [SerializeField] private Stat attackSpeed = new Stat(0, -999, 999);
    [SerializeField] private Stat critChance = new Stat(0, -999, 999);
    [SerializeField] private Stat speed = new Stat(0, -999, 999);

    public Stat Health => health;
    public Stat Damages => damages;
    public Stat Range => range;
    public Stat AttackSpeed => attackSpeed;
    public Stat CritChance => critChance;
    public Stat Speed => speed;

    public enum ModifierType
    {
        ADD, // + and -
        MUL, // x and /
        PER  // %
    }

    public float StatModifier(Stat _stat, ModifierType _modifierType, float _modifierValue)
    {
        float tempStat = _stat.Value;
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
        return CheckIfStatClamped(tempStat, _stat);
    }

    private float CheckIfStatClamped(float _statValue, Stat _stat)
    {
        _statValue = Mathf.Clamp(_statValue, _stat.Min, _stat.Max);
        return _statValue;
    }
}