using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace layout.Models;

public class Student
{
    public int Id { get; set; }
    [DisplayName("Podaj imię: ")]
    [Required(ErrorMessage = "Imię jest wymagane")]
    public string FirstName { get; set; }

    [DisplayName("Podaj nazwisko: ")]
    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    public string LastName { get; set; }

    [DisplayName("Podaj wiek: ")]
    [Required(ErrorMessage = "Wiek jest wymagany")]
    [Range(1, 120, ErrorMessage = "Wiek musi być z przedziału 1 - 120")]
    public int? Age { get; set; }

    public Student() {}

    public Student(int Id, string FirstName, string LastName, int Age) {
        this.Id = Id;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Age = Age;
    }
}
