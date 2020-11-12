//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public abstract class FishStateBaseBkup
//{
//    protected List<IFishBehavior> stateBehaviors;
//    protected Fish fish;
//    protected Flock flock;
//    protected Transform transform;
//    protected Collider2D Collider;

//    public FishStateBase(Fish fish)
//    {
//        this.fish = fish;
//        transform = fish.transform;
//        Collider = fish.Collider;
//        flock = fish.Flock;
//    }

//    public virtual void StateEntry() { }
//    public virtual void StateUpdate()
//    {
//        List<Transform> neighbors = GetNeighbors(flock.neighborRadius);

//        Vector2 moveDir = transform.up;
//        foreach (var behavior in stateBehaviors)
//        {
//            moveDir = behavior.CalculateMoveDir(fish, neighbors, flock);
//        }
//        fish.Move(moveDir);
//    }
//    public virtual void StateFixedUpdate() { }
//    public virtual void StateExit() { }

//    protected virtual void TransitionCheck() { }
    
//    protected List<Transform> GetNeighbors(float checkRadius)
//    {
//        List<Transform> neighbors = new List<Transform>();
//        Collider2D[] neighborColliders = Physics2D.OverlapCircleAll(transform.position, checkRadius);
//        foreach (Collider2D c in neighborColliders)
//        {
//            if (c != Collider)
//            {
//                neighbors.Add(c.transform);
//            }
//        }
//        return neighbors;
//    }
//}