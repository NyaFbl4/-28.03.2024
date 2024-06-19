using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "Bullet Config",
        menuName = "Bullets/New BulletsContainer"
    )]
    public sealed class ContainerConfig : ScriptableObject
    {
        public int initialCount;
        public Transform container;
        public Transform worldTransform;
    }
}