using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Common.AssessementServices.Interfaces
{
    public interface IASSUnitOfWork : IUnitOfWork
    {
        IFormRepository FormRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IQuestionPropositionRepository QuestionPropositionRepository { get; }
        IResponseRepository ResponseRepository { get; }
        ISubmissionRepository SubmissionRepository { get; }
        ICommentRepository CommentRepository { get; }
    }
}
