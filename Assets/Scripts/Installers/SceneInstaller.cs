using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelBackgroundParametrsConfig _levelBackgroundParametrsConfig;
        [SerializeField] private LevelContainer _levelContainer;
        public override void InstallBindings()
        {
            this.Container
                .Bind<GameManager>()
                .AsSingle();
            
            this.Container
                .Bind<LevelBounds>()
                .AsSingle()
                .WithArguments(_levelContainer.leftBorder,
                               _levelContainer.rightBorder,
                               _levelContainer.downBorder,
                               _levelContainer.topBorder);

            this.Container
                .BindInterfacesAndSelfTo<LevelBackground>()
                .AsSingle()
                .WithArguments(_levelBackgroundParametrsConfig.parametrs,
                               _levelContainer.background);

            this.Container
                .Bind<LevelContainer>()
                .FromInstance(_levelContainer)
                .AsSingle();

        }
    }
}