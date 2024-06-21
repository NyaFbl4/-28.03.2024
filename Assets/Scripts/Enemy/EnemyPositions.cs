using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPositions //: IEnemyPositions
    {
        //[SerializeField]
        private Transform[] _spawnPositions;

        //[SerializeField]
        private Transform[] _attackPositions;

        [Inject]
        public EnemyPositions(Transform[] spawnPositions, Transform[] attackPositions)
        {
            _spawnPositions = spawnPositions;
            _attackPositions = attackPositions;
        }

        public Transform RandomSpawnPosition()
        {
            return this.RandomTransform(this._spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return this.RandomTransform(this._attackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}