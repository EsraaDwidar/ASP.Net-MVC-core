﻿// <auto-generated />
using Lab3_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab3_MVC.Migrations
{
    [DbContext(typeof(ITIContext))]
    partial class ITIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentsDeptId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "DepartmentsDeptId");

                    b.HasIndex("DepartmentsDeptId");

                    b.ToTable("CourseDepartment");
                });

            modelBuilder.Entity("Lab3_MVC.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Crs_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Lab3_MVC.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("DeptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Lab3_MVC.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Lab3_MVC.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DeptNo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Img")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("DeptNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Lab3_MVC.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CrstId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CrstId");

                    b.HasIndex("CrstId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("Lab3_MVC.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("Lab3_MVC.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab3_MVC.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lab3_MVC.Models.Student", b =>
                {
                    b.HasOne("Lab3_MVC.Models.Department", "Department")
                        .WithMany("students")
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Lab3_MVC.Models.StudentCourse", b =>
                {
                    b.HasOne("Lab3_MVC.Models.Course", "Course")
                        .WithMany("CourseStudent")
                        .HasForeignKey("CrstId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab3_MVC.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Lab3_MVC.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab3_MVC.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lab3_MVC.Models.Course", b =>
                {
                    b.Navigation("CourseStudent");
                });

            modelBuilder.Entity("Lab3_MVC.Models.Department", b =>
                {
                    b.Navigation("students");
                });

            modelBuilder.Entity("Lab3_MVC.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
