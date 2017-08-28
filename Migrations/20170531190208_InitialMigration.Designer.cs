﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetCoreBootstrap.Models.Database;

namespace NetCoreBootstrap.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20170531190208_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("NetCoreBootstrap.Models.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("createAt");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .HasColumnName("lastname");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnName("updateAt");

                    b.HasKey("Id");

                    b.ToTable("user");
                });
        }
    }
}
