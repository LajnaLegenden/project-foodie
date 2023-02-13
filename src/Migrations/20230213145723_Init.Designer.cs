﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project_foodie.Model;

#nullable disable

namespace projectfoodie.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230213145723_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AllergenDish", b =>
                {
                    b.Property<int>("AllergensId")
                        .HasColumnType("int");

                    b.Property<int>("DishesId")
                        .HasColumnType("int");

                    b.HasKey("AllergensId", "DishesId");

                    b.HasIndex("DishesId");

                    b.ToTable("AllergenDish");
                });

            modelBuilder.Entity("AllergenIngredient", b =>
                {
                    b.Property<int>("AllergensId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientsId")
                        .HasColumnType("int");

                    b.HasKey("AllergensId", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("AllergenIngredient");
                });

            modelBuilder.Entity("DayMenuDish", b =>
                {
                    b.Property<int>("dayMenusId")
                        .HasColumnType("int");

                    b.Property<int>("dishesId")
                        .HasColumnType("int");

                    b.HasKey("dayMenusId", "dishesId");

                    b.HasIndex("dishesId");

                    b.ToTable("DayMenuDish");
                });

            modelBuilder.Entity("DishIngredient", b =>
                {
                    b.Property<int>("DishesId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientsId")
                        .HasColumnType("int");

                    b.HasKey("DishesId", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("DishIngredient");
                });

            modelBuilder.Entity("DishOrder", b =>
                {
                    b.Property<int>("DishesId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("DishesId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("DishOrder");
                });

            modelBuilder.Entity("OrderOrderItem", b =>
                {
                    b.Property<int>("OrderItemsId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("OrderItemsId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("OrderOrderItem");
                });

            modelBuilder.Entity("project_foodie.Model.Allergen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("project_foodie.Model.DayMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("DayMenu");
                });

            modelBuilder.Entity("project_foodie.Model.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("project_foodie.Model.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("project_foodie.Model.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("lastOrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("project_foodie.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("menuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("project_foodie.Model.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("orderItemId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("AllergenDish", b =>
                {
                    b.HasOne("project_foodie.Model.Allergen", null)
                        .WithMany()
                        .HasForeignKey("AllergensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_foodie.Model.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllergenIngredient", b =>
                {
                    b.HasOne("project_foodie.Model.Allergen", null)
                        .WithMany()
                        .HasForeignKey("AllergensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_foodie.Model.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DayMenuDish", b =>
                {
                    b.HasOne("project_foodie.Model.DayMenu", null)
                        .WithMany()
                        .HasForeignKey("dayMenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_foodie.Model.Dish", null)
                        .WithMany()
                        .HasForeignKey("dishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DishIngredient", b =>
                {
                    b.HasOne("project_foodie.Model.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_foodie.Model.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DishOrder", b =>
                {
                    b.HasOne("project_foodie.Model.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_foodie.Model.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderOrderItem", b =>
                {
                    b.HasOne("project_foodie.Model.OrderItem", null)
                        .WithMany()
                        .HasForeignKey("OrderItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_foodie.Model.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("project_foodie.Model.DayMenu", b =>
                {
                    b.HasOne("project_foodie.Model.Menu", null)
                        .WithMany("dayMenus")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("project_foodie.Model.Menu", b =>
                {
                    b.Navigation("dayMenus");
                });
#pragma warning restore 612, 618
        }
    }
}