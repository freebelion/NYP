## SchoolApp1
- This project is another object-oriented programming example
  which uses associations between classes.

- It is another toy application which *supposedly* helps
  manage a school with academic years and students.

- Noone should even think this is a good way of developing
  an application which manages a school in real world.

- I will only try to demonstrate what kind of thought process
  goes into developing this type of application.

- Let us start with a class to represent a course.
  - It should definitely have a property for the name of the course.
  - It should also have a property for an identifying code.
  - It may also have a property to store
    the description of the course.

    How about starting with this simple class definition?
    ```
    public class CourseDefinition
        {
            public string Code { get; init; }
            public string Name { get; init; }
            public string Description { get; init; }
        }
    ```
  - I named this class **CourseDefinition**,
    because that's what it actually represents.
    - An object of this class type will represent
      the written description of a course,
      but not a course given in a certain academic teaching session.

- Now, C# compiler would raise some errors for that class
  definition, because it does not have a constructor function
  to initialize the string properties.

- There is also a bigger issue: I have simply used
  auto-properties, instead of properties which provide
  controlled access and perform some validation
  on a private string variable.

- For example, the code of a course would depend on
  the course subject, but the subject would probably
  not be an arbitrary string.

- Most schools offer courses on a limited number of subjects
  with names generally recognized by all the people
  with at least some schooling.

- Therefore, I have decided to define an `enum`,
  a list of integer codes associated with the names
  of some standard subjects:

  ```
    public enum CourseSubject
    {
        History,
        Literature,
        Mathematics,
        Physics,
        Chemistry,
        Software
    }
  ```

- Now, a school would probably use its own three-letter
  or four-letter code strings matching those subject codes.

- I have decided to store the code strings in a `Dictionary`
collection which is a property of my manager class
named `School`:

  ```
    public class School
    {
        public Dictionary<CourseSubject, string> CourseCodes { get; set; }
        public School()
        { 
            CourseCodes = new Dictionary<CourseSubject, string>();
            CourseCodes.Add(CourseSubject.History, "HIST");
            CourseCodes.Add(CourseSubject.Literature, "LITR");
            CourseCodes.Add(CourseSubject.Mathematics, "MATH");
            CourseCodes.Add(CourseSubject.Physics, "PHYS");
            CourseCodes.Add(CourseSubject.Chemistry, "CHEM");
            CourseCodes.Add(CourseSubject.Software, "SOFT");
        }

    }
  ```
   > A `Dictionary` structure is a collection of matched pairs,
     the first of which is a *key*, the other one is a *value*.
     Once we add pairs to it, like I did above,
     we can access the value matching a key by using the key
     like an index number in an array
     (see the constructor function below)

- Then I came up with a constructor for the `CourseDefinition`
class:
  ```
        public CourseDefinition(CourseSubject course_subject,
            string course_code, string course_name, string course_description)
        {
            Subject = course_subject;
            Code = course_code;
            Name = course_name;
            Description = course_description;
        }
  ```

- Now, you may see the need to define a class to represent
  a teaching session. It should probably need a string property
  to store a name, and maybe two properties to store
  the start time and ending time, and a list of courses
  to be offered during the session.
  - Again, I cannot claim that it will make sense,
    but here is a class definition I have come up with:

    ```
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
    ```

  
