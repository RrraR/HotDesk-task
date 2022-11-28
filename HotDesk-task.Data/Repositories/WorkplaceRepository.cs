using HotDesk_task.Data.Entities;

namespace HotDesk_task.Data.Repositories;

public class WorkplaceRepository : IWorkplaceRepository
{
    private readonly HotDesk_task_DbContext _dbContext;

    public WorkplaceRepository(HotDesk_task_DbContext context)
    {
        _dbContext = context;
    }

    public List<Workplace> GetAllWorkplaces()
    {
        return _dbContext.Workplaces.ToList();
    }

    public Workplace GetWorkplaceById(int id)
    {
        return _dbContext.Workplaces.FirstOrDefault(w => w.WorkplaceId == id);
    }
}