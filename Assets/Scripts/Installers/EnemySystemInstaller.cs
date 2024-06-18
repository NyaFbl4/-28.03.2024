using Zenject;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySystemInstaller : MonoInstaller
    {
        [SerializeField]
        private EnemyPositions _enemyPositions;

        [SerializeField]
        private GameObject _character;

        [SerializeField] 
        private ContainerConfig _enemyContainerConfig;

        [SerializeField]
        private GameObject _prefab;

        public override void InstallBindings()
        {
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
        }
    }
}