using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyInstaller : MonoInstaller
    {
        //[SerializeField] private EnemyAttackAgent _enemyAttackAgent;
        //[SerializeField] private EnemyMoveAgent _enemyMoveAgent;
        
        [SerializeField] private GameObject prerfab;
        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<EnemyMoveAgent>()
                .FromComponentInNewPrefab(prerfab)
                .AsCached();
            
            this.Container
                .BindInterfacesAndSelfTo<EnemyAttackAgent>()
                .FromComponentInNewPrefab(prerfab)
                .AsCached();
        }
        
    }
}