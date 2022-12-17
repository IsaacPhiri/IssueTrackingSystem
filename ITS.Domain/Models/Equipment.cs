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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }    
        public int DepartmentId { get; set; }   
        public Department Department { get; set; }  
        public List<Issue> Issues { get; set; }
    }
}
