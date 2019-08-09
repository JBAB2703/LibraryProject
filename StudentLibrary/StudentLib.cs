using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLibrary {

    public class StudentLib {

        public static string About = "About StudentLib";

        public List<Student> ListStudents() {
            var db = new AppEfDbContext();
            return db.Students.ToList();

        }
        public Student GetStudent(int id) {
            var db = new AppEfDbContext();
            return db.Students.Find(id);
        }
        
    }
}
