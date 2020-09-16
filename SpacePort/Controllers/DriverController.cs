﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpacePort.Models;
using SpacePort.Services.Interfaces;
using SpacePort.Services.Repositories;

namespace SpacePort.Controllers
{
    [ApiController]
    [Route("api/v1.0/drivers")]
    public class DriverController : Controller
    {
        private readonly IDriverRepository _repo;
        private readonly ILogger<DriverController> _logger;

        public DriverController(IDriverRepository repo, ILogger<DriverController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}