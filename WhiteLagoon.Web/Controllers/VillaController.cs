using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        public ApplicationDbContext _db { get; set; }

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var list = _db.Villas.ToList();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "Имя не может быть равно деталям.");
            }
            else if (ModelState.IsValid)
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Update(int villaId)
        {
            var obj = _db.Villas.FirstOrDefault(x => x.Id == villaId);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
