using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entities {
    public class Course : BaseObject, IVenue {

        public TimingType timing { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; } = new List<Student> ();

        public string Address { get; set; }

        public void ClenAddress () {
            Printer.DrawLine ();
            Console.WriteLine ("Cleaning Course");
            Console.WriteLine ("Course Cleaned");
        }
    }
}