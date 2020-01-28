using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using OnlineServices.WebUx.Mvc6.Areas.Facilities.Models;

namespace OnlineServices.WebUx.Mvc6.Areas.Facilities.Controllers
{
    [Area("Facilities")]
    public class AttendeeController : Controller
    {
        private readonly IFSAttendeeRole attendeeRole;

        public AttendeeController(IFSAttendeeRole attendeeRole)
        {
            this.attendeeRole = attendeeRole;
        }

        //Get Formulaire vide
        [HttpGet]
        public IActionResult IncidentReporting()
        {
            var temp = new ExampleVM()
            {
                A = 1,
                B = 2
            };
            return View();
        }

        public List<RoomTO> GetRoomByFloor(int FloorID)
        {
            return new List<RoomTO>
            {
                new RoomTO { Archived=false, Name = new MultiLanguageString("","",""), Floor = new FloorTO { Archived=false, Id= 25, Number = -2 }  }
            };
        }

        //Submit Formlulaire
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IncidentReporting(IncidentTO incidentTO)
        {
            incidentTO.SubmitDate = DateTime.Now;
            
            attendeeRole.CreateIncident(incidentTO);

            return View();
        }
    }
}