using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_app
{
    [Serializable()]
    class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public bool gender { get; set; }
        public decimal cgpa { get; set; }

        public Student(string id, string name, int age, decimal cgpa,bool gender) {
            this.id = id;
            this.name = name;
            this.age = age;
            this.cgpa = cgpa;
            this.gender = gender;

        }
    }
}
