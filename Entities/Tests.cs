using System;

namespace CoreEscuela.Entities {
    public class Tests : BaseObject {
        //public string UniqueId { get; private set; }

        //public string Name { get; set; }

        public Student By { get; set; }

        public Subject ItsSubject { get; set; }

        public float grade { get; set; }

        //public Tests() => UniqueId = Guid.NewGuid().ToString();

    }
}