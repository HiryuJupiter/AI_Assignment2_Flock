using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Path : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;

    public int GetClosestWaypointIndex (Vector3 pos)
    {
        int closestIndex = 0;
        float closestDist = float.MaxValue;
        for (int i = 0; i < waypoints.Count; i++)
        {
            float dist = Vector2.SqrMagnitude(pos - waypoints[i].position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestIndex = i;
            }
        }
        return closestIndex;
    }

    public Vector3 GetWaypointPosition (int index)
    {
        if (index < waypoints.Count)
        {
            return waypoints[index].position;
        }
        return waypoints[0].position;
    }

    public int GetNextIndex (int currentIndex)
    {
        if (++currentIndex >= waypoints.Count)
        {
            currentIndex = 0;
        }
        return currentIndex;
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(waypoints[i].position, Vector3.one);

            if (i < waypoints.Count - 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
    }
}