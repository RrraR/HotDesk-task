using HotDesk_task.Data.Entities;

namespace HotDesk_task.Data.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly HotDesk_task_DbContext _dbContext;

    public EquipmentRepository(HotDesk_task_DbContext context)
    {
        _dbContext = context;
    }
    
    public List<string> GetAllEquipmentTypes()
    {
        return _dbContext.Equipments.Select(x => x.Type).ToList();
    }
    
}