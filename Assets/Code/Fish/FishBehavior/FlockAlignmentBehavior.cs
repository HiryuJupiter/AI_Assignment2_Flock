using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlockPrototype
{
    public class FlockAlignmentBehavior : IFishBehavior
    {
        float weight = 0.1f;

        //Constructor
        public FlockAlignmentBehavior(float weight = 0.1f)
        {
            this.weight = weight;
        }

        public Vector2 CalculateMoveDir(FishBase agent, FishNeighbors neighbors, Flock flock)
        {
            Vector2 alignmentDir = Vector2.zero;

            //If we have one neighbor to begin with, then ...
            if (neighbors.SameFlock.Count > 0)
            {
                //Get the averaged forward direction of neighbors
                foreach (Transform n in neighbors.SameFlock)
                {
                    alignmentDir += (Vector2)n.transform.up;
                }
                alignmentDir = alignmentDir * weight / neighbors.SameFlock.Count;
            }

            return alignmentDir;
        }
    }
}