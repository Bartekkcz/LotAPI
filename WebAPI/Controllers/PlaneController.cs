﻿using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Get()
        {
            var planes = _planeService.GetAllPlanes();
            return Ok(planes);
        }

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
    }
}