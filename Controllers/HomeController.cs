using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Case_Deti.Models;
using Case_Deti.Data;
using Microsoft.EntityFrameworkCore;

namespace Case_Deti.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DetiContext _db;

        public HomeController(ILogger<HomeController> logger, DetiContext context)
        {
            _logger = logger;
            _db = context;
        }

        public async Task<ActionResult> Index()
        {
            await FillDB(_db);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task FillDB(DetiContext db)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Login == "hackadmin" && u.Password == Util.GetEncryptedBytes("hackadmin"));
            if (user == null)
            {
                var admin = new Data.User() 
                { 
                    Login = "hackadmin", 
                    Password = Util.GetEncryptedBytes("hackadmin"), 
                    FirstName = "--", LastName = "---", 
                    MiddleName = "---", Role = 
                    Role.Admin 
                };

                var profession = new Data.Profession()
                {
                    Name = "test prof",
                    ImgURL = @"https://sun9-29.userapi.com/1-WgAmlkOwd-1_sW7Wp_uUlWFEjHdkAsZLxiLg/JCI0QEBnKX8.jpg",
                    ProfessionID = 0
                };

                var category = new Data.Category()
                {
                    ImgURL = @"https://sun9-29.userapi.com/1-WgAmlkOwd-1_sW7Wp_uUlWFEjHdkAsZLxiLg/JCI0QEBnKX8.jpg",
                    Name = "test cat",
                    CategoryID = 0
                };

                _db.ProfessionCategories.Add(new ProfessionCategory() { Category = category, Profession = profession });

                var course = new Data.Course()
                {
                    
                };


                _db.Users.Add(admin);
                await _db.SaveChangesAsync();
            };
        }
    }
}
