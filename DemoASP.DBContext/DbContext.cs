using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace DomainContext
{
    public class MyDbContext:DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {           
        }
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
                new Student {Id=1, FirstName="Вася",     LastName="Пупкин",   GroupId=1 },
                new Student {Id=2, FirstName="Олег",     LastName="Иванов",   GroupId=3 },
                new Student {Id=3, FirstName="Ольга",    LastName="Петрова",  GroupId=1 },
                new Student {Id=4, FirstName="Таня",     LastName="Сидорова", GroupId=3 },
                new Student {Id=5, FirstName="Света",    LastName="Иванова",  GroupId=2 },
                new Student {Id=6, FirstName="Владимир", LastName="Петров",   GroupId=2 },
                new Student {Id=7, FirstName="Николай",  LastName="Павлов",   GroupId=1 },
                new Student {Id=8, FirstName="Петр",     LastName="Иванов",   GroupId=3 });
        }
    }
}
