using HotDesk_task.Data.Entities;

namespace HotDesk_task.Data.Repositories;

public interface IWorkplaceRepository
{
    public List<Workplace> GetAllWorkplaces();

    public Workplace GetWorkplaceById(int id);
}