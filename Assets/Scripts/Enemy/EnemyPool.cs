using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour, IInitializable
    {
        private EnemyPositions _enemyPositions;
        private GameObject _character;

        [SerializeField]
        private Transform _worldTransform;
        [SerializeField]
        private Transform _container;
        [SerializeField]
        private GameObject _prefab;

        private int initialCount = 5;
        private EnemySpawner _enemySpawner;

        public readonly Queue<GameObject> enemyPool = new();
        
        [Inject]
        public void Construct(EnemyPositions enemyPositions, GameObject character,
            EnemySpawner enemySpawner)
        {
            this._enemyPositions = enemyPositions;
            this._character = character;
            this._enemySpawner = enemySpawner;
        }
        
        /*
        public EnemyPool(EnemyPositions enemyPositions, GameObject character,
                EnemySpawner enemySpawner, int init, GameObject prefab,
            Transform worldTransform, Transform container)
        {
            this._enemyPositions = enemyPositions;
            this._character = character;
            this._enemySpawner = enemySpawner;
            this._worldTransform = worldTransform;
            this._container = container;
            this._prefab = prefab;
            this.initialCount = init;
        }
        */
        public void Initialize()
        {
            for (var i = 0; i < initialCount; i++)
            {
                //var enemy = Instantiate(this._prefab, this._container);
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