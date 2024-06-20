using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private UnitConfig _characterConfig;
        //[SerializeField] private HitPointsComponent _hitPointsComponent;
        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<CharacterController>()
                //.FromInstance(this._characterController)
                .AsSingle();
            
            this.Container
                .BindInterfacesAndSelfTo<InputManager>()
                .AsSingle();

            this.Container
                .Bind<GameObject>()
                .FromInstance(this._character)
                .AsSingle();
            
            this.Container
                .Bind<HitPointsComponent>()
                .FromComponentInNewPrefab(this._character)
                .AsSingle();

            this.Container
                .Bind<WeaponComponent>()
                .FromComponentInHierarchy(this._character)
                .AsSingle();

            this.Container
                .Bind<TeamComponent>()
                .FromComponentInHierarchy(this._character)
                .AsSingle();
            
            this.Container
                .Bind<MoveComponent>()
                .FromComponentInHierarchy(this._character)
                .AsSingle();

            this.Container
                .Bind<UnitConfig>()
                .FromInstance(this._characterConfig)
                .AsSingle();
        }
    }
}