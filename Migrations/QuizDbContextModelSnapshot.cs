﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizAppApi.Data;

#nullable disable

namespace QuizAppApi.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    partial class QuizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuizAppApi.Models.AnswerChoice", b =>
                {
                    b.Property<int>("AnswerChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerChoiceId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("AnswerChoiceId");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerChoices");
                });

            modelBuilder.Entity("QuizAppApi.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizAppApi.Models.QuizSession", b =>
                {
                    b.Property<int>("QuizSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuizSessionId"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Passed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalCorrect")
                        .HasColumnType("int");

                    b.Property<int>("TotalQuestions")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("QuizSessionId");

                    b.HasIndex("UserId");

                    b.ToTable("QuizSessions");
                });

            modelBuilder.Entity("QuizAppApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("QuizAppApi.Models.UserAnswer", b =>
                {
                    b.Property<int>("UserAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAnswerId"));

                    b.Property<DateTime>("AnsweredAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuizSessionId")
                        .HasColumnType("int");

                    b.Property<int>("SelectedChoiceId")
                        .HasColumnType("int");

                    b.HasKey("UserAnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SelectedChoiceId");

                    b.HasIndex("QuizSessionId", "QuestionId")
                        .IsUnique();

                    b.ToTable("UserAnswers");
                });

            modelBuilder.Entity("QuizAppApi.Models.AnswerChoice", b =>
                {
                    b.HasOne("QuizAppApi.Models.Question", "Question")
                        .WithMany("AnswerChoices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizAppApi.Models.QuizSession", b =>
                {
                    b.HasOne("QuizAppApi.Models.User", "User")
                        .WithMany("QuizSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizAppApi.Models.UserAnswer", b =>
                {
                    b.HasOne("QuizAppApi.Models.Question", "Question")
                        .WithMany("UserAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QuizAppApi.Models.QuizSession", "QuizSession")
                        .WithMany("UserAnswers")
                        .HasForeignKey("QuizSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizAppApi.Models.AnswerChoice", "SelectedChoice")
                        .WithMany("UserAnswers")
                        .HasForeignKey("SelectedChoiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("QuizSession");

                    b.Navigation("SelectedChoice");
                });

            modelBuilder.Entity("QuizAppApi.Models.AnswerChoice", b =>
                {
                    b.Navigation("UserAnswers");
                });

            modelBuilder.Entity("QuizAppApi.Models.Question", b =>
                {
                    b.Navigation("AnswerChoices");

                    b.Navigation("UserAnswers");
                });

            modelBuilder.Entity("QuizAppApi.Models.QuizSession", b =>
                {
                    b.Navigation("UserAnswers");
                });

            modelBuilder.Entity("QuizAppApi.Models.User", b =>
                {
                    b.Navigation("QuizSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
