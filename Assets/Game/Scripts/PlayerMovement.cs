using UnityEngine;

namespace Game.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        
        public bool CanMove { get; private set; } = true;   // false when player is hiding
        public bool CanLook { get; private set; } = true;  
        
        [SerializeField] private float speed = 5f;
        [SerializeField] private float lookSensitivity = 0.1f; // the speed of the mouse
        [SerializeField] private Transform playerCamera;
        [SerializeField] private float maxLookAngle = 80f; //How far the player can view

        
        private CharacterController controller;

        private Vector2 direction;
        private float cameraPitch; //to move camera up and down

        void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (!CanMove)// if player is hiding they can't move so skip the rest of code
                return;
            
            var movement = transform.forward * direction.y + transform.right * direction.x; 
            movement = movement * speed;
            
            controller.Move(movement * Time.deltaTime);
        }

        public void Move(Vector2 input)
        {
            direction = input;
        }
        
        public void Look(Vector2 mouseDelta)
        {
            if (!CanLook) // if player is in menu then camera won't move around
                return;
            
            transform.Rotate(0f, mouseDelta.x * lookSensitivity, 0f);
            
            cameraPitch -= mouseDelta.y * lookSensitivity; // get's the input mouse from where player is moving the mouse to move the camera up and down
            
            cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle); // to keep the view at 80 and not have camera issue like spinning
            
            playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        }
    }
}


