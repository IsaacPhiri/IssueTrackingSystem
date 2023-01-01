using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Domain.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required,Range(1,int.MaxValue)]
        public int DepartmentId { get; set; }   
        public Department Department { get; set; }  
        public List<Issue> Issues { get; set; }
    }
}
