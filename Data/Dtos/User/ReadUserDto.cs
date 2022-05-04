﻿using KanbanProjectFinal.Entities;
using System.ComponentModel.DataAnnotations;

namespace KanbanProjectFinal.Data.Dtos
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual object Cards { get; set; }
    }
}