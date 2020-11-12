using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInRadiusBehavior : IFishBehavior
{
    Vector2 center = Vector2.zero;
    const float radius = 8f;
    const float radiusSqr = radius * radius;
    public  Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
    {
        //If the fish is at the outer edge of the radius, make it move towards center
        Vector2 dirToCenter = center - (Vector2)fish.transform.position;
        float percent = dirToCenter.sqrMagnitude / radiusSqr;

        if (percent > 0.7f)
        {
            //Make the attraction force stronger the further away it is.
            return dirToCenter * percent * percent;
        }
        return Vector2.zero;
    }

}


/*
 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Flock/Behavior/Stay In Radius")]
public class StayInRadiusBehavior : FlockBehavior
{
    public Vector2 center;
    public float maxDistance = 15f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        Vector2 dirToCenter = center - (Vector2)agent.transform.position;
        float t = dirToCenter.magnitude / maxDistance;
        
        if (t  > 0.9f)
        {
            return dirToCenter * t * t;
        }
        return Vector2.zero;
    }
}
 */