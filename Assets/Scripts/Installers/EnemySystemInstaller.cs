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

        //[SerializeField] private GameObject _prefab;

        public override void InstallBindings()
        {
            this.Container
                .Bind<EnemyPositions>()
                .FromInstance(this._enemyPositions)
                .AsSingle();

            this.Container
                .Bind<EnemyPool>()
                .FromInstance(this._enemyPool)
                .AsSingle()
                .WithArguments(_enemyContainerConfig.container,
                               _enemyContainerConfig.worldTransform);

            this.Container
                .BindInterfacesAndSelfTo<EnemyManager>()
                .AsSingle();

            this.Container
                .Bind<EnemySpawner>()
                .FromInstance(this._enemySpawner)
                .AsCached();
            
        }
    }
}