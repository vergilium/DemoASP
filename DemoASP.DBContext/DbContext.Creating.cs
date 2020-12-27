using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContext
{
    public partial class MyDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
               .HasOne(f => f.Faculty)
               .WithMany(p => p.Groups)
               .HasForeignKey(pt => pt.FacultyId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(st => st.Students)
                .HasForeignKey(stu => stu.GroupId);

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId);
            /*
                      modelBuilder.Entity<TS>()
                          .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

                      modelBuilder.Entity<TS>()
                          .HasOne(ts => ts.Teacher)
                          .WithMany(t => t.TS)
                          .HasForeignKey(ts => ts.TeacherId);

                      modelBuilder.Entity<TS>()
                          .HasOne(ts => ts.Subject)
                          .WithMany(s => s.TS)
                          .HasForeignKey(ts => ts.SubjectId);
                      */

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers)
                .UsingEntity<TS>(
                    tsr => tsr.HasOne(ts => ts.Subject)
                        .WithMany(s => s.TS)
                        .HasForeignKey(ts => ts.SubjectId),

                    tsr => tsr.HasOne(ts => ts.Teacher)
                    .WithMany(t => t.TS)
                    .HasForeignKey(ts => ts.TeacherId)
                );

            //modelBuilder.Entity<Mark>()
            //    .HasOne<TS>(m => new TS { Subject = m.Subject, Teacher = m.Teacher })
            //    .WithMany(s => s.Marks)
            //    .HasForeignKey(m => new { m.TeacherId, m.SubjectId })
            //    .HasPrincipalKey(p => new { p.TeacherId, p.SubjectId });


            //modelBuilder.Entity<Mark>()
            //    .HasOne<TS>(m => m.TS)
            //    .WithMany(ts => ts.Marks)
            //    .HasForeignKey(m => new { m.Teacher, m.SubjectId });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Faculty>().HasData(
               new Faculty { Id = 1, Name = "Программирования" },
               new Faculty { Id = 2, Name = "Администрирования" },
               new Faculty { Id = 3, Name = "Графики" });

            modelBuilder.Entity<Group>().HasData(
              new Group { Id = 1, Name = "СПВ22-01", FacultyId = 1 },
              new Group { Id = 2, Name = "СПД22-21", FacultyId = 3 },
              new Group { Id = 3, Name = "СПУ20-01", FacultyId = 1 });

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Василий", MiddleName = "Иванович", LastName = "Пупкин", GroupId = 1 },
                new Student { Id = 2, FirstName = "Олег", MiddleName = "Петрович", LastName = "Иванов", GroupId = 3 },
                new Student { Id = 3, FirstName = "Ольга", MiddleName = "Ивановна", LastName = "Петрова", GroupId = 1 },
                new Student { Id = 4, FirstName = "Татьяна", MiddleName = "Владимировна", LastName = "Сидорова", GroupId = 3 },
                new Student { Id = 5, FirstName = "Светлана", MiddleName = "Петровна", LastName = "Иванова", GroupId = 2 },
                new Student { Id = 6, FirstName = "Владимир", MiddleName = "Владимирович", LastName = "Петров", GroupId = 2 },
                new Student { Id = 7, FirstName = "Николай", MiddleName = "Иванович", LastName = "Павлов", GroupId = 1 },
                new Student { Id = 8, FirstName = "Петр", MiddleName = "Дмитриевич", LastName = "Иванов", GroupId = 3 });

            modelBuilder.Entity<Department>().HasData(
               new Department { Id = 1, Name = "Кафедра разработки ПО" },
               new Department { Id = 2, Name = "Кафедра администрирования Linux" });

            modelBuilder.Entity<Teacher>().HasData(
               new Teacher { Id = 1, DepartmentId = 1, FirstName = "Иванов", LastName = "Николай", MiddleName = "Иванович" },
               new Teacher { Id = 2, DepartmentId = 2, FirstName = "Петров", LastName = "Петр", MiddleName = "Петрович" });

            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "C++" },
                new Subject { Id = 2, Name = "C#" },
                new Subject { Id = 3, Name = "Администрирование Linux" });

            modelBuilder.Entity<TS>().HasData(
                new TS { TeacherId = 1, SubjectId = 1 },
                new TS { TeacherId = 1, SubjectId = 2 },
                new TS { TeacherId = 2, SubjectId = 3 });



            //modelBuilder.Entity<Mark>().HasData(
            //    new Mark { Id = 1, Value = 12, StudentId = 1 },
            //    new Mark { Id = 2, Value = 11, StudentId = 1 },
            //    new Mark { Id = 3, Value = 10, StudentId = 1 },
            //    new Mark { Id = 4, Value = 9, StudentId = 1 },
            //    new Mark { Id = 5, Value = 2, StudentId = 1 },
            //    new Mark { Id = 6, Value = 12, StudentId = 1 });
        }
    }
}
