using api_ToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_ToDoList.Services
{
    public interface IToDoService
    {
        public IEnumerable<ToDoList> GetAll();
        public ToDoList GetByID( int id);
        public ToDoList Update(ToDoList list);
        public ToDoList Create(ToDoList list);
        public bool Delete(ToDoList list);
    }
}
