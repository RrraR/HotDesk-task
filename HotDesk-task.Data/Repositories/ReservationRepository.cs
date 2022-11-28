using HotDesk_task.Data.Entities;
using HotDesk_task;

namespace HotDesk_task.Data.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly HotDesk_task_DbContext _dbContext;

    public ReservationRepository(HotDesk_task_DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Reservation GetReservationByReservationId(int reservationId)
    {
        return _dbContext.Reservations.FirstOrDefault(r => r.ReservationId == reservationId);
    }
    
    public List<Reservation> GetReservationsListByEmployeeId(int employeeId)
    {
        var temp = _dbContext.Reservations.Where(r => r.IdEmployee == employeeId).ToList();
        return temp;
    }

    public void Add(Reservation reservation)
    {
        _dbContext.Add(reservation);
        _dbContext.SaveChanges();
    }

    public void Delete(Reservation reservation)
    {
        _dbContext.Remove(reservation);
        _dbContext.SaveChanges();
    }

    public int GetLastReservation()
    {
        var temp = _dbContext.Reservations.Max(r=>r.ReservationId);
        return temp + 1;
    }

    public bool CheckReservationTime(int workplaceId, DateTime timeFrom, DateTime timeTo)
    {
        var reservationsForTable = _dbContext.Reservations.Where(r => r.IdWorkplace == workplaceId).ToList();
        foreach (var item in reservationsForTable)
        {
            if (!(item.TimeFrom <= timeTo && timeFrom <= item.TimeTo))
            {
                //a.start < b.end && b.start < a.end;
                //false if dont overlap
                //true if overlap
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}