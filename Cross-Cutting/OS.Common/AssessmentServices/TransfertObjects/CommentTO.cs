using OS.Common.DataAccessHelpers;

namespace OS.Common.AssessementServices.TransfertObjects
{
    public class CommentTO : IEntity<int>
    {
        public int Id { get ;set; }
        public string Content { get; set; }
        public ResponseTO Response { get; set; }
    }
}