using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDesk_task.Data.Entities;

public class EquipmentForWorkplace
{
    [Key]
    public int EFW_Id { get; set; }
    
    public int IdWorkplace { get; set; }
    
    public int IdEquipment { get; set; }
    
    public int Count { get; set; }
    
    [NotMapped]
    [ForeignKey("IdWorkplace")]
    public virtual Workplace Workplace { get; set; }
    
    [NotMapped]
    [ForeignKey("IdEquipment")]
    public virtual Equipment Equipments { get; set; }
}