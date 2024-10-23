using Microsoft.EntityFrameworkCore;
using SimpleTodo.DataAccess.Abstract;
using SimpleTodo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodo.DataAccess.Concrete
{
    public class TodoRepository : ITodoRepository
    {

        public async Task<Item> CreateItem(Item item)
        {
            using (var todoDbContext = new TodoDbContext())
            {
                todoDbContext.Items.Add(item);
                await todoDbContext.SaveChangesAsync();
                return item;
            }
        }

        public async Task DeleteItem(int id)
        {
            using (var todoDbContext = new TodoDbContext())
            {
                var deletedItem = await GetItemById(id);
                todoDbContext.Items.Remove(deletedItem);
                await todoDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Item>> GetAllItems()
        {
            using(var todoDbContext = new TodoDbContext())
            {
                return await todoDbContext.Items.ToListAsync();
            }
        }

        public async Task<Item> GetItemById(int id)
        {
            using (var todoDbContext = new TodoDbContext())
            {
                return await todoDbContext.Items.FindAsync(id);
            }
        }

        public async Task<Item> UpdateItem(Item item)
        {
            using( var todoDbContext = new TodoDbContext())
            {
                todoDbContext.Items.Update(item);
                await todoDbContext.SaveChangesAsync();
                return item;
            }
        }
    }
}
