using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "Bullet Config",
        menuName = "Bullets/New BulletsContainer"
    )]
    public sealed class BulletsContainerConfig : ScriptableObject
    {
        public int initialCount;
        public Transform container;
        public Transform worldTransform;
    }
}