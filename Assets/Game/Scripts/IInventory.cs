using System.Collections.Generic;
using System;

namespace Game.Scripts
{
    public interface IInventory
    {
        event Action Changed; //When an item is added or mreoved it will update the inventory
        
        IReadOnlyDictionary<ItemType, int> Items { get;}
        
        bool TryAdd(ItemType item, int quantity);
        bool TryRemove(ItemType item, int quantity);
        bool TryRemove(ItemType item);
        bool Contains(ItemType item, int quantity); 
    }
}