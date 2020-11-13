namespace FlockPrototype
{
    //The hunt state is made of the follow logic:
    //- To avoid any obstacles that comes near 
    //- To move towards the nearest prey
    public class OrganizedHuntState : FishStateBase
    {
        //Constructor
        public OrganizedHuntState(FishBase fish) : base(fish)
        {
            //behaviors.Add(new FlockAlignmentBehavior());
            behaviors.Add(new ObstacleAvoidanceBehavior(fish.Flock));
            behaviors.Add(new PursuitBehavior());
        }
    }
}