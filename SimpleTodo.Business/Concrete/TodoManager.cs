using SimpleTodo.Business.Abstract;
using SimpleTodo.DataAccess.Abstract;
using SimpleTodo.DataAccess.Concrete;
using SimpleTodo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodo.Business.Concrete
{
    public class TodoManager : ITodoService
    {
        private ITodoRepository _todoRepository;
        public TodoManager(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<Item> CreateItem(Item item)
        {
            return await _todoRepository.CreateItem(item);
        }

        public async Task DeleteItem(int id)
        {
             await GetItemById(id);
             await _todoRepository.DeleteItem(id);
            
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _todoRepository.GetAllItems();
        }

        public async Task<Item> GetItemById(int id)
        {
            if(id > 0)
            {
                return await _todoRepository.GetItemById(id);
            }
            throw new Exception("id can not be less than 1");
            
        }

        public async Task<Item> UpdateItem(Item item)
        {
            return await _todoRepository.UpdateItem(item);
        }
    }
}
