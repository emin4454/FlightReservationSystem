using Hospital.Data;
using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
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
            var filteredUsers = _context.Users.Select( x => new UserView
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
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }
            var user = _userManager.FindByIdAsync(id).Result;
            var selectListItems = _context.Roles.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Name,
            });
            ViewBag.UserRoles = selectListItems;
            var userView = new UserViewForEdit { 
                userId = user.Id,
                userLastName = user.userLastName,
                userName = user.UserName,
            };
            if (user == null)
            {
                return NotFound();
            }
            return View(userView);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("userName,userLastName,role,userId")] UserViewForEdit userView)
        {
            var user = await _userManager.FindByIdAsync(userView.userId);

            if (user == null)
            {
                return NotFound();
            }

            // Kullanıcının mevcut rollerini alın
            var userRoles = await _userManager.GetRolesAsync(user);

            // Seçilen rolleri alın
            var selectedRoles = new String[] { userView.role };

            // Yeni rolleri bulun

            var newRoles = selectedRoles.Except(userRoles);
            if (newRoles != null) { 
            // Eski rolleri bulun
                var removedRoles = userRoles.Except(selectedRoles);

            // Yeni rolleri kullanıcıya ata
                await _userManager.AddToRolesAsync(user, newRoles);

            // Eski rolleri kullanıcıdan kaldır
                await _userManager.RemoveFromRolesAsync(user, removedRoles);

            // Veritabanındaki değişiklikleri kaydet
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction(nameof(Index));
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
