using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Submission> Submissions { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");


             

            modelBuilder.Entity<Instructor>()
               
                .HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);





            modelBuilder.Entity<Submission>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Submissions)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Assignment>()
                 .HasOne(a => a.Course)
                 .WithMany(c => c.Assignments)
                 .HasForeignKey(a => a.CourseId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m =>m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                 .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasOne(c =>c.Instructor)
                .WithMany(i =>i.Courses)
                .HasForeignKey(c =>c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Submission>()
                .HasOne( s => s.Assignment)
                .WithMany(a => a.Submissions)
                .HasForeignKey(s =>s.AssignmentId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
