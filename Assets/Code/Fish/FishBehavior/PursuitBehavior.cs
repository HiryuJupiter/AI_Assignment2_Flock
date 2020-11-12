using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FlockPrototype
{
    public class PursuitBehavior : IFishBehavior
    {
        public Vector2 CalculateMoveDir(FishBase fish, FishNeighbors neighbors, Flock flock)
        {
            Vector2 move = Vector2.zero;

            //Only pursuit preys that are not in hiding.  (Using a linq statement that is more performant)
            List<FishBase> preys = neighbors.Preys.Where(p => !p.IsHiding).ToList();

            //If there is only one prey, then skip trying to find the closest prey
            if (preys.Count == 1)
            {
                move = preys[0].transform.position - fish.transform.position;
            }
            else if (preys.Count > 1)
            {
                //Find closest prey
                move = (fish.transform.position - neighbors.GetClosestPrey().position).normalized;
            }
            Debug.DrawRay(fish.transform.position, move, Color.red);
            return move;
        }
    }
}