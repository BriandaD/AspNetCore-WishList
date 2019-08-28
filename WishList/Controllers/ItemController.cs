using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _Context;

        public ItemController(ApplicationDbContext _context)
        {
            _Context = _context;
        }

        public IActionResult Index()
        {
            var model = _Context.Items.ToList();
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _Context.Items.Add(item);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _Context.Items.Find(id);
            _Context.Items.Remove(item);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
