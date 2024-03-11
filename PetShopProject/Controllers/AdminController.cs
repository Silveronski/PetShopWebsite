using Microsoft.AspNetCore.Mvc;
using PetShopProject.Data;
using PetShopProject.Models;
namespace PetShopProject.Controllers
{
	public class AdminController : Controller
	{
		PetShopContext _context;
		readonly IWebHostEnvironment _webHostEnvironment;
		public AdminController(PetShopContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
			_webHostEnvironment = webHostEnvironment;
		}
        public IActionResult AdminHomePage()
		{
			return View(_context.Animals.ToList());
		}

        public IActionResult AddAnimal()
        {
            return View();
        }

		[HttpPost]
		public IActionResult AddAnimal(Animal animal, int selectedCategoryIndex, IFormFile imgFileInput)
		{			
			bool isFileImage = true;			

			if (selectedCategoryIndex == -1)
				ModelState.AddModelError("CategoryId", "You must choose a category!");

			if (imgFileInput != null)
			{
				if (!IsImageFile(imgFileInput))
				{
					ModelState.AddModelError("PictureName", "The uploaded file is not a valid image!");
					isFileImage = false;
				}
			}
			else
			{
				ModelState.AddModelError("PictureName", "You must provide an image!");
			}

			animal.CategoryId = selectedCategoryIndex + 1;

			if (imgFileInput != null && imgFileInput.Length > 0 && isFileImage)
			{
				SaveAnimalImage(animal, imgFileInput);
			}

			if (!ModelState.IsValid || imgFileInput == null)
				return View(animal);

			_context.Animals.Add(animal);
            _context.SaveChanges();
			TempData["success"] = "Animal created successfully";
			return RedirectToAction("AdminHomePage");
		}

		private bool IsImageFile(IFormFile imgFileInput)
		{
			var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
			var fileExtension = Path.GetExtension(imgFileInput.FileName).ToLowerInvariant();

			return validExtensions.Contains(fileExtension);
		}

		private void SaveAnimalImage(Animal animal, IFormFile imgFileInput)
		{
			var imgExtension = Path.GetExtension(imgFileInput.FileName);
			var fileName = animal.Name + imgExtension;
			var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "animalImages", fileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				imgFileInput.CopyTo(fileStream);
			}
			
			animal.PictureName = $"~/images/animalImages/{animal.Name}{imgExtension}";
		}

		// GET
		public IActionResult EditAnimal(int id)
        {
			var animal = _context.Animals.FirstOrDefault(a => a.AnimalId == id);
			if (animal != null && id != 0)
				return View(animal);

			return NotFound();
        }

		// POST
		[HttpPost]
		public IActionResult EditAnimal(Animal animal, int selectedCategoryIndex, IFormFile? imgFileInput)
		{			
			bool isFileImage = true;		

			if (selectedCategoryIndex == -1)
			{
				ModelState.AddModelError("CategoryId", "You must choose a category!");
			}

			if (imgFileInput != null)
			{
				if (!IsImageFile(imgFileInput))
				{
					ModelState.AddModelError("PictureName", "The uploaded file is not a valid image!");
					isFileImage = false;
				}
			}			

			animal.CategoryId = selectedCategoryIndex;

			if (imgFileInput != null && imgFileInput.Length > 0 && isFileImage)
			{
				SaveAnimalImage(animal, imgFileInput);
			}

			if (!ModelState.IsValid)
				return View(animal);

			_context.Animals.Update(animal);
			_context.SaveChanges();
			TempData["success"] = "Animal updated successfully";
			return RedirectToAction("AdminHomePage");
		}

		// GET
		public IActionResult DeleteAnimal(int id)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.AnimalId == id);
			if (animal != null && id != 0)
				return View(animal);

			return NotFound();
        }

        // POST
        [HttpPost]
		public IActionResult DeleteAnimal(Animal animal)
        {
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
				TempData["success"] = "Animal removed successfully";
				return RedirectToAction("AdminHomePage");
			}
			return NotFound();
		}
	}
}