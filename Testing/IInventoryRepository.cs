using System;
using System.Collections.Generic;
using Testing.Models;

namespace Testing
{
    public interface IInventoryRepository
    {
        public IEnumerable<Inventory> GetAllInventory();
        public Inventory GetInventory(int id);
        public void UpdateInventory(Inventory item);
        public void InsertInventory(Inventory itemToInsert);
        public void DeleteItem(Inventory dItem);
    }
}
