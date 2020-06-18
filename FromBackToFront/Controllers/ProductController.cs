using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FromBackToFront.DAL;
using FromBackToFront.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FromBackToFront.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.ProductCount = _db.Products.Count();
            return View(_db.Products.Select(p=>new ProductVM
            {
                Id=p.Id,
                Price=p.Price,
                Title=p.Title,
                Category=p.Category,
                Image=p.Image
            }).Take(8));
        }
        public IActionResult Load(int skip)
        {
            var model = _db.Products.Select(p => new ProductVM
            {
                Id = p.Id,
                Price = p.Price,
                Title = p.Title,
                Category = p.Category,
                Image = p.Image
            }).Skip(skip).Take(8);
            return PartialView("_ProductPartial",model);
            #region OldVersion
            /* return Json(_db.Products.Select(p => new ProductVM
 {
     Id = p.Id,
     Price = p.Price,
     Title = p.Title,
     Category = p.Category,
     Image = p.Image
 }).Skip(8).Take(8));*/
            #endregion
        }
    }
}