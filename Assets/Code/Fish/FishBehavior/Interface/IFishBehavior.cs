using System.Collections.Generic;
using UnityEngine;

public interface IFishBehavior
{
    Vector2 CalculateMoveDir(FishBase agent, FishNeighbors neighbors, Flock flock);
}