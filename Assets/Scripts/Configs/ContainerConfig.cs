using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "Container Config",
        menuName = "Container/New ContainerConfig"
    )]
    public sealed class ContainerConfig : ScriptableObject
    {
        public int initialCount;
        public Transform container;
        public Transform worldTransform;
    }
}