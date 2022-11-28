using HotDesk_task.Data.Entities;
using HotDesk_task;

namespace HotDesk_task.Data.Repositories;

public interface IReservationRepository
{
    public List<Reservation> GetReservationsListByEmployeeId(int employeeId);

    public void Add(Reservation reservation);

    public int GetLastReservation();

    public Reservation GetReservationByReservationId(int reservationId);

    public void Delete(Reservation reservation);

    public bool CheckReservationTime(int workplaceId, DateTime timeFrom, DateTime timeTo);
}