using Microsoft.EntityFrameworkCore;
using TodoApi.Model;

namespace TodoApi.Config;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ToDoModel> ToDo { get; set; }
}