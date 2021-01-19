namespace CoreEscuela.Entities {
    public interface IVenue {
        string Address { get; set; }

        void ClenAddress ();
    }
}

//Interfaces are used to define the structure of an object
//comments as a convenction, interfaces starts with I
//as a general rule the members of an interface do not have access modifiers
// in other words, all its members are public