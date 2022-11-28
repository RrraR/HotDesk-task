using HotDesk_task.Data.Entities;

namespace HotDesk_task.Data.Repositories;

public interface IEquipmentForWorkplaceRepository
{
    public Dictionary<string, int> GetEquipmentForWorkplace(int workplaceId);
}