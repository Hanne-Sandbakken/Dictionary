﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dictionary.Data;

#nullable disable

namespace dictionary.Migrations
{
    [DbContext(typeof(DictionaryDbContext))]
    partial class DictionaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("WordClassId")
                        .HasColumnType("int");

                    b.Property<string>("de")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("WordClassId");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            WordClassId = 1,
                            de = "Haus",
                            no = "hus"
                        },
                        new
                        {
                            Id = 2,
                            WordClassId = 1,
                            de = "Flasche",
                            no = "flaske"
                        },
                        new
                        {
                            Id = 3,
                            WordClassId = 2,
                            de = "gehen",
                            no = "gå"
                        },
                        new
                        {
                            Id = 4,
                            WordClassId = 2,
                            de = "sitzen",
                            no = "sitte"
                        },
                        new
                        {
                            Id = 5,
                            WordClassId = 3,
                            de = "blau",
                            no = "blå"
                        },
                        new
                        {
                            Id = 6,
                            WordClassId = 3,
                            de = "Klein",
                            no = "liten"
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
