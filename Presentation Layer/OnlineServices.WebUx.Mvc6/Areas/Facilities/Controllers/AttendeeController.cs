using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace OnlineServices.WebUx.Mvc6.Areas.Facilities.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IFSAttendeeRole attendeeRole;

        public AttendeeController(IFSAttendeeRole attendeeRole)
        {
            this.attendeeRole = attendeeRole;
        }

        //Get Formulaire vide
        public IActionResult IncidentReporting()
        {
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
        public IActionResult IncidentReportingSubmited(IncidentTO incidentTO)
        {
            incidentTO.SubmitDate = DateTime.Now;
            
            attendeeRole.CreateIncident(incidentTO);

            return View();
        }
    }
}