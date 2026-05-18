using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities;

[Table("PCComponents")]
[PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponent
{
    [ForeignKey(nameof(PC))]
    public int PCId { get; set; }
 
    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    [ForeignKey(nameof(Component))]
    public string ComponentCode { get; set; } = null!;
 
    public int Amount { get; set; }
    
    public PC PC { get; set; } = null!;
    public Component Component { get; set; } = null!;
}

