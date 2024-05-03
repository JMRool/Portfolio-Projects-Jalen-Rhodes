// See https://aka.ms/new-cousing System;
using System.Collections.Generic;
using System.IO;

class Program
{
    internal class DataStructures
    {
        public static List<Student> students = new List<Student>();
        public static Student[] bestStudents = new Student[5];
        public static Stack<Student> studentStack = new Stack<Student>();
        public static Stack<Student> handedOutShirts = new Stack<Student>();
        public static LinkedList<Student> studentList = new LinkedList<Student>();
        public static Queue<Student> studentQueue = new Queue<Student>();
        public static char userOption = 'z';

        public static void AddStudentsList()
        {
            Console.WriteLine("Enter the student's ID:");
            string id = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.ID == id)
                {
                    Console.WriteLine($"Student with ID '{id}' already exists");
                    Console.WriteLine("Try Again");
                    return;
                }

            }
            Console.WriteLine("Enter the student's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the student's age:");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
            }
            else
            {
                Console.WriteLine("Invalid age input. MUST BE AN INTEGER VALUE! Please try again from the start.");
                return;
            }

            Console.WriteLine("Enter the student's favorite color:");
            string favoriteColor = Console.ReadLine();


            Student newStudent = new Student(name, age, favoriteColor, id);
            students.Add(newStudent);

            Console.WriteLine("Press 'q' to quit adding students or any other key to continue:");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        public static void AddStudentsArray()
        {
            List<Student> tempStudents = new List<Student>();
            for (int i = 0; i < bestStudents.Length; i++)
            {
                Console.WriteLine("Info for student {0}:", (i + 1));
                Console.WriteLine("Enter the student's ID:");
                string id = Console.ReadLine();

                foreach (Student student in tempStudents)
                {
                    if (student.ID == id)
                    {
                        Console.WriteLine($"Student with ID: '{id}' already exists");
                        Console.WriteLine("Try Again");
                        return;
                    }

                }
                Console.WriteLine("Enter the student's name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the student's age:");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                }
                else
                {
                    Console.WriteLine("Invalid age input. MUST BE AN INTEGER VALUE! Please try again from the start.");
                    return;
                }

                Console.WriteLine("Enter the student's favorite color:");
                string favoriteColor = Console.ReadLine();


                Student newStudent = new Student(name, age, favoriteColor, id);
                tempStudents.Add(newStudent);

            }
            bestStudents = new Student[5] { tempStudents.ElementAt(0), tempStudents.ElementAt(1), tempStudents.ElementAt(2), tempStudents.ElementAt(3), tempStudents.ElementAt(4) };

        }

        public static void AddStudentsStack()
        {
            Console.WriteLine("Enter the student's ID:");
            string id = Console.ReadLine();

            Student[] shirts = studentStack.ToArray();
            foreach (Student student in shirts)
            {
                if (student.ID == id)
                {
                    Console.WriteLine($"You've already printed the shirt for student ID: '{id}'");
                    Console.WriteLine("Try Again");
                    return;
                }

            }
            shirts = handedOutShirts.ToArray();
            foreach (Student student in shirts)
            {
                if (student.ID == id)
                {
                    Console.WriteLine($"You've alread handed out the shirt for student ID: '{id}'");
                    Console.WriteLine("Try Again");
                    return;
                }

            }

            Console.WriteLine("Enter the student's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the student's age:");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
            }
            else
            {
                Console.WriteLine("Invalid age input. MUST BE AN INTEGER VALUE! Please try again from the start.");
                return;
            }

            Console.WriteLine("Enter the student's favorite color:");
            string favoriteColor = Console.ReadLine();


            Student newStudent = new Student(name, age, favoriteColor, id);
            studentStack.Push(newStudent);

            Console.WriteLine("Press 'q' to quit printing shirts or any other key to continue:");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();


        }

        public static void AddStudentsQueue()
        {
            Console.WriteLine("Enter the student's ID:");
            string id = Console.ReadLine();
            
            Student[] tempArray = studentQueue.ToArray();
            foreach (Student student in tempArray)
            {
                if (student.ID == id)
                {
                    Console.WriteLine($"Student with ID '{id}' already exists");
                    Console.WriteLine("Try Again");
                    return;
                }

            }

            Console.WriteLine("Enter the student's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the student's age:");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
            }
            else
            {
                Console.WriteLine("Invalid age input. MUST BE AN INTEGER VALUE! Please try again from the start.");
                return;
            }

            Console.WriteLine("Enter the student's favorite color:");
            string favoriteColor = Console.ReadLine();


            Student newStudent = new Student(name, age, favoriteColor, id);
            studentQueue.Enqueue(newStudent);

            Console.WriteLine("Press 'q' to quit adding students or any other key to continue:");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        public static void AddStudentsLinkedList()
        {
            Console.WriteLine("Enter the student's ID:");
            string id = Console.ReadLine();

            Student[] studentLine = studentList.ToArray();
            foreach (Student student in studentLine)
            {
                if (student.ID == id)
                {
                    Console.WriteLine($"You've already added the student with ID '{id}' to this line.");
                    Console.WriteLine("Try Again");
                    return;
                }

            }

            Console.WriteLine("Enter the student's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the student's age:");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
            }
            else
            {
                Console.WriteLine("Invalid age input. MUST BE AN INTEGER VALUE! Please try again from the start.");
                return;
            }

            Console.WriteLine("Enter the student's favorite color:");
            string favoriteColor = Console.ReadLine();


            Student newStudent = new Student(name, age, favoriteColor, id);
            studentList.AddLast(newStudent);

            Console.WriteLine("Press 'q' to quit printing shirts or any other key to continue:");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        public static void SwapStudents(string studentID1, string studentID2)
        {
            if (studentID1 == studentID2)
            {
                Console.WriteLine("Try again with 2 different student IDs.");
                return;
            }

            if (studentList.Count < 2)
            {
                Console.WriteLine("Try again with at least 2 students already in line.");
                return;
            }
            LinkedListNode<Student> node1 = FindStudentNode(studentID1);
            LinkedListNode<Student> node2 = FindStudentNode(studentID2);

            if ((node1 != null) && (node2 != null))
            {
                Student temp = node1.Value;
                node1.Value = node2.Value;
                node2.Value = temp;
            }
            else
            {
                Console.WriteLine("One or both students not found in the list, Try Again!");
            }
        }

        public static LinkedListNode<Student> FindStudentNode(string studentID)
        {
            foreach (var node in studentList)
            {
                if (node.ID.ToLower() == studentID.ToLower())
                {
                    return studentList.Find(node);
                }
            }
            return null;
        }

        public static void ListStudents()
        {
            Console.WriteLine();
            Console.WriteLine("Menu\n'a' - Add more students to class:\n'v' - View students in the List:\n'e' - Edit a student's Info:\n'r' - Remove a student:\n'c' - Clear all students from the List:\n'q' - Quit\n");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
            while (char.ToLower(userOption) != 'q')
            {
                if (char.ToLower(userOption) == 'v')
                {
                    foreach (Student student in students)
                    {
                        Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Age: {student.Age}, Favorite Color: {student.FavoriteColor}");
                    }
                    if (students.Count == 0)
                    {
                        Console.WriteLine("No students in list");
                    }
                    Console.WriteLine();
                }
                else if (char.ToLower(userOption) == 'a')
                {
                    while (char.ToLower(userOption) != 'q')
                    {
                        AddStudentsList();
                    }
                }
                else if (char.ToLower(userOption) == 'e')
                {
                    Console.WriteLine("Enter the Student's ID\n");
                    string searchID = Console.ReadLine();
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
                            if (students[i].ID.ToLower() == searchID.ToLower())
                            {
                                students[i].Name = newInfo;
                                studentFound = true;
                                Console.WriteLine("Student Info Edited!\n");
                            }
                        }
                        if (!studentFound)
                        {
                            Console.WriteLine("Student Not Found, Check spelling...\n");
                        }
                    }
                    else if (char.ToLower(userOption) == 'a')
                    {
                        Console.WriteLine("Enter the Student's New Age\n");
                        if (int.TryParse(Console.ReadLine(), out int newInfo))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Invalid age input. MUST BE AN INTEGER VALUE! Please try again from the start.");
                            return;
                        }
                        Console.WriteLine();
                        bool studentFound = false;
                        for (int i = 0; i < students.Count; i++)
                        {
                            if (students[i].ID.ToLower() == searchID.ToLower())
                            {
                                students[i].Age = newInfo;
                                studentFound = true;
                                Console.WriteLine("Student Info Edited!\n");
                            }
                        }
                        if (!studentFound)
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
                            if (students[i].ID.ToLower() == searchID.ToLower())
                            {
                                students[i].FavoriteColor = newInfo;
                                studentFound = true;
                                Console.WriteLine("Student Info Edited!\n");
                            }
                        }
                        if (!studentFound)
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
                    Console.WriteLine("Enter the Student's ID\n");
                    string removeID = Console.ReadLine();
                    Console.WriteLine();

                    bool studentFound = false;
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].ID.ToLower() == removeID.ToLower())
                        {
                            students.RemoveAt(i);
                            studentFound = true;
                            Console.WriteLine($"{removeID} Removed!\n");
                        }
                    }
                    if (!studentFound)
                    {
                        Console.WriteLine("Student Not Found, Try Again...\n");
                    }
                }
                else if (char.ToLower(userOption) == 'c')
                {
                    students.Clear();
                    Console.WriteLine("List Cleared\n");
                }
                else if (char.ToLower(userOption) != 'q')
                {
                    Console.WriteLine("Invalid Option\n");
                }
                Console.WriteLine();
                Console.WriteLine("Menu\n'a' - Add more students to class:\n'v' - View students in the List:\n'e' - Edit a student's Info:\n'r' - Remove a student:\n'c' - Clear all students from the List:\n'q' - Quit\n");
                userOption = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }

        public static void ArrayStudents()
        {
            Console.WriteLine();
            Console.WriteLine("Menu\n'a' - Add Students to Top 5 Students Array:\n'c' - Clear Top 5 Students Array:\n'v' - View Top 5 Students:\n'q' - Quit\n");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
            while (char.ToLower(userOption) != 'q')
            {
                if (char.ToLower(userOption) == 'a')
                {
                    if (bestStudents[0] != null)
                    {
                        Console.WriteLine("Array full, you must clear it first");
                    }
                    else
                    {
                        AddStudentsArray();
                    }

                }
                else if (char.ToLower(userOption) == 'c')
                {
                    bestStudents = new Student[5];
                }
                else if (char.ToLower(userOption) == 'v')
                {
                    if (bestStudents[0] == null)
                    {
                        Console.WriteLine("No students in Array");
                    }
                    else
                    {
                        foreach (Student student in bestStudents)
                        {
                            Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Age: {student.Age}, Favorite Color: {student.FavoriteColor}");
                        }
                    }
                }
                else if (char.ToLower(userOption) != 'q')
                {
                    Console.WriteLine("Invalid Option\n");
                }
                Console.WriteLine();
                Console.WriteLine("Menu\n'a' - Add Students to Top 5 Students Array:\n'c' - Clear Top 5 Students Array:\n'v' - View Top 5 Students:\n'q' - Quit\n");
                userOption = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }

        public static void StackStudents()
        {
            Console.WriteLine();
            Console.WriteLine("Menu\n'p' - Print a new student t shirt and add it to the stack:\n'c' - Check if you have already printed a student's shirt:\n'h' - Hand out a t shirt from the stack:\n'd' - Destroy all t shirts:\n'q' - Quit\n");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
            while (char.ToLower(userOption) != 'q')
            {
                if (char.ToLower(userOption) == 'c')
                {
                    Console.WriteLine("Enter the student's ID:");
                    string id = Console.ReadLine();

                    Student[] shirts = studentStack.ToArray();
                    foreach (Student student in shirts)
                    {
                        if (student.ID == id)
                        {
                            Console.WriteLine($"You've already printed the shirt for student ID: '{id}'");
                            return;
                        }

                    }
                    shirts = handedOutShirts.ToArray();
                    foreach (Student student in shirts)
                    {
                        if (student.ID == id)
                        {
                            Console.WriteLine($"You've alread handed out the shirt for student ID: '{id}'");
                            return;
                        }

                    }

                }
                else if (char.ToLower(userOption) == 'p')
                {
                    while (char.ToLower(userOption) != 'q')
                    {
                        AddStudentsStack();
                    }
                }
                else if (char.ToLower(userOption) == 'h')
                {
                    if (studentStack.Count != 0)
                    {
                        handedOutShirts.Push(studentStack.Pop());
                        Console.WriteLine("You just handed out the shirt of student: '{0}'", handedOutShirts.Peek().ID);
                        if (handedOutShirts.Count == 0)
                        {
                            Console.WriteLine("You Are All Done!!!\n");
                        }
                        else
                        {
                            Console.WriteLine("Number of shirts left to hand out: {0}\n", studentStack.Count);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Shirts in Stack\n");
                    }

                }
                else if (char.ToLower(userOption) == 'd')
                {
                    studentStack.Clear();
                    Console.WriteLine("Stack Cleared\n");
                }
                else if (char.ToLower(userOption) != 'q')
                {
                    Console.WriteLine("Invalid Option\n");
                }
                Console.WriteLine();
                Console.WriteLine("Menu\n'p' - Print a new student t shirt and add it to the stack:\n'c' - Check if you have already printed a student's shirt:\n'h' - Hand out a t shirt from the stack:\n'd' - Destroy all t shirts:\n'q' - Quit\n");
                userOption = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }

        public static void QueueStudents()
        {
            Console.WriteLine();
            Console.WriteLine("Menu\n'a' - Add student to lunch line:\n'l' - Student leaves lunch line:\n'r' - Remove all students from lunch line:\n'q' - Quit\n");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
            while (char.ToLower(userOption) != 'q')
            {
                if (char.ToLower(userOption) == 'a')
                {
                    while (char.ToLower(userOption) != 'q')
                    {
                        AddStudentsQueue();
                    }
                }
                else if (char.ToLower(userOption) == 'l')
                {
                    if (studentQueue.Count != 0)
                    {
                        Student tempStudent = studentQueue.Dequeue();
                        Console.WriteLine("Student of ID '{0}' just left the queue!", tempStudent.ID);
                        if (studentQueue.Count == 0)
                        {
                            Console.WriteLine("All students have left the queue!!!\n");
                        }
                        else
                        {
                            Console.WriteLine("{0} students left in the queue!\n", studentQueue.Count);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No students in lunch queue\n");
                    }

                }
                else if (char.ToLower(userOption) == 'r')
                {
                    studentQueue.Clear();
                    Console.WriteLine("Queue Cleared\n");
                }
                else if (char.ToLower(userOption) != 'q')
                {
                    Console.WriteLine("Invalid Option\n");
                }
                Console.WriteLine();
                Console.WriteLine("Menu\n'a' - Add student to lunch line:\n'l' - Student leaves lunch line:\n'r' - Remove all students from lunch line:\n'q' - Quit\n");
                userOption = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }

        public static void LinkedListStudents()
        {
            Console.WriteLine();
            Console.WriteLine("Menu\n'a' - Add student to single file line:\n'p' - Pull a student out of line:\n'r' - Remove all students from line:\n's' - Swap the line position of two students\n'q' - Quit\n");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
            while (char.ToLower(userOption) != 'q')
            {
                if (char.ToLower(userOption) == 's')
                {
                    Console.WriteLine("Enter the first student's ID:");
                    string firstID = Console.ReadLine();

                    Console.WriteLine("Enter the second student's ID:");
                    string secondID = Console.ReadLine();

                    SwapStudents(firstID, secondID);
                }
                else if (char.ToLower(userOption) == 'a')
                {
                    while (char.ToLower(userOption) != 'q')
                    {
                        AddStudentsLinkedList();
                    }
                }
                else if (char.ToLower(userOption) == 'l')
                {
                    Console.WriteLine("Enter the Student's ID\n");
                    string removeID = Console.ReadLine();
                    Console.WriteLine();
                    LinkedListNode<Student> currentNode = studentList.First;

                    bool studentFound = false;
                    while (currentNode != null)
                    {
                        if (currentNode.Value.ID.ToLower() == removeID.ToLower())
                        {
                            studentList.Remove(currentNode);
                            studentFound = true;
                            Console.WriteLine($"{removeID} Removed!");
                            break;
                        }
                        currentNode = currentNode.Next;
                    }
                    if (!studentFound)
                    {
                        Console.WriteLine("Student Not Found, Try Again...\n");
                    }

                }
                else if (char.ToLower(userOption) == 'r')
                {
                    studentList.Clear();
                    Console.WriteLine("Linked List Cleared\n");
                }
                else if (char.ToLower(userOption) != 'q')
                {
                    Console.WriteLine("Invalid Option\n");
                }
                Console.WriteLine();
                Console.WriteLine("Menu\n'a' - Add student to single file line:\n'l' - Student leaves line:\n'r' - Remove all students from line:\n's' - Swap the line position of two students\n'q' - Quit\n");
                userOption = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }

        public static void PrintAll()
        {
            Console.WriteLine("\nStudent in Array");
            
            if (bestStudents[0] == null)
            {
                Console.WriteLine("No students in Array");
            }
            else
            {
                foreach (Student student in bestStudents)
                {
                    Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Age: {student.Age}, Favorite Color: {student.FavoriteColor}");
                }
            }

            Console.WriteLine("\nStudents in List");
            
            if (students.Count == 0)
            {
                Console.WriteLine("No students in list");
            }
            else
            {
                foreach (Student student in students)
                {
                    Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Age: {student.Age}, Favorite Color: {student.FavoriteColor}");
                }
            }

            Console.WriteLine("\nStudent shirts in Stack");

            if (studentStack.Count == 0)
            {
                Console.WriteLine("No students in Stack");
            }
            else
            {
                Student[] tempArray = studentStack.ToArray();
                foreach (Student student in tempArray)
                {
                    Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Age: {student.Age}, Favorite Color: {student.FavoriteColor}");
                }
            }

            Console.WriteLine("\nStudent shirts in handed out");

            if (handedOutShirts.Count == 0)
            {
                Console.WriteLine("No shirts handed out");
            }
            else
            {
                Student[] tempArray = handedOutShirts.ToArray();
                foreach (Student student in tempArray)
                {
                    Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Age: {student.Age}, Favorite Color: {student.FavoriteColor}");
                }
            }

            Console.WriteLine("\nStudents in Queue");

            if (studentQueue.Count == 0)
            {
                Console.WriteLine("No students in Queue");
            }
            else
            {
                Student[] tempArray = studentQueue.ToArray();
                foreach (Student student in tempArray)
                {
                    Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Age: {student.Age}, Favorite Color: {student.FavoriteColor}");
                }
            }

            Console.WriteLine("\nStudents in Linked List");

            if (studentList.Count == 0)
            {
                Console.WriteLine("No students in Linked List");
            }
            else
            {
                Student[] tempArray = studentList.ToArray();
                foreach (Student student in tempArray)
                {
                    Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Age: {student.Age}, Favorite Color: {student.FavoriteColor}");
                }
            }


        }
        public static void Main(string[] args)
        {

            Console.WriteLine("Menu\n'A' - Array student:\n'L' - List Student:\n'S' - Stack Students:\n'U' - Queue Students:\n'D' - Linked List Student:\n'P' - Print All\n'Q' - Quit\n");
            userOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
            while (char.ToLower(userOption) != 'q')
            {
                if (char.ToLower(userOption) == 'a')
                {
                    while (char.ToLower(userOption) != 'q')
                    {
                        ArrayStudents();
                    }

                }
                else if (char.ToLower(userOption) == 'l')
                {
                    while (char.ToLower(userOption) != 'q')
                    {
                        ListStudents();
                    }
                }
                else if (char.ToLower(userOption) == 's')
                {

                    while (char.ToLower(userOption) != 'q')
                    {
                        StackStudents();
                    }

                }
                else if (char.ToLower(userOption) == 'u')
                {
                    while (char.ToLower(userOption) != 'q')
                    {
                        QueueStudents();
                    }
                }
                else if (char.ToLower(userOption) == 'd')
                {
                    while (char.ToLower(userOption) != 'q')
                    {
                        LinkedListStudents();
                    }
                }
                else if (char.ToLower(userOption) == 'p')
                {
                    PrintAll();
                }
                else if (char.ToLower(userOption) != 'q')
                {
                    Console.WriteLine("Invalid Option\n");
                }
                Console.WriteLine();
                Console.WriteLine("Menu\n'A' - Array student:\n'L' - List Student:\n'S' - Stack Students:\n'U' - Queue Students:\n'D' - Linked List Student:\n'P' - Print All\n'Q' - Quit\n");
                userOption = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }
    }
}