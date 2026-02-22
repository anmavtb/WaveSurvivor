using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] private int waveNumber = 1;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float gameTime = 0f;
    [SerializeField] private int displayTimer = 0;

    public int WaveNumber => waveNumber;
    public float Timer => timer;
    public float GameTime => gameTime;
    public int DisplayTimer => displayTimer;

    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void GameStart()
    {
        waveNumber = 1;
        SetupTimer(waveNumber);
    }

    private void UpdateTimer()
    {
        gameTime -= Time.deltaTime;
        displayTimer = (int)gameTime + 1;
        if (displayTimer <= 0)
        {
            EndWave();
        }
    }

    private void SetupTimer(int _waveNumber)
    {
        timer = 30 + 5 * (_waveNumber - 1);
        if (timer > 60) timer = 60;
        gameTime = timer;
    }

    private void EndWave()
    {
        waveNumber++;
        SetupTimer(waveNumber);
    }
}