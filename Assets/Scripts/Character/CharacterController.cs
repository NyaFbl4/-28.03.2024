using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterController : IFixedTickable
    {
        //[SerializeField] 
        private readonly GameObject _character; 
        //[SerializeField] 
        private readonly GameManager _gameManager;
        //[SerializeField] 
        private readonly BulletSystem _bulletSystem;
        //[SerializeField] 
        private readonly BulletConfig _bulletConfig;
        
        public bool _fireRequired;

        //[Inject]
        public CharacterController(GameObject character, GameManager gameManager, 
                              BulletSystem bulletSystem, BulletConfig bulletConfig)
        {
            _character = character;
            _gameManager = gameManager;
            _bulletSystem = bulletSystem;
            _bulletConfig = bulletConfig;
            
            Debug.Log("injected CharacterController");
        }

        private void OnEnable()
        {
            _character.GetComponent<HitPointsComponent>().hpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _character.GetComponent<HitPointsComponent>().hpEmpty -= OnCharacterDeath;
        }

        public void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();

        public void FixedTick()
        {
            if (_fireRequired)
            {
                OnFlyBullet();
                _fireRequired = false;
            }
        }

        private void OnFlyBullet()
        {
            var weapon = _character.GetComponent<WeaponComponent>();
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int) _bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * _bulletConfig.speed
            });
        }
    }
}