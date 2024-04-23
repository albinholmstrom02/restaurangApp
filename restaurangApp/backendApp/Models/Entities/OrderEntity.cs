﻿using System.ComponentModel.DataAnnotations;

namespace backendApp.Models.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int TotalPrice { get; set; }
        public string Dishes { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
