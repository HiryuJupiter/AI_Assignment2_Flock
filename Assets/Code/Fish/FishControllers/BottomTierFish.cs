namespace FlockPrototype
{
    //Class for the lowest tier fish
    public class BottomTierFish : FishBase
    {
        //Override the base class Initialze method so we ...
        //...can specify which particular state classes to assign
        public override void Initialize(Flock flock)
        {
            base.Initialize(flock);
            escapeState = new EscapeState(this);
            passiveState = new WaypointState(this);
        }

        //Override fixed update to skip the step of looking for prey
        protected override void FixedUpdate()
        {
            neighbors.DetectNeighbors();
            if (neighbors.HasPredator())
            {
                escapeState.StateFixedUpdate();
            }
            else
            {
                passiveState.StateFixedUpdate();
            }
        }
    }
}