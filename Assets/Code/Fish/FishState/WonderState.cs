namespace FlockPrototype
{
    public class WonderState : FishStateBase
    {
        //Constructor
        public WonderState(FishBase fish) : base(fish)
        {
            behaviors.Add(new FlockAlignmentBehavior());
            behaviors.Add(new ObstacleAvoidanceBehavior(fish.Flock));
            behaviors.Add(new ObstacleAvoidanceBehavior(fish.Flock));
            behaviors.Add(new StayInRadiusBehavior());
            behaviors.Add(new SameFlockAvoidanceBehavior(fish.Flock));
        }
    }
}