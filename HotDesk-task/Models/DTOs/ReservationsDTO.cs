namespace HotDesk_task.Models;

public class ReservationsDTO
{
    public int ReservationId { get; set; }
    public WorkplaceDTO Workplace { get; set; }
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
}