//using UnityEngine;
//using System.Linq;
//using System.Collections;
//using System.Collections.Generic;

//public class FishNeighbors
//{
//    //Cache
//    float neighborRadius;
//    Transform transform;
//    Collider2D collider;
//    int fishType;

//    LayerMask layerHideSpot;
//    LayerMask layerObstacle;

//    //Properties
//    public List<Transform> Predators { get; private set; }
//    public List<Transform> SameFlock { get; private set; }
//    public List<Transform> Preys { get; private set; }
//    public List<Transform> Obstacles { get; private set; }
//    public List<Transform> HideSpots { get; private set; }

//    public FishNeighbors(Fish fish)
//    {
//        //Cache
//        neighborRadius = fish.Flock.NeighborRadius;
//        transform = fish.transform;
//        collider = fish.Collider;
//        fishType = (int)fish.FishType;

//        layerHideSpot = Settings.instance.Layer_HideSpot;
//        layerObstacle = Settings.instance.Layer_Obstacle;

//        //Debug.Log(" layerObstacle :" + (int)layerObstacle + "layerHideSpot:" + (int)layerHideSpot);
//    }

//    public void DetectNeighbors()
//    {
//        //Predators   = new List<Transform>();
//        //SameFlock   = new List<Transform>();
//        //Preys       = new List<Transform>();
//        //Obstacles   = new List<Transform>();
//        //HideSpots   = new List<Transform>();

//        Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(transform.position, neighborRadius);
//        var neighbors = overlappingColliders.Select(o => o.GetComponent<Fish>()).ToList();
//        neighbors.Remove(this);


//        foreach (Collider2D c in overlappingColliders)
//        {
//            //If the collider is not the fish itself,
//            if (c != collider)
//            {
//                Fish neighbor = c.GetComponent<Fish>();
//                //If the neighbor is a fish
//                if (neighbor != null)
//                {
//                    //Check if the neighbor is a predator, same flock, or prey
//                    int neighborType = (int)neighbor.FishType;
//                    if (neighborType > fishType)
//                    {
//                        Predators.Add(neighbor.transform);
//                    }
//                    else if (neighborType == fishType)
//                    {
//                        SameFlock.Add(neighbor.transform);
//                    }
//                    else
//                    {
//                        Preys.Add(neighbor.transform);
//                    }
//                }
//                //if the neighbor is not a fish...
//                else
//                {
//                    //Debug.Log("no neighbor :"  + c.gameObject.name +  " on layer: " + c.gameObject.layer   + ".layerObstacle : " + layerObstacle + " , 1 <<  c.gameObject.layer :  " + (int)(1 << c.gameObject.layer));

//                    //...check if it is a hide spot or an obstacle
//                    if (layerObstacle == (layerObstacle | 1 <<  c.gameObject.layer))
//                    {
//                        //Debug.Log("layerObstacle :");
//                        Obstacles.Add(c.transform);
//                    }
//                    else if (layerHideSpot == (layerHideSpot | 1 << c.gameObject.layer))
//                    {
//                        HideSpots.Add(c.transform);
//                    }
//                }
//            }
//        }
//    }
    
//    public bool HasPredator ()  => Predators.Count > 0;
//    public Transform GetClosestPredator ()
//    {
//        Transform closest = null;
//        if (Predators.Count == 1)
//        {
//            closest = Predators[0];
//        }
//        else
//        {
//            float closestDist = float.MaxValue;
//            foreach (Transform predator in Predators)
//            {
//                float dist = Vector2.SqrMagnitude(predator.position - transform.position);
//                if (dist < closestDist)
//                {
//                    closest = predator;
//                    closestDist = dist;
//                }
//            }
//        }
//        return closest;
//    }

//    public bool HasPrey() => Preys.Count > 0;
//    //public Transform GetClosestPrey()
//    //{
//    //    Transform closest = null;
//    //    if (Preys.Count == 1)
//    //    {
//    //        closest = Preys[0];
//    //    }
//    //    else
//    //    {
//    //        float closestDist = float.MaxValue;
//    //        foreach (Transform prey in Preys)
//    //        {
//    //            float dist = Vector2.SqrMagnitude(prey.position - transform.position);
//    //            if (dist < closestDist)
//    //            {
//    //                closest = prey;
//    //                closestDist = dist;
//    //            }
//    //        }
//    //    }
//    //    return closest;
//    //}
//    //public bool TryFindClosestPrey(out Transform closest)
//    //{
//    //    if (!HasPrey())
//    //    {
//    //        closest = null;
//    //        return false;
//    //    }
//    //    else
//    //    {
//    //        closest = GetClosestPrey();
//    //        return true;
//    //    }
//    //}

//    public bool HasHideSpot() => HideSpots.Count > 0;
//    public Transform GetClosestHideSpot()
//    {
//        Transform closest = null;
//        if (HideSpots.Count == 1)
//        {
//            closest = HideSpots[0];
//        }
//        else
//        {
//            float closestDist = float.MaxValue;
//            foreach (Transform hideSpot in HideSpots)
//            {
//                float dist = Vector2.SqrMagnitude(hideSpot.position - transform.position);
//                if (dist < closestDist)
//                {
//                    closest = hideSpot;
//                    closestDist = dist;
//                }
//            }
//        }
            
//        return closest;
//    }

//}

///*
 
//    public bool TryGetClosestPredator(out Transform closest)
//    {
//        closest = null;
//        if (predators.Count > 0)
//        {
//            float closestDist = float.MaxValue;

//            foreach (Transform predator in predators)
//            {
//                float dist = Vector2.SqrMagnitude(predator.position - transform.position);
//                if (dist < closestDist)
//                {
//                    closest = predator;
//                    closestDist = dist;
//                }
//            }

//            if (closest != null)
//                return true;
//        }
//        return false;
//    }
// */