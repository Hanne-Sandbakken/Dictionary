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
    [DbContext(typeof(IWordRepositoy))]
    [Migration("20230810115440_newDatabase")]
    partial class newDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<string>("GermanWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NorwegianWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WordClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordClassId");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GermanWord = "Haus",
                            NorwegianWord = "hus",
                            WordClassId = 1
                        },
                        new
                        {
                            Id = 2,
                            GermanWord = "Flasche",
                            NorwegianWord = "flaske",
                            WordClassId = 1
                        },
                        new
                        {
                            Id = 3,
                            GermanWord = "gehen",
                            NorwegianWord = "gå",
                            WordClassId = 2
                        },
                        new
                        {
                            Id = 4,
                            GermanWord = "sitzen",
                            NorwegianWord = "sitte",
                            WordClassId = 2
                        },
                        new
                        {
                            Id = 5,
                            GermanWord = "blau",
                            NorwegianWord = "blå",
                            WordClassId = 3
                        },
                        new
                        {
                            Id = 6,
                            GermanWord = "Klein",
                            NorwegianWord = "liten",
                            WordClassId = 3
                        });
                });

            modelBuilder.Entity("dictionary.Data.WordClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WordClasses");

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

                    b.ToTable("WordProjects");
                });

            modelBuilder.Entity("dictionary.Data.Word", b =>
                {
                    b.HasOne("dictionary.Data.WordClass", "WordClass")
                        .WithMany("Words")
                        .HasForeignKey("WordClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WordClass");
                });

            modelBuilder.Entity("dictionary.Data.WordProject", b =>
                {
                    b.HasOne("dictionary.Data.Project", "Project")
                        .WithMany("WordProjects")
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

            modelBuilder.Entity("dictionary.Data.Project", b =>
                {
                    b.Navigation("WordProjects");
                });

            modelBuilder.Entity("dictionary.Data.Word", b =>
                {
                    b.Navigation("WordProjects");
                });

            modelBuilder.Entity("dictionary.Data.WordClass", b =>
                {
                    b.Navigation("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
