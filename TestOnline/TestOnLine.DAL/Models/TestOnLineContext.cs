using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestOnLine.Dal.Models
{
    public class TestOnLineContext : DbContext
    {
        public TestOnLineContext()
        { }

        public TestOnLineContext(DbContextOptions<TestOnLineContext> options) : base(options)
        { }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestQuestion> TestQuestion { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer", "dbo");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Answer__Question__4E53A1AA");
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate", "dbo");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidate__TestI__540C7B00");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question", "dbo");

                entity.Property(e => e.Statement)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("Result", "dbo");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK__Result__AnswerId__57DD0BE4");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Result__Candidat__56E8E7AB");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Test", "dbo");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestQuestion>(entity =>
            {
                entity.ToTable("TestQuestion", "dbo");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TestQuestion)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TestQuest__Quest__4B7734FF");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestQuestion)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TestQuest__TestI__4A8310C6");
            });
        }
    }
}
