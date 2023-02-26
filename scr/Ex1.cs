using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Ex1
{
    /// <summary>
    /// LINQ використовує лямбда-вирази для фільтрування та обчислення
    /// </summary>
    public static void Run()
    {
        // шлях до файлу CSV
        string filePath = "students.csv";

        // Читання файлу CSV і створення списку об’єктів Student
        List<Student> students = File.ReadAllLines(filePath)
                                      .Skip(1) // Пропускаємо рядок заголовка
                                      .Select(line => line.Split(','))
                                      .Select(fields => new Student
                                      {
                                          Id = int.Parse(fields[0]),
                                          Name = fields[1],
                                          Grade = int.Parse(fields[2]),
                                          GPA = double.Parse(fields[3])
                                      })
                                      .ToList();

        // Фільтруємо список студентів за класом за допомогою лямбда-виразу
        List<Student> bestStudents = students.Where(s => s.GPA >= 90)
                                                  .ToList();

        // Виводимо відфільтрований список студентів
        foreach (Student student in bestStudents)
        {
            Console.WriteLine($"Ім'я: {student.Name}, Клас: {student.Grade}, середній бал: {student.GPA}");
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public double GPA { get; set; }
    }
}
