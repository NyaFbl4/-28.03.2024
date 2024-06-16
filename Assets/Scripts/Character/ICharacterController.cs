using UnityEngine;

namespace ShootEmUp
{
    public interface ICharacterController
    {
        void OnCharacterDeath(GameObject character);
    }
}