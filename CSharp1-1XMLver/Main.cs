using CSharp1_1Xmlver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CSharp1_1Xmlver
{
    internal class Program
    {
        public static List<Student> students = new List<Student>();
        public static char userOption = 'z';
        public static string customPath = @"D:\jmich\Documents\student_xml";

        public static void SaveStudentsToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (TextWriter writer = new StreamWriter(customPath))
            {
                serializer.Serialize(writer, students);
            }
            Console.WriteLine();
        }

        public static void LoadStudentsFromXml()
        {
            if (File.Exists(customPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                using (TextReader reader = new StreamReader(customPath))
                {
                    students = (List<Student>)serializer.Deserialize(reader);
                    Console.WriteLine("Students loaded from D:\\jmich\\Documents");
                }
            }
            else
            {
                Console.WriteLine("No existing students.xml file found.");
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
            LoadStudentsFromXml();

            Console.WriteLine("Menu\n'a' - Add more students:\n'v' - View students in the Xml:\n'e' - Edit a student's Info:\n'r' - Remove a student:\n'c' - Clear all students from the Xml:\n'q' - Quit\n");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();

            while (char.ToLower(userOption) != 'q')
            {
                if (char.ToLower(userOption) == 'v')
                {
                    LoadStudentsFromXml();
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
                    SaveStudentsToXml();
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
                            SaveStudentsToXml();
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
                            SaveStudentsToXml();
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
                            SaveStudentsToXml();
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
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].Name.ToLower() == removeName.ToLower())
                        {
                            students.RemoveAt(i);
                            studentFound = true;
                            Console.WriteLine($"{removeName} Removed!\n");
                        }
                    }
                    if (studentFound)
                    {
                        SaveStudentsToXml();
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
                    SaveStudentsToXml();
                }
                else if (char.ToLower(userOption) != 'q')
                {
                    Console.WriteLine("Invalid Option\n");
                }

                Console.WriteLine("Menu\n'a' - Add more students:\n'v' - View students in the Xml:\n'e' - Edit a student's Info:\n'r' - Remove a student:\n'c' - Clear all students from the Xml:\n'q' - Quit\n");
                userOption = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }
    }
}

