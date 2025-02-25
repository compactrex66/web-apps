using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace layout.Models;

public class Game
{
    public int Id { get; set; }
    [DisplayName("Podaj grę: ")]
    public string GameTitle { get; set; }

    [DisplayName("Podaj dewelopera: ")]
    public string Developer { get; set; }

    [DisplayName("Podaj cenę: ")]
    public double? Price { get; set; }

    public Game() {}

    public Game(int Id, string GameTitle, string Developer, double Price) {
        this.Id = Id;
        this.GameTitle = GameTitle;
        this.Developer = Developer;
        this.Price = Price;
    }
}
