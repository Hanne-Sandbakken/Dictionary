﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dictionary.Data;

#nullable disable

namespace dictionary.Migrations
{
    [DbContext(typeof(DictionaryDbContext))]
    [Migration("20230706092411_SeededCategoiesyAndWords")]
    partial class SeededCategoiesyAndWords
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dictionary.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Noun"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Verb"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Adjective"
                        });
                });

            modelBuilder.Entity("dictionary.Data.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("dictionary.Data.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("GermanWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NorwegianWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            GermanWord = "Haus",
                            NorwegianWord = "hus"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            GermanWord = "Flasche",
                            NorwegianWord = "flaske"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            GermanWord = "gehen",
                            NorwegianWord = "gå"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            GermanWord = "sitzen",
                            NorwegianWord = "sitte"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            GermanWord = "blau",
                            NorwegianWord = "blå"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            GermanWord = "Klein",
                            NorwegianWord = "liten"
                        });
                });

            modelBuilder.Entity("dictionary.Data.WordProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("WordId");

                    b.ToTable("WordsProjects");
                });

            modelBuilder.Entity("dictionary.Data.Word", b =>
                {
                    b.HasOne("dictionary.Data.Category", "Category")
                        .WithMany("Words")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("dictionary.Data.WordProject", b =>
                {
                    b.HasOne("dictionary.Data.Project", "Project")
                        .WithMany("WordsProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dictionary.Data.Word", "Word")
                        .WithMany("WordProjects")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("dictionary.Data.Category", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("dictionary.Data.Project", b =>
                {
                    b.Navigation("WordsProjects");
                });

            modelBuilder.Entity("dictionary.Data.Word", b =>
                {
                    b.Navigation("WordProjects");
                });
#pragma warning restore 612, 618
        }
    }
}