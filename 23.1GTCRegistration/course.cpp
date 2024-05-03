
#include <string>
#include <queue>
#include <iostream>
#include "course.h"

//constructors
Course::Course() {
    this->course_name = "none";
    this->credit_hours = 0;
    this->course_max = 0;
    this->course_enrollment = 0;
}

Course::Course(std::string courseName, int creditHours, int courseMax) {
    this->course_name = courseName;
    this->credit_hours = creditHours;
    this->course_max = courseMax;
    this->course_enrollment = 0;
}

//accessors
std::string Course::GetCourseName() const{
    return course_name;
}

int Course::GetCreditHours() const{
    return credit_hours;
}

int Course::GetCourseMax() const{
    return course_max;
}

int Course::GetCourseEnrollment() const{
    return course_enrollment;
}

std::deque<std::string>& Course::GetRoster() {
    return roster;
}

void Course::AddStudent(const std::string studentName) {

    //add student to the deque
    roster.push_back(studentName);

    //increase enrollment
    ++course_enrollment;
}