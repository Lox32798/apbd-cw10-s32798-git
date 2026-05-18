using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities;

[Table("ComponentTypes")]
public class ComponentType
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; }
    [MaxLength(150)]
    public string FullName { get; set; }
    
    ICollection<Component> Components { get; set; } = new List<Component>();
}