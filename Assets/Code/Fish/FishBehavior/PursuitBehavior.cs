using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PursuitBehavior : IFishBehavior
{
    //Cache
    float sqrNeighborRadius;

    public PursuitBehavior(Flock flock)
    {
        sqrNeighborRadius = flock.NeighborRadius * flock.NeighborRadius;
    }

    public  Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
    {
        Vector2 move = Vector2.zero;

        List<FishBase> preys = neighbors.Preys.Where(p => !p.IsHiding).ToList();

        if (preys.Count == 1)
        {
            move = preys[0].transform.position - fish.transform.position;
        }
        else if (preys.Count > 1)
        {
            //Find closest prey
            move = (fish.transform.position - neighbors.GetClosestPrey().position).normalized;
        }
        Debug.DrawRay(fish.transform.position, move, Color.red);
        return move;
    }
}