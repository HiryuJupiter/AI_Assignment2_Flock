using UnityEngine;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager instance;

    [SerializeField]
    Path testPath;
    //public List<Transform> SharkPath;
    //public List<Transform> DouphinPath;

    public Path GetTestPath => testPath;

    void Awake()
    {
        instance = this;
    }
}