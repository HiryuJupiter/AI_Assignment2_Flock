using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EscapeState : FishStateBase
{
    public EscapeState(FishBase fish) : base(fish)
    {
        behaviors.Add(new EscapeBehavior(fish.Flock));
        behaviors.Add(new StayInRadiusBehavior());
    }
}