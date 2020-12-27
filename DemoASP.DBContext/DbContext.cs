using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace DomainContext
{
    public partial class MyDbContext : IdentityDbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TS> TS { get; set; }
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        
    }
}
