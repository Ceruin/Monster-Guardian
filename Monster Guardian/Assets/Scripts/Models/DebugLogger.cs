using System;
using System.Text;
using UnityEngine;

public class DebugLogger : IDisposable
{
    public DebugLogger()
    {
    }

    public StringBuilder Log { get; private set; } = new StringBuilder();

    public void AddLog(object action)
    {
        Log.AppendLine(JsonUtility.ToJson(action, true));
    }

    [Obsolete("Find use for it")]
    public T AddLog<T>(Func<T> action)
    {
        return action.Invoke();
    }

    public void Dispose()
    {
        Debug.Log(Log);
    }
}