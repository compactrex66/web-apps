using System;

namespace layout.Models.Abstractions;

public interface IStudentRepo
{
    List<Student> GetAllStudents();
    Student GetStudentById(int id);
    void AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(int id);
}