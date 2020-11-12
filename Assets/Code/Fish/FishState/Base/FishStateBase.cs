using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class FishStateBase 
{
    //const float BaseMoveSpeed = 0f;

    protected List<IFishBehavior> behaviors = new List<IFishBehavior>();
    protected FishBase fish;
    protected Transform transform;

    public FishStateBase(FishBase fish)
    {
        this.fish = fish;
        transform = fish.transform;
    }

    public virtual void StateFixedUpdate()
    {
        //Start with a basic forward movement and then add on behavior movements
        Vector2 moveDir = transform.up;
        foreach (var behavior in behaviors)
        {
            moveDir += behavior.CalculateMoveDir(fish, fish.neighbors, fish.Flock);
        }
        fish.Move(moveDir);
    }

    public virtual void StateExit () { }
}