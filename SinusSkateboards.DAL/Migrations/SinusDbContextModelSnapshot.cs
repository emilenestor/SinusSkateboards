﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SinusSkateboards.DAL;

namespace SinusSkateboards.DAL.Migrations
{
    [DbContext(typeof(SinusDbContext))]
    partial class SinusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SinusSkateboards.DTO.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
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
                });

            modelBuilder.Entity("SinusSkateboards.DTO.Models.CustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("SinusSkateboards.DTO.Models.OrderDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("SinusSkateboards.DTO.Models.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SinusSkateboards.DTO.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            Colour = "Ash - Grey",
                            Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                            ImagePath = "hoodie-ash.png",
                            Price = 599.99m,
                            Title = "Hoodie"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            Colour = "Fire - Red",
                            Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                            ImagePath = "hoodie-fire.png",
                            Price = 599.99m,
                            Title = "Hoodie"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            Colour = "Green",
                            Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                            ImagePath = "hoodie-green.png",
                            Price = 599.99m,
                            Title = "Hoodie"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Colour = "Ocean - Blue",
                            Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                            ImagePath = "hoodie-ocean.png",
                            Price = 599.99m,
                            Title = "Hoodie"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            Colour = "Purple",
                            Description = "If you're looking for a top-quality, instant-favorite sweatshirt, you've come to the right place! Our Premium Hoodie is everything you could ask for: it's warm and cozy, heavyweight and roomy, and built to last.",
                            ImagePath = "hoodie-purple.png",
                            Price = 599.99m,
                            Title = "Hoodie"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Colour = "Blue",
                            Description = "This snapback cap comes with instant street cred. A must-have for anyone seeking that urban style, the snap-back comes with a flat but flexible brim. Throw this on as a complement to whatever look you’re going for.",
                            ImagePath = "sinus-cap-blue.png",
                            Price = 299.99m,
                            Title = "Cap"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Colour = "Green",
                            Description = "This snapback cap comes with instant street cred. A must-have for anyone seeking that urban style, the snap-back comes with a flat but flexible brim. Throw this on as a complement to whatever look you’re going for.",
                            ImagePath = "sinus-cap-green.png",
                            Price = 299.99m,
                            Title = "Cap"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Colour = "Purple",
                            Description = "This snapback cap comes with instant street cred. A must-have for anyone seeking that urban style, the snap-back comes with a flat but flexible brim. Throw this on as a complement to whatever look you’re going for.",
                            ImagePath = "sinus-cap-purple.png",
                            Price = 299.99m,
                            Title = "Cap"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Colour = "Red",
                            Description = "This snapback cap comes with instant street cred. A must-have for anyone seeking that urban style, the snap-back comes with a flat but flexible brim. Throw this on as a complement to whatever look you’re going for.",
                            ImagePath = "sinus-cap-red.png",
                            Price = 299.99m,
                            Title = "Cap"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Colour = "Print",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-eagle.png",
                            Price = 699.99m,
                            Title = "Skateboard - Eagle"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            Colour = "Print",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-fire.png",
                            Price = 699.99m,
                            Title = "Skateboard - Fire"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            Colour = "Print",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-gretasfury.png",
                            Price = 699.99m,
                            Title = "Skateboard - Greta's Fury"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Colour = "Print",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-ink.png",
                            Price = 699.99m,
                            Title = "Skateboard - Ink"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 1,
                            Colour = "Wood",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-logo.png",
                            Price = 699.99m,
                            Title = "Skateboard - SINUS"
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 1,
                            Colour = "Print",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-northern_lights.png",
                            Price = 699.99m,
                            Title = "Skateboard - Northern Lights"
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 1,
                            Colour = "Print",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-plastic.png",
                            Price = 699.99m,
                            Title = "Skateboard - Plastic"
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 1,
                            Colour = "Print",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-polar.png",
                            Price = 699.99m,
                            Title = "Skateboard - Polar"
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 1,
                            Colour = "Purple",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-purple.png",
                            Price = 699.99m,
                            Title = "Skateboard - SINUS"
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 1,
                            Colour = "Yellow",
                            Description = "This skateboard is suited for all levels of skill, just waiting for you to take it to the streets or the skatepark.",
                            ImagePath = "sinus-skateboard-yellow.png",
                            Price = 699.99m,
                            Title = "Skateboard - SINUS"
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 5,
                            Colour = "Blue",
                            Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                            ImagePath = "sinus-tshirt-blue.png",
                            Price = 199.99m,
                            Title = "T-Shirt"
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 5,
                            Colour = "Grey",
                            Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                            ImagePath = "sinus-tshirt-grey.png",
                            Price = 199.99m,
                            Title = "T-Shirt"
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 5,
                            Colour = "Pink",
                            Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                            ImagePath = "sinus-tshirt-pink.png",
                            Price = 199.99m,
                            Title = "T-Shirt"
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 5,
                            Colour = "Purple",
                            Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                            ImagePath = "sinus-tshirt-purple.png",
                            Price = 199.99m,
                            Title = "T-Shirt"
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 5,
                            Colour = "Yellow",
                            Description = "This is our best seller for a reason. Relaxed, tailored and ultra-comfortable, you'll love the way you look in this durable, reliable classic.",
                            ImagePath = "sinus-tshirt-yellow.png",
                            Price = 199.99m,
                            Title = "T-Shirt"
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 2,
                            Colour = "Red Wave",
                            Description = "Instant classic.",
                            ImagePath = "sinus-wheel-rocket.png",
                            Price = 499.99m,
                            Title = "Wheels"
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 2,
                            Colour = "White",
                            Description = "Instant classic.",
                            ImagePath = "sinus-wheel-spinner.png",
                            Price = 499.99m,
                            Title = "Wheels"
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 2,
                            Colour = "Grey Wave",
                            Description = "Instant classic.",
                            ImagePath = "sinus-wheel-wave.png",
                            Price = 499.99m,
                            Title = "Wheels"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SinusSkateboards.DTO.Models.OrderDetailsModel", b =>
                {
                    b.HasOne("SinusSkateboards.DTO.Models.OrderModel", "Order")
                        .WithMany("OrderedProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SinusSkateboards.DTO.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SinusSkateboards.DTO.Models.OrderModel", b =>
                {
                    b.HasOne("SinusSkateboards.DTO.Models.CustomerModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SinusSkateboards.DTO.Models.ProductModel", b =>
                {
                    b.HasOne("SinusSkateboards.DTO.Models.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SinusSkateboards.DTO.Models.OrderModel", b =>
                {
                    b.Navigation("OrderedProducts");
                });
#pragma warning restore 612, 618
        }
    }
}