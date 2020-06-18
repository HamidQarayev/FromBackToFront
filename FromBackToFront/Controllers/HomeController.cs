using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FromBackToFront.DAL;
using FromBackToFront.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FromBackToFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HomeVM model = new HomeVM()
            {
                Sliders=_db.Sliders,
                Content=_db.Contents.First(),
                Categories=_db.Categories,
                Products=_db.Products.OrderByDescending(p=>p.Id).Take(8)

            };
            return View(model);
        }
    }
}