﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CollisionManager : MonoBehaviour
{

    public static CollisionManager Instance = null;                                     

    private static List<CustomCollider> colliders;
    public List<CustomCollider> Colliders { get { return colliders; } private set { ;} }
    
   
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void AddCollider(CustomCollider collider)
    {
        if (colliders == null)
        {
            colliders = new List<CustomCollider>();
        }
        colliders.Add(collider);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < colliders.Count - 1; i++)
        {
            for (int j = i + 1; j < colliders.Count; j++)
            {
                colliders[i].CheckCollision(colliders[j]);
            }
        }
    }

    public bool Raycast(CustomRay ray, out CustomRayHit outHit)
    {
        outHit = new CustomRayHit();
        foreach (var item in colliders)
        {
            item.Ray(ray.Origin, ray.Direction * 1000, out outHit);
        }
        return outHit.IsHit;
    }



}
    