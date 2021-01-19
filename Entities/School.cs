using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entities {
    public class School : BaseObject, IVenue {
        //public string UniqueId { get; private set; } = Guid.NewGuid ().ToString ();
        private string name;

        /*public string Name {
            get { return name; }
            set { name = value; }
        }*/

        public int YearOfCreation { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Addresses { get; set; }

        public TypesOfSchool Type { get; set; }
        public Course[] Courses { get; set; } // normal array
        public List<Course> CoursesList { get; set; } // Generic List class
        public string Address {
            get =>
                throw new NotImplementedException ();
            set =>
                throw new NotImplementedException ();
        }

        public School (string name) => (Name) = (name);
        public School (string name, int year, TypesOfSchool types, string pais = "", string city = "") {
            Name = name;
            YearOfCreation = year;
            Type = types;
            Country = pais;
            City = city;
        }

        public override string ToString () => $"Nombre {Name}, Tipo {Type}, Pais {Country}, Ciudad {City} ";

        public void ClenAddress () {
            Printer.DrawLine ();
            Console.WriteLine ("Cleaning School");
            foreach (var course in CoursesList) {
                course.ClenAddress ();
            }
            Console.WriteLine ("School Cleaned");
        }
    }
}