using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities;

[Table("Components")]
public class Component
{
    [Key]
    [MaxLength(10)]
    public string Cide { get; set; }
    [MaxLength(300)]
    public string Name { get; set; }
    public string Description { get; set; }
    [ForeignKey("ComponentManufacturer")]
    public int ComponentManufacturersId { get; set; }
    [ForeignKey("ComponentType")]
    public int ComponentTypesId { get; set; }
    
    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();

    public ComponentManufacturer ComponentManufacturer { get; set; } = null;
    public ComponentType ComponentType { get; set; } = null;
}