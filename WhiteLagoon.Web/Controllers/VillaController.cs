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
                TempData["success"] = "Villa created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Update(int villaId)
        {
            var obj = _db.Villas.FirstOrDefault(x => x.Id == villaId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }

        public IActionResult Delete(int villaId)
        {
            var obj = _db.Villas.FirstOrDefault(x => x.Id == villaId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);

        }

        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _db.Villas.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Villa updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _db.Villas.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb is not null)
            {
                _db.Villas.Remove(objFromDb);
                _db.SaveChanges();
                TempData["success"] = "Villa deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
