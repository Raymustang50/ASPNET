using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Testing.Models;

namespace Testing
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IDbConnection _conn;

        public InventoryRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Inventory> GetAllInventory()
        {
            return _conn.Query<Inventory>("SELECT * FROM INVENTORY;");
        }

        public Inventory GetInventory(int id)
        {
            return _conn.QuerySingle<Inventory>("SELECT * FROM INVENTORY WHERE ID = @id;",
                new { id = id });
        }

        public void UpdateInventory(Inventory equipment)
        {
            _conn.Execute("UPDATE INVENTORY SET Quantity = @quantity WHERE ID = @id",
                new { quantity = equipment.Quantity });
        }

        public void InsertInventory(Inventory itemToInsert)
        {
            _conn.Execute("INSERT INTO INVENTORY (ITEM, SIZE, QUANTITY) VALUES (@item, @size, @quantity);",
                new { item = itemToInsert.Item, size = itemToInsert.Size, quantity = itemToInsert.Quantity });

        }

        public void DeleteItem(Inventory dItem)
        {
            _conn.Execute("DELETE FROM INVENTORY WHERE Id = @id;",
                new { id = dItem.Id });
        }



    }
    }