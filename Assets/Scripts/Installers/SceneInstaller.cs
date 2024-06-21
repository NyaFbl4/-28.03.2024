using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelBoundsConfig _levelBoundsConfig;

        [SerializeField] private LevelBackgroundParametrsConfig _levelBackgroundParametrsConfig;
        //[SerializeField] private GameObject _character;
        

        //[SerializeField] private CharacterController _characterController;

        //[SerializeField] private GameManager _gameManager;
        //[SerializeField] private BulletSystem _bulletSystem;
        //[SerializeField] private BulletConfig _bulletConfig;

        //[SerializeField] private GameObject _character;
        //[SerializeField] private Bullet _bulletPrefab;
        //[SerializeField] private Transform _wolrdTransform;
        //[SerializeField] private LevelBounds _levelBounds;

        public override void InstallBindings()
        {
            this.Container
                .Bind<GameManager>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            this.Container
                .Bind<LevelBounds>()
                .AsSingle()
                .WithArguments(_levelBoundsConfig.leftBorder,
                                _levelBoundsConfig.rightBorder,
                                _levelBoundsConfig.downBorder,
                                _levelBoundsConfig.topBorder);

            this.Container
                .BindInterfacesAndSelfTo<LevelBackground>()
                .AsSingle()
                .WithArguments(_levelBackgroundParametrsConfig.parametrs,
                               _levelBackgroundParametrsConfig.transform);

        }
    }
}