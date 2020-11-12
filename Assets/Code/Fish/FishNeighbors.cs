using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class FishNeighbors
{
    //Cache
    float neighborRadius;
    Transform transform;
    Collider2D collider;
    int fishType;

    LayerMask layerHideSpot;
    LayerMask layerObstacle;

    //Properties
    public List<Transform> Predators { get; private set; }
    public List<Transform> SameFlock { get; private set; }
    //public List<Transform> SameTierDifferentFlock { get; private set; }
    public List<FishBase> Preys { get; private set; }
    public List<Transform> Obstacles { get; private set; }
    public List<Transform> HideSpots { get; private set; }

    public FishNeighbors(FishBase fish)
    {
        //Cache
        neighborRadius = fish.Flock.NeighborRadius;
        transform = fish.transform;
        collider = fish.Collider;
        fishType = (int)fish.FishType;

        layerHideSpot = Settings.instance.Layer_HideSpot;
        layerObstacle = Settings.instance.Layer_Obstacle;

        //Debug.Log(" layerObstacle :" + (int)layerObstacle + "layerHideSpot:" + (int)layerHideSpot);
    }

    public void DetectNeighbors()
    {
        Predators   = new List<Transform>();
        SameFlock   = new List<Transform>();
        Preys       = new List<FishBase>();
        Obstacles   = new List<Transform>();
        HideSpots   = new List<Transform>();

        Collider2D[] overlaps = Physics2D.OverlapCircleAll(transform.position, neighborRadius);

        foreach (Collider2D c in overlaps)
        {
            //If the collider is not the fish itself,
            if (c != collider)
            {
                FishBase neighbor = c.GetComponent<FishBase>();
                //If the neighbor is a fish
                if (neighbor != null)
                {
                    //Check if the neighbor is a predator, same flock, or prey
                    int neighborType = (int)neighbor.FishType;
                    if (neighborType == fishType)
                    {
                        SameFlock.Add(neighbor.transform);
                    }
                    else
                    {
                        if (neighborType - fishType == 1)
                        {
                            Predators.Add(neighbor.transform);
                        }
                        else if (neighborType - fishType == -1)
                        {
                            Preys.Add(neighbor);
                        }
                    }
                }
                //if the neighbor is not a fish...
                else
                {

                    //...check if it is a hide spot or an obstacle
                    if (layerObstacle == (layerObstacle | 1 <<  c.gameObject.layer))
                    {
                        Obstacles.Add(c.transform);
                    }
                    else if (layerHideSpot == (layerHideSpot | 1 << c.gameObject.layer))
                    {
                        HideSpots.Add(c.transform);
                    }
                }
            }
        }
    }
    
    public bool HasPredator ()  => Predators.Count > 0;
    public Transform GetClosestPredator ()
    {
        Transform closest = null;
        if (Predators.Count == 1)
        {
            closest = Predators[0];
        }
        else
        {
            float closestDist = float.MaxValue;
            foreach (Transform predator in Predators)
            {
                float dist = Vector2.SqrMagnitude(predator.position - transform.position);
                if (dist < closestDist)
                {
                    closest = predator;
                    closestDist = dist;
                }
            }
        }
        return closest;
    }

    public bool HasPrey() => Preys.Count > 0;
    public Transform GetClosestPrey()
    {
        Transform closest = null;
        if (Preys.Count == 1)
        {
            closest = Preys[0].transform;
        }
        else
        {
            float closestDist = float.MaxValue;
            foreach (FishBase prey in Preys)
            {
                float dist = Vector2.SqrMagnitude(prey.transform.position - transform.position);
                if (dist < closestDist)
                {
                    closest = prey.transform;
                    closestDist = dist;
                }
            }
        }
        return closest;
    }


    public bool HasHideSpot() => HideSpots.Count > 0;
    public Transform GetClosestHideSpot()
    {
        Transform closest = null;
        if (HideSpots.Count == 1)
        {
            closest = HideSpots[0];
        }
        else
        {
            float closestDist = float.MaxValue;
            foreach (Transform hideSpot in HideSpots)
            {
                float dist = Vector2.SqrMagnitude(hideSpot.position - transform.position);
                if (dist < closestDist)
                {
                    closest = hideSpot;
                    closestDist = dist;
                }
            }
        }
            
        return closest;
    }

}

/*
 
    public bool TryGetClosestPredator(out Transform closest)
    {
        closest = null;
        if (predators.Count > 0)
        {
            float closestDist = float.MaxValue;

            foreach (Transform predator in predators)
            {
                float dist = Vector2.SqrMagnitude(predator.position - transform.position);
                if (dist < closestDist)
                {
                    closest = predator;
                    closestDist = dist;
                }
            }

            if (closest != null)
                return true;
        }
        return false;
    }
 */