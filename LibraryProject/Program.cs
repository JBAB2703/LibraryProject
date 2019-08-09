using System;
using StudentLibrary;
//using JesseUtilitiesLibrary;

namespace LibraryProject {

    class Program {

        static void Main(string[] args) {

            var lib = new StudentLib();
            //insert a student (elmer fudd)
            var ef = new Student
            {
                Id = 0,
                Firstname = "Elmer",
                Lastname = "Fudd",
                Sat = 600,
                Gpa = 1.5,
                IsFulltime = true,
                MajorId = 1
            };
            var ok = lib.InsertStudent(ef);
            Console.WriteLine(ef);
            Console.WriteLine((ok ? "Insert Successful!" : "Insert Failed!"));

            //remove a student
            var johnsmith = lib.GetStudent(2);
            lib.DeleteStudent(johnsmith);
            
            //update jon smith id=(2)
            var jonsmith = lib.GetStudent(2);
            jonsmith.Firstname = "John";
            var success = lib.UpdateStudent(jonsmith);

            //get list of all students
            var students = lib.ListStudents();

            foreach(var s in students) {
                Console.WriteLine($"{s.Firstname} {s.Lastname} {s.Major?.Description}");
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
