using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp1
{
    public class School
    {
        /// <summary>
        /// This Dictionary structure will store matched pairs of
        /// course subject IDs with subject codes.
        /// </summary>
        public Dictionary<CourseSubject, string> CourseCodes { get; init; }

        /// <summary>
        /// This property will store the sessions with their course offerings
        /// </summary>
        public List<Session> SchoolSessions { get; init; }

        /// <summary>
        /// This constructor will initialize a school object
        /// and load the existing data about the school,
        /// but in this sample application
        /// I am only creating fake data.
        /// </summary>
        public School()
        { 
            CourseCodes = new Dictionary<CourseSubject, string>();
            LoadCourseCodes();

            SchoolSessions = new List<Session>();
        }

        /// <summary>
        /// In a real-world application, this internal method
        /// would load course codes from a database, maybe,
        /// but here I am only making up the codes for testing.
        /// </summary>
        private void LoadCourseCodes()
        {
            CourseCodes.Add(CourseSubject.History, "HIST");
            CourseCodes.Add(CourseSubject.Literature, "LITR");
            CourseCodes.Add(CourseSubject.Mathematics, "MATH");
            CourseCodes.Add(CourseSubject.Physics, "PHYS");
            CourseCodes.Add(CourseSubject.Chemistry, "CHEM");
            CourseCodes.Add(CourseSubject.Software, "SOFT");
        }

        /// <summary>
        /// In a real-world application, the school would acquire
        /// information about registering students and load up
        /// the definitions of the courses offered in the new session.
        /// </summary>
        public void StartNewSession(DateTime startDate)
        {
            // There could be a session name made up according to some school rules.
            // Here, I am only pretending that a school session is 114 days,
            // starting from the given date.
            Session newSession = new(startDate, startDate.AddDays(114));
            SchoolSessions.Add(newSession);
            // Then the school will load some course definitions for the new session,
            // probably from a database table created by curriculum designers.
            LoadSessionCourses(newSession);
        }

        /// <summary>
        /// This internal method simply makes up some course definitions
        /// </summary>
        private void LoadSessionCourses(Session schoolSession)
        {
            schoolSession.SessionCourses.Add(
                new(CourseSubject.Literature,
                    CourseCodes[CourseSubject.Literature] + "101",
                    "Introduction to English Literature",
                    "A general overview of English Literature throughout the ages"));

            schoolSession.SessionCourses.Add(
                new(CourseSubject.Mathematics,
                    CourseCodes[CourseSubject.Mathematics] + "203",
                    "Introduction to Calculus",
                    "Discussions on method of derivatives and integrals"));
        }
    }
}
