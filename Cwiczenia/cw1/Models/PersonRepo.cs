using System;

namespace cw1.Models;

public class PersonRepo
{
    public static List<Person> GetPersons() {
        return new List<Person> {
            new Person {Id = 0, FirstName = "Tomasz", LastName = "Bułecki", Age = 23},
            new Person {Id = 1, FirstName = "Roman", LastName = "Bułecki", Age = 11},
            new Person {Id = 2, FirstName = "Natasz", LastName = "Kasza", Age = 45},
            new Person {Id = 3, FirstName = "Ryszard", LastName = "Kowal", Age = 22}
        };
    }
}
