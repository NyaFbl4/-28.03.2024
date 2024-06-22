using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _character;
        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<CharacterController>()
                .AsSingle();
            
            this.Container
                .BindInterfacesAndSelfTo<InputManager>()
                .AsSingle();

            this.Container
                .Bind<GameObject>()
                .FromInstance(this._character)
                .AsCached();
        }
    }
}