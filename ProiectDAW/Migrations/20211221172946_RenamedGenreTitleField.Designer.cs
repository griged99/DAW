﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectDAW.Data;

namespace ProiectDAW.Migrations
{
    [DbContext(typeof(NgReadingContext))]
    [Migration("20211221172946_RenamedGenreTitleField")]
    partial class RenamedGenreTitleField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProiectDAW.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UploaderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UploaderId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("ProiectDAW.Models.BookGenre", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenres");
                });

            modelBuilder.Entity("ProiectDAW.Models.DirectLoginUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("DirectLoginUsers");
                });

            modelBuilder.Entity("ProiectDAW.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ProiectDAW.Models.Library", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("ProiectDAW.Models.LibraryBook", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LibraryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "LibraryId");

                    b.HasIndex("LibraryId");

                    b.ToTable("LibraryBooks");
                });

            modelBuilder.Entity("ProiectDAW.Models.Review", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.HasKey("BookId", "ReviewerId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ProiectDAW.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProiectDAW.Models.UserSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("RememberPageNumber")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersSettings");
                });

            modelBuilder.Entity("ProiectDAW.Models.Book", b =>
                {
                    b.HasOne("ProiectDAW.Models.User", "Uploader")
                        .WithMany("Uploads")
                        .HasForeignKey("UploaderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Uploader");
                });

            modelBuilder.Entity("ProiectDAW.Models.BookGenre", b =>
                {
                    b.HasOne("ProiectDAW.Models.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectDAW.Models.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("ProiectDAW.Models.DirectLoginUser", b =>
                {
                    b.HasOne("ProiectDAW.Models.User", "User")
                        .WithOne("DirectLoginUser")
                        .HasForeignKey("ProiectDAW.Models.DirectLoginUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProiectDAW.Models.Library", b =>
                {
                    b.HasOne("ProiectDAW.Models.User", "Owner")
                        .WithMany("Libraries")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ProiectDAW.Models.LibraryBook", b =>
                {
                    b.HasOne("ProiectDAW.Models.Book", "Book")
                        .WithMany("LibraryBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectDAW.Models.Library", "Library")
                        .WithMany("LibraryBooks")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("ProiectDAW.Models.Review", b =>
                {
                    b.HasOne("ProiectDAW.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectDAW.Models.User", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("ProiectDAW.Models.UserSettings", b =>
                {
                    b.HasOne("ProiectDAW.Models.User", "User")
                        .WithOne("UserSettings")
                        .HasForeignKey("ProiectDAW.Models.UserSettings", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProiectDAW.Models.Book", b =>
                {
                    b.Navigation("BookGenres");

                    b.Navigation("LibraryBooks");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ProiectDAW.Models.Genre", b =>
                {
                    b.Navigation("BookGenres");
                });

            modelBuilder.Entity("ProiectDAW.Models.Library", b =>
                {
                    b.Navigation("LibraryBooks");
                });

            modelBuilder.Entity("ProiectDAW.Models.User", b =>
                {
                    b.Navigation("DirectLoginUser");

                    b.Navigation("Libraries");

                    b.Navigation("Reviews");

                    b.Navigation("Uploads");

                    b.Navigation("UserSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
