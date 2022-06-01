using System;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;

namespace QuizApp.Data
{
    public class QuizDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ExamSession> ExamSessions { get; set; }

        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options)
        { }
    }
}

