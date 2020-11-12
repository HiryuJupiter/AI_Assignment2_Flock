using UnityEngine;
using System.Collections;

public class BottomTierFish : FishBase
{
    public override void Initialize(Flock flock)
    {
        base.Initialize(flock);
        escapeState = new EscapeState(this);
        passiveState = new WaypointState(this);
    }

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