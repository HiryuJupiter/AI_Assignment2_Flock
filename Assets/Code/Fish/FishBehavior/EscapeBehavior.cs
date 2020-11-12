using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeBehavior : IFishBehavior
{
    const float hideWeight = 5f;
    const float hideBehindObjectDist = 2f;

    float sqrNeighborRadius;

    public EscapeBehavior(Flock flock)
    {
        sqrNeighborRadius = flock.NeighborRadius * flock.NeighborRadius;
    }

    public  Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
    {
        Vector2 escapeDir = Vector2.zero;

        if (neighbors.HasHideSpot())
        {
            Vector2 dir = neighbors.GetClosestHideSpot().position - fish.transform.position;

            //Hide logic version 1: hide inside the hide zones
            if (Vector2.SqrMagnitude(dir) > flock.SmallRadius)
            {
                //Debug.DrawRay(fish.transform.position, escapeDir, Color.yellow);
                escapeDir = dir.normalized * hideWeight;
            }

            //Hide logic version 2: hide behind objects
            escapeDir = (Vector2)neighbors.GetClosestHideSpot().position + dir.normalized * hideBehindObjectDist;
            escapeDir = dir * hideWeight;
            Debug.DrawRay(fish.transform.position, neighbors.GetClosestHideSpot().position, Color.green);
        }
        else
        {
            //If there is no hiding spot, then run away
            //We use normalized to make the movement less powerful
            escapeDir = fish.transform.position - neighbors.GetClosestPredator().position;

            //Escape harder if the enemy is closer
            float perc = sqrNeighborRadius - escapeDir.sqrMagnitude / sqrNeighborRadius;
            escapeDir = escapeDir * perc;
            //Debug.DrawRay(fish.transform.position, escapeDir, Color.blue);
        }

        return escapeDir;
    }
}
