
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Xml.Linq;

[Serializable]
public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string FavoriteColor { get; set; }

    public Student()
    {
        Name = "null";
        Age = 0;
        FavoriteColor = "RGB";

    }
    public Student(string name, int age, string color)
    {
        Name = name;
        Age = age;
        FavoriteColor = color;
    }
}
