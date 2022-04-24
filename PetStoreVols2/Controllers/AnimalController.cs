#nullable disable
using Microsoft.AspNetCore.Mvc;
using PetStoreRestAPI3.Models;
using PetStoreRestAPI3.Services;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepo;

        public AnimalController(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public IActionResult Index()
        {
            var animal = _animalRepo.ReadAll();
            return View(animal);
        }
        [Route("api/[controller]/create")]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Animal newAnimal)
        {
            if (ModelState.IsValid)
            {
                _animalRepo.Create(newAnimal);
                return RedirectToAction("Index");
            }
            return View(newAnimal);
        }
        [Route("api/[controller]/details")]
        public IActionResult Details(int id)
        {
            var animal = _animalRepo.Read(id);
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
            var animal = _animalRepo.Read(id);
            if (animal == null)
            {
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        
        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _animalRepo.Update(animal.Animalid, animal);
                return RedirectToAction("Index");
            }
            return View(animal);
        }
        [Route("api/[controller]/delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var animal = _animalRepo.Read(id);
            if (animal == null)
            {
                return RedirectToAction("Index");
            }
            return View(animal);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _animalRepo.Delete(id);
            return RedirectToAction("Index");
        }

        //// GET: api/Animal
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        //{
        //    return await _context.Animal.ToListAsync();
        //}

        //// GET: api/Animal/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Animal>> GetAnimal(int id)
        //{
        //    var animal = await _context.Animal.FindAsync(id);

        //    if (animal == null)
        //    {
        //        return NotFound();
        //    }

        //    return animal;
        //}

        //// PUT: api/Animal/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAnimal(int id, Animal animal)
        //{
        //    if (id != animal.Animalid)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(animal).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AnimalExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Animals
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        //{
        //    _context.Animal.Add(animal);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAnimal", new { id = animal.Animalid }, animal);
        //}

        //// DELETE: api/Animals/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAnimal(int id)
        //{
        //    var animal = await _context.Animal.FindAsync(id);
        //    if (animal == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Animal.Remove(animal);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AnimalExists(int id)
        //{
        //    return _context.Animal.Any(e => e.Animalid == id);
        //}
    }
}
