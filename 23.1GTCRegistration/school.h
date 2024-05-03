
#ifndef SCHOOL_H
#define SCHOOL_H

#include <iostream>
#include <sstream>
#include <fstream>
#include <string>
#include <deque>
#include <algorithm>

#include "course.h"
#include "student.h"


class School {
public:
    //constructor
    School(std::string schoolName);

    //scheduling function that handles the school's data
    void Schedule(std::deque<Student>& students, std::deque<Course>& courses);
    void PreSchedule(std::deque<Student>& students, std::deque<Course> courses);

private:

    //private member vasribale for constructor
    std::string schoolName;
};

#endif
