using SimpleTodo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodo.Business.Abstract
{
    public interface ITodoService
    {
        Task<List<Item>> GetAllItems();
        Task<Item> GetItemById(int id);
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task DeleteItem(int id);
    }
}
