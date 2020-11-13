namespace FlockPrototype
{
    //The wonder state is made up of the following logic
    // - align with neighbors from the same flock
    // - avoid nearby obstacles
    // - keep a small distance from neighbors from the same flock so they don't overlap
    // - stay in radius of the gameplay area
    public class WonderState : FishStateBase
    {
        //Constructor
        public WonderState(FishBase fish) : base(fish)
        {
            behaviors.Add(new FlockAlignmentBehavior());
            behaviors.Add(new ObstacleAvoidanceBehavior(fish.Flock));
            behaviors.Add(new StayInRadiusBehavior());
            behaviors.Add(new SameFlockAvoidanceBehavior(fish.Flock));
        }
    }
}