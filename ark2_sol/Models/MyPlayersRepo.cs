using MySql.Data.MySqlClient;

namespace ark2_sol.Models;

public class MyPlayersRepo
{
    private readonly string? _connectionString;

    public MyPlayersRepo(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public List<MyPlayer> GetPlayers(int number)
    {
        using var connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT zawodnik.id, zawodnik.imie, zawodnik.nazwisko, pozycja.nazwa  FROM zawodnik inner join pozycja on zawodnik.pozycja_id = pozycja.id WHERE pozycja.id = {number}";
        connection.Open();
        List<MyPlayer> players = new List<MyPlayer>();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            players.Add(new MyPlayer {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Surname = reader.GetString(2),
                PositionName = reader.GetString(3),
            });
        }
        
        return players;
    }
}