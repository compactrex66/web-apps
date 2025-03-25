using System;

namespace arkusz2.Models;

public class Player
{
    public int PositionId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Player(int positionId, string firstName, string lastName) {
        PositionId = positionId;
        FirstName = firstName;
        LastName = lastName;
    }
}
