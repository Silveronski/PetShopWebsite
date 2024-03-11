using Microsoft.AspNetCore.Mvc;
using PetShopProject.Data;
using PetShopProject.Models;
namespace PetShopProject.Controllers
{
    public class PetShopController : Controller
    {
        PetShopContext _context { get; set; }
        public PetShopController(PetShopContext context)
        {
            _context = context;
        }
        public IActionResult HomePage()
        {
            var twoSelectedAnimals = Animal.GetTwoSelectedAnimals(_context.Animals.ToList());
            return View(twoSelectedAnimals);
        }

		public IActionResult Catalog()
        {
            return View(_context.Animals.ToList());
        }

		public IActionResult AnimalDetails(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid animal id");

            var animal = _context.Animals.FirstOrDefault(a => a.AnimalId == id);
            
			if (animal != null)
				return View(animal);

			return NotFound();
        }

		[HttpPost]
		public IActionResult SubmitComment(string comment, int id)
		{
            if (comment != null && id != 0)
            {
			    var animal = _context.Animals.FirstOrDefault(a => a.AnimalId == id);
			    var commentObj = new Comment { AnimalId = id, CommentText = comment, Animal = animal };
			    animal!.Comments!.Add(commentObj);
			    _context.SaveChanges();
			    TempData["success"] = "Comment added successfully";
			    return RedirectToAction("AnimalDetails", new { id });
            }
            return View();
		}
	}
}
