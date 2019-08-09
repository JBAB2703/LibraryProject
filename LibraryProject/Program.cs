﻿using System;
using StudentLibrary;
//using JesseUtilitiesLibrary;

namespace LibraryProject {

    class Program {

        static void Main(string[] args) {

            var lib = new StudentLib();
            //get list of all students
            var students = lib.ListStudents();
            foreach(var s in students) {
                Console.WriteLine($"{s.Firstname} {s.Lastname}");
            }
            //get a student by primary key    
            var student = lib.GetStudent(1);
            if (student == null) {
                Console.WriteLine("Student Not Found");
            }   else {
                Console.WriteLine($"S4: {student.Firstname} {student.Lastname}");
            }

            //this should fail
            var s444 = lib.GetStudent(444);
            if(s444 == null) {
                Console.WriteLine("Student not found");
            }
            else {
                Console.WriteLine($"S444: {student.Firstname} {student.Lastname}");
            }
            }
    }
}
