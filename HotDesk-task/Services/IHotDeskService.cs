using HotDesk_task.Data.Entities;
using HotDesk_task.Models;

namespace HotDesk_task.Services;

public interface IHotDeskService
{
    public bool CheckEmployee(string firstName, string lastName);

    public AvailableWorkplacesViewModel GetAvailableWorkplacesViewModel();

    public CurrentReservationsViewModel GetCurrentReservationsViewModel(string firstName, string lastName);

    public SingleReservationViewModel GetSingleReservationViewModelByReservationId(int reservationId);

    public bool AddNewReservation(int workplaceId, NewReservationFormViewModel formViewModel, string firstName,
        string lastName);

    public bool DeleteReservation(int reservationId, string firstName, string lastName);

    public NewReservationFormViewModel GetNewReservationFormViewModel(int workplaceId);
}