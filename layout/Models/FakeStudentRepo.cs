using System;
using layout.Models.Abstractions;

namespace layout.Models;

public class FakeStudentRepo : IStudentRepo
{
    private List<Student> _students = new List<Student> {
        new(1, "Jan", "Kowalski", 24),
        new(2, "Adam", "Dudkowski", 21),
        new(3, "Błażej", "Baran", 16),
    };
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
        return _students;
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
