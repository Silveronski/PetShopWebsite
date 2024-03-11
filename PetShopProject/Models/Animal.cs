using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PetShopProject.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

		[Required(ErrorMessage = "You must fill out the name!")]
		[StringLength(15, ErrorMessage = "Animal name must be under 16 characters!")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters!")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "You must fill out the age!")]
		[Range(1, 50, ErrorMessage = "Age must be between 1 and 50!")]
		public int Age { get; set; }

        [DisplayName("Image")]
		public string? PictureName { get; set; }

		[Required(ErrorMessage = "You must fill out the description!")]
		[StringLength(35, ErrorMessage = "Description must be under 36 characters!")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Description can only contain letters!")]
		public string? Description { get; set; }

        [ForeignKey("CategoryId")]
		[Required(ErrorMessage = "You must fill out the category!")]
		public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set;}


		public static List<Animal> GetTwoSelectedAnimals(List<Animal> animals)
		{
			return animals.OrderByDescending(a => a.Comments?.Count ?? 0)
											.ThenBy(a => a.AnimalId)
											.Take(2)
											.ToList();
		}

	}
}