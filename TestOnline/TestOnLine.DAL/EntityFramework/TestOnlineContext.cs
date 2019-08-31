using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestOnline.DAL
{
    public partial class TestOnlineContext : DbContext
    {
        public TestOnlineContext()
        {
        }

        public TestOnlineContext(DbContextOptions<TestOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestQuestion> TestQuestion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-000Q89N\\SQLEXPRESS;initial catalog=TestOnline;integrated security=True;MultipleActiveResultSets=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Answer__Question__2F10007B");
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
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
                    .HasConstraintName("FK__Candidate__TestI__276EDEB3");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Statement)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Result__AnswerId__3E52440B");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Result__Candidat__3D5E1FD2");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestQuestion>(entity =>
            {
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TestQuestion)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__TestQuest__Quest__31EC6D26");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestQuestion)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__TestQuest__TestI__32E0915F");
            });
        }
    }
}
