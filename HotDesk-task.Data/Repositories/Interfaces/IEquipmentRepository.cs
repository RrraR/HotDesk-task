using HotDesk_task.Data.Entities;

namespace HotDesk_task.Data.Repositories;

public interface IEquipmentRepository
{
    public List<string> GetAllEquipmentTypes();
}