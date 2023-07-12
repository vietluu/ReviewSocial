﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewSocial.Database;

#nullable disable

namespace ReviewSocial.Migrations
{
    [DbContext(typeof(Db_ReviewSocialContext))]
    [Migration("20230712030950_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReviewSocial.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("ReviewSocial.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("content");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createdDate");

                    b.Property<int?>("PostsId")
                        .HasColumnType("int")
                        .HasColumnName("posts_id");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("PostsId");

                    b.HasIndex("UserId");

                    b.ToTable("comment", (string)null);
                });

            modelBuilder.Entity("ReviewSocial.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createdDate");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<string>("Thumbnail")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("thumbnail");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("title");

                    b.Property<int?>("TotalReport")
                        .HasColumnType("int")
                        .HasColumnName("totalReport");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int?>("View")
                        .HasColumnType("int")
                        .HasColumnName("view");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("ReviewSocial.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("avatar");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createdDate");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("role");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("ReviewSocial.Models.Comment", b =>
                {
                    b.HasOne("ReviewSocial.Models.Post", "Posts")
                        .WithMany("Comments")
                        .HasForeignKey("PostsId")
                        .HasConstraintName("FK_Comment_posts");

                    b.HasOne("ReviewSocial.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Comment_user");

                    b.Navigation("Posts");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReviewSocial.Models.Post", b =>
                {
                    b.HasOne("ReviewSocial.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_post_category");

                    b.HasOne("ReviewSocial.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_post_user");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReviewSocial.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("ReviewSocial.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ReviewSocial.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}