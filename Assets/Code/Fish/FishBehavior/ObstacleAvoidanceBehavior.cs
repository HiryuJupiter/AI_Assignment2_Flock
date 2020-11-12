using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidanceBehavior : IFishBehavior
{
    float weight;
    float squaredCheckDist;

    //Constructor
    public ObstacleAvoidanceBehavior(Flock flock, float weight = 2f)
    {
        this.weight = weight;
        squaredCheckDist = flock.SmallRadius * flock.SmallRadius;
    }

    public Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
    {
        Vector2 avoidanceDir = Vector2.zero;

        //Find the direction that allows us to avoid nearby obstacles
        if (neighbors.Obstacles.Count > 0)
        {
            foreach (Transform n in neighbors.Obstacles)
            {
                //Only consider the obstacles that are very close to us
                if (Vector2.SqrMagnitude(fish.transform.position - n.position) < squaredCheckDist)
                {
                    avoidanceDir += (Vector2)(fish.transform.position - n.position);
                }
            }

            //Average out the move direction
            avoidanceDir /= neighbors.Obstacles.Count;
        }

        return avoidanceDir * weight;
    }
}