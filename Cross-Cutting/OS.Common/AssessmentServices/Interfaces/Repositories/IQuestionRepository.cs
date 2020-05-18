using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Common.AssessementServices.Interfaces.Repositories
{
	public interface IQuestionRepository : IRepository<QuestionTO, int>
	{
		// méthodes spécifiques au FormQuestionRepository à rajouter ??
		IEnumerable<QuestionTO> GetAllOfForm(int FormId);
	}
}
