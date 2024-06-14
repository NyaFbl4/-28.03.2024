using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public float HorizontalDirection { get; private set; }

        [SerializeField]
        private GameObject _character;

        //[SerializeField]
        private CharacterController _characterController;

        [Inject]
        public void Construct(CharacterController characterController)
        {
            this._characterController = characterController;
            Debug.Log("injected CharacterController");
        }

        private void Update()
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
        
        private void FixedUpdate()
        {
            this._character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(this.HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}