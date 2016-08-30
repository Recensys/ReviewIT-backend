using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RecensysCoreRepository;

namespace RecensysCoreRepository.Migrations
{
    [DbContext(typeof(RecensysContext))]
    [Migration("20160829144339_TestMigration")]
    partial class TestMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("RecensysCoreRepository.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("StudyId");

                    b.HasKey("Id");

                    b.HasIndex("StudyId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Criteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FieldId");

                    b.Property<int>("StudyId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("StudyId");

                    b.ToTable("Criterias");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<int>("FieldId");

                    b.Property<int>("TaskId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("FieldId");

                    b.HasIndex("TaskId");

                    b.ToTable("Data");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.DataType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("DataTypes");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DataTypeId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("StudyId");

                    b.HasKey("Id");

                    b.HasIndex("DataTypeId");

                    b.HasIndex("StudyId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("NextStageId");

                    b.Property<bool>("StageInitiated");

                    b.Property<int>("StudyId");

                    b.HasKey("Id");

                    b.HasIndex("NextStageId");

                    b.HasIndex("StudyId");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.StageFieldRelation", b =>
                {
                    b.Property<int>("FieldId");

                    b.Property<int>("FieldTypeId");

                    b.Property<int>("StageId");

                    b.Property<int>("FieldType");

                    b.HasKey("FieldId", "FieldTypeId", "StageId");

                    b.HasIndex("FieldId");

                    b.HasIndex("StageId");

                    b.ToTable("StageFields");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.StageRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("StageRoles");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Strategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("StageId");

                    b.Property<int>("StrategyTypeId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("StageId");

                    b.HasIndex("StrategyTypeId");

                    b.ToTable("Strategies");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.StrategyFieldRelation", b =>
                {
                    b.Property<int>("FieldId");

                    b.Property<int>("StrategyId");

                    b.HasKey("FieldId", "StrategyId");

                    b.HasIndex("FieldId");

                    b.HasIndex("StrategyId");

                    b.ToTable("StrategyFieldRelation");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.StrategyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("StrategyType");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Study", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Studies");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<int>("ParentId");

                    b.Property<int>("StageId");

                    b.Property<int>("TaskTypeId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("ParentId");

                    b.HasIndex("StageId");

                    b.HasIndex("TaskTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.TaskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("TaskTypes");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("First_Name");

                    b.Property<string>("Last_Name");

                    b.Property<string>("Password");

                    b.Property<string>("Password_Salt");

                    b.Property<string>("Username");

                    b.Property<string>("eMail");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.UserStageRelation", b =>
                {
                    b.Property<int>("StageId");

                    b.Property<int>("StageRoleId");

                    b.Property<int>("UserId");

                    b.HasKey("StageId", "StageRoleId", "UserId");

                    b.HasIndex("StageId");

                    b.HasIndex("StageRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserStageRelation");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.UserStudyRelation", b =>
                {
                    b.Property<int>("StudyId");

                    b.Property<int>("UserId");

                    b.Property<bool>("IsAdmin");

                    b.HasKey("StudyId", "UserId");

                    b.HasIndex("StudyId");

                    b.HasIndex("UserId");

                    b.ToTable("UserStudyRelation");
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Article", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Study", "Study")
                        .WithMany("Articles")
                        .HasForeignKey("StudyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Criteria", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Field", "Field")
                        .WithMany("Criteria")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.Study", "Study")
                        .WithMany("Criteria")
                        .HasForeignKey("StudyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Data", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Article", "Article")
                        .WithMany("Data")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.Field", "Field")
                        .WithMany("Data")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.Task", "Task")
                        .WithMany("Data")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Field", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.DataType", "DataType")
                        .WithMany("Fields")
                        .HasForeignKey("DataTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.Study", "Study")
                        .WithMany("Fields")
                        .HasForeignKey("StudyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Stage", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Stage", "NextStage")
                        .WithMany()
                        .HasForeignKey("NextStageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.Study", "Study")
                        .WithMany("Stages")
                        .HasForeignKey("StudyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.StageFieldRelation", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Field", "Field")
                        .WithMany("StageFields")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.Stage", "Stage")
                        .WithMany("StageFields")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Strategy", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.StrategyType", "StrategyType")
                        .WithMany("Strategies")
                        .HasForeignKey("StrategyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.StrategyFieldRelation", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Field", "Field")
                        .WithMany("StrategyRelations")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.Strategy", "Strategy")
                        .WithMany("FieldRelations")
                        .HasForeignKey("StrategyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.Task", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.Article", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.Stage", "Stage")
                        .WithMany("Tasks")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.TaskType", "TaskType")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.UserStageRelation", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Stage", "Stage")
                        .WithMany("UserRelations")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.StageRole", "StageRole")
                        .WithMany("UserStageRelations")
                        .HasForeignKey("StageRoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.User", "User")
                        .WithMany("StageRelations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecensysCoreRepository.Entities.UserStudyRelation", b =>
                {
                    b.HasOne("RecensysCoreRepository.Entities.Study", "Study")
                        .WithMany()
                        .HasForeignKey("StudyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecensysCoreRepository.Entities.User", "User")
                        .WithMany("StudyRelations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
