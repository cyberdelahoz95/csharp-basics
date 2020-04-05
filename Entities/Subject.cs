using System;

namespace CoreEscuela.Entities
{
    public class Subject
    {
        public string UniqueId { get; private set; }

        public string Name { get; set; }

        public Subject() => UniqueId = Guid.NewGuid().ToString();

    }
}