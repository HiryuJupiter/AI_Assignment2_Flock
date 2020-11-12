using UnityEngine;
using System.Collections;

public class WaypointState : FishStateBase
{
    public WaypointState(FishBase fish) : base(fish)
    {
        behaviors.Add(new FlockAlignmentBehavior());
        behaviors.Add(new ObstacleAvoidanceBehavior(fish.Flock));
        //behaviors.Add(new StayInRadiusBehavior());
        behaviors.Add(new SameFlockAvoidanceBehavior(fish.Flock));
        behaviors.Add(new WaypointFollowBehavior(WaypointManager.instance.GetTestPath));
    }
}