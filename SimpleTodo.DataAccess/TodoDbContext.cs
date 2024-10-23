using Microsoft.EntityFrameworkCore;
using SimpleTodo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodo.DataAccess
{
    public class TodoDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-CTKVAB6\\SQLEXPRESS; Database=TodoDb; uid=sa; pwd=1234;");
        }

        public DbSet<Item> Items { get; set; }
    }
}
