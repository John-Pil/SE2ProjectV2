using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;
using PetStoreRestAPI3.Services;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchandiseController : Controller
    {
        private readonly IMerchandiseRepository _merchandiseRepo;

        public MerchandiseController(IMerchandiseRepository merchandiseRepo)
        {
            _merchandiseRepo = merchandiseRepo;
        }

        public IActionResult Index()
        {
            var merchandise = _merchandiseRepo.ReadAll();
            return View(merchandise);
        }
        [Route("api/[controller]/create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Merchandise newMerchandise)
        {
            if (ModelState.IsValid)
            {
                _merchandiseRepo.Create(newMerchandise);
                return RedirectToAction("Index");
            }
            return View(newMerchandise);
        }
        [Route("api/[controller]/details")]
        public IActionResult Details(int id)
        {
            var merchandise = _merchandiseRepo.Read(id);
            if (merchandise == null)
            {
                return RedirectToAction("Index");
            }
            return View(merchandise);
        }
        [Route("api/[controller]/edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var merchandise = _merchandiseRepo.Read(id);
            if (merchandise == null)
            {
                return RedirectToAction("Index");
            }
            return View(merchandise);
        }


        [HttpPost]
        public IActionResult Edit(Merchandise merchandise)
        {
            if (ModelState.IsValid)
            {
                _merchandiseRepo.Update(merchandise.Itemid, merchandise);
                return RedirectToAction("Index");
            }
            return View(merchandise);
        }
        [Route("api/[controller]/delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var merchandise = _merchandiseRepo.Read(id);
            if (merchandise == null)
            {
                return RedirectToAction("Index");
            }
            return View(merchandise);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _merchandiseRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
