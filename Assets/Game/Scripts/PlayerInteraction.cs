using UnityEngine;
using System; 

namespace Game.Scripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;
        [SerializeField] private float interactDistance = 2f; // How far the player can reach

        public event Action<IInteractable> TargetChanged;
        
        public IInteractable CurrentTarget { get; private set; }

        private void Update()
        {
            IInteractable newTarget = FindTarget();// What is the player looking at this area?

            if (newTarget != CurrentTarget) // Only do something if it changed from the last frame where the player was looking at
            {
                CurrentTarget = newTarget;
                
                TargetChanged?.Invoke(newTarget);
                
                /* for testing
                if(CurrentTarget != null)
                    Debug.Log("Looking at something interactable");
                else
                {
                    Debug.Log("Looking at nothing");
                }
                */
            }
            
        }

        private IInteractable FindTarget()
        {
            
            //if player is looking at something and nothing is being detected within reach then there's no target to interact
            if (!Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, interactDistance))
                return null;
            // if player is looking at something and it is interactable then player can interact
            if(hit.collider.TryGetComponent(out IInteractable interactable))
                return interactable; 
            
            return null; //player looks at something, but it's not interactable like a wall
        }

        public void Interact()
        {
            //if(!Physics.Raycast(playerCamera.position, playerCamera.forward, out var hitInfo, interactDistance))
                //return;

            if (CurrentTarget == null)
                return;

            CurrentTarget.Interact();
        }
    }
}