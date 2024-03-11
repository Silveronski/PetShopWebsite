using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PetShopProject.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [ForeignKey("AnimalId")]
        public int AnimalId { get; set; }

        [StringLength(25)]		
		public string? CommentText { get; set; }

        public virtual Animal? Animal { get; set; }
    }
}
