using Microsoft.EntityFrameworkCore;
using PetShopProject.Data.Enums;
using PetShopProject.Models;
namespace PetShopProject.Data
{
    public class PetShopContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public const string animalImagesPath = "~/images/animalImages/";
		public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new { CategoryId = 1, Name = CategoryType.Mammal.ToString() },
                new { CategoryId = 2, Name = CategoryType.Bird.ToString() },
                new { CategoryId = 3, Name = CategoryType.Reptile.ToString() },
                new { CategoryId = 4, Name = CategoryType.Amphibian.ToString() },
                new { CategoryId = 5, Name = CategoryType.Fish.ToString() }
            );

            modelBuilder.Entity<Animal>().HasData(

                new { AnimalId = 1, Name = "Dog", Age = 5, PictureName = $"{animalImagesPath}dog.png", Description = "A smart dog", CategoryId = 1 },
                new { AnimalId = 2, Name = "Cat", Age = 3, PictureName = $"{animalImagesPath}cat.png", Description = "A playful cat", CategoryId = 1 },
                new { AnimalId = 3, Name = "Parrot", Age = 2, PictureName = $"{animalImagesPath}parrot.jpg", Description = "A colorful parrot", CategoryId = 2 },
                new { AnimalId = 4, Name = "Snake", Age = 4, PictureName = $"{animalImagesPath}snake.png", Description = "A slithering snake", CategoryId = 3 },
                new { AnimalId = 5, Name = "Frog", Age = 1, PictureName = $"{animalImagesPath}frog.jpeg", Description = "A jumping frog", CategoryId = 4 },
                new { AnimalId = 6, Name = "Goldfish", Age = 1, PictureName = $"{animalImagesPath}goldfish.png", Description = "A shiny goldfish", CategoryId = 5 },
                new { AnimalId = 7, Name = "Hamster", Age = 2, PictureName = $"{animalImagesPath}hamster.png", Description = "A cute hamster", CategoryId = 1 },
                new { AnimalId = 8, Name = "Owl", Age = 3, PictureName = $"{animalImagesPath}owl.png", Description = "A wise owl", CategoryId = 2 },
                new { AnimalId = 9, Name = "Lizard", Age = 2, PictureName = $"{animalImagesPath}lizard.jpeg", Description = "A crawling lizard", CategoryId = 3 },
                new { AnimalId = 10, Name = "Turtle", Age = 5, PictureName = $"{animalImagesPath}turtle.png", Description = "A slow turtle", CategoryId = 4 },
                new { AnimalId = 11, Name = "Shark", Age = 8, PictureName = $"{animalImagesPath}shark.png", Description = "A fierce shark", CategoryId = 5 },
                new { AnimalId = 12, Name = "Rabbit", Age = 2, PictureName = $"{animalImagesPath}rabbit.jpg", Description = "A hopping rabbit", CategoryId = 1 },
                new { AnimalId = 13, Name = "Eagle", Age = 4, PictureName = $"{animalImagesPath}eagle.jpg", Description = "A majestic eagle", CategoryId = 2 },
                new { AnimalId = 14, Name = "Iguana", Age = 3, PictureName = $"{animalImagesPath}iguana.jpeg", Description = "A colorful iguana", CategoryId = 3 },
                new { AnimalId = 15, Name = "Guppy", Age = 1, PictureName = $"{animalImagesPath}guppy.jpeg", Description = "A tiny guppy fish", CategoryId = 5 }     
                );

            modelBuilder.Entity<Comment>().HasData(

                new { CommentId = 1, AnimalId = 1, CommentText = "Great dog!" },
                new { CommentId = 2, AnimalId = 1, CommentText = "Very friendly!" },
                new { CommentId = 3, AnimalId = 1, CommentText = "Love the picture!" },
                new { CommentId = 4, AnimalId = 1, CommentText = "Awesome pet!" },
                new { CommentId = 5, AnimalId = 1, CommentText = "Adorable!" },


                new { CommentId = 6, AnimalId = 13, CommentText = "Beautiful eagle!" },
                new { CommentId = 7, AnimalId = 13, CommentText = "Majestic bird!" },
                new { CommentId = 8, AnimalId = 13, CommentText = "Impressive!" },


                new { CommentId = 9, AnimalId = 2, CommentText = "Lovely cat!" },
                new { CommentId = 10, AnimalId = 2, CommentText = "Playful and cute!" },

               
                new { CommentId = 11, AnimalId = 5, CommentText = "Unique frog!" },
                new { CommentId = 12, AnimalId = 5, CommentText = "Interesting colors!" },

               
                new { CommentId = 13, AnimalId = 6, CommentText = "Shiny goldfish!" },
                new { CommentId = 14, AnimalId = 6, CommentText = "Cute pet!" },

             
                new { CommentId = 15, AnimalId = 7, CommentText = "Love the hamster!" },
                new { CommentId = 16, AnimalId = 7, CommentText = "Cute little guy!" },


                new { CommentId = 17, AnimalId = 8, CommentText = "Wise owl!" },
                new { CommentId = 18, AnimalId = 8, CommentText = "Impressive bird!" }, 
                

                new { CommentId = 19, AnimalId = 9, CommentText = "Crawling lizard!" },
                new { CommentId = 20, AnimalId = 9, CommentText = "Interesting reptile!" },


                new { CommentId = 21, AnimalId = 10, CommentText = "Slow turtle!" },
                new { CommentId = 22, AnimalId = 10, CommentText = "Adorable!" },


                new { CommentId = 23, AnimalId = 11, CommentText = "Fierce shark!" },
                new { CommentId = 24, AnimalId = 11, CommentText = "Impressive predator!" },


                new { CommentId = 25, AnimalId = 12, CommentText = "Hopping rabbit!" },
                new { CommentId = 26, AnimalId = 12, CommentText = "Cute bunny!" },
                             
               
                new { CommentId = 27, AnimalId = 14, CommentText = "Colorful iguana!" },
                new { CommentId = 28, AnimalId = 14, CommentText = "Unique reptile!" }, 
                

                new { CommentId = 29, AnimalId = 15, CommentText = "Tiny guppy fish!" },
                new { CommentId = 30, AnimalId = 15, CommentText = "Colorful and small!" },


                new { CommentId = 31, AnimalId = 3, CommentText = "Beautiful plumage!" },
                new { CommentId = 32, AnimalId = 3, CommentText = "Impressive bird sounds!" },

               
                new { CommentId = 33, AnimalId = 4, CommentText = "Slithering beauty!" },
                new { CommentId = 34, AnimalId = 4, CommentText = "Unique patterns!" }
            );
        }
    }
}
