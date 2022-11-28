using HotDesk_task.Data.Entities;

namespace HotDesk_task.Data.Repositories;

public class EquipmentForWorkplaceRepository : IEquipmentForWorkplaceRepository
{
    private readonly HotDesk_task_DbContext _dbContext;

    public EquipmentForWorkplaceRepository(HotDesk_task_DbContext context)
    {
        _dbContext = context;
    }

    public Dictionary<string, int> GetEquipmentForWorkplace(int workplaceId)
    {
        var tempDictionary = new Dictionary<string, int>();
        var tempList = _dbContext.EquipmentForWorkplaces
            .Where(x => x.IdWorkplace == workplaceId)
            .ToList();
        
        foreach (var item in tempList)
        {
            tempDictionary.Add(GetEquipmetTypeFromId(item.IdEquipment), GetEquipmetCountFromId(item.IdEquipment));
        }

        if (tempDictionary.Count == 0)
        {
            tempDictionary.Add("No equipment on the workplace ", 0);
        }
        
        return tempDictionary;
    }

    public string GetEquipmetTypeFromId(int equipmentId)
    {
        return _dbContext.Equipments.FirstOrDefault(e => e.EquipmentId == equipmentId).Type;
    }

    public int GetEquipmetCountFromId(int equipmentId)
    {
        return _dbContext.EquipmentForWorkplaces.FirstOrDefault(x => x.IdEquipment == equipmentId).Count;
    }
}