﻿using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult Create(CreatePlaneDto newPlane)
        {
            var plane = _planeService.AddNewPlane(newPlane);
            return Created($"api/planes/(plane.Id)", plane);
        }

        [SwaggerOperation(Summary = "Update existing plane")]
        [HttpPut]
        public IActionResult Update(UpdatePlaneDto updatePlane) 
        {
            _planeService.UpdatePlane(updatePlane);
            return NoContent();
        }
    }
}
