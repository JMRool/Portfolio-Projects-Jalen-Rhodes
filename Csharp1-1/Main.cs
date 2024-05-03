using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Csharp1_1
{
    internal class Program
    {
        public static List<Student> students = new List<Student>();
        public static char userOption = 'z';
        public static string customPath = @"D:\jmich\Documents\students.json";

        public static void Save()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(students, options);
            File.WriteAllText(customPath, json);
            Console.WriteLine();
        }

        public static void Load()
        {
            if (File.Exists(customPath))
            {
                string json = File.ReadAllText(customPath);
                students = JsonSerializer.Deserialize<List<Student>>(json);
                Console.WriteLine("Students loaded from D:\\jmich\\Documents");
            }
            else
            {
                Console.WriteLine("No students.json file found...");
            }
        }

        public static void AddStudents()
        {
            Console.WriteLine("Enter the student's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the student's age:");
            int age = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the student's favorite color:");
            string favoriteColor = Console.ReadLine();

            Student newStudent = new Student(name, age, favoriteColor);
            students.Add(newStudent);

            Console.WriteLine("Press 'q' to quit or any other key to continue:");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            Load();

            Console.WriteLine("Menu\n'a' - Add more students:\n'v' - View students in the Json:\n'e' - Edit a student's Info:\n'r' - Remove a student:\n'c' - Clear all students from the Json:\n'q' - Quit\n");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();

            while (char.ToLower(userOption) != 'q')
            {
                if (char.ToLower(userOption) == 'v')
                {
                    Load();
                    foreach (Student student in students)
                    {
                        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Favorite Color: {student.FavoriteColor}");
                    }
                    Console.WriteLine();
                }
                else if (char.ToLower(userOption) == 'a')
                {
                    while (char.ToLower(userOption) != 'q')
                    {
                        AddStudents();
                    }
                    Save();
                }
                else if (char.ToLower(userOption) == 'e')
                {
                    Console.WriteLine("Enter the Student's Name\n");
                    string searchName = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Menu\n'n' - Edit student name:\n'a' - Edit student age:\n'c' - Edit student color:\n");
                    userOption = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (char.ToLower(userOption) == 'n')
                    {
                        Console.WriteLine("Enter the Student's New Name\n");
                        string newInfo = Console.ReadLine();
                        Console.WriteLine();
                        bool studentFound = false;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].Name.ToLower() == searchName.ToLower())
                            {
                                students[i].Name = newInfo;
                                studentFound = true;
                                Console.WriteLine("Student Info Edited!\n");
                            }
                        }
                        if (studentFound)
                        {
                            Save();
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found, Check spelling...\n");
                        }
                    }
                    else if (char.ToLower(userOption) == 'a')
                    {
                        Console.WriteLine("Enter the Student's New Age\n");
                        int newInfo = Int32.Parse(Console.ReadLine());
                        Console.WriteLine();
                        bool studentFound = false;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].Name.ToLower() == searchName.ToLower())
                            {
                                students[i].Age = newInfo;
                                studentFound = true;
                                Console.WriteLine("Student Info Edited!\n");
                            }
                        }
                        if (studentFound)
                        {
                            Save();
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found, Check spelling...\n");
                        }
                    }
                    else if (char.ToLower(userOption) == 'c')
                    {
                        Console.WriteLine("Enter the Student's New Favorite Color\n");
                        string newInfo = Console.ReadLine();
                        Console.WriteLine();
                        bool studentFound = false;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].Name.ToLower() == searchName.ToLower())
                            {
                                students[i].FavoriteColor = newInfo;
                                studentFound = true;
                                Console.WriteLine("Student Info Edited!\n");
                            }
                        }
                        if (studentFound)
                        {
                            Save();
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found, Check spelling...\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option\n");
                    }

                }
                else if (char.ToLower(userOption) == 'r')
                {
                    Console.WriteLine("Enter the Student's Name\n");
                    string removeName = Console.ReadLine();
                    Console.WriteLine();

                    bool studentFound = false;
                    for (int i = 0; i < students.Count; i++) {
                        if (students[i].Name.ToLower() == removeName.ToLower())
                        {
                            students.RemoveAt(i);
                            studentFound = true;
                            Console.WriteLine($"{removeName} Removed!\n");
                        }
                    }
                    if (studentFound)
                    {
                        Save();
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found, Check spelling...\n");
                    }
                }
                else if (char.ToLower(userOption) == 'c')
                {
                    students.Clear();
                    Console.WriteLine("File Cleared\n");
                    Save();
                }
                else if (char.ToLower(userOption) != 'q')
                {
                    Console.WriteLine("Invalid Option\n");
                }

                Console.WriteLine("Menu\n'a' - Add more students:\n'v' - View students in the Json:\n'e' - Edit a student's Info:\n'r' - Remove a student:\n'c' - Clear all students from the Json:\n'q' - Quit\n");
                userOption = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }
    }
}

