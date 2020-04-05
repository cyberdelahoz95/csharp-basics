using System;
using System.Collections.Generic;

namespace CoreEscuela.Entities {
    public class Course {
        public string Name { get; set; }

        public string UniqueId { get; private set; }

        public TimingType timing { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; } = new List<Student> ();

        public Course () {
            UniqueId = Guid.NewGuid ().ToString ();
        }
    }
}