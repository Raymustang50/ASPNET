using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Testing.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository repo;

        public InventoryController(IInventoryRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var inventory = repo.GetAllInventory();

            return View(inventory);
        }

        public IActionResult ViewInventory(int id)
        {
            var item = repo.GetInventory(id);

            return View(item);
        }

        public IActionResult UpdateInventory(int id)
        {
            Inventory e = repo.GetInventory(id);

            if (e == null)
            {
                return View("ProductNotFound");
            }

            return View(e);
        }

        public IActionResult UpdateInventoryToDatabase(Inventory e)
        {
            repo.UpdateInventory(e);

            return RedirectToAction("ViewInventory", new { id = e.Id });
        }

        public IActionResult InsertItemToDatabase(Inventory itemToInsert)
        {

            repo.InsertInventory(itemToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(Inventory dItem)
        {
            repo.DeleteItem(dItem);

            return RedirectToAction("Index");
        }

        public IActionResult InsertInventory()
        {
            return View(new Inventory());
        }

        public IActionResult Search(string searchString)
        {
            var search = repo.SearchInventory(searchString);
            return View(search);
        }

    }
}
