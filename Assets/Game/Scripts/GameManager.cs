using UnityEngine;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance; //belongs to the class itself, not to one object. so every script will share this same one variable.
        
        public static GameManager Instance => instance;

        public IInventory Inventory { get; } = new Inventory(); //Reads the player's inventory so no one can replace it with a new one.

        private void Awake()
        {
            if (instance != null)
            {
                DestroyImmediate(gameObject);
                return;
            }//if gamemanager already exists, it will delete the dublicated one

            instance = this;
        }

        private void OnDestroy()
        {
            if (instance == this)// clear the singleton when this Gamemanager is destroyed
                instance = null;
        }
        
    }
}