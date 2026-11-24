using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerInteraction))]
    public class Player : MonoBehaviour
    {
        
        // A reference to the components attached
        private PlayerMovement movement;
        private PlayerInteraction interaction;
       

        private void Awake()
        {
            movement = GetComponent<PlayerMovement>();
            interaction = GetComponent<PlayerInteraction>();
            
        }
        
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Take input from Player Input and pass it on to the other scripts

        // Received by the PlayerInput component
        // when WASD is pressed
        private void OnMove(InputValue value)
        {
            var input = value.Get<Vector2>();
            movement.Move(input);
        }
        
        private void OnLook(InputValue value)
        {
            Vector2 input = value.Get<Vector2>();
            movement.Look(input);
        }

        private void OnInteract(InputValue value)
        {
            interaction.Interact();
        }
    }
}