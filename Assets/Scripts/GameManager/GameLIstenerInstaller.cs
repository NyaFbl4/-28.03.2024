using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class GameLIstenerInstaller : MonoBehaviour
    {
        private GameManager _gameManager;
        
        [Inject]
        public void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
    }
}