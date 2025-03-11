using System;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;

namespace egzamin.Models;

public class RepoReservation
{
    private string? _connString;
    public RepoReservation(IConfiguration configuration)
    {
        _connString = configuration.GetConnectionString("mysql");
    }

    public void SaveToDb(Reservation reservation) {
        using MySqlConnection conn = new MySqlConnection(_connString);
        conn.Open();
        using MySqlCommand command = conn.CreateCommand();
        command.CommandText = $"INSERT INTO rezerwacje(nr_stolika, data_rez, liczba_osob, telefon) VALUES({reservation.TableNumber}, '{reservation.Date}', {reservation.PeopleCount}, '{reservation.PhoneNumber}')";
        command.ExecuteNonQuery();
    }

    public List<Reservation> GetAllReservations() {
        List<Reservation> reservations = new List<Reservation>();
        using MySqlConnection conn = new MySqlConnection(_connString);
        conn.Open();
        using MySqlCommand command = conn.CreateCommand();
        command.CommandText = "SELECT * FROM rezerwacje";
        using MySqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
            Reservation reservation = new Reservation();
            reservation.Id = reader.GetInt32(0);
            reservation.TableNumber = reader.GetInt32(1);
            reservation.Date = reader.GetMySqlDateTime("data_rez").ToString();
            reservation.PeopleCount = reader.GetInt32(3);
            reservation.PhoneNumber = reader.GetString(4);
            reservations.Add(reservation);
        }
        return reservations;
    }
}
