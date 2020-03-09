//using OS.AssessementServices.DataLayer;
//using OS.Common.EvaluationServices;
//using OS.Common.AssessementServices.TransfertObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;


//namespace OS.AssessementServices.BusinessLayer.UseCases
//{
//    public partial class ESAttendeeRole : IESAttendeeRole
//    {
//        public bool SetResponse(ICollection<ResponseTO> responses)
//        {
//            try
//            {
//                responses.Select(r => iESUnitOfWork.ResponseRepository.Add(r));
//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
