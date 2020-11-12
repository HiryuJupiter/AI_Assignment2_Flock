using UnityEngine;
using System.Collections.Generic;

namespace FlockPrototype
{
    public class WaypointManager : MonoBehaviour
    {
        //Lazy singleton
        public static WaypointManager instance;

        [SerializeField]
        Path testPath;

        //Simply holds all the path options and let object access them
        public Path GetTestPath => testPath;

        void Awake()
        {
            instance = this;
        }
    }
}