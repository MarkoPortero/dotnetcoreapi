using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarksWebApp.Models
{
    public class ToodoContext : DbContext
    {
        public ToodoContext(DbContextOptions<ToodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
