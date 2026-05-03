using System;
using UnityEngine;

public class PlayerExp : Singleton<PlayerExp>
{
    [SerializeField] private int playerLevel = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int expToNextLevel = 10;

    public int PlayerLevel => playerLevel;
    public int CurrentExp => currentExp;
    public int ExpToNextLevel => expToNextLevel;

    public void AddExp(int _amount)
    {
        currentExp += _amount;
        if (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        playerLevel++;
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.5f);
        StatsManager.Instance.StatModifier(StatsManager.Instance.Health, StatsManager.ModifierType.ADD, 1);
        // Choose an upgrade
    }
}