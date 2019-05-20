﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service.Models;

namespace Service.Migrations
{
    [DbContext(typeof(RoomManagementContext))]
    partial class RoomManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Service.Models.Management", b =>
                {
                    b.Property<int>("IdManagement")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<int?>("RoomIdRoom");

                    b.Property<DateTime>("Start");

                    b.Property<string>("Title");

                    b.Property<int?>("UserIdUser");

                    b.HasKey("IdManagement");

                    b.HasIndex("RoomIdRoom");

                    b.HasIndex("UserIdUser");

                    b.ToTable("Managements");
                });

            modelBuilder.Entity("Service.Models.Room", b =>
                {
                    b.Property<int>("IdRoom")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AlterDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Name");

                    b.Property<bool>("Status");

                    b.HasKey("IdRoom");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Service.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Administrator");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Service.Models.Management", b =>
                {
                    b.HasOne("Service.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomIdRoom");

                    b.HasOne("Service.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserIdUser");
                });
#pragma warning restore 612, 618
        }
    }
}
