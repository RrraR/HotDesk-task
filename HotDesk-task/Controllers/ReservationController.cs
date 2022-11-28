using HotDesk_task.Models;
using HotDesk_task.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotDesk_task.Controllers;

public class ReservationController : Controller
{
    private readonly IHotDeskService _service;

    public ReservationController(IHotDeskService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult LogIn(LogInViewModel logInViewModel)
    {
        if (_service.CheckEmployee(logInViewModel.FirstName, logInViewModel.LastName))
        {
            Response.Cookies.Append("LogInFName", $"{logInViewModel.FirstName}");
            Response.Cookies.Append("LogInLName", $"{logInViewModel.LastName}");
            return View("Reservations",
                _service.GetCurrentReservationsViewModel(logInViewModel.FirstName, logInViewModel.LastName));
        }

        //return View("");
        ModelState.AddModelError(nameof(logInViewModel.LastName), "Employee name not found");
        return View("~/Views/Home/Index.cshtml");
    }

    public IActionResult GetAvailableWorkplacesList()
    {
        return View("AvailableWorkplaces", _service.GetAvailableWorkplacesViewModel());
    }

    public IActionResult CreateNewReservation(int workplaceId)
    {
        return View("NewReservationForm", _service.GetNewReservationFormViewModel(workplaceId));
    }

    public IActionResult GetDeleteReservationForm(int reservationId)
    {
        return View("DeleteReservationForm", _service.GetSingleReservationViewModelByReservationId(reservationId));
    }

    public IActionResult DeleteReservation(int reservationId)
    {
        var firstName = Request.Cookies["LogInFName"];
        var lastName = Request.Cookies["LogInLName"];

        //delete
        _service.DeleteReservation(reservationId, firstName, lastName);

        return View("Reservations", _service.GetCurrentReservationsViewModel(firstName, lastName));
    }

    public IActionResult UpdateReservationsList(int workplaceId, NewReservationFormViewModel formViewModel)
    {
        var firstName = Request.Cookies["LogInFName"];
        var lastName = Request.Cookies["LogInLName"];

        var res = DateTime.Compare(formViewModel.TimeFrom, formViewModel.TimeTo);
        // <0 − If TimeFrom is earlier than TimeTo
        //  0 − If TimeFrom is the same as TimeTo
        // >0 − If TimeFrom is later than TimeTo

        if (res < 0)
        {
            if (_service.AddNewReservation(workplaceId, formViewModel, firstName, lastName))
            {
                return View("Reservations", _service.GetCurrentReservationsViewModel(firstName, lastName));
            }
            else
            {
                ModelState.AddModelError(nameof(formViewModel.TimeTo), "Time frame overlaps with another reservation");
                return View("NewReservationForm", _service.GetNewReservationFormViewModel(workplaceId));
            }
        }
        else
        {
            ModelState.AddModelError(nameof(formViewModel.TimeTo), "Incorrect timeframe");
            return View("NewReservationForm", _service.GetNewReservationFormViewModel(workplaceId));
        }
    }
}