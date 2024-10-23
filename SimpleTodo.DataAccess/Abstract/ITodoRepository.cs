using SimpleTodo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodo.DataAccess.Abstract
{
    public interface ITodoRepository
    {
        Task<List<Item>> GetAllItems();
        Task<Item> GetItemById(int id);
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task DeleteItem(int id);

    }
}
