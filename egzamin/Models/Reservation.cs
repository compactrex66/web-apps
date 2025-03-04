using System;

namespace egzamin.Models;

public class Reservation
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public string Date { get; set; }
    public int PeopleCount   { get; set; }
    public string PhoneNumber { get; set; }
}
