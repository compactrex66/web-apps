using System;
using MySql.Data.MySqlClient;

namespace layout.Models;

public class GamesRepo
{
    private readonly string? _connectionString;
    public GamesRepo(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddGame(Game game)
    {
        using var connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO games (game_title, developer, price) values(" + $"'{game.GameTitle}', '{game.Developer}', '{game.Price}'" + ")";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void DeleteGame(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "DELETE FROM games WHERE id="+$"'{id}'"+"";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Game> GetAllGames()
    {
        using var connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM games";
        connection.Open();
        List<Game> games = new List<Game>();
        var reader = command.ExecuteReader();
        while(reader.Read()) {
            games.Add(
                new Game {
                    Id = reader.GetInt32(0),
                    GameTitle = reader.GetString(1),
                    Developer = reader.GetString(2),
                    Price = reader.GetDouble(3)
                }
            );
        }
        connection.Close();
        return games;
    }

    public Game GetGameById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateGame(Game game)
    {
        throw new NotImplementedException();
    }
}
