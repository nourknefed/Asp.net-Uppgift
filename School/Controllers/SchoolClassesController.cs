using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;
using School.Models.ViewModels;
using School.Services;

namespace School.Controllers
{
    [Authorize(Roles ="Admin")]

    public class SchoolClassesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityService _identityService;

        public ApplicationUser Teacher { get; set; }


        public SchoolClassesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IIdentityService identityService)
        {
            _context = context;
            _userManager = userManager;
            _identityService = identityService;
        }

        // GET: SchoolClasses
        public async Task<IActionResult> Index()
        {
            var classes = await _context.SchoolClasses.ToListAsync();
            var students = _context.StudentSchools.ToList();

            foreach (var schoolClass in classes)
            {
                
               schoolClass.Teacher = await _userManager.Users.FirstOrDefaultAsync(ap => ap.Id == schoolClass.TeacherId);
             
                //schoolClass.Students = (ICollection<ApplicationUser>)await _context.StudentSchools.FirstOrDefaultAsync(s => s.SchoolClassId == schoolClass.Id);

                foreach (var student in students)
                {
         
                   
                    ViewBag.Students = (await _userManager.GetUsersInRoleAsync("Student"), student.Student.DisplayName, student.SchoolClassId = schoolClass.Id);
                   

                }



            }

          



            return View(classes);
        }

      

        // GET: SchoolClasses/Details/5

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.SchoolClasses
                .FirstOrDefaultAsync(m => m.Id == id);

            var students = _context.StudentSchools.ToList();

            schoolClass.Teacher = await _userManager.Users.FirstOrDefaultAsync(ap => ap.Id == schoolClass.TeacherId);


            foreach (var student in students)
            {


                ViewBag.Students = (await _userManager.GetUsersInRoleAsync("Student"), student.Student.DisplayName, student.SchoolClassId = schoolClass.Id);


            }





            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        // GET: SchoolClasses/Create
        public async Task <IActionResult> Create()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");

            ViewData["TeacherId"] = new SelectList(await _userManager.GetUsersInRoleAsync("Teacher"), "Id", "DisplayName");
            //ViewData["Teachers"] = new SelectList(_context.Users, "Id", "DisplayName", schoolClass.Teacher);

            ViewBag.Teachers = teachers;
         
            return View();
        }

        // POST: SchoolClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year, TeacherId")] SchoolClass schoolClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TeacherId"] = new SelectList(_context.Users, "Id", "TeacherId", schoolClass.TeacherId);

            return View(schoolClass);
        }

        // GET: SchoolClasses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.SchoolClasses.FindAsync(id);
            if (schoolClass == null)
            {
                return NotFound();
            }
            return View(schoolClass);
        }

        // POST: SchoolClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Year")] SchoolClass schoolClass)
        {
            if (id != schoolClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolClassExists(schoolClass.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(schoolClass);
        }

        // GET: SchoolClasses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.SchoolClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        // POST: SchoolClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var schoolClass = await _context.SchoolClasses.FindAsync(id);
            _context.SchoolClasses.Remove(schoolClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolClassExists(string id)
        {
            return _context.SchoolClasses.Any(e => e.Id == id);
        }
    }
}
