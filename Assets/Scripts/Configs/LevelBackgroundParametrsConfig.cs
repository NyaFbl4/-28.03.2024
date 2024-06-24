using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "Level Background Parametrs Config",
        menuName = "Config/New LevelBackgroundParametrsConfig"
    )]
    public sealed class LevelBackgroundParametrsConfig : ScriptableObject
    {
        public Params parametrs;
    }
}