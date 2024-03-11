using System.ComponentModel;
namespace PetShopProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string? Name { get; set; }
    }
}
