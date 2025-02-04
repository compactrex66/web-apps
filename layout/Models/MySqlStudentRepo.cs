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
        throw new NotImplementedException();
    }

    public void DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAllStudents()
    {
        using var connection = new MySqlConnection(_connectionString);
        MySqlCommand commnad = connection.CreateCommand();
        commnad.CommandText = "SELECT * FROM students";
        connection.Open();
        List<Student> students = new List<Student>();
        var reader = commnad.ExecuteReader();
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
