using UnityEngine;

namespace Game.Scripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;
        [SerializeField] private float interactDistance = 2f;

        public void Interact()
        {
            if(!Physics.Raycast(playerCamera.position, playerCamera.forward, out var hitInfo, interactDistance))
                return;

            if (hitInfo.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}