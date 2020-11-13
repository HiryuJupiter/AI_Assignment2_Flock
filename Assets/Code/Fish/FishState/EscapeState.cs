namespace FlockPrototype
{
    //The escape state is composed of the following logic: staying 
    //in radius and escaping from predator by hiding in a nearby hide spot 
    //    or running away from the predator if no hide spot is available
    public class EscapeState : FishStateBase
    {
        //Constructor
        public EscapeState(FishBase fish) : base(fish)
        {
            behaviors.Add(new EscapeBehavior(fish.Flock));
            behaviors.Add(new StayInRadiusBehavior());
        }
    }
}