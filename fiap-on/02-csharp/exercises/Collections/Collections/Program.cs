using System;
using Collections.Classes;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Exemplo 1
            string[] names1 = { "João", "Maria", "José" };

            // Exemplo 2
            string[] names2 = new string[3];
            names1[0] = "João";
            names2[1] = "Maria";
            names2[2] = "José";
            */

            /*
            // Criando um array de cursos
            Course[] listCourses = new Course[3];

            // Criando os items do array
            listCourses[0] = new Course(1, "Curso 1");
            listCourses[1] = new Course(2, "Curso 2");
            listCourses[2] = new Course(3, "Curso 3");

            // Navegando pelo array e imprimindo o conteúdo
            foreach (Course curso in listCourses)
            {
                Console.WriteLine(curso.NameCourse);
            }

            Console.Read();
            */

            /*
            List<Course> courses = new List<Course>();

            Course c1 = new Course(1, "Curso 1");
            courses.Add(c1);

            courses.Add(new Course(2, "Curso 2"));
            courses.Add(new Course(4, "Curso 4"));

            // Inserindo um curso em uma posição específica.
            courses.Insert(2, new Course(3, "Curso 3"));

            // Removendo um objeto de uma determinada posição
            courses.RemoveAt(3);
            // Removendo o objeto pela referência de c1
            courses.Remove(c1);

            foreach (var course in courses)
            {
                Console.WriteLine(course.NameCourse);
            }

            Console.Read();
            */

            /*
            // Criando uma lista ordenada
            SortedSet<string> students = new SortedSet<string>();

            // Adicionando elementos na lista
            students.Add("Alberto");
            students.Add("Giovanna");
            students.Add("Fabio");
            students.Add("Victor");
            students.Add("Carlos");

            Console.Write("Encontrou o aluno Carlos: ");

            // Procurando na lista um determinado elemento
            Console.WriteLine(students.Contains("Carlos"));
            Console.WriteLine("");

            foreach (string student in students)
            {
                Console.WriteLine(student);
            }

            Console.Read();
            */

            Course c1 = new Course(1, "Curso 1");
            Course c2 = new Course(2, "Curso 2");
            Course c3 = new Course(3, "Curso 3");

            // Criando um lista de objeto na estrutura chave + valor
            Dictionary<string, Course> dictionary = new Dictionary<String, Course>();
            dictionary.Add(c1.NameCourse, c1);
            dictionary.Add(c2.NameCourse, c2);
            dictionary.Add(c3.NameCourse, c3);

            // procurando um determinado elemento
            Console.Write("Encontrou o Curso 2: ");
            Console.WriteLine(dictionary["Curso 2"] == null ? false : true);
            Console.WriteLine("");

            // Navegando pela coleção e imprimindo os objetos.
            foreach (KeyValuePair<string, Course> itemCourse in dictionary)
            {
                string key = itemCourse.Key;
                Course c = dictionary[key];
                Console.WriteLine(c.NameCourse);
            }

            Console.Read();
        }
    }
}
