using OS.Common.RegistrationServices.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Common.RegistrationServices
{
    public interface IRSAssistantRole
    {
        bool AddUser(UserTO user);
        bool UpdateUser(UserTO user);
        bool RemoveUser(UserTO user);
        List<UserTO> GetUsers();
        UserTO GetUserById(int id);
        List<UserTO> GetUsersBySession(int sessionId);

        bool AddSession(SessionTO session);
        bool UpdateSession(SessionTO session);
        bool RemoveSession(SessionTO session);
        List<SessionTO> GetSessions();

        SessionTO GetSessionById(int sessionId);

        bool AddCourse(CourseTO course);
        bool UpdateCourse(CourseTO course);
        bool RemoveCourse(CourseTO course);
        List<CourseTO> GetCourses();
        CourseTO GetCourseById(int id);
        bool IsUserInSession(int userId, int sessionId);
    }
}
