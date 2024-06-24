using Zenject;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySystemInstaller : MonoInstaller
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private ContainerConfig _enemyContainerConfig;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemyTransformContainer _enemyTransformContainer;

        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<EnemyPool>()
                .AsSingle()
                .WithArguments(_enemyTransformContainer.container,
                               _enemyTransformContainer.worldTransform,
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
                .Bind<EnemyPositions>()
                .AsSingle()
                .WithArguments(_enemyTransformContainer.spawn, 
                               _enemyTransformContainer.attack);

            this.Container
                .Bind<EnemyTransformContainer>()
                .FromInstance(_enemyTransformContainer)
                .AsSingle();
            
            /*
            this.Container
                .BindFactory<GameObject, EnemySpawner>()
                .FromComponentInNewPrefab(_prefabEnemy)
                .WithGameObjectName("ENEMY")
                .UnderTransform(_enemyTransformContainer.container);
                */
        }
    }
}