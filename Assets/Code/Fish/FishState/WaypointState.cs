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