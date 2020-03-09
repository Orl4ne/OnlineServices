using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Common.AssessementServices.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<CommentTO, int>
    {
        CommentTO GetById(int Id);
        bool Remove(CommentTO entity);
        bool Remove(int Id);
        CommentTO Update(CommentTO Entity);
    }
}
