using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp1
{
    public class Session
    {
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        /// <summary>
        /// This List will store the collection of string codes
        /// of the courses offered during the session.
        /// </summary>
        public List<string> SessionCourses { get; private set; }

        public Session(DateTime start, DateTime end)
        {
            StartDate = start; EndDate = end;
            SessionCourses = new List<string>();
        }
    }
}
