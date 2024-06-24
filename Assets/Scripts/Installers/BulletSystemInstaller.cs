using ShootEmUp;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletSystemInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private BulletsContainer _bulletsContainer;
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
                .WithArguments(_bulletsContainer.container,
                               _bulletsContainer.worldTransform,
                               _bulletsContainerConfig.initialCount);

            this.Container
                .BindFactory<Bullet, BulletSpawner>()
                .FromComponentInNewPrefab(_bulletPrefab)
                .WithGameObjectName("BULLET")
                .UnderTransform(_bulletsContainer.container);

            this.Container
                .Bind<BulletsContainer>()
                .FromInstance(_bulletsContainer)
                .AsSingle();
        }
    }
}
