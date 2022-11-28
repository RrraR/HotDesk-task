using HotDesk_task.Data.Entities;

namespace HotDesk_task.Data.Repositories;

public interface IEmployeeRepository
{

    public Employee GetEmployeeIdByName(string firstName, string lastName);

    public bool CheckIfEmployee(string firstName, string lastName);
}