using System;
using System.Diagnostics;

[Serializable]
public class Life
{
    public int HealthPoints;

    public TimeSpan TimeToLive;

    private Stopwatch LifeTimer = new Stopwatch();

    public bool Dead
    {
        get
        {
            return !LifeTimer.IsRunning || LifeTimer.Elapsed >= TimeToLive || HealthPoints <= 0;
        }
    }

    public void Start()
    {
        LifeTimer.Start();
    }

    public void Stop()
    {
        LifeTimer.Stop();
    }
}