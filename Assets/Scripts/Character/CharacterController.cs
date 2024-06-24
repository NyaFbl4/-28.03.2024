using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterController : IFixedTickable , IInitializable, IDisposable
    {
        private readonly GameObject _character;
        private readonly GameManager _gameManager;
        private readonly BulletSystem _bulletSystem;
        private readonly BulletConfig _bulletConfig;

        public bool _fireRequired;

        public CharacterController(GameObject character, GameManager gameManager, 
                              BulletSystem bulletSystem, BulletConfig bulletCharacterConfig)
        {
            _character = character;
            _gameManager = gameManager;
            _bulletSystem = bulletSystem;
            _bulletConfig = bulletCharacterConfig;
        }

        public void Initialize()
        {
            _character.GetComponent<HitPointsComponent>().hpEmpty += OnCharacterDeath;
        }

        public void Dispose()
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