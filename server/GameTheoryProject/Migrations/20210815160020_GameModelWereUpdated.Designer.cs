﻿// <auto-generated />
using System;
using GameTheoryProject.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameTheoryProject.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20210815160020_GameModelWereUpdated")]
    partial class GameModelWereUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameTheoryProject.Domain.Entites.Game", b =>
                {
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameTheoryProject.Domain.Entites.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameTheoryProject.Domain.Entites.UserGameResponse", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.HasKey("GameId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGameResponses");
                });

            modelBuilder.Entity("GameTheoryProject.Domain.Entites.UserGameResponse", b =>
                {
                    b.HasOne("GameTheoryProject.Domain.Entites.Game", "Game")
                        .WithMany("UserGameResponses")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameTheoryProject.Domain.Entites.User", "User")
                        .WithMany("UserGameResponses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameTheoryProject.Domain.Entites.Game", b =>
                {
                    b.Navigation("UserGameResponses");
                });

            modelBuilder.Entity("GameTheoryProject.Domain.Entites.User", b =>
                {
                    b.Navigation("UserGameResponses");
                });
#pragma warning restore 612, 618
        }
    }
}