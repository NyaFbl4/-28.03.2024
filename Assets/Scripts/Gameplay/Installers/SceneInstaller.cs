using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] 
        private CharacterController _characterController;
        public override void InstallBindings()
        {
            /*
            this.Container
                .Bind<BulletSystem>()
                .To<CharacterController>()
                .FromInstance(this._characterController)
                .AsSingle();
                */
            this.Container
                .Bind<CharacterController>()
                .FromInstance(this._characterController)
                .AsSingle();
        }
    }
}