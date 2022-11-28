using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDesk_task.Data.Entities;

public class Reservation
{
    [Key]
    public int ReservationId { get; set; }
    public int IdEmployee { get; set; }
    public int IdWorkplace { get; set; }

    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
    
    [NotMapped]
    [ForeignKey("IdEmployee")]
    public virtual Employee Employee { get; set; }
    
    [NotMapped]
    [ForeignKey("IdWorkplace")]
    public virtual Workplace Workplace { get; set; }
}