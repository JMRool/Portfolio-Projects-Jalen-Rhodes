
#ifndef STUDENT_H
#define STUDENT_H

#include <string>
#include "course.h"
#include <queue>

class Student {
public:

    //constructors
    Student();
    Student(std::string first_name, std::string last_name, std::string student_id);

    //manipulates the courses in the students' schedules
    void AddCourse(const std::string courseName);
    void RemoveCourse(const std::string& courseName);

    //mutator
    void SetScheduleHours(int scheduleHours);

    //accessors
    std::string GetFirstName() const;
    std::string GetLastName() const;
    std::string GetStudentID() const;
    std::deque<std::string>& GetFullSchedule();
    int GetScheduleHours() const;

private:

    // private variable declaration
    std::string first_name;
    std::string last_name;
    std::string student_id;
    std::deque<std::string> full_schedule;
    int schedule_hours;
};

#endif