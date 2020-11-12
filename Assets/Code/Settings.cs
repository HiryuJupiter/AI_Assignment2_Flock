using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{
    public static Settings instance;

    [SerializeField] LayerMask layer_hideSpot;

    [SerializeField] LayerMask layer_Obstacle;

    public LayerMask Layer_HideSpot => layer_hideSpot;
    public LayerMask Layer_Obstacle => layer_Obstacle;

    void Awake()
    {
        instance = this;
    }
}