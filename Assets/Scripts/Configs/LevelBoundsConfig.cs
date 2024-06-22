using UnityEngine;

namespace ShootEmUp
{    
    [CreateAssetMenu(
        fileName = "Level Bounds Config",
        menuName = "Config/New LevelBoundsConfig"
    )]
    public sealed class LevelBoundsConfig :  ScriptableObject
    {
        public Transform leftBorder;
        public Transform rightBorder;
        public Transform downBorder;
        public Transform topBorder;
    }
}