using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class InputManager : ITickable, IFixedTickable
    {
        public float HorizontalDirection { get; private set; }

        //[SerializeField]
        private readonly GameObject _character;

        //[SerializeField]
        private readonly CharacterController _characterController;

        //[Inject]
        public  InputManager(CharacterController characterController, GameObject character)
        {
            this._characterController = characterController;
            this._character = character;
            Debug.Log("injected InputManager");
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _characterController._fireRequired = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.HorizontalDirection = 1;
            }
            else
            {
                this.HorizontalDirection = 0;
            }
        }
        
        public void FixedTick()
        {
            this._character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(this.HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}