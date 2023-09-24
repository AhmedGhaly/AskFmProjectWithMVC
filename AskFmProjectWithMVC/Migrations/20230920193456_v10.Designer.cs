﻿// <auto-generated />
using System;
using AskFmProjectWithMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    [DbContext(typeof(AskContext))]
    [Migration("20230920193456_v10")]
    partial class v10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Answer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("answer_text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("likeCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("post_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("question_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("question_id");

                    b.HasIndex("user_id");

                    b.ToTable("answers");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Follow", b =>
                {
                    b.Property<int>("follower_user_id")
                        .HasColumnType("int");

                    b.Property<int>("following_user_id")
                        .HasColumnType("int");

                    b.HasKey("follower_user_id", "following_user_id");

                    b.HasIndex("following_user_id");

                    b.ToTable("follows");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Like", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("answer_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("answer_id");

                    b.HasIndex("user_id");

                    b.ToTable("likes");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Question", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("post_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("question_text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("unkown")
                        .HasColumnType("bit");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<string>("bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("username_id")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Answer", b =>
                {
                    b.HasOne("AskFmProjectWithMVC.Models.Question", "question")
                        .WithMany("answers")
                        .HasForeignKey("question_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AskFmProjectWithMVC.Models.User", "user")
                        .WithMany("answers")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("question");

                    b.Navigation("user");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Follow", b =>
                {
                    b.HasOne("AskFmProjectWithMVC.Models.User", "follower_user")
                        .WithMany("follower")
                        .HasForeignKey("follower_user_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AskFmProjectWithMVC.Models.User", "following_user")
                        .WithMany("following")
                        .HasForeignKey("following_user_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("follower_user");

                    b.Navigation("following_user");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Like", b =>
                {
                    b.HasOne("AskFmProjectWithMVC.Models.Answer", "answer")
                        .WithMany("likes")
                        .HasForeignKey("answer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AskFmProjectWithMVC.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("answer");

                    b.Navigation("user");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Question", b =>
                {
                    b.HasOne("AskFmProjectWithMVC.Models.User", "user")
                        .WithMany("questions")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Answer", b =>
                {
                    b.Navigation("likes");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.Question", b =>
                {
                    b.Navigation("answers");
                });

            modelBuilder.Entity("AskFmProjectWithMVC.Models.User", b =>
                {
                    b.Navigation("answers");

                    b.Navigation("follower");

                    b.Navigation("following");

                    b.Navigation("questions");
                });
#pragma warning restore 612, 618
        }
    }
}
