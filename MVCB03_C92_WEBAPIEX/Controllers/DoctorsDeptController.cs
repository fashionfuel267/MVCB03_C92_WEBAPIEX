using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCB03_C92_WEBAPIEX.Models;

namespace MVCB03_C92_WEBAPIEX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class DoctorsDeptController : ControllerBase
    {
        private readonly dbDoctorsModel _context;
        public DoctorsDeptController(   dbDoctorsModel db) 
          { 
            _context = db;
        }
        [HttpGet]
        public IEnumerable<DoctorsDpartment> Get()
        {
            return _context.DoctorsDpartment.ToList();
        }
        [HttpPost]
        public IActionResult Post(DoctorsDpartment dpartment)
        {
            _context.DoctorsDpartment.Add(dpartment);
            if(_context.SaveChanges()>0)
            {
                return Created("", dpartment);
            }

            return Problem("could not Save");
        }
    }
}
