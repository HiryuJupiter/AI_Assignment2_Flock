using UnityEngine;

//Using an interface to specify a method signature
public interface IFishBehavior
{
    Vector2 CalculateMoveDir(FishBase agent, FishNeighbors neighbors, Flock flock);
}