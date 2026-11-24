using UnityEngine;

namespace Game.Scripts
{
    public class item_delete : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Destroy(gameObject);
        }
    }
}