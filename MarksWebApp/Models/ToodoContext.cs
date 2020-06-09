namespace MarksWebApp.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ToodoContext : DbContext
    {
        public ToodoContext(DbContextOptions<ToodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
