#include <iostream>
#include <sstream>
#include <fstream>
#include <string>
#include <deque>
#include <algorithm>
#include "utils.h"

using namespace std;

//comparison functions
bool CompareByLastName(const Student& s1, const Student& s2) {
    return s1.GetLastName() < s2.GetLastName();
}
bool CompareByCourseName(const Course& c1, const Course& c2) {
    return c1.GetCourseName() < c2.GetCourseName();
}
bool CompareStrings(const string& s1, const string& s2) {
    return s1 < s2;
}

int main()
{
    //strings for the file names
    string studentFileName, courseFileName;

    //deques of objects to hold student and course data
    deque<Course> courses;
    deque<Student> students;

    //create school object so that the schedule functions can be used later
    School GTC("GwinnettTech");

    //get file names forom the user
    cin >> courseFileName;
    cin >> studentFileName;

    //open file for reading
    ifstream courseFile(courseFileName);

    //check if it opened
    if (!courseFile) {
        cout << "Error: Could not open file." << endl;
        return 1;
    }

    string course_code;
    int credit_hours, max_enrollment;
    while (courseFile >> course_code >> credit_hours >> max_enrollment) {

        //process the data
        courses.push_back({ course_code, credit_hours, max_enrollment });
    }

    //close file after reading
    courseFile.close();

    //open new file
    ifstream studentFile(studentFileName);

    //check if it opened
    if (!studentFile) {
        cout << "Error: Could not open file." << endl;
        return 1;
    }
    else if (studentFile.is_open()) {

        string line;
        while (getline(studentFile, line)) {

            //parse the line into fields using stringstream and comma as delimiter
            stringstream ss(line);
            string first_name, last_name, student_id, course_code;
            getline(ss, last_name, ',');
            getline(ss, first_name, ',');
            getline(ss, student_id, ',');
            getline(ss, course_code, ',');

            //find the corresponding student object in the deque, or create a new one
            bool found = false;
            for (int i = 0; i < students.size(); i++) {

                //check if everthing except the course is the same about the students
                if ((students[i].GetStudentID() == student_id) && (students[i].GetLastName() == last_name) && (students[i].GetFirstName() == first_name)) {
                    students[i].AddCourse(course_code);
                    found = true;
                    break;
                }
            }
            if (!found) {
                Student student(first_name, last_name, student_id);
                student.AddCourse(course_code);
                students.push_back(student);
            }
        }

        //close file after reading
        studentFile.close();
    }

    //creat temp deque so that the real students have no hours yet
    deque<Student> tempStudents(students);

    //pre schedul the temp student so that the have hourse for the printing
    GTC.PreSchedule(tempStudents, courses);

    //temp deque for sorting courses
    deque<Course> tempCourses(courses);

    //sorts the deques by name
    sort(tempStudents.begin(), tempStudents.end(), CompareByLastName);
    sort(tempCourses.begin(), tempCourses.end(), CompareByCourseName);

    //print the ccourses and student before
    cout << "All Courses - Before Scheduling" << endl;
    cout << "course Name:credit hours:enrollment:max" << endl;
    cout << "========================================" << endl;
    for (int i = 0; i < tempCourses.size(); ++i) {
        cout << tempCourses.at(i).GetCourseName() << ":" << tempCourses.at(i).GetCreditHours() << ":" << tempCourses.at(i).GetCourseEnrollment() << ":" << tempCourses.at(i).GetCourseMax();
        cout << endl;
    }
    cout << endl << endl;
    cout << "All Students - Before Scheduling" << endl;
    cout << "last Name, First Name:Student ID:Hours" << endl;
    cout << "========================================" << endl;
    for (int i = 0; i < tempStudents.size(); ++i) {
        cout << tempStudents.at(i).GetLastName() << ", " << tempStudents.at(i).GetFirstName() << ":" << tempStudents.at(i).GetStudentID() << ":";
        cout << tempStudents.at(i).GetScheduleHours();
        cout << endl;
    }

    cout << endl << endl;

    //do real scheduling on the real student and course deques
    GTC.Schedule(students, courses);

    //sort the deques for printing
    sort(students.begin(), students.end(), CompareByLastName);
    sort(courses.begin(), courses.end(), CompareByCourseName);
    
    //sort the student schedules
    for (int i = 0; i < students.size(); ++i) {
        sort(students.at(i).GetFullSchedule().begin(), students.at(i).GetFullSchedule().end(), CompareStrings);
    }

    //sort the course rosters
    for (int i = 0; i < courses.size(); ++i) {
        sort(courses.at(i).GetRoster().begin(), courses.at(i).GetRoster().end(), CompareStrings);
    }

    //print the rosters
    cout << "All Course Rosters" << endl << endl;
    for (int i = 0; i < courses.size(); ++i) {
        cout << "Course Roster: " << courses.at(i).GetCourseName() << endl;
        cout << "========================================" << endl;

        //checks if the course has any students
        if (courses.at(i).GetRoster().size() == 0) {
            cout << "No students registered" << endl;
        }
        else {

            //print the students numbered
            for (int j = 0; j < courses.at(i).GetRoster().size(); ++j) {
                cout << (j + 1) << ". " << courses.at(i).GetRoster().at(j) << endl;
            }
        }
        cout << endl;
    }
    cout << endl << endl;

    //print the schedules
    cout << "All Student Schedules" << endl << endl;
    for (int i = 0; i < students.size(); ++i) {
        cout << students.at(i).GetLastName() << ", " << students.at(i).GetFirstName() << "'s Schedule" << endl;
        cout << "ID: " << students.at(i).GetStudentID() << endl;
        cout << "Hours: " << students.at(i).GetScheduleHours() << endl;
        cout << "========================================" << endl;

        //checks if the students have any courses
        if (students.at(i).GetScheduleHours() == 0) {
            cout << "No Schedule" << endl;
        }
        else {
            
            //prints the courses
            for (int j = 0; j < students.at(i).GetFullSchedule().size(); ++j) {
                cout << students.at(i).GetFullSchedule().at(j) << endl;
            }
        }
        cout << endl;
    }
    cout << endl;

    //print the student and course deques after aall scheduling is over
    cout << "All Students - After Scheduling" << endl;
    cout << "last Name, First Name:Student ID:Hours" << endl;
    cout << "========================================" << endl;
    for (int i = 0; i < students.size(); ++i) {
        cout << students.at(i).GetLastName() << ", " << students.at(i).GetFirstName() << ":" << students.at(i).GetStudentID() << ":";
        cout << students.at(i).GetScheduleHours();
        cout << endl;
    }
    cout << endl << endl;
    cout << "All Courses - After Scheduling" << endl;
    cout << "course Name:credit hours:enrollment:max" << endl;
    cout << "========================================" << endl;
    for (int i = 0; i < courses.size(); ++i) {
        cout << courses.at(i).GetCourseName() << ":" << courses.at(i).GetCreditHours() << ":" << courses.at(i).GetCourseEnrollment() << ":" << courses.at(i).GetCourseMax();
        cout << endl;
    }

    return 0;
}