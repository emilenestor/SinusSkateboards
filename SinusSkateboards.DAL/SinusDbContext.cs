using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinusSkateboards.DAL
{
    public class SinusDbContext : IdentityDbContext
    {
        public SinusDbContext(DbContextOptions<SinusDbContext> options) : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }
        public DbSet<CustomerModel> CustomerDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryModel>().HasData(
                new
                {
                    Id = 1,
                    Name = "Skateboards"
                },
                new
                {
                    Id = 2,
                    Name = "Wheels"
                },
                new
                {
                    Id = 3,
                    Name = "Headwear"
                },
                new
                {
                    Id = 4,
                    Name = "Hoodies"
                },
                new
                {
                    Id = 5,
                    Name = "T-Shirts"
                });

            modelBuilder.Entity<ProductModel>().HasData(
                new
                {
                    Id = 1,
                    ImagePath = "hoodie-ash.png",
                    Title = "Hoodie",
                    Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                    Colour = "Ash - Grey",
                    CategoryId = 4,
                    Price = 599.99M,
                },
                new
                {
                    Id = 2,
                    ImagePath = "hoodie-fire.png",
                    Title = "Hoodie",
                    Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                    Colour = "Fire - Red",
                    CategoryId = 4,
                    Price = 599.99M,
                },
                new
                {
                    Id = 3,
                    ImagePath = "hoodie-green.png",
                    Title = "Hoodie",
                    Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                    Colour = "Green",
                    CategoryId = 4,
                    Price = 599.99M,
                },
                new
                {
                    Id = 4,
                    ImagePath = "hoodie-ocean.png",
                    Title = "Hoodie",
                    Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                    Colour = "Ocean - Blue",
                    CategoryId = 4,
                    Price = 599.99M,
                },
                new
                {
                    Id = 5,
                    ImagePath = "hoodie-purple.png",
                    Title = "Hoodie",
                    Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                    Colour = "Purple",
                    CategoryId = 4,
                    Price = 599.99M,
                },
                new
                {
                    Id = 6,
                    ImagePath = "sinus-cap-blue.png",
                    Title = "Cap",
                    Description = "This snapback cap comes with instant street cred. A must-have for anyone seeking that urban style, the snap-back comes with a flat but flexible brim. Throw this on as a complement to whatever look you’re going for.",
                    Colour = "Blue",
                    CategoryId = 3,
                    Price = 299.99M,
                },
                new
                {
                    Id = 7,
                    ImagePath = "sinus-cap-green.png",
                    Title = "Cap",
                    Description = "This snapback cap comes with instant street cred. A must-have for anyone seeking that urban style, the snap-back comes with a flat but flexible brim. Throw this on as a complement to whatever look you’re going for.",
                    Colour = "Green",
                    CategoryId = 3,
                    Price = 299.99M,
                },
                new
                {
                    Id = 8,
                    ImagePath = "sinus-cap-purple.png",
                    Title = "Cap",
                    Description = "This snapback cap comes with instant street cred. A must-have for anyone seeking that urban style, the snap-back comes with a flat but flexible brim. Throw this on as a complement to whatever look you’re going for.",
                    Colour = "Purple",
                    CategoryId = 3,
                    Price = 299.99M,
                },
                new
                {
                    Id = 9,
                    ImagePath = "sinus-cap-red.png",
                    Title = "Cap",
                    Description = "This snapback cap comes with instant street cred. A must-have for anyone seeking that urban style, the snap-back comes with a flat but flexible brim. Throw this on as a complement to whatever look you’re going for.",
                    Colour = "Red",
                    CategoryId = 3,
                    Price = 299.99M,
                },
                new
                {
                    Id = 10,
                    ImagePath = "sinus-skateboard-eagle.png",
                    Title = "Skateboard - Eagle",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Print",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 11,
                    ImagePath = "sinus-skateboard-fire.png",
                    Title = "Skateboard - Fire",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Print",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 12,
                    ImagePath = "sinus-skateboard-gretasfury.png",
                    Title = "Skateboard - Greta's Fury",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Print",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 13,
                    ImagePath = "sinus-skateboard-ink.png",
                    Title = "Skateboard - Ink",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Print",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 14,
                    ImagePath = "sinus-skateboard-logo.png",
                    Title = "Skateboard - SINUS",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Wood",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 15,
                    ImagePath = "sinus-skateboard-northern_lights.png",
                    Title = "Skateboard - Northern Lights",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Print",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 16,
                    ImagePath = "sinus-skateboard-plastic.png",
                    Title = "Skateboard - Plastic",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Print",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 17,
                    ImagePath = "sinus-skateboard-polar.png",
                    Title = "Skateboard - Polar",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Print",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 18,
                    ImagePath = "sinus-skateboard-purple.png",
                    Title = "Skateboard - SINUS",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Purple",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 19,
                    ImagePath = "sinus-skateboard-yellow.png",
                    Title = "Skateboard - SINUS",
                    Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                    Colour = "Yellow",
                    CategoryId = 1,
                    Price = 699.99M,
                },
                new
                {
                    Id = 20,
                    ImagePath = "sinus-tshirt-blue.png",
                    Title = "T-Shirt",
                    Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                    Colour = "Blue",
                    CategoryId = 5,
                    Price = 199.99M,
                },
                new
                {
                    Id = 21,
                    ImagePath = "sinus-tshirt-grey.png",
                    Title = "T-Shirt",
                    Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                    Colour = "Grey",
                    CategoryId = 5,
                    Price = 199.99M,
                },
                new
                {
                    Id = 22,
                    ImagePath = "sinus-tshirt-pink.png",
                    Title = "T-Shirt",
                    Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                    Colour = "Pink",
                    CategoryId = 5,
                    Price = 199.99M,
                },
                new
                {
                    Id = 23,
                    ImagePath = "sinus-tshirt-purple.png",
                    Title = "T-Shirt",
                    Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                    Colour = "Purple",
                    CategoryId = 5,
                    Price = 199.99M,
                },
                new
                {
                    Id = 24,
                    ImagePath = "sinus-tshirt-yellow.png",
                    Title = "T-Shirt",
                    Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                    Colour = "Yellow",
                    CategoryId = 5,
                    Price = 199.99M,
                },
                new
                {
                    Id = 25,
                    ImagePath = "sinus-wheel-rocket.png",
                    Title = "Wheels",
                    Description = "Instant classic.",
                    Colour = "Red Wave",
                    CategoryId = 2,
                    Price = 499.99M,
                },
                new
                {
                    Id = 26,
                    ImagePath = "sinus-wheel-spinner.png",
                    Title = "Wheels",
                    Description = "Instant classic.",
                    Colour = "White",
                    CategoryId = 2,
                    Price = 499.99M,
                },
                new
                {
                    Id = 27,
                    ImagePath = "sinus-wheel-wave.png",
                    Title = "Wheels",
                    Description = "Instant classic.",
                    Colour = "Grey Wave",
                    CategoryId = 2,
                    Price = 499.99M,
                });
        }
    }
}
