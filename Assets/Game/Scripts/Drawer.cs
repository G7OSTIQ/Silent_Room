using System.Collections;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Game.Scripts
{
    public class Drawer :  MonoBehaviour, IInteractable
    {
        [SerializeField] public bool hasItem = true;
        [SerializeField] private Item item;
        [SerializeField] private float openDistance = 0.4f; // Animation how far it will slide
        [SerializeField] private float openTime = 0.5f; //How long it takes to slide;
        
        private Vector3 closePosition; //drawer is when closed
        private Vector3 openPosition;   //drawer when it's open
        private bool isMoving;          // bool to make sure it's sliding , so player interaction is ignored


        public bool IsOpened { get; private set; } //everyone can read if it's open but only the drawer can change it as in if it has something or not

        private void Awake()
        {
            closePosition = transform.localPosition; // localposition means position is compared to the parent which is the Cabinet
            openPosition = closePosition + Vector3.forward * openDistance;
        }
        
        public void Interact()
        {
            
            if(isMoving) //if the drawer is still opening ignore the rest until finished
                return;
            
            if (IsOpened) //If it's already opened do nothing do no add anything
                StartCoroutine(SlideRoutine(openPosition, closePosition, false)); // close it
            else
                StartCoroutine(SlideRoutine(closePosition, openPosition, true)); // open it
            
            //IsOpened = true;

            

            /*
            if (!hasItem)
            {
                Debug.Log("The drawer is empty");
                return;
            } // there is no item
            

            //Give the item to the player
            GameManager.Instance.Inventory.TryAdd(item, 1);
            Debug.Log("Found a" + item); // tells what the item is

            hasItem = false; //The drawer is empty now
            */
        }

        private IEnumerator SlideRoutine(Vector3 from, Vector3 to, bool opening) //opening meaning if am opening which is true or closeing which is false
        {
            isMoving = true;

            float timePassed = 0f;

            // Keeps going until enough time has passed
            while (timePassed < openTime)
            {
                timePassed += Time.deltaTime;
                
                float t = timePassed / openTime; //t goes from 0 starts to 1 finished
                transform.localPosition = Vector3.Lerp(from, to, t); //Put the drawer at the right point between closed and open
                yield return null; // pauses her and contine on the next frame
            }
            
            transform.localPosition = to; // makes sure it will end exactly at the open position
            
            IsOpened = opening;
            isMoving = false;

            if (opening)
            {
                GiveItem(); // onces the drawer is fully opened give the item to player
            }
            
        }

        // Gives the item to the player or displays nothing
        private void GiveItem()
        {
            
            if (!hasItem)
            {
                Debug.Log("The drawer is empty");
                return;
            } // there is no item
            

            //Give the item to the player
            // GameManager.Instance.Inventory.TryAdd(item, 1);
            Debug.Log("Found a" + item); // tells what the item is

            hasItem = false; //when player already opened it, it would give another item
            
        }
        
        
        
        public void SetContents(ItemType itemType) //Put an item in the drawer
        {
            hasItem = true;
            // item = itemType;
        }

        public void SetEmpty()// make the drawer empty
        {
            hasItem = false;
        }
    }
}