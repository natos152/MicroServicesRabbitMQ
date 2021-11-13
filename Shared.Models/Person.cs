using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class Person
    {
        string fullName;
        DateTime date;
        int age;
        string profession;

        public string FullName { get => fullName; set => fullName = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Age { get => age; set => age = value; }
        public string Profession { get => profession; set => profession = value; }

        public Person(DateTime date, string fullName, int age, string profession)
        {
            FullName = fullName;
            Date = date;
            Age = age;
            Profession = profession;
        }
    }
}
