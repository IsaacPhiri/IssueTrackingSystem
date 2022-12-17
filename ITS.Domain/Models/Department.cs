global using System.ComponentModel.DataAnnotations;


namespace ITS.Domain.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Equipment> Equipments { get; set; }

    }
}
