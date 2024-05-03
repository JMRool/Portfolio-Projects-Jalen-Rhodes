using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string ID { get; set; }
    public string FavoriteColor { get; set; }

    public Student()
    {
        Name = "null";
        Age = 0;
        FavoriteColor = "RGB";
        ID = "null";

    }
    public Student(string name, int age, string color, string id)
    {
        Name = name;
        Age = age;
        FavoriteColor = color;
        ID = id;
    }

}
