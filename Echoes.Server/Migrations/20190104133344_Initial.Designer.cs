﻿// <auto-generated />
using System;
using EchoesServer.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Echoes.Server.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20190104133344_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Assignments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Assignment");

                    b.HasData(
                        new { Id = 1, ClassId = 2, Description = "This is an assignment.", Title = "Assignment1" },
                        new { Id = 2, ClassId = 2, Description = "This is an assignment.", Title = "Assignment2" },
                        new { Id = 3, ClassId = 2, Description = "This is an assignment.", Title = "Assignment3" },
                        new { Id = 4, ClassId = 2, Description = "This is an assignment.", Title = "Assignment4" },
                        new { Id = 5, ClassId = 1, Description = "This is an assignment.", Title = "Assignment5" },
                        new { Id = 6, ClassId = 3, Description = "This is an assignment.", Title = "Assignment6" },
                        new { Id = 7, ClassId = 2, Description = "This is an assignment.", Title = "Assignment7" },
                        new { Id = 8, ClassId = 3, Description = "This is an assignment.", Title = "Assignment8" },
                        new { Id = 9, ClassId = 2, Description = "This is an assignment.", Title = "Assignment9" },
                        new { Id = 10, ClassId = 2, Description = "This is an assignment.", Title = "Assignment10" },
                        new { Id = 11, ClassId = 2, Description = "This is an assignment.", Title = "Assignment11" },
                        new { Id = 12, ClassId = 1, Description = "This is an assignment.", Title = "Assignment12" },
                        new { Id = 13, ClassId = 3, Description = "This is an assignment.", Title = "Assignment13" },
                        new { Id = 14, ClassId = 3, Description = "This is an assignment.", Title = "Assignment14" },
                        new { Id = 15, ClassId = 2, Description = "This is an assignment.", Title = "Assignment15" },
                        new { Id = 16, ClassId = 1, Description = "This is an assignment.", Title = "Assignment16" },
                        new { Id = 17, ClassId = 1, Description = "This is an assignment.", Title = "Assignment17" },
                        new { Id = 18, ClassId = 3, Description = "This is an assignment.", Title = "Assignment18" },
                        new { Id = 19, ClassId = 2, Description = "This is an assignment.", Title = "Assignment19" },
                        new { Id = 20, ClassId = 3, Description = "This is an assignment.", Title = "Assignment20" },
                        new { Id = 21, ClassId = 2, Description = "This is an assignment.", Title = "Assignment21" },
                        new { Id = 22, ClassId = 2, Description = "This is an assignment.", Title = "Assignment22" },
                        new { Id = 23, ClassId = 1, Description = "This is an assignment.", Title = "Assignment23" },
                        new { Id = 24, ClassId = 2, Description = "This is an assignment.", Title = "Assignment24" },
                        new { Id = 25, ClassId = 3, Description = "This is an assignment.", Title = "Assignment25" },
                        new { Id = 26, ClassId = 2, Description = "This is an assignment.", Title = "Assignment26" },
                        new { Id = 27, ClassId = 2, Description = "This is an assignment.", Title = "Assignment27" },
                        new { Id = 28, ClassId = 2, Description = "This is an assignment.", Title = "Assignment28" },
                        new { Id = 29, ClassId = 3, Description = "This is an assignment.", Title = "Assignment29" },
                        new { Id = 30, ClassId = 1, Description = "This is an assignment.", Title = "Assignment30" }
                    );
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new { Id = 1, Name = "Class1" },
                        new { Id = 2, Name = "Class2" },
                        new { Id = 3, Name = "Class3" }
                    );
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Students");

                    b.HasData(
                        new { Id = 1, FirstName = "Student1", LastName = "LastName1" },
                        new { Id = 2, FirstName = "Student2", LastName = "LastName2" },
                        new { Id = 3, FirstName = "Student3", LastName = "LastName3" },
                        new { Id = 4, FirstName = "Student4", LastName = "LastName4" },
                        new { Id = 5, FirstName = "Student5", LastName = "LastName5" },
                        new { Id = 6, FirstName = "Student6", LastName = "LastName6" },
                        new { Id = 7, FirstName = "Student7", LastName = "LastName7" },
                        new { Id = 8, FirstName = "Student8", LastName = "LastName8" },
                        new { Id = 9, FirstName = "Student9", LastName = "LastName9" },
                        new { Id = 10, FirstName = "Student10", LastName = "LastName10" },
                        new { Id = 11, FirstName = "Student11", LastName = "LastName11" },
                        new { Id = 12, FirstName = "Student12", LastName = "LastName12" },
                        new { Id = 13, FirstName = "Student13", LastName = "LastName13" },
                        new { Id = 14, FirstName = "Student14", LastName = "LastName14" },
                        new { Id = 15, FirstName = "Student15", LastName = "LastName15" },
                        new { Id = 16, FirstName = "Student16", LastName = "LastName16" },
                        new { Id = 17, FirstName = "Student17", LastName = "LastName17" },
                        new { Id = 18, FirstName = "Student18", LastName = "LastName18" },
                        new { Id = 19, FirstName = "Student19", LastName = "LastName19" },
                        new { Id = 20, FirstName = "Student20", LastName = "LastName20" },
                        new { Id = 21, FirstName = "Student21", LastName = "LastName21" },
                        new { Id = 22, FirstName = "Student22", LastName = "LastName22" },
                        new { Id = 23, FirstName = "Student23", LastName = "LastName23" },
                        new { Id = 24, FirstName = "Student24", LastName = "LastName24" },
                        new { Id = 25, FirstName = "Student25", LastName = "LastName25" },
                        new { Id = 26, FirstName = "Student26", LastName = "LastName26" },
                        new { Id = 27, FirstName = "Student27", LastName = "LastName27" },
                        new { Id = 28, FirstName = "Student28", LastName = "LastName28" },
                        new { Id = 29, FirstName = "Student29", LastName = "LastName29" },
                        new { Id = 30, FirstName = "Student30", LastName = "LastName30" },
                        new { Id = 31, FirstName = "Student31", LastName = "LastName31" },
                        new { Id = 32, FirstName = "Student32", LastName = "LastName32" },
                        new { Id = 33, FirstName = "Student33", LastName = "LastName33" },
                        new { Id = 34, FirstName = "Student34", LastName = "LastName34" },
                        new { Id = 35, FirstName = "Student35", LastName = "LastName35" },
                        new { Id = 36, FirstName = "Student36", LastName = "LastName36" },
                        new { Id = 37, FirstName = "Student37", LastName = "LastName37" },
                        new { Id = 38, FirstName = "Student38", LastName = "LastName38" },
                        new { Id = 39, FirstName = "Student39", LastName = "LastName39" },
                        new { Id = 40, FirstName = "Student40", LastName = "LastName40" },
                        new { Id = 41, FirstName = "Student41", LastName = "LastName41" },
                        new { Id = 42, FirstName = "Student42", LastName = "LastName42" },
                        new { Id = 43, FirstName = "Student43", LastName = "LastName43" },
                        new { Id = 44, FirstName = "Student44", LastName = "LastName44" },
                        new { Id = 45, FirstName = "Student45", LastName = "LastName45" },
                        new { Id = 46, FirstName = "Student46", LastName = "LastName46" },
                        new { Id = 47, FirstName = "Student47", LastName = "LastName47" },
                        new { Id = 48, FirstName = "Student48", LastName = "LastName48" },
                        new { Id = 49, FirstName = "Student49", LastName = "LastName49" },
                        new { Id = 50, FirstName = "Student50", LastName = "LastName50" }
                    );
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.StudentAssignment", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("AssignmentId");

                    b.HasKey("StudentId", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("StudentAssignment");
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.StudentClass", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("ClassId");

                    b.HasKey("StudentId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("StudentClasses");

                    b.HasData(
                        new { StudentId = 1, ClassId = 1 },
                        new { StudentId = 1, ClassId = 2 },
                        new { StudentId = 2, ClassId = 1 },
                        new { StudentId = 2, ClassId = 3 }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.Exam", b =>
                {
                    b.HasBaseType("EchoesServer.Api.Data.Entities.Assignment");


                    b.ToTable("Exam");

                    b.HasDiscriminator().HasValue("Exam");
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.Homework", b =>
                {
                    b.HasBaseType("EchoesServer.Api.Data.Entities.Assignment");


                    b.ToTable("Homework");

                    b.HasDiscriminator().HasValue("Homework");
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.Assignment", b =>
                {
                    b.HasOne("EchoesServer.Api.Data.Entities.Class", "Class")
                        .WithMany("Assignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.Student", b =>
                {
                    b.HasOne("EchoesServer.Api.Data.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.StudentAssignment", b =>
                {
                    b.HasOne("EchoesServer.Api.Data.Entities.Assignment", "Assignment")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EchoesServer.Api.Data.Entities.Student", "Student")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EchoesServer.Api.Data.Entities.StudentClass", b =>
                {
                    b.HasOne("EchoesServer.Api.Data.Entities.Class", "Class")
                        .WithMany("StudentClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EchoesServer.Api.Data.Entities.Student", "Student")
                        .WithMany("StudentClasses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EchoesServer.Api.Data.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EchoesServer.Api.Data.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EchoesServer.Api.Data.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EchoesServer.Api.Data.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
