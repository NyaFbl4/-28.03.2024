using Zenject;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySystemInstaller : MonoInstaller
    {
        [SerializeField] 
        private ContainerConfig _enemyContainerConfig;

        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private EnemyPool _enemyPool;
        //[SerializeField] private 

        [SerializeField]
        private GameObject _prefab;

        public override void InstallBindings()
        {
            this.Container
                .Bind<EnemyPositions>()
                .FromInstance(this._enemyPositions)
                .AsSingle();

            this.Container
                .Bind<EnemyPool>()
                .FromInstance(this._enemyPool)
                .AsSingle();

            this.Container
                .BindInterfacesAndSelfTo<EnemyManager>()
                .AsSingle();




            /*
            this.Container
                .Bind<EnemyPositions>()
                .FromInstance(this._enemyPositions)
                .AsSingle();

            this.Container
                .Bind<GameObject>()
                .FromInstance(this._character)
                .AsSingle();
            
            this.Container
                .Bind<ContainerConfig>()
                .FromInstance(this._enemyContainerConfig)
                .AsCached();
            
            this.Container
                .BindFactory<GameObject, EnemyFactory>()
                .FromComponentInNewPrefab(_prefab)
                .WithGameObjectName("Enemy")
                .UnderTransform(_enemyContainerConfig.container);
                */
        }
    }
}