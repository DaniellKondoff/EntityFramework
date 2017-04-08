using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new StudentContext();
            //context.Database.Initialize(true);

            //3.WorkingWitTheDB
            //ListAllUserAndTheirHomeWorks(context);
            //ListAllCourcesAndRecources(context);
            //ListAllCoursesMoreThan5Res(context);
            //ListAllCourseByDate(context);
            //ListStudentsAndTheirCourses(context);
        }

        private static void ListStudentsAndTheirCourses(StudentContext context)
        {
            var student = context.Students
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.Name);

            foreach (var stud in student)
            {
                if (stud.Courses.Count != 0)
                {
                    Console.WriteLine(stud.Name);
                    Console.WriteLine(stud.Courses.Count);
                    Console.WriteLine(stud.Courses.Sum(c => c.Price));
                    Console.WriteLine(stud.Courses.Average(c => c.Price));
                }

            }
        }

        private static void ListAllCourseByDate(StudentContext context)
        {
            DateTime activeDate = new DateTime(2017, 03, 10);
            var courses = context.Courses
                .Where(c => c.StartDate <= activeDate && c.EndDate >= activeDate)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = SqlFunctions.DateDiff("day", c.StartDate, c.EndDate),
                    StudentsCount = c.Students.Count
                })
                .OrderByDescending(c => c.StudentsCount)
                .ThenByDescending(c => c.Duration);

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name}");
                Console.WriteLine($"{course.StartDate}");
                Console.WriteLine($"{course.EndDate}");
                Console.WriteLine($"{course.Duration}");
                Console.WriteLine($"{course.StudentsCount}");
            }
        }

        private static void ListAllCoursesMoreThan5Res(StudentContext context)
        {
            var course = context.Courses
                .Where(c => c.Recources.Count > 5)
                .OrderByDescending(c => c.Recources.Count)
                .ThenByDescending(c => c.StartDate);

            foreach (var cour in course)
            {
                Console.WriteLine($" Course Name: {cour.Name} Resource Count: {cour.Recources.Count}");
            }
        }

        private static void ListAllCourcesAndRecources(StudentContext context)
        {
            var courses = context.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate);
            foreach (var course in courses)
            {
                Console.WriteLine($"Course Name: {course.Name} Course Description:{course.Description}");

                foreach (var res in course.Recources)
                {
                    Console.WriteLine($" Recouse ID: {res.Id}");
                    Console.WriteLine($" Recouse Name: {res.Name}");
                    Console.WriteLine($" Recouse Type: {res.TypeOfResources}");
                    Console.WriteLine($" Recouse Url: {res.URL}");
                    Console.WriteLine();
                }
            }
        }

        private static void ListAllUserAndTheirHomeWorks(StudentContext context)
        {
            var students = context.Students;

            foreach (var student in students)
            {
                Console.WriteLine($"Student Name: {student.Name}");

                if (student.Homeworks.Count == 0)
                {
                    Console.WriteLine(" There is no homework for that student");
                    continue;
                }
                foreach (var homework in student.Homeworks)
                {
                    Console.WriteLine($" Homework Content: {homework.Content}");
                    Console.WriteLine($" Homework ContentType: {homework.ContentType}");

                }

            }
        }
    }
}
