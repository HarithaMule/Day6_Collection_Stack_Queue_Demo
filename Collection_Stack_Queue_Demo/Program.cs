using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


class Course
{
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public Course(string code, String name)

    {
        CourseCode = code;
        CourseName = name;
    }
}
        class EnrollmentRequest
        {
            public int LearnerId { get; set; }
            public string CourseCode { get; set; }
        }
class AdminAction
{
    public string ActionName { get; set; }


}
class Sessions
{
    public string Title { get; set; }

}
class Enrollment
{
 public int LearnerId { get; set; }
    public string CourseCode { get; set; }
}
    

    
    class Program
    {
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Enterprise Management !!!!");
        //create list of available courses
        List<Course> courses = new List<Course>();
        courses.Add(new Course("C101", "C# Programming"));
        courses.Add(new Course("C102", "Java Programming"));
        Console.WriteLine("Available courses:");
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.CourseCode} --- {course.CourseName}");
        }
        //fetching course details
        Dictionary<string, Course> CourseDictionary = new Dictionary<string, Course>();
        foreach (var course in courses)
        {
            CourseDictionary[course.CourseCode] = course;
        }
        Console.WriteLine("\nFetching course using Dictionary:");
        if (CourseDictionary.ContainsKey("C101"))
        {
            Console.WriteLine(CourseDictionary["C101"].CourseName);
        }
        else
        {
            Console.WriteLine("Course not found");
        }
        //prevent duplicate enrollment
        HashSet<int> enrolledLearners = new HashSet<int>();
        enrolledLearners.Add(101);
        enrolledLearners.Add(101);
        Console.WriteLine("\n Unique Enrollment Count:" + enrolledLearners.Count);

        //Process enrollment requests in order
        Queue<EnrollmentRequest> enrollmentRequest = new Queue<EnrollmentRequest>();
        enrollmentRequest.Enqueue(new EnrollmentRequest { LearnerId = 101, CourseCode = "C101" });
        enrollmentRequest.Enqueue(new EnrollmentRequest { LearnerId = 102, CourseCode = "C102" });
        Console.WriteLine("\n Processing Enrollment requests:");
        while(enrollmentRequest.Count > 0)
        {
            var request = enrollmentRequest.Dequeue();
            Console.WriteLine($"Processed Learner {request.LearnerId} for Course {request.CourseCode}");

        }
        //undo admin options 
        Stack<AdminAction> admins = new Stack<AdminAction>();
        admins.Push(new AdminAction { ActionName = "Add Course" });
        admins.Push(new AdminAction { ActionName = "RemoveCourse" });

        Console.WriteLine("\n Undo Admin Action:");
        Console.WriteLine(admins.Pop().ActionName);

        //display sessions in sorted by start time
        SortedList<DateTime, Sessions> sortedSession = new SortedList<DateTime, Sessions>();
        sortedSession.Add(DateTime.Now.AddHours(2), new Sessions { Title = "Advance C#" });
        sortedSession.Add(DateTime.Now.AddHours(1), new Sessions { Title = "Python Programming" });

        Console.WriteLine("\nSessions sorted by Start Time:");
        foreach (var session in sortedSession)
            Console.WriteLine($"{session.Key}:{session.Value.Title}");

        //handle concurrent enrollments

        ConcurrentDictionary<int, Enrollment> conEnrollment = new ConcurrentDictionary<int, Enrollment>();
        conEnrollment.TryAdd(101, new Enrollment { LearnerId = 101, CourseCode = "C101" });

        Console.WriteLine("\nConcurrent Enrollment Count: " + conEnrollment.Count);

    }
    }
        

