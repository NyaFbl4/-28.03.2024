using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour, IFixedTickable
    {
        [SerializeField] private GameObject _character; 
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
        
        public bool _fireRequired;

        [Inject]
        public void Construct(GameObject character, GameManager gameManager, 
                              BulletSystem bulletSystem, BulletConfig bulletConfig)
        {
            this._character = character;
            this._gameManager = gameManager;
            this._bulletSystem = bulletSystem;
            this._bulletConfig = bulletConfig;
            
            Debug.Log("injected CharacterController");
        }

        private void OnEnable()
        {
            this._character.GetComponent<HitPointsComponent>().hpEmpty += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            this._character.GetComponent<HitPointsComponent>().hpEmpty -= this.OnCharacterDeath;
        }

        public void OnCharacterDeath(GameObject _) => this._gameManager.FinishGame();

        public void FixedTick()
        {
            if (this._fireRequired)
            {
                this.OnFlyBullet();
                this._fireRequired = false;
            }
        }

        private void OnFlyBullet()
        {
            var weapon = this._character.GetComponent<WeaponComponent>();
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int) this._bulletConfig.physicsLayer,
                color = this._bulletConfig.color,
                damage = this._bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * this._bulletConfig.speed
            });
        }
    }
}