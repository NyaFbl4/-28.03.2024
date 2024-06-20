using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private LevelBounds _levelBounds;

        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<BulletSystem>()
                .AsSingle();

            this.Container
                .Bind<GameObject>()
                .FromInstance(this._character)
                .AsSingle();

            this.Container
                .Bind<GameManager>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            this.Container
                .Bind<LevelBounds>()
                .FromInstance(this._levelBounds)
                .AsTransient();

        }
    }
}