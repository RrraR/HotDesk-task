using HotDesk_task.Data.Entities;

namespace HotDesk_task.Models;

public class NewReservationFormViewModel
{
    public WorkplaceDTO Workplace { get; set; }
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
    
    
}