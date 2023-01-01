using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Domain.Models
{
    public class Inspector
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
       
        [Required,RegularExpression(@"^\d{6}\/\d{2}\/\d{1}$")]
       
        public string NRC { get; set; } = string.Empty; 
    }
}
