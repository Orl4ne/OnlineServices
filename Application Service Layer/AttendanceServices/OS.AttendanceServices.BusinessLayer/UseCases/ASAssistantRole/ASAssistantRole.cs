﻿//using OS.AttendanceServices.DataLayer;
//using OS.Common.AttendanceServices;
//using OS.Common.AttendanceServices.TransfertObjects;
//using OS.Common.RegistrationServices;

//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace OS.AttendanceServices.BusinessLayer
//{
//    public class ASAssistantRole : IASAssistantRole
//    {
//        private readonly AttendanceContext attendanceContextIoC;
//        private IRSServiceRole registrationServiceIoC;

//        public ASAssistantRole(AttendanceContext contextIoC, IRSServiceRole registrationServiceIoC)
//        {
//            this.attendanceContextIoC = contextIoC;
//            this.registrationServiceIoC = registrationServiceIoC ?? throw new ArgumentNullException(nameof(registrationServiceIoC));
//        }

//        public List<CheckInTO> GetAttendeeCheckIns(int sessionId, int attendeeId) //Get of different sessions too!
//        {
//            if (sessionId <= 0)
//                throw new Exception("SessionId must be greater then 0");
//            if (attendeeId <= 0)
//                throw new Exception("AttendeeId must be greater then 0");

//            return GetCheckInsInSession(sessionId).Where(x => x.AttendeeId == attendeeId).ToList();
//        }

//        public List<CheckInTO> GetCheckInsInSession(int sessionId)
//        {
//            if (sessionId <= 0)
//                throw new Exception("SessionId must be greater then 0");

//            var listUser = registrationServiceIoC.GetUsersBySession(sessionId);

//            var listPresence = new List<CheckInTO>();

//            using (var UoW = new ASUnitOfWork(attendanceContextIoC))
//            {
//                //listPresence = QUERY REPO NATHAN..
//            }

//            return listPresence;
//        }

//        public bool SetCheckIn(CheckInTO checkInInfo)
//        {
//            throw new NotImplementedException();
//        }

//        public bool SetPresence(int sessionId, int attendeeId, DateTime presenceTime)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}