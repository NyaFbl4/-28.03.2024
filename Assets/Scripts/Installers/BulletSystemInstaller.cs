using ShootEmUp;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletSystemInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;

        [SerializeField] private BulletConfig _bulletCharacterConfig;

        [SerializeField] private ContainerConfig _bulletsContainerConfig;

        public override void InstallBindings()
        {
            this.Container
                .Bind<Bullet>()
                .FromInstance(this._bulletPrefab)
                .AsCached();

            this.Container
                .Bind<BulletConfig>()
                .FromInstance(this._bulletCharacterConfig)
                .AsCached();
            
            this.Container
                .BindInterfacesAndSelfTo<BulletSystem>()
                .AsSingle()
                .WithArguments(_bulletsContainerConfig.container,
                               _bulletsContainerConfig.worldTransform,
                               _bulletsContainerConfig.initialCount);

            this.Container
                .BindFactory<Bullet, BulletSpawner>()
                .FromComponentInNewPrefab(_bulletPrefab)
                .WithGameObjectName("BULLET")
                .UnderTransform(_bulletsContainerConfig.container);
        }
    }
}
