using HotDesk_task.Data.Entities;
using HotDesk_task.Data.Repositories;
using HotDesk_task.Models;
using Microsoft.CodeAnalysis;

namespace HotDesk_task.Services;

public class HotDeskService : IHotDeskService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IEquipmentForWorkplaceRepository _equipmentForWorkplaceRepository;
    private readonly IWorkplaceRepository _workplaceRepository;

    public HotDeskService(IEmployeeRepository employee, IReservationRepository reservationRepository,
        IEquipmentRepository equipmentRepository, IEquipmentForWorkplaceRepository equipmentForWorkplaceRepository,
        IWorkplaceRepository workplaceRepository)
    {
        _employeeRepository = employee;
        _reservationRepository = reservationRepository;
        _equipmentRepository = equipmentRepository;
        _equipmentForWorkplaceRepository = equipmentForWorkplaceRepository;
        _workplaceRepository = workplaceRepository;
    }

    public AvailableWorkplacesViewModel GetAvailableWorkplacesViewModel()
    {
        var workplaces = _workplaceRepository.GetAllWorkplaces();
        var model = new AvailableWorkplacesViewModel()
        {
            Workplaces = workplaces.Select(x => new WorkplaceDTO()
            {
                WorkplaceId = x.WorkplaceId,
                Floor = x.Floor,
                Room = x.Room,
                TableNumber = x.TableNumber,
                EquipmentOnWorkplace = _equipmentForWorkplaceRepository.GetEquipmentForWorkplace(x.WorkplaceId)
            }).ToList()
        };

        return model;
    }

    public CurrentReservationsViewModel GetCurrentReservationsViewModel(string firstName, string lastName)
    {
        var employee = _employeeRepository.GetEmployeeIdByName(firstName, lastName);
        var reservationList = _reservationRepository.GetReservationsListByEmployeeId(employee.EmployeeId);
        var model = new CurrentReservationsViewModel()
        {
            Reservations = reservationList.Select(x =>
                {
                    var w = _workplaceRepository.GetWorkplaceById(x.IdWorkplace);
                    return new ReservationsDTO()
                    {
                        ReservationId = x.ReservationId,
                        Workplace = new WorkplaceDTO()
                        {
                            WorkplaceId = x.IdWorkplace,
                            Floor = w.Floor,
                            Room = w.Room,
                            TableNumber = w.TableNumber,
                            EquipmentOnWorkplace =
                                _equipmentForWorkplaceRepository.GetEquipmentForWorkplace(w.WorkplaceId)
                        },
                        TimeFrom = x.TimeFrom,
                        TimeTo = x.TimeTo
                    };
                })
                .ToList()
        };
        return model;
    }

    public SingleReservationViewModel GetSingleReservationViewModelByReservationId(int reservationId)
    {
        var temp = _reservationRepository.GetReservationByReservationId(reservationId);
        var workplace = _workplaceRepository.GetWorkplaceById(temp.IdWorkplace);
        var model = new SingleReservationViewModel()
        {
            Reservation = new ReservationsDTO()
            {
                ReservationId = temp.ReservationId,
                Workplace = new WorkplaceDTO()
                {
                    Floor = workplace.Floor,
                    Room = workplace.Room,
                    TableNumber = workplace.TableNumber,
                    WorkplaceId = workplace.WorkplaceId,
                    EquipmentOnWorkplace =
                        _equipmentForWorkplaceRepository.GetEquipmentForWorkplace(workplace.WorkplaceId)
                },
                TimeFrom = temp.TimeFrom,
                TimeTo = temp.TimeTo
            }
        };
        return model;
    }

    public bool DeleteReservation(int reservationId, string firstName, string lastName)
    {
        var reservation = _reservationRepository.GetReservationByReservationId(reservationId);
        
        _reservationRepository.Delete(reservation);
        return true;
    }

    public NewReservationFormViewModel GetNewReservationFormViewModel(int workplaceId)
    {
        var workplace = _workplaceRepository.GetWorkplaceById(workplaceId);

        var model = new NewReservationFormViewModel()
        {
            Workplace = new WorkplaceDTO()
            {
                WorkplaceId = workplace.WorkplaceId,
                Floor = workplace.Floor,
                Room = workplace.Room,
                TableNumber = workplace.TableNumber,
                EquipmentOnWorkplace = _equipmentForWorkplaceRepository.GetEquipmentForWorkplace(workplaceId)
            },
            TimeFrom = DateTime.Today,
            TimeTo = DateTime.Today
        };
        return model;
    }

    public bool AddNewReservation(int workplaceId, NewReservationFormViewModel formViewModel, string firstName,
        string lastName)
    {
        var empl = _employeeRepository.GetEmployeeIdByName(firstName, lastName);
        

        var temp = _reservationRepository.GetReservationsListByEmployeeId(
            _employeeRepository.GetEmployeeIdByName(firstName, lastName).EmployeeId);
        foreach (var item in temp)
        {
            if (!(item.TimeFrom.Date <= formViewModel.TimeTo.Date && formViewModel.TimeFrom.Date <= item.TimeTo.Date))
            {
                continue;
            }
            else
            {
                return false;
            }
        }

        //time validation
        if (!_reservationRepository.CheckReservationTime(workplaceId, formViewModel.TimeFrom, formViewModel.TimeTo))
        {
            return false;
        }

        if (empl == null) return false;

        var workplace = _workplaceRepository.GetWorkplaceById(workplaceId);
        var r = new Reservation()
        {
            IdEmployee = empl.EmployeeId,
            Employee = empl,
            Workplace = workplace,
            IdWorkplace = workplace.WorkplaceId,
            ReservationId = _reservationRepository.GetLastReservation(),
            TimeFrom = formViewModel.TimeFrom,
            TimeTo = formViewModel.TimeTo
        };

        _reservationRepository.Add(r);
        return true;
    }
    
    

    public bool CheckEmployee(string firstName, string lastName)
    {
        return _employeeRepository.CheckIfEmployee(firstName, lastName);
    }
}