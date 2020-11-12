namespace FlockPrototype
{
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