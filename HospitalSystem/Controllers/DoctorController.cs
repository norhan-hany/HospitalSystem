using HospitalSystem.Data;
using HospitalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context =
            new ApplicationDbContext();

public IActionResult Index(string? searchName, string? specialty, int page = 1)
        {
            int pageSize = 3;

            var doctors = _context.Doctors
                .Include(d => d.Specialization)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                doctors = doctors.Where(d =>
                    d.Name.Contains(searchName));
            }

            if (!string.IsNullOrWhiteSpace(specialty))
            {
                doctors = doctors.Where(d =>
                    d.Specialization != null &&
                    d.Specialization.Name == specialty);
            }

            ViewBag.Specialties = _context.Doctors
                .Where(d => d.Specialization != null)
                .Select(d => d.Specialization!.Name)
                .Distinct()
                .ToList();

            int totalDoctors = doctors.Count();
            int totalPages = (int)Math.Ceiling(totalDoctors / (double)pageSize);

            page = Math.Max(1, Math.Min(page, Math.Max(totalPages, 1)));

            var result = doctors
                .OrderBy(d => d.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.SearchName = searchName;
            ViewBag.SelectedSpecialty = specialty;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(result);
        }


        // GET: Doctor/appointments/1
        [HttpGet]
        public IActionResult appointments(int id)
        {
            var doctor = _context.Doctors
                .Include(d => d.Specialization)
                .FirstOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                return NotFound();
            }

            ViewBag.DoctorName = doctor.Name;

            var appointment = new Appointment
            {
                DoctorId = doctor.Id,
                Date = DateTime.Today,
                Time = TimeSpan.FromHours(9)
            };

            return View("appointment", appointment);
        }

        // POST: Doctor/appointments
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult appointments(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                var doctor = _context.Doctors
                    .FirstOrDefault(d => d.Id == appointment.DoctorId);

                if (doctor == null)
                    return NotFound();

                ViewBag.DoctorName = doctor.Name;
                return View("appointment", appointment);
            }
            _context.Appointments.Add(appointment);

            int result = _context.SaveChanges();

            Console.WriteLine($"Saved rows: {result}");

            return RedirectToAction("Index", "Appointments");

        }
    }
}
