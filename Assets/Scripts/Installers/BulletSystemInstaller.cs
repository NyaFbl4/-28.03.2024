using ShootEmUp;
using UnityEngine;
using Zenject;

public class BulletSystemInstaller : MonoInstaller
{
    [SerializeField] private Bullet _bulletPrefab;
    
    [SerializeField] private BulletSystem _bulletSystem;
    [SerializeField] private BulletConfig _bulletCharacterConfig;
    
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _worldTransform;
    [SerializeField] private LevelBounds _levelBounds;
    [SerializeField] private BulletsContainerConfig _bulletsContainerConfig;
    
    public override void InstallBindings()
    {
        this.Container
            .Bind<Bullet>()
            .FromComponentInNewPrefab(this._bulletPrefab)
            .AsCached();
        
        this.Container
            .Bind<BulletSystem>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container
            .Bind<BulletConfig>()
            .FromInstance(this._bulletCharacterConfig)
            .AsCached();
        
        this.Container
            .Bind<LevelBounds>()
            .FromInstance(this._levelBounds)
            .AsTransient();
        
        this.Container
            .Bind<BulletsContainerConfig>()
            .FromInstance(this._bulletsContainerConfig)
            .AsCached();

        /*
        this.Container
            .BindInterfacesTo<BulletSystem>()
            .AsSingle()
            .WithArguments(this._bulletsContainerConfig);
            */

        /*
        this.Container
            .Bind<Transform>()
            .FromInstance(this._container)
            .AsCached();
        
        this.Container
            .Bind<Transform>()
            .FromInstance(this._worldTransform)
            .AsCached();
            */

    }
}
