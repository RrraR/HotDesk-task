namespace HotDesk_task.Models;

public class WorkplaceDTO
{
    public int WorkplaceId { get; set; }
    public int Floor { get; set; }
    public int Room { get; set; }
    public int TableNumber { get; set; }
    public Dictionary<string, int> EquipmentOnWorkplace { get; set; }
}