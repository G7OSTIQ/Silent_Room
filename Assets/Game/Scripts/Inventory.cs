using System;
using System.Collections.Generic;

namespace Game.Scripts
{
    public class Inventory : IInventory
    {
        public event Action Changed;
        private Dictionary<ItemType, int> items = new();
        public IReadOnlyDictionary<ItemType, int> Items => items;        
        public bool TryAdd(ItemType item, int quantity)
        {
            if (quantity < 1) // can't add 0 or a negative number
                return false;
            
            items.TryGetValue(item, out var current); //checks how many do we have if 0 then nothing
            
            items[item] = current + quantity; //saves the new amount
            
            Changed?.Invoke();
            return true;
        }

        public bool TryRemove(ItemType item, int quantity)
        {
           if (quantity < 1)
               return false;
           
           if(!Contains(item, quantity)) //if the list doesn't contains any of it's items then we can't remove it.
               return false;
           
           int remaining = items[item] - quantity;
           
           if (remaining == 0) // if no items are left then remove the item
               items.Remove(item);
           else 
               items[item] = remaining;
           
           Changed?.Invoke();
           return true;
        }

        public bool TryRemove(ItemType item)
        {
            var success = items.Remove(item);
            
            if (success)
                Changed?.Invoke();
            
            return success;
        }


        public bool Contains(ItemType item, int quantity)
        {
            return items.TryGetValue(item, out int current) && current >= quantity;                  
        }
    }
}