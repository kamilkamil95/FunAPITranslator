// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecruitmentTaskForJuniorASF.Data;

namespace RecruitmentTaskForJuniorASF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211101204712_deleteTranslationtResponsemodel")]
    partial class deleteTranslationtResponsemodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("RecruitmentTaskForJuniorASF.Models.LanguageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("RecruitmentTaskForJuniorASF.Models.TranslationRequestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("LanguageModelId")
                        .HasColumnType("integer");

                    b.Property<string>("TextToTranslate")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LanguageModelId");

                    b.ToTable("TranslationRequests");
                });

            modelBuilder.Entity("RecruitmentTaskForJuniorASF.Models.TranslationRequestModel", b =>
                {
                    b.HasOne("RecruitmentTaskForJuniorASF.Models.LanguageModel", "LanguageModel")
                        .WithMany()
                        .HasForeignKey("LanguageModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LanguageModel");
                });
#pragma warning restore 612, 618
        }
    }
}
