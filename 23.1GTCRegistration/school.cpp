
#include "school.h"

//constructor
School::School(std::string name) {
    this->schoolName = name;
}


void School::PreSchedule(std::deque<Student>& tempStudents, std::deque<Course> courses) {

    //nested for loops that finds what courses the student has and changes the credit hours of the students before scheduling
    for (int i = 0; i < tempStudents.size(); ++i) {
        for (int j = 0; j < tempStudents.at(i).GetFullSchedule().size(); ++j) {
            for (int k = 0; k < courses.size(); ++k) {
                if (tempStudents.at(i).GetFullSchedule().at(j) == courses.at(k).GetCourseName()) {
                    tempStudents.at(i).SetScheduleHours(courses.at(k).GetCreditHours());
                }
            }
        }
    }
}

//manipulates data for the student schedules and the course rosters
void School::Schedule(std::deque<Student>& students, std::deque<Course>& courses) {

    //similar nested for loops to the PreSchedule function
    //finds the courses of tthe student, adds schedule hours, and increases enrollment of courses
    for (int i = 0; i < students.size(); ++i) {
        for (int j = 0; j < students.at(i).GetFullSchedule().size(); ++j) {

            //checks if the student was found
            bool studentAddedToCourse = false;
            for (int k = 0; k < courses.size(); ++k) {
                if ((students.at(i).GetFullSchedule().at(j) == courses.at(k).GetCourseName()) && (courses.at(k).GetCourseEnrollment() < courses.at(k).GetCourseMax())) {
                    students.at(i).SetScheduleHours(courses.at(k).GetCreditHours());
                    std::string studentName = students.at(i).GetLastName() + ", " + students.at(i).GetFirstName();

                    //adds students to the course's roster
                    courses.at(k).AddStudent(studentName);
                    studentAddedToCourse = true;
                }
            }

            //removes the course from the student if they could not register
            if (!studentAddedToCourse) {
                std::string courseName = students.at(i).GetFullSchedule().at(j);
                students.at(i).RemoveCourse(courseName);
            }
        }
    }
}