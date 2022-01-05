using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeWebApplication1.Models
{
    public class Student
    {
        public string fName;
        public string lName;
        public DateTime birthDate;
        public string mail;
        public int grade;
        public Student(string fName, string lName, DateTime birthDate, string mail, int grade)
        {
          this.fName = fName;
            this.lName = lName;
            this.birthDate = birthDate;
            this.mail = mail;
            this.grade = grade;

        }
    }
}