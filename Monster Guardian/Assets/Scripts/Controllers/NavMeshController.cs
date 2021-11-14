using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// The navmesh class is a singleton static, this means we cannot creat extensions or partial methods so those are all to live as statics in this class
/// </summary>
public static class NavMeshController
{
    public static Vector3 RandomPoint(Vector3 center, float range, int hitAttempts = 30)
    {
        for (int i = 0; i < hitAttempts; i++) // retry if failed
        {
            Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        return center; // default if nothing found :/ todo: maybe make it null or throw an error
    }
}
