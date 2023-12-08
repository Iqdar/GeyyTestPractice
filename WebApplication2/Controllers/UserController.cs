using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace GerryTestPractice.Controllers
{
    public class UserController : Controller
    {

        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var user = _context.Users.ToList();
            return View("Index", user);
        }

        public IActionResult AddUser()
        {
            User user = new User();
            return View("UserForm", user);
        }

        public IActionResult EditUser(int id)
        {
            var user = _context.Users.SingleOrDefault( c => c.Id == id);
            return View("UserForm", user);
        }

        public IActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("UserForm", user);
            }
            if (user.Id == 0)
            {
                _context.Users.Add(user);
                //return View("UserForm", user);
            }
            else
            {
                var userInDb = _context.Users.Single(c => c.Id == user.Id);
                userInDb.Name = user.Name;
                userInDb.Email = user.Email;    
                userInDb.BirthDate = user.BirthDate;
                user.Gender = user.Gender;
                user.CreatedOn = userInDb.CreatedOn;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "User");
        }


    }
}
