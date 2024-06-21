using Zenject;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySystemInstaller : MonoInstaller
    {
        //[SerializeField] private ContainerConfig _enemyContainerConfig;

        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private ContainerConfig _enemyContainerConfig;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private PositionsConfig _positionsConfig;

        //[SerializeField] private GameObject _prefab;

        public override void InstallBindings()
        {
            /*
            this.Container
                .Bind<EnemyPositions>()
                .FromInstance(this._enemyPositions)
                .AsSingle();
            */
            this.Container
                .BindInterfacesAndSelfTo<EnemyPool>()
                //.FromInstance(this._enemyPool)
                .AsSingle()
                .WithArguments(_enemyContainerConfig.container,
                               _enemyContainerConfig.worldTransform,
                               _enemyContainerConfig.initialCount,
                               _enemyContainerConfig.prefab);

            this.Container
                .BindInterfacesAndSelfTo<EnemyManager>()
                .AsSingle();
            
            this.Container
                .Bind<EnemySpawner>()
                .FromInstance(this._enemySpawner)
                .AsCached();

            
            this.Container
                //.BindInterfacesAndSelfTo<EnemyPositions>()
                .Bind<EnemyPositions>()
                .AsSingle()
                .WithArguments(_positionsConfig.spawnPositions,
                               _positionsConfig.attackPositions);
            
        }
    }
}