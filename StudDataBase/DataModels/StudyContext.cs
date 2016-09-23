namespace StudDataBase.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudyContext : DbContext
    {

        public StudyContext()
            : base("name=StudyContext")
        {}

        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }

}