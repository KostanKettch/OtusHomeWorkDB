﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OtusHomeWorkDB.Domain;

#nullable disable

namespace OtusHomeWorkDB.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230831174215_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Domain.Entity.Category", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            id = new Guid("8b28655c-c935-49c4-86c5-75600284bd40"),
                            name = "Видеоигры и приставки"
                        },
                        new
                        {
                            id = new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527"),
                            name = "Игрушки и хобби"
                        });
                });

            modelBuilder.Entity("WebApplication1.Domain.Entity.Good", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<float>("stock")
                        .HasColumnType("real");

                    b.Property<Guid>("subcategory_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.HasIndex("subcategory_id");

                    b.HasIndex("user_id");

                    b.ToTable("goods");

                    b.HasData(
                        new
                        {
                            id = new Guid("04caacf4-491b-4393-977b-fd4da948abaf"),
                            name = "Nintendo Game Boy Advance",
                            price = 200f,
                            stock = 10f,
                            subcategory_id = new Guid("77a743c2-4ae6-4d95-91d6-bcc2ee821e99"),
                            user_id = new Guid("dc023717-32e7-49f3-b3df-f6136bb1b3ba")
                        },
                        new
                        {
                            id = new Guid("cc8ee15f-f3bc-4249-889e-71eb6fb1792f"),
                            name = "DND Dice",
                            price = 20f,
                            stock = 1f,
                            subcategory_id = new Guid("8c7910a7-b4ad-42b1-bf00-73ba89324f4c"),
                            user_id = new Guid("dc023717-32e7-49f3-b3df-f6136bb1b3ba")
                        },
                        new
                        {
                            id = new Guid("dd42f1cd-ac51-4805-b132-5ad3bd12f032"),
                            name = "Rubiks cube",
                            price = 5f,
                            stock = 15f,
                            subcategory_id = new Guid("6718cb33-600f-40c3-b100-35e6fcb5b1fd"),
                            user_id = new Guid("dc023717-32e7-49f3-b3df-f6136bb1b3ba")
                        },
                        new
                        {
                            id = new Guid("cbf3556c-f9c6-47a7-931e-70ec5e45e6c2"),
                            name = "Knight-Arcanum - Stormcast Eternals Questor Relictor - Warhammer Age Of Sigmar",
                            price = 3f,
                            stock = 33f,
                            subcategory_id = new Guid("d102abf7-f9cf-4f87-a401-783ab5e4f1a0"),
                            user_id = new Guid("cc9efa9c-0182-42bb-a465-44be5311e0b9")
                        },
                        new
                        {
                            id = new Guid("31e8f304-c0d2-40ad-b3c2-32640abf781c"),
                            name = "ELEKTRONIKA 24-01 Game Nu Pogodi Eggs Soviet Nintendo USSR WORKING",
                            price = 110f,
                            stock = 1f,
                            subcategory_id = new Guid("74b3fce3-0bbb-43e8-b722-0df53773303c"),
                            user_id = new Guid("d0a82306-a01e-4049-93cb-7ccf225d0e96")
                        },
                        new
                        {
                            id = new Guid("a062143a-ff05-493c-8802-9e91511b06d5"),
                            name = "Lego Western Set 6764 Sherrif Lock",
                            price = 299f,
                            stock = 7f,
                            subcategory_id = new Guid("169fc074-72a8-482a-9e59-23259affe804"),
                            user_id = new Guid("cc9efa9c-0182-42bb-a465-44be5311e0b9")
                        });
                });

            modelBuilder.Entity("WebApplication1.Domain.Entity.Subcategory", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("parent_category_id")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.HasIndex("parent_category_id");

                    b.ToTable("subcategories");

                    b.HasData(
                        new
                        {
                            id = new Guid("77a743c2-4ae6-4d95-91d6-bcc2ee821e99"),
                            name = "Игровые приставки",
                            parent_category_id = new Guid("8b28655c-c935-49c4-86c5-75600284bd40")
                        },
                        new
                        {
                            id = new Guid("31dfad83-c6e0-48f6-bc08-8124b688c6fe"),
                            name = "Товары для видеоигр",
                            parent_category_id = new Guid("8b28655c-c935-49c4-86c5-75600284bd40")
                        },
                        new
                        {
                            id = new Guid("5f2ea570-81e9-49a1-8d83-e1a605e7b10c"),
                            name = "Видеоигры",
                            parent_category_id = new Guid("8b28655c-c935-49c4-86c5-75600284bd40")
                        },
                        new
                        {
                            id = new Guid("56dc00e6-f8de-44fa-870c-7a3bb2b1c785"),
                            name = "Игры",
                            parent_category_id = new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527")
                        },
                        new
                        {
                            id = new Guid("e4254a4f-c474-4f5c-9a0f-9c57866aef8e"),
                            name = "Строительные игрушки",
                            parent_category_id = new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527")
                        },
                        new
                        {
                            id = new Guid("d102abf7-f9cf-4f87-a401-783ab5e4f1a0"),
                            name = "Миниатюры и военные игры",
                            parent_category_id = new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527")
                        },
                        new
                        {
                            id = new Guid("6718cb33-600f-40c3-b100-35e6fcb5b1fd"),
                            name = "Настольные и традиционные игры",
                            parent_category_id = new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527")
                        },
                        new
                        {
                            id = new Guid("8c7910a7-b4ad-42b1-bf00-73ba89324f4c"),
                            name = "Ролевые игры",
                            parent_category_id = new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527")
                        },
                        new
                        {
                            id = new Guid("74b3fce3-0bbb-43e8-b722-0df53773303c"),
                            name = "Электронные игры",
                            parent_category_id = new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527")
                        },
                        new
                        {
                            id = new Guid("169fc074-72a8-482a-9e59-23259affe804"),
                            name = "Игрушки-конструкторы LEGO (R)",
                            parent_category_id = new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527")
                        });
                });

            modelBuilder.Entity("WebApplication1.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("is_approved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("is_banned")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            id = new Guid("b828ad5b-e854-4c17-b6cd-0c5896bedf84"),
                            email = "romeNoMe@email.com",
                            is_approved = false,
                            is_banned = false,
                            login = "romeNoMe"
                        },
                        new
                        {
                            id = new Guid("dc023717-32e7-49f3-b3df-f6136bb1b3ba"),
                            email = "tHErSagN@email.com",
                            is_approved = false,
                            is_banned = false,
                            login = "tHErSagN"
                        },
                        new
                        {
                            id = new Guid("ccc4d935-6da2-404c-a471-b847e44bb325"),
                            email = "bletrove@email.com",
                            is_approved = false,
                            is_banned = false,
                            login = "bletrove"
                        },
                        new
                        {
                            id = new Guid("cc9efa9c-0182-42bb-a465-44be5311e0b9"),
                            email = "cichatra@email.com",
                            is_approved = false,
                            is_banned = false,
                            login = "cichatra"
                        },
                        new
                        {
                            id = new Guid("d0a82306-a01e-4049-93cb-7ccf225d0e96"),
                            email = "sleynxic@email.com",
                            is_approved = false,
                            is_banned = false,
                            login = "sleynxic"
                        });
                });

            modelBuilder.Entity("WebApplication1.Domain.Entity.Good", b =>
                {
                    b.HasOne("WebApplication1.Domain.Entity.Subcategory", "subcategory")
                        .WithMany("Goods")
                        .HasForeignKey("subcategory_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Domain.Entity.User", "user")
                        .WithMany("Goods")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subcategory");

                    b.Navigation("user");
                });

            modelBuilder.Entity("WebApplication1.Domain.Entity.Subcategory", b =>
                {
                    b.HasOne("WebApplication1.Domain.Entity.Category", "parent_category")
                        .WithMany("Subcategories")
                        .HasForeignKey("parent_category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("parent_category");
                });

            modelBuilder.Entity("WebApplication1.Domain.Entity.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("WebApplication1.Domain.Entity.Subcategory", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("WebApplication1.Domain.Entity.User", b =>
                {
                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}
