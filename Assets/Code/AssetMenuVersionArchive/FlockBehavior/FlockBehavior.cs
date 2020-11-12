using System.Collections.Generic;
using UnityEngine;

namespace FlockPrototype
{
    //Abstract base class that extends from scriptable object instead of monobehavior
    public abstract class FlockBehavior : ScriptableObject
    {
        public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform> neighbors, Flock flock);
    }
}