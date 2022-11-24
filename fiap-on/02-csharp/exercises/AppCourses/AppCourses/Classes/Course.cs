using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCourses.Classes
{

    public interface IStudent
    {
        void CreateStudent();
    }

    public interface IInstructor
    {
        void CreateInstructor();
    }

    public class Course : IStudent, IInstructor
    {
        public int Code;
        public string NameCourse;
        public string NameInstructor;
        public int Workload;
        public int MinStudents;
        public int MaxStudents;

        public void CreateStudent(string name)
        {
            if (name == null)
            {
                // lançando uma exception
                throw new CustomException("Nome do aluno inválido");
            }
        }

        public void CreateInstructor()
        {
            Console.WriteLine("Criando instrutor.");
        }

        public Course()
        {
            // construtor padrão
        }

        public Course(string name, string instructor)
        {
            this.NameCourse = name;
            this.NameInstructor = instructor;
        }

        public void CreateCourse(string name, string instructor)
        {
            this.NameCourse = name;
            this.NameInstructor = instructor;
        }

        public bool EnrollStudent(string nameStudent)
        {
            // verificar a quantidade de alunos
            return true;
        }

        public int GetMaxStudents()
        {
            // retorna o valor do atributo
            return MaxStudents;
        }
    }
}
