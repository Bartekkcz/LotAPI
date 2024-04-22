using Application.Dto;
using Application.Interfaces;
using Application.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlaneController : ControllerBase
    {
        private readonly IPlaneService _planeService;
        public PlaneController(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        [SwaggerOperation(Summary = "Retrieves all planes")]
        [HttpGet]
        public IActionResult Get()
        {
            var planes = _planeService.GetAllPlanes();
            return Ok(planes);
        }

        [SwaggerOperation(Summary = "Retrieves chosen plane by unique id")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id) 
        {
            var plane = _planeService.GetPlaneById(id);
            if (plane == null)
            {
                return NotFound();
            }
            return Ok(plane);
        }

        [SwaggerOperation(Summary = "Create a new plane")]
        [HttpPost]
        [Authorize(Roles = "2,3")]
        public IActionResult Create(CreatePlaneDto newPlane)
        {
            //var validator = new CreatePlaneDtoValidator();
            //var validationResult = validator.Validate(newPlane);
            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}
            var plane = _planeService.AddNewPlane(newPlane);
            if (plane == null)
            {
                return StatusCode(500, "Failed to create plane.");
            }

            return Created($"api/planes/{plane.Id}", plane);
        }

        [SwaggerOperation(Summary = "Update existing plane")]
        [HttpPut]
        [Authorize(Roles = "2,3")]
        public IActionResult Update(UpdatePlaneDto updatePlane) 
        {
            _planeService.UpdatePlane(updatePlane);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete existing plane")]
        [HttpDelete]
        [Authorize(Roles = "2,3")]
        public IActionResult Delete(int id)
        {
            _planeService.DeletePlane(id);
            return NoContent();
        }
    }
}
