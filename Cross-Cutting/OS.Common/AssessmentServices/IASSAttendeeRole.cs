using OS.Common.AssessementServices.TransfertObjects;
using System.Collections.Generic;

namespace OS.Common.EvaluationServices
{
    public interface IASSAttendeeRole
    {
        FormTO GetActiveForm(int sessionId, int attendeeId);


        //bool SetResponse(ICollection<ResponseTO> responses);
    }
}
