﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProjectFinal.Entities
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]     
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        //public ICollection<Card> Cards { get; set; }
    }
}

