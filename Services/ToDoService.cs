using api_ToDoList.Database;
using api_ToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_ToDoList.Services
{
    public class ToDoService : IToDoService
    {
        private readonly Context _Context;
        public ToDoService(Context Context)
        {
            _Context = Context;
        }

        public ToDoList Create(ToDoList list)
        {
            _Context.toDoList.Add(list);

            var salvo = _Context.SaveChanges();

            if (salvo > 0)
            {
                return list;
            }

            return null;
        }

        public bool Delete(ToDoList list)
        {
            _Context.toDoList.Remove(list);

            var salvo = _Context.SaveChanges();

            if (salvo > 0)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<ToDoList> GetAll()
        {
            var retorno = _Context.toDoList.ToList();

            return retorno;
        }

        public ToDoList GetByID(int id)
        {
            var retorno = _Context.toDoList.Where(x => x.Id == id).FirstOrDefault();

            return retorno;
        }

        public ToDoList Update(ToDoList list)
        {
            var obj = _Context.toDoList.Update(list);

            var salvo = _Context.SaveChanges();

            if (salvo > 0)
            {
                return list;
            }

            return null;
        }
    }
}
