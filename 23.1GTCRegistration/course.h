
#ifndef COURSE_H
#define COURSE_H

#include <string>
#include <queue>

class Course {
public:
    //constructors
    Course(std::string course_name, int credit_hours, int course_max);
    Course();

    //manipulates the roster
    void AddStudent(const std::string studentName);

    //accessors
    std::string GetCourseName() const;
    int GetCreditHours() const;
    int GetCourseMax() const;
    int GetCourseEnrollment() const;
    std::deque<std::string>& GetRoster();


private:

    // private variable declaration
    std::string course_name;
    int credit_hours;
    int course_max;
    int course_enrollment;
    std::deque<std::string> roster;
 
};

#endif
