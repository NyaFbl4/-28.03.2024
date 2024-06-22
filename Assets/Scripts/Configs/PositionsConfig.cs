using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "Positions Config",
        menuName = "Config/New PositionsConfig"
    )]
    public sealed class PositionsConfig : ScriptableObject
    {
        public Transform[] spawnPositions;
        public Transform[] attackPositions;
    }
}