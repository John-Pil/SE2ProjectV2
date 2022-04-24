using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;
using PetStoreRestAPI3.Services;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalOrderController : Controller
    {
        private readonly IAnimalOrderRepository _animalOrderRepo;

        public AnimalOrderController(IAnimalOrderRepository animalOrderRepo)
        {
            _animalOrderRepo = animalOrderRepo;
        }

        public IActionResult Index()
        {
            var animalOrder = _animalOrderRepo.ReadAll();
            return View(animalOrder);
        }
        [Route("api /[controller]/create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(AnimalOrder newAnimalOrder)
        {
            if (ModelState.IsValid)
            {
                _animalOrderRepo.Create(newAnimalOrder);
                return RedirectToAction("Index");
            }
            return View(newAnimalOrder);
        }
        [Route("api/[controller]/details")]
        public IActionResult Details(int id)
        {
            var animal = _animalOrderRepo.Read(id);
            if (animal == null)
            {
                return RedirectToAction("Index");
            }
            return View(animal);
        }
        [Route("api/[controller]/edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var animal = _animalOrderRepo.Read(id);
            if (animal == null)
            {
                return RedirectToAction("Index");
            }
            return View(animal);
        }


        [HttpPost]
        public IActionResult Edit(AnimalOrder animalOrder)
        {
            if (ModelState.IsValid)
            {
                _animalOrderRepo.Update(animalOrder.Orderid, animalOrder);
                return RedirectToAction("Index");
            }
            return View(animalOrder);
        }
        [Route("api/[controller]/delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var animal = _animalOrderRepo.Read(id);
            if (animal == null)
            {
                return RedirectToAction("Index");
            }
            return View(animal);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _animalOrderRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}