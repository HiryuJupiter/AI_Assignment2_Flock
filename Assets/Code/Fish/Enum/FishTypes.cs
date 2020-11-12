namespace FlockPrototype
{
    //We want enums of a greater index value to represent higher tier on the food chain.
    public enum FishTypes
    {
        TinyFish, //Only moves in alignment and avoid obstacles
        SmallFish, //Swims in waypoints, avoid predators
        MediumFish, //Swims freely, avoid predators
        BigFish,
    }
}