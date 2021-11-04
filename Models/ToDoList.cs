using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_ToDoList.Models
{
    [Table("TB_ToDoList")]
    public class ToDoList
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
    }
}
