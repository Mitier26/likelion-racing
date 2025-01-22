using System;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public static RoadManager instance;
    
    public float speed = 10f;
    public List<Road> roads = new List<Road>();

    private float gasSpawnDistance = 80f;
    private float distance = 40f;
    public Road lastRoad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.isPlaying) return;

        float movement = speed * Time.deltaTime;
        
        foreach (Road road in roads)
        {
            road.Move(movement);
        }

        distance += movement;

        if (distance >= gasSpawnDistance)
        {
            lastRoad.SpawnGas();
            distance = 0f;
        }
    }
}