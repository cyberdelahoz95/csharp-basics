using System;

namespace CoreEscuela.Entities {
    public abstract class BaseObject {
        public string UniqueId { get; private set; }
        public string Name { get; set; }

        public BaseObject () {
            UniqueId = Guid.NewGuid ().ToString ();
        }

        public override string ToString () {
            return $"{Name} {UniqueId}";
        }
    }
}