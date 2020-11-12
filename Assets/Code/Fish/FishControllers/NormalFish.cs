using UnityEngine;
using System.Collections;

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