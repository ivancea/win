﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WhatIsNext.Model.Contexts;

namespace WhatIsNext.Migrations
{
    [DbContext(typeof(WinContext))]
    [Migration("20190223225342_FixedManyToManyConceptDependencies")]
    partial class FixedManyToManyConceptDependencies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WhatIsNext.Model.Entities.Concept", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("GraphId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GraphId");

                    b.ToTable("Concepts");
                });

            modelBuilder.Entity("WhatIsNext.Model.Entities.ConceptDependency", b =>
                {
                    b.Property<int>("ConceptId");

                    b.Property<int>("DependencyId");

                    b.HasKey("ConceptId", "DependencyId");

                    b.HasIndex("DependencyId");

                    b.ToTable("ConceptDependency");
                });

            modelBuilder.Entity("WhatIsNext.Model.Entities.Graph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Graphs");
                });

            modelBuilder.Entity("WhatIsNext.Model.Entities.Concept", b =>
                {
                    b.HasOne("WhatIsNext.Model.Entities.Graph", "Graph")
                        .WithMany("Concepts")
                        .HasForeignKey("GraphId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhatIsNext.Model.Entities.ConceptDependency", b =>
                {
                    b.HasOne("WhatIsNext.Model.Entities.Concept", "Concept")
                        .WithMany("Dependencies")
                        .HasForeignKey("ConceptId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WhatIsNext.Model.Entities.Concept", "Dependency")
                        .WithMany("DependantConcepts")
                        .HasForeignKey("DependencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}