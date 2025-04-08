using MySql.Data.MySqlClient;

namespace ark2_sol.Models;

public class MyGamesRepo
{
    private readonly string? _connectionString;

    public MyGamesRepo(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public List<MyGame> GetAllGames()
    {
        using var connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM `rozgrywka` WHERE `zespol1` = 'EVG'";
        connection.Open();
        List<MyGame> games = new List<MyGame>();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            games.Add(new MyGame {
                Id = reader.GetInt32(0),
                team1 = reader.GetString(1),
                team2 = reader.GetString(2),
                result = reader.GetString(3),
                date = reader.GetDateTime(4).ToString("yyyy-MM-dd"),
            });
        }
        
        return games;
    }
}