using api_ToDoList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_ToDoList.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt) { }
    
        public DbSet<ToDoList> toDoList { get; set; }
    }
}
