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

        public List<CourseDefinition> SessionCourses { get; private set; }

        public Session(DateTime start, DateTime end)
        {
            StartDate = start; EndDate = end;
            SessionCourses = new List<CourseDefinition>();
        }
    }
}
