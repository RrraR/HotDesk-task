using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDesk_task.Data.Entities;

public class Equipment
{
    [Key]
    public int EquipmentId { get; set; }
    public string Type { get; set; }
    
    [NotMapped]
    public virtual ICollection<EquipmentForWorkplace> EquipmentForWorkplace { get; set; }
}