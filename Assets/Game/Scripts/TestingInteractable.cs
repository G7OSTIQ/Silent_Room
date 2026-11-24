using UnityEngine;

namespace Game.Scripts
{
    public class TestingInteractable: MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemType itemToGive = ItemType.Key;

        public void Interact()
        {
            GameManager.Instance.Inventory.TryAdd(itemToGive, 1);
            
            Debug.Log("Picked up: " + itemToGive + " | Total: " + GameManager.Instance.Inventory.Items[itemToGive]);
        }
    }
}