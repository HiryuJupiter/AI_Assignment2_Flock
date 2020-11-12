using UnityEngine;

namespace FlockPrototype
{
    public class StayInRadiusBehavior : IFishBehavior
    {
        Vector2 center = Vector2.zero;
        const float radius = 8f;
        const float radiusSqr = radius * radius;

        public Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
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
}