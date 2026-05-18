using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; }
    [MaxLength(300)]
    public string FullName { get; set; }
    
    public DateTime FoundationDate { get; set; }
    public ICollection<Component> Components { get; set; } = new List<Component>();
}