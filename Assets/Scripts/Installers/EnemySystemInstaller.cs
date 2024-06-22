using Zenject;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySystemInstaller : MonoInstaller
    {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private ContainerConfig _enemyContainerConfig;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private PositionsConfig _positionsConfig;

        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<EnemyPool>()
                .FromInstance(this._enemyPool)
                .AsSingle();

            //
            /*
            this.Container
                .BindInterfacesAndSelfTo<EnemyPool>()
                .AsSingle()
                .WithArguments(_enemyContainerConfig.container,
                               _enemyContainerConfig.worldTransform,
                               _enemyContainerConfig.initialCount,
                               _enemyContainerConfig.prefab);
             */

            this.Container
                .BindInterfacesAndSelfTo<EnemyManager>()
                .AsSingle();
            
            this.Container
                .Bind<EnemySpawner>()
                .FromInstance(this._enemySpawner)
                .AsCached();

            
            this.Container
                .Bind<EnemyPositions>()
                .AsSingle()
                .WithArguments(_positionsConfig.spawnPositions,
                               _positionsConfig.attackPositions);
            
        }
    }
}