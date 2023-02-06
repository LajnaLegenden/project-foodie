using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace project_foodie.Model;

public class UserContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=/data/foodie/sqlite.db;");
    }
}
public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }

}