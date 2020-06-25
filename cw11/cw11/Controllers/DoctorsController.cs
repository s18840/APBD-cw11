using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;
using cw11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDbService _service;

        public DoctorsController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            IActionResult response;
            try
            {
                IEnumerable<Doctor> doctors = _service.GetDoctors();
                response = Ok(doctors);
            }
            catch (Exception e)
            {
                response = BadRequest($"No doctors\n{e.Message}");
            }
            return response;
        }

        [HttpPost]
        public IActionResult AddNewDoctor(Doctor doctor)
        {
            IActionResult response;
            try
            {
                _service.AddDoctor(doctor);
                response = Ok($"Doctor added");
            }
            catch (Exception e)
            {
                response = BadRequest($"Can't add doctor\n{e.Message}");
            }
            return response;
        }

        [HttpPut]
        public IActionResult ModifyDoctor(Doctor doctor)
        {
            IActionResult response;
            try
            {
                _service.ModifyDoctor(doctor);
                response = Ok($"Doctor modified");
            }
            catch (Exception e)
            {
                response = BadRequest($"Can't modify doctor\n{e.Message}");
            }
            return response;
        }

        [HttpPost("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            IActionResult response;
            try
            {
                _service.DeleteDoctor(id);
                response = Ok($"Doctor deleted");
            }
            catch (Exception e)
            {
                response = BadRequest($"Can't delete doctor\n{e.Message}");
            }
            return response;
        }
    }
}
