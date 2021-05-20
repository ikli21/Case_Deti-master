using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case_Deti.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Case_Deti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        private readonly ILogger<ProfessionsController> _logger;
        private readonly DetiContext _db;
        public ProfessionsController(ILogger<ProfessionsController> logger, DetiContext context)
        {
            _logger = logger;
            _db = context;
        }

        // GET: api/<ApiController>
        [HttpGet]
        public async Task<IEnumerable<Profession>> GetProfessions()
        {
            return _db.Professions
                .Include(p => p.CategoryProfessions)
                .ThenInclude(c => c.Category)
                .ToArray();
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Profession>> Get(int id)
        {
            return _db.Professions.Where(p => p.ProfessionID == id).ToArray();
        }

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly DetiContext _db;
        public CategoriesController(ILogger<CategoriesController> logger, DetiContext context)
        {
            _logger = logger;
            _db = context;
        }

        // GET: api/<ApiController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return _db.Categories
                .Include(p => p.CategoryProfessions)
                .ThenInclude(c => c.Profession)
                .ToArray();
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Category>> Get(int id)
        {
            return _db.Categories.Where(c => c.CategoryID == id).ToArray();
        }

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly DetiContext _db;
        public CoursesController(ILogger<CoursesController> logger, DetiContext context)
        {
            _logger = logger;
            _db = context;
        }

        // GET: api/<ApiController>
        [HttpGet]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return _db.Courses.ToArray();
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Course>> GetRelatedCourses(int id)
        {
            //курсы под профессию
            var prof = await _db.Professions
                .Where(p => p.ProfessionID == id)
                .Include(p => p.ProfessionCourses)
                .ThenInclude(pc => pc.Course)
                .FirstOrDefaultAsync();
            if (prof == null) return null;

            var courses = new List<Course>();
            foreach (var pc in prof.ProfessionCourses) courses.Add(pc.Course);
            return courses;
        }

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
