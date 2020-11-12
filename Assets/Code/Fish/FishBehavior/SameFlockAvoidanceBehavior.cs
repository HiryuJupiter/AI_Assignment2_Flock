using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameFlockAvoidanceBehavior : IFishBehavior
{
    float weight;
    float squaredCheckDist;
    public SameFlockAvoidanceBehavior(Flock flock, float weight = 2f)
    {
        this.weight = weight;
        squaredCheckDist = flock.SmallRadius * flock.SmallRadius;
    }
    public Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
    {
        Vector2 avoidanceDir = Vector2.zero;

        if (neighbors.SameFlock.Count > 0)
        {
            foreach (Transform n in neighbors.SameFlock)
            {
                if (Vector2.SqrMagnitude(fish.transform.position - n.position) < squaredCheckDist)
                {
                    avoidanceDir += (Vector2)(fish.transform.position - n.position);
                }
            }
            avoidanceDir /= neighbors.SameFlock.Count ;
        }

        return avoidanceDir * weight;
    }
}