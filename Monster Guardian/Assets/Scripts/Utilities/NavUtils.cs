﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public static class NavUtils
{
    public static void Path(this NavMeshAgent agent, Vector3 goal)
    {
        agent.destination = goal;
    }

    public static Vector3 RandomPoint(Vector3 center, float range)
    {
        for (int i = 0; i < 30; i++) // 30 is the number of tries
        {
            Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        return center;
    }
}
