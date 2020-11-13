namespace FlockPrototype
{
    //The waypoint state is made up of the following logic
    // - align with neighbors from the same flock
    // - avoid nearby obstacles
    // - keep a small distance from neighbors from the same flock so they don't overlap
    // - Follow waypoints
    public class WaypointState : FishStateBase
    {
        //Constructor
        public WaypointState(FishBase fish) : base(fish)
        {
            behaviors.Add(new FlockAlignmentBehavior());
            behaviors.Add(new ObstacleAvoidanceBehavior(fish.Flock));
            behaviors.Add(new SameFlockAvoidanceBehavior(fish.Flock));
            behaviors.Add(new WaypointFollowBehavior(WaypointManager.instance.GetTestPath));
        }
    }
}