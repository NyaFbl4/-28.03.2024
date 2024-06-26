﻿using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        public GameObject EnemySpawn(GameObject prefab, Transform container)
        {
            var enemy = Instantiate(prefab, container);
            return enemy;
        }
    }
}