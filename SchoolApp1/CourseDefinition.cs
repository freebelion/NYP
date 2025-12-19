using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp1
{
    public class CourseDefinition
    {
        public CourseSubject Subject { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }

        public CourseDefinition(CourseSubject course_subject,
            string course_code, string course_name, string course_description)
        {
            Subject = course_subject;
            Code = course_code;
            Name = course_name;
            Description = course_description;
        }
    }
}
