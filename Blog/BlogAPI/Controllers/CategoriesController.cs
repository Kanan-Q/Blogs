using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController(ICategoryRepostory _repo) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll().ToListAsync());
        }

        [HttpGet("{id}")]
        public string Get(int id)

        {
            return "slm";
        }

        [HttpPost]
        public void Post(Category cat)
        {
            _repo.Add(cat);
            _repo.SaveChanges();
        }

    }
}
