using System;
using layout.Models.Abstractions;
using MySql.Data.MySqlClient;

namespace layout.Models;

public class MySqlStudentRepo : IStudentRepo
{
    private readonly string? _connectionString;
    public MySqlStudentRepo(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddStudent(Student student)
    {
        using var connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO students (first_name, last_name, age) values(" + $"'{student.FirstName}', '{student.LastName}', '{student.Age}'" + ")";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void DeleteStudent(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "DELETE FROM students WHERE id="+$"'{id}'"+"";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Student> GetAllStudents()
    {
        using var connection = new MySqlConnection(_connectionString);
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM students";
        connection.Open();
        List<Student> students = new List<Student>();
        var reader = command.ExecuteReader();
        while(reader.Read()) {
            students.Add(
                new Student {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Age = reader.GetInt32(3)
                }
            );
        }
        connection.Close();
        return students;
    }

    public Student GetStudentById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }
}
