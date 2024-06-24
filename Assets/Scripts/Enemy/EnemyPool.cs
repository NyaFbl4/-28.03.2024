using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPool : IInitializable
    {
        private EnemyPositions _enemyPositions;
        private GameObject _character;
        
        private Transform _worldTransform;

        private Transform _container;

        private GameObject _prefab;

        private int initialCount = 5;
        private EnemySpawner _enemySpawner;

        public readonly Queue<GameObject> enemyPool = new();

        public EnemyPool(EnemyPositions enemyPositions, GameObject prefab,
                EnemySpawner enemySpawner, int init, GameObject character,
            Transform container, Transform worldTransform)
        {
            this._enemyPositions = enemyPositions;
            this._character = character;
            this._enemySpawner = enemySpawner;
            this._container = container;
            this._worldTransform = worldTransform;
            this._prefab = prefab;
            this.initialCount = init;
        }
        
        public void Initialize()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var enemy = _enemySpawner.EnemySpawn(_prefab, _container);
                this.enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!enemyPool.TryDequeue(out var enemy))
            {
                Debug.Log("false");
                return null;
            }
            
            Debug.Log("true");
            
            enemy.transform.SetParent(this._worldTransform);

            var spawnPosition = this._enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = this._enemyPositions.RandomAttackPosition();
            
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(this._character);
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this._container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}