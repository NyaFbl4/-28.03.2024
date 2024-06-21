using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class Enemy
    {
        public GameObject Prefab { get; }
        public TeamComponent teamComponent { get; }
        public MoveComponent moveComponent { get; }
        public WeaponComponent weaponComponent { get; }
        public HitPointsComponent hitPointsComponent { get; }
        public EnemyMoveAgent enemyMoveAgent { get; }
        public EnemyAttackAgent enemyAttackAgent { get; }
        
        public Enemy(GameObject prefab)
        {
            Prefab = prefab;
            teamComponent = prefab.GetComponent<TeamComponent>();
            moveComponent = prefab.GetComponent<MoveComponent>();
            weaponComponent = prefab.GetComponent<WeaponComponent>();
            hitPointsComponent = prefab.GetComponent<HitPointsComponent>();
            enemyMoveAgent = prefab.GetComponent<EnemyMoveAgent>();
            enemyAttackAgent = prefab.GetComponent<EnemyAttackAgent>();
        }
    }
}