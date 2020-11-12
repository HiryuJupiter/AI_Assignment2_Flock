using UnityEngine;

namespace FlockPrototype
{
    public class WaypointFollowBehavior : IFishBehavior
    {
        //Variables
        Path path;
        int waypointIndex = -1;
        Vector3 waypointPos;
        float weight = 4f;

        //Constructor
        public WaypointFollowBehavior(Path path, float weight = 4f)
        {
            this.path = path;
            this.weight = weight;
        }

        public Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
        {
            //If we don't have a waypoint yet, then find one
            if (waypointIndex == -1)
            {
                FindClosestWayPoint(fish);
            }
            Debug.DrawLine(fish.transform.position, waypointPos);

            //If we have arrived at waypoint, then get the next one
            if (HasArrivedAtWaypoint(fish))
            {
                GetNextWaypoint();
            }

            return (waypointPos - fish.transform.position).normalized * weight;
        }

        public void StopFollowingPath()
        {
            //We use -1 to indicate we don't have a waypoint currently
            waypointIndex = -1;
        }


        bool HasArrivedAtWaypoint(FishBase fish)
        {
            //Use a distance check to see if we've arrived at a destination
            return (Vector2.SqrMagnitude(waypointPos - fish.transform.position) < 1f);
        }

        void FindClosestWayPoint(FishBase fish)
        {
            //Use the path class to find closest waypoint
            waypointIndex = path.GetClosestWaypointIndex(fish.transform.position);
            waypointPos = path.GetWaypointPosition(waypointIndex);
        }

        void GetNextWaypoint()
        {
            //Use a path class method to find the next waypoint
            waypointIndex = path.GetNextIndex(waypointIndex);
            waypointPos = path.GetWaypointPosition(waypointIndex);
        }

    }
}