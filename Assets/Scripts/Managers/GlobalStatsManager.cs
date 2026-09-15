using UnityEngine;

public class GlobalStatsManager : Singleton<GlobalStatsManager>
{
    public int deathCount = 0;
    public int killCount = 0;
    public int maxWaveCompleted = 0;
    public int maxLevel = 1;

    public void AddDeath()
    {
        deathCount++;
    }

    public void AddKill()
    {
        killCount++;
    }

    public void CheckMaxLevel(int _level)
    {
        maxLevel = CheckMaxValue(maxLevel, _level);
    }

    public void CheckMaxWaveCompleted(int _wave)
    {
        maxWaveCompleted = CheckMaxValue(maxWaveCompleted, _wave);
    }

    private int CheckMaxValue(int _current, int _newValue)
    {
        return Mathf.Max(_current, _newValue);
    }
}