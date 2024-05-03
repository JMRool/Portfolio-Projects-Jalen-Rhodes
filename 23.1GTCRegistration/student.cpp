
#include <string>
#include <iostream>
#include <queue>
#include "student.h"

//constructors
Student::Student() {
    this->first_name = "none";
    this->last_name = "none";
    this->student_id = "none";
    this->schedule_hours = 0;
}

Student::Student(std::string firstName, std::string lastName, std::string studentID) {
    this->first_name = firstName;
    this->last_name = lastName;
    this->student_id = studentID;
    this->schedule_hours = 0;
}

//accessors
std::string Student::GetFirstName() const{
    return first_name;
}

std::string Student::GetLastName() const{
    return last_name;
}

std::string Student::GetStudentID() const{
    return student_id;
}

std::deque<std::string>& Student::GetFullSchedule() {
    return full_schedule;
}

int Student::GetScheduleHours() const {
    return schedule_hours;
}

//mutator
void Student::SetScheduleHours(int scheduleHours) {
    this->schedule_hours += scheduleHours;
}

void Student::AddCourse(std::string courseName) {
    //add student to the schedule deque
    full_schedule.push_back(courseName);
}

void Student::RemoveCourse(const std::string& courseName) {
    
    //gets a reference to the student's schedule deque
    std::deque<std::string>& schedule = GetFullSchedule();

    //finds the course in the schedule deque and remove it
    for (auto i = schedule.begin(); i != schedule.end(); ++i) {
        if (*i == courseName) {
            schedule.erase(i);
            //exits the loop once the course is found and removed
            break;
        }
    }
}