using UnityEngine;

namespace FlockPrototype
{
    public class SameFlockCohesion : IFishBehavior
    {
        //Stats
        float smoothTime = 0.1f;
        float squaredCheckDist;
        float weight;

        //Status
        Vector2 smoothDampVelocity;

        //Constructor
        public SameFlockCohesion(Flock flock, float weight = 0.1f)
        {
            this.weight = weight;
            squaredCheckDist = flock.MediumRadius * flock.MediumRadius;
        }

        public Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
        {
            Vector2 move = Vector2.zero;

            if (neighbors.SameFlock.Count > 0)
            {
                //Find the averaged mid point of nearby neighbors
                foreach (Transform n in neighbors.SameFlock)
                {
                    if (Vector2.SqrMagnitude(fish.transform.position - n.position) < squaredCheckDist)
                    {
                        move += (Vector2)n.position;
                    }
                }
                move /= neighbors.SameFlock.Count;

                //Move the fish towards that position
                move -= (Vector2)fish.transform.position;
                move = Vector2.SmoothDamp(fish.transform.up, move, ref smoothDampVelocity, smoothTime) * weight;
            }

            return move;
        }
    }
}