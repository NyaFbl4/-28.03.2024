using UnityEngine;

namespace ShootEmUp
{
    public interface IEnemyPositions
    {
        public Transform RandomSpawnPosition();
        public Transform RandomAttackPosition();
    }
}