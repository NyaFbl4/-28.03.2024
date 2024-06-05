using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class SceneLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameManager>();
        }
    }
}