using Zenject;

namespace ShootEmUp
{
    public class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<CharacterController>()
                //.FromInstance(this._characterController)
                .AsSingle();
            
            this.Container
                .BindInterfacesAndSelfTo<InputManager>()
                .AsSingle();
        }
    }
}