using System;
using AppCourses.Classes;

namespace AppCourses
{
    class Program
    {
        static void Main(string[] args)
        {
            // tratamento de exeception
            try
            {
                string name = null;
                Console.WriteLine(name.Substring(2));
                new Course().CreateStudent(name);
            }
            // capturando uma exceção de referência nula.
            // similar ao NullPointerExceptionn do Java
            catch (CustomException p)
            {
                Console.WriteLine(p.Message);
            }
            catch(Exception)
            {
                Console.WriteLine("Problema na execução da operação");
                throw new Exception("Problema na execução da operação");
            }

            Course course1 = new Course();

            course1.CreateCourse("name", "instructor");
            course1.EnrollStudent("student");
            course1.GetMaxStudents();

            Course course2 = new Course("Course", "Instructor");
            Course course3 = new Course("Node.js", 5, 40);

            CourseVocation courseVocation = new CourseVocation;
            courseVocation.EnrollStudent("student");
        }
    }
}