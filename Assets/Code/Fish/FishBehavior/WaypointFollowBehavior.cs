using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

//The waypoints game objects need to be on Path layer.

public class WaypointFollowBehavior : IFishBehavior
{
    const float Radius = 1f;

    Path path;
    int waypointIndex = -1;
    Vector3 waypointPos;
    float weight = 4f;

    public WaypointFollowBehavior(Path path, float weight = 4f)
    {
        this.path = path;
        this.weight = weight;
    }

    public Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
    {
        //If we don't have a waypoint yet, then find one
        if (waypointIndex == -1)
        {
            FindClosestWayPoint(fish);
        }
        Debug.DrawLine(fish.transform.position, waypointPos);

        //If we have arrived at waypoint, then get the next one
        if (HasArrivedAtWaypoint(fish))
        {
            GetNextWaypoint();
        }

        return (waypointPos - fish.transform.position).normalized * weight;
    }

    bool HasArrivedAtWaypoint(FishBase fish)
    {
        return (Vector2.SqrMagnitude(waypointPos - fish.transform.position) < 1f);
    }

    public void StopFollowingPath ()
    {
        waypointIndex = -1;
    }

    void FindClosestWayPoint (FishBase fish)
    {
        waypointIndex = path.GetClosestWaypointIndex(fish.transform.position);
        waypointPos = path.GetWaypointPosition(waypointIndex);
    }

    void GetNextWaypoint ()
    {
        waypointIndex = path.GetNextIndex(waypointIndex);
        waypointPos = path.GetWaypointPosition(waypointIndex);
    }

}