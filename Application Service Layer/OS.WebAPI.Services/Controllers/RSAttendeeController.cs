﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OS.Common.AttendanceServices;
using OS.Common.RegistrationServices;
using OS.Common.RegistrationServices.TransferObjects;

namespace OS.WebAPI.Services.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RSAttendeeController : ControllerBase
    {
        private readonly ILogger<RSAttendeeController> _logger;
        private readonly IRSAttendeeRole iRSAttendeeRole;

        public RSAttendeeController(ILogger<RSAttendeeController> logger, IRSAttendeeRole iRSAttendeeRole)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.iRSAttendeeRole = iRSAttendeeRole ?? throw new ArgumentNullException(nameof(iRSAttendeeRole));
        }

        [HttpGet("{userId}")]
        public IActionResult GetTodaySession(int userId, DateTime date)
        {
            return new JsonResult(iRSAttendeeRole.GetSessionByUserByDate(userId, date));
        }

        [HttpGet("{email}")]
        public IActionResult GetIdByMail(string email)
        {
            return new JsonResult(iRSAttendeeRole.GetIdByMail(email));
        }
    }
}