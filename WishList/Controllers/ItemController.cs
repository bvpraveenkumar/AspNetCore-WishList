﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", _context.Items.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item Item)
        {
            _context.Items.Add(Item);
            _context.SaveChanges();

            return RedirectToAction("Index");  
        }

        public IActionResult Delete(int Id)
        {
            var Item = _context.Items.Where(x => x.Id == Id).SingleOrDefault(); 
            _context.Remove(Item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}