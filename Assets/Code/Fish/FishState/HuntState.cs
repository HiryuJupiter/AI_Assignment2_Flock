using UnityEngine;
using System.Collections;

public class OrganizedHuntState : FishStateBase
{
    public OrganizedHuntState(FishBase fish) : base(fish)
    {
        behaviors.Add(new FlockAlignmentBehavior());
        behaviors.Add(new ObstacleAvoidanceBehavior(fish.Flock));
        behaviors.Add(new PursuitBehavior(fish.Flock));
    }
}