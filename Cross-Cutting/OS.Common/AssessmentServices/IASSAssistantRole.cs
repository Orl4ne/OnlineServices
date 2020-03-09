using OS.Common.AssessementServices.TransfertObjects;
using System.Collections.Generic;

namespace OS.Common.EvaluationServices
{
    public interface IASSAssistantRole
    {
        bool AddForm(FormTO formTo);
        bool AddQuestionByForm(QuestionTO questionTO);
        bool AddPropositionByQuestion(QuestionPropositionTO propositionTO);
        bool RemoveFormById(int Id);
        FormTO GetFormById(int Id);
        List<FormTO> GetAllForms();
        QuestionTO GetQuestionById(int questionID);
        bool RemovePropositionById(int propositionId);
        bool RemoveQuestionById(int id);
        //bool GetQuestionsByFormId(int id);
        //List<ResponseTO> GetActiveForm(int sessionId, int userId);
        //bool SetResponse(ICollection<ResponseTO> responses);
    }
}
