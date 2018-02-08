using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class ItemsController : Controller
    {
        [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View();
        }

        [HttpGet("/categories/{categoryId}/items/new")]
        public ActionResult CreateForm(int categoryId)
        {
          Category category = Category.Find(categoryId);
          return View(category);
        }


        [HttpPost("/category/{categoryId}/items/{id}")]
        public ActionResult Details(int id)
        {
          Item item = Item.Find(id);
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category category = Category.Find(item.GetId());
          model.Add("item", item);
          model.Add("category", category);
          return View();
        }

        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
          Item.ClearAll();
          return View();
        }

    }
}
