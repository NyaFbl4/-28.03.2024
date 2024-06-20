using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private LevelBounds _levelBounds;

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
            /*
            this.Container
                .BindInterfacesAndSelfTo<BulletSystem>()
                .AsSingle();
            */

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