using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Classes
{
    public class Course
    {
        public int Code;
        public string NameCourse;

        public Course(int code, string name)
        {
            this.Code = code;
            this.NameCourse = name;
        }
    }
}