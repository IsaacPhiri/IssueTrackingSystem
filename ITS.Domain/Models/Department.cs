﻿global using System.ComponentModel.DataAnnotations;


namespace ITS.Domain.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        

    }
}
