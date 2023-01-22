using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Domain.Models
{
    public class Issue
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public int EquipmentId { get; set; }    
        public int InspectorId { get; set; }    
        public string Description { get; set; }
        public DateTime Date { get; set; }  
        public IssueStatus Status { get; set; }
        public DateTime? ClosedDate { get; set; }
        public Equipment Equipment { get; set; }
        public Inspector Inspector { get; set; }
        public Issue()
        {
            Status = IssueStatus.Open;
        }

    }
}
