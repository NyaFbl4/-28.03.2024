using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        //[Header("Spawn")]
        [SerializeField]
        private EnemyPositions _enemyPositions;

        [SerializeField]
        private GameObject _character;

        [SerializeField]
        private Transform _worldTransform;

        //[Header("Pool")]
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private GameObject _prefab;

        public readonly Queue<GameObject> enemyPool = new();
        
        [Inject]
        public void Construct(EnemyPositions enemyPositions, GameObject character,
            Transform worldTransform, Transform container)
        {
            this._enemyPositions = enemyPositions;
            this._character = character;
            this._worldTransform = worldTransform;
            this._container = container;
        }
        

        private void Awake()
        {
            for (var i = 0; i < 7; i++)
            {
                var enemy = Instantiate(this._prefab, this._container);
                this.enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!this.enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

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