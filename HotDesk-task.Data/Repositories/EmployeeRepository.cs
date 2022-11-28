using HotDesk_task.Data.Entities;

namespace HotDesk_task.Data.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly HotDesk_task_DbContext _dbContext;

    public EmployeeRepository(HotDesk_task_DbContext context)
    {
        _dbContext = context;
    }

    public Employee GetEmployeeIdByName(string firstName, string lastName)
    {
        //return _dbContext.Employees.FirstOrDefault(x => x.FirstName == firstName && x.FirstName == lastName);
        return _dbContext.Employees.First(x => x.FirstName == firstName && x.LastName == lastName);
    }

    public bool CheckIfEmployee(string firstName, string lastName)
    {
        return _dbContext.Employees.Any(x => x.FirstName == firstName && x.FirstName == firstName);
    }
}