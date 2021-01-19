using System;
using System.Collections.Generic;

namespace CoreEscuela.Entities {
    public class Student : BaseObject {
        //public string UniqueId { get; private set; }

        //public string Name { get; set; }

        //public Student() => UniqueId = Guid.NewGuid().ToString();

        public List<Tests> Surveys { get; set; } = new List<Tests> ();

    }
}