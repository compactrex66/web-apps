using System;
using MySql.Data.MySqlClient;

namespace arkusz2.Models;

public class PlayerRepo
{
    private string? _connectionString;
    public PlayerRepo(IConfiguration configuration) {
        _connectionString = configuration.GetConnectionString("mysql");
    }
    public List<Player> GetFromChosenPosition(int positionId) {
        using MySqlConnection conn = new MySqlConnection(_connectionString);
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = $"SELECT imie, nazwisko FROM zawodnik WHERE pozycja_id={positionId}";
        
        MySqlDataReader reader = command.ExecuteReader();
        List<Player> players = new List<Player>();
        while(reader.HasRows) {
            players.Add(new Player(positionId, reader.GetString(0), reader.GetString(1)));
        }

        return players;
    }
}
