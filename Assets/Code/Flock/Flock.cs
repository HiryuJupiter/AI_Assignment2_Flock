﻿using System.Collections.Generic;
using UnityEngine;
public class Flock : MonoBehaviour
{
    [Header("Fish stats")]
    [SerializeField] float neighborRadius = 1.5f; 
    [SerializeField] float mediumRadius = 1.0f; 
    [SerializeField] float smallRadius = 0.5f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float steering = 0.2f;
    [SerializeField] FishTypes fishType;

    [Header("Prefab")]
    public FishBase FishPrefab;

    List<FishBase> inactive = new List<FishBase>();
    List<FishBase> active = new List<FishBase>();

    public float NeighborRadius => neighborRadius;
    public float MoveSpeed => moveSpeed;
    public float MediumRadius => mediumRadius;
    public float SmallRadius => smallRadius;
    public float Steering => steering;
    public FishTypes FishType => fishType;

    void MassPopulate (int spawnAmount, float density = 0.08f)
    {
        //Spawn many fishes at the same time
        float radius = spawnAmount * density;
        for (int i = 0; i < spawnAmount; i++)
        {
            FishBase fish = Spawn(Random.insideUnitCircle * radius);
            fish.Initialize(this);
            active.Add(fish);
        }
    }

    public FishBase Spawn(Vector2 position)
    {
        FishBase fish;
        if (inactive.Count == 0)
        {
            fish = Instantiate(FishPrefab, position, GetRandomRotation(), transform);
            fish.Initialize(this);
        }
        else
        {
            //Pop from pool
            fish = inactive[0];
            inactive[0].transform.position = position;
            inactive[0].gameObject.SetActive(true);
            inactive.RemoveAt(0);
        }
        return fish;
    }

    public void Despawn(FishBase fish)
    {
        inactive.Add(fish);
        active.Remove(fish);
        fish.gameObject.SetActive(false);
    }

    Quaternion GetRandomRotation() => Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0, 360f)));
}