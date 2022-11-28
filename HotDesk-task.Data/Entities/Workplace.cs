using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDesk_task.Data.Entities;

public class Workplace
{
    [Key]
    public int WorkplaceId { get; set; }
    public int Floor { get; set; }
    public int Room { get; set; }
    public int TableNumber { get; set; }
    
    [NotMapped]
    public virtual ICollection<Reservation> Reservations { get; set; }
    //public Reservation Reservation { get; set; }
    
    [NotMapped]
    public virtual ICollection<EquipmentForWorkplace> EquipmentForWorkplace { get; set; }
}