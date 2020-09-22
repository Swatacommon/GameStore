﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Models.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    partial class GameStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Models.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<long>("PublisherId")
                        .HasColumnType("bigint");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Models.GameCategory", b =>
                {
                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("GameId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("GameCategorys");
                });

            modelBuilder.Entity("Models.GameGenre", b =>
                {
                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("GenreId")
                        .HasColumnType("bigint");

                    b.HasKey("GameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GameGenres");
                });

            modelBuilder.Entity("Models.GameMethodActivation", b =>
                {
                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("MethodActivationId")
                        .HasColumnType("bigint");

                    b.HasKey("GameId", "MethodActivationId");

                    b.HasIndex("MethodActivationId");

                    b.ToTable("GameMethodActivations");
                });

            modelBuilder.Entity("Models.GamePlatform", b =>
                {
                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("PlatformId")
                        .HasColumnType("bigint");

                    b.HasKey("GameId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("GamePlatforms");
                });

            modelBuilder.Entity("Models.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Models.MethodActivation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("MethodActivations");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("Order_date")
                        .HasColumnType("date");

                    b.Property<int>("TotalPrice")
                        .HasColumnName("Total_price")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.OrderGame", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.HasKey("OrderId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("OrderGames");
                });

            modelBuilder.Entity("Models.Platform", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("Models.Publisher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Game", b =>
                {
                    b.HasOne("Models.Publisher", "Publisher")
                        .WithMany("Game")
                        .HasForeignKey("PublisherId")
                        .HasConstraintName("FK_Game_Publishers")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.GameCategory", b =>
                {
                    b.HasOne("Models.Category", "Category")
                        .WithMany("GameCategory")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_GameCategory_Categories")
                        .IsRequired();

                    b.HasOne("Models.Game", "Game")
                        .WithMany("GameCategory")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_GameCategory_Games")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.GameGenre", b =>
                {
                    b.HasOne("Models.Game", "Game")
                        .WithMany("GameGenre")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_GameGenre_Games")
                        .IsRequired();

                    b.HasOne("Models.Genre", "Genre")
                        .WithMany("GameGenre")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_GameGenre_Genres")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.GameMethodActivation", b =>
                {
                    b.HasOne("Models.Game", "Game")
                        .WithMany("GameMethodActivation")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_GameMethodActivation_Games")
                        .IsRequired();

                    b.HasOne("Models.MethodActivation", "MethodActivation")
                        .WithMany("GameMethodActivation")
                        .HasForeignKey("MethodActivationId")
                        .HasConstraintName("FK_GameMethodActivation_MethodActivations")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.GamePlatform", b =>
                {
                    b.HasOne("Models.Game", "Game")
                        .WithMany("GamePlatform")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_GamePlatform_Games")
                        .IsRequired();

                    b.HasOne("Models.Platform", "Platform")
                        .WithMany("GamePlatform")
                        .HasForeignKey("PlatformId")
                        .HasConstraintName("FK_GamePlatform_Platforms")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Order_Users");
                });

            modelBuilder.Entity("Models.OrderGame", b =>
                {
                    b.HasOne("Models.Game", "Game")
                        .WithMany("OrderGame")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_OrderGame_Games")
                        .IsRequired();

                    b.HasOne("Models.Order", "Order")
                        .WithMany("OrderGame")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderGame_Orders")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}