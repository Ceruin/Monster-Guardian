using System;
using UnityEngine;

[Serializable]
public class Attack : MonoBehaviour
{
    public float AttackRadius = 0.0f;

    private int Damage = 5; // damage

    /// <summary>
    /// Reduce my health
    /// </summary>
    public void GetHit()
    {
    }

    /// <summary>
    /// Reduce enemy health
    /// </summary>
    public void Hit()
    {
    }

    /// <summary>
    /// Check if target is within radius
    /// </summary>
    private void CanHit()
    {
    }
}