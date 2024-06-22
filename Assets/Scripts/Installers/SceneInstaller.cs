using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelBoundsConfig _levelBoundsConfig;

        [SerializeField] private LevelBackgroundParametrsConfig _levelBackgroundParametrsConfig;

        public override void InstallBindings()
        {
            this.Container
                .Bind<GameManager>()
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