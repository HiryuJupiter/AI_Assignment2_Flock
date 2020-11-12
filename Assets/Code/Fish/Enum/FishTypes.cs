using UnityEngine;
using System.Collections;

//Enums of a greater index value must be higher on the food chain.
public enum FishTypes
{
    TinyFish, //Only moves in alignment and avoid obstacles
    SmallFish, //Swims in waypoints, avoid predators
    MediumFish, //Swims freely, avoid predators
    BigFish,
}