using Hospital.Data;
using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace HospitalAppointmentSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        private readonly HospitalDataContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public UserController(HospitalDataContext context,UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager= userManager;
            _roleManager= roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roless = _userManager.GetRolesAsync(_context.Users.FirstOrDefault(x=>x==x)).Result;

            var filteredUsers = _context.Users.Select(x => new UserView
            {
                userId = x.Id,
                userEmail = x.Email,
                userLastName = x.userLastName,
                userName = x.UserName,
                roles = _userManager.GetRolesAsync(x).Result
            }) ;
            
            return _context.users != null ?
                        View(filteredUsers) :
                        Problem("Entity set 'HospitalDataContext.appointments'  is null.");
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
