
using HospitalSystem.Data;
using HospitalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context =
            new ApplicationDbContext();

        // GET: Appointments/Index
        public IActionResult Index()
        {
            var appointments = _context.Appointments
                .Include(a => a.Doctor)
                .ToList();

            return View(appointments);
        }
        // POST: Appointments/Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(appointment);
        }

    }
}