using TMPro;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] private int waveNumber = 1;
    [SerializeField] private float waveTimer = 0f;

    [SerializeField] private TextMeshProUGUI waveNumberText;
    [SerializeField] private TextMeshProUGUI waveTimerText;

    public int WaveNumber => waveNumber;
    public float WaveTimer => waveTimer;

    void Start()
    {
        GameStart();
        UpdateUIText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        UpdateUIText();
    }

    private void GameStart()
    {
        waveNumber = 1;
        SetupWaveTimer(waveNumber);
    }

    private void SetupWaveTimer(int _waveNumber)
    {
        waveTimer = 30 + 5 * (_waveNumber - 1);
        if (waveTimer > 60) waveTimer = 60;
        waveTimer++;
    }

    private void UpdateUIText()
    {
        waveNumberText.text = "Wave " + waveNumber.ToString();
        int displayTimer = (int)waveTimer;
        waveTimerText.text = displayTimer.ToString();
    }

    private void UpdateTimer()
    {
        waveTimer -= Time.deltaTime;
        if (waveTimer < 0)
        {
            EndWave();
        }
    }

    private void EndWave()
    {
        GlobalStatsManager.Instance.CheckMaxWaveCompleted(waveNumber);
        waveNumber++;
        SetupWaveTimer(waveNumber);
    }
}