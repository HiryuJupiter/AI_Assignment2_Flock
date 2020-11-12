using UnityEngine;

namespace FlockPrototype
{
    public class SameFlockAvoidanceBehavior : IFishBehavior
    {
        float weight;
        float squaredCheckDist;

        //Constructor
        public SameFlockAvoidanceBehavior(Flock flock, float weight = 2f)
        {
            this.weight = weight;

            //Cache calculation
            squaredCheckDist = flock.SmallRadius * flock.SmallRadius;
        }
        public Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
        {
            Vector2 avoidanceDir = Vector2.zero;

            //If we have neighbors from the same flock...
            if (neighbors.SameFlock.Count > 0)
            {
                //Then add up their forward facing direction and then average it
                foreach (Transform n in neighbors.SameFlock)
                {
                    if (Vector2.SqrMagnitude(fish.transform.position - n.position) < squaredCheckDist)
                    {
                        avoidanceDir += (Vector2)(fish.transform.position - n.position);
                    }
                }
                avoidanceDir /= neighbors.SameFlock.Count;
            }

            return avoidanceDir * weight;
        }
    }
}