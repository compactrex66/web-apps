using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace layout.Models;

public class Game
{
    public int Id { get; set; }
    [DisplayName("Podaj grę: ")]
    [Required(ErrorMessage = "Tytuł jest wymagany")]
    public string GameTitle { get; set; }

    [DisplayName("Podaj dewelopera: ")]
    [Required(ErrorMessage = "Deweloper jest wymagany")]
    public string Developer { get; set; }

    [DisplayName("Podaj cenę: ")]
    [Required(ErrorMessage = "cena jest wymagana")]
    [Range(0, 9999, ErrorMessage = "Cena musi być z przedziału 0 - 9999")]
    public double? Price { get; set; }

    public Game() {}

    public Game(int Id, string FirstName, string LastName, Double Age) {
        this.Id = Id;
        this.GameTitle = FirstName;
        this.Developer = LastName;
        this.Price = Age;
    }
}
