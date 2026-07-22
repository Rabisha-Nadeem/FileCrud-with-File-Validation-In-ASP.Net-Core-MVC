using FileCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace FileCrud.Db
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }

    }
}
