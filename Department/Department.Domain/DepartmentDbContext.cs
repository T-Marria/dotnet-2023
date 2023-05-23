﻿using Microsoft.EntityFrameworkCore;
using static Google.Protobuf.WireFormat;

namespace Department.Domain;
public class DepartmentDbContext : DbContext
{
    /// <summary>
    /// Collection of groups
    /// </summary>
    public DbSet<Group>? Groups { get; set; }

    /// <summary>
    /// Collection of teachers
    /// </summary>
    public DbSet<Teacher>? Teachers { get; set; }

    /// <summary>
    /// Collection of subjects
    /// </summary>
    public DbSet<Subject>? Subjects { get; set; }

    /// <summary>
    /// Collection of courses
    /// </summary>
    public DbSet<Course>? Courses { get; set; }

    public DepartmentDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Insetring data into database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var group1 = new Group { Id = 6311, StudentAmount = 25, EducationType = "D" };
        var group2 = new Group { Id = 6312, StudentAmount = 16, EducationType = "D" };
        var group3 = new Group { Id = 6295, StudentAmount = 25, EducationType = "V" };

        modelBuilder.Entity<Group>().HasData(new List<Group> { group1, group2, group3 });

        var subject1 = new Subject { Name = "Математический анализ", Semester = 1 };
        var subject2 = new Subject { Name = "Промышленное программирование", Semester = 6 };
        var subject3 = new Subject { Name = "Статистический анализ данных", Semester = 5 };
        var subject4 = new Subject { Name = "Дискретная математика", Semester = 2 };
        var subject5 = new Subject { Name = "Физкультура", Semester = 3 };

        modelBuilder.Entity<Subject>().HasData(new List<Subject> { subject1, subject2, subject3, subject4, subject5 });

        var teacher1 = new Teacher { FullName = "Максимова Людмила Александровна", Degree = "Профессор" };
        var teacher2 = new Teacher { FullName = "Шашкова Татьяна Якубовна", Degree = "Доцент" };
        var teacher3 = new Teacher { FullName = "Аввакумова Тамара Николаевна", Degree = "Профессор" };

        modelBuilder.Entity<Teacher>().HasData(new List<Teacher> { teacher1, teacher2, teacher3 });

        var course1 = new Course { SubjectName = "Математический анализ", CourseType = "Лекции", SemesterHours = 256, GroupId = 6312, TeachersName = "Максимова Людмила Александровна" };
        var course2 = new Course { SubjectName = "Промышленное программирование", CourseType = "Курсовой проект", SemesterHours = 123, GroupId = 6311, TeachersName = "Шашкова Татьяна Якубовна" };
        var course3 = new Course { SubjectName = "Физкультура", CourseType = "Курсовой проект", SemesterHours = 14, GroupId = 6295, TeachersName = "Максимова Людмила Александровна" };
        var course4 = new Course { SubjectName = "Математический анализ", CourseType = "Лекции", SemesterHours = 500, GroupId = 6311, TeachersName = "Шашкова Татьяна Якубовна" };

        modelBuilder.Entity<Course>().HasData(new List<Course> { course1, course2, course3 });
    }
}
