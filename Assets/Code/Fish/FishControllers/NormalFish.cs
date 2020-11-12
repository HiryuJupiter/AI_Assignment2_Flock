//Derived class for fishes other than the smallest kind
public class NormalFish : FishBase
{
    public override void Initialize(Flock flock)
    {
        base.Initialize(flock);
        escapeState = new EscapeState(this);
        huntState = new OrganizedHuntState(this);
        passiveState = new WonderState(this);
    }
}