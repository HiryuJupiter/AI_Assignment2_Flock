public class OrganizedHuntState : FishStateBase
{
    //Constructor
    public OrganizedHuntState(FishBase fish) : base(fish)
    {
        behaviors.Add(new FlockAlignmentBehavior());
        behaviors.Add(new ObstacleAvoidanceBehavior(fish.Flock));
        behaviors.Add(new PursuitBehavior());
    }
}