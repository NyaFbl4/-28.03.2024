using UnityEngine;

namespace ShootEmUp
{    [CreateAssetMenu(
        fileName = "Unit Config",
        menuName = "Unit/New UnitConfig"
    )]
    public sealed class UnitConfig : ScriptableObject
    {
        public int hitPoint;
        public float speed;
        public Transform firePoint;
        public bool isPlayer;
    }
}