using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLibrary {
    public class StudentLib
    {
        public static string About = "About StudentLib";
        public List<Student> ListStudents()
        {
            var db = new AppEfDbContext();
            return db.Students.ToList();
        }
        public Student GetStudent(int id)
        {
            var db = new AppEfDbContext();
            return db.Students.Find(id);
        }
        public bool UpdateStudent(Student s)
        {
            var db = new AppEfDbContext();
            var sDb = GetStudent(s.Id);
            if (sDb == null)
            {
                throw new Exception("Student cannot be found");
            }
            sDb.Firstname = s.Firstname;
            sDb.Lastname = s.Lastname;
            sDb.Gpa = s.Gpa;
            sDb.Sat = s.Sat;
            sDb.IsFulltime = s.IsFulltime;
            sDb.MajorId = s.MajorId;
            if (s.MajorId != null)
            {
                var major = db.Majors.Find(s.MajorId);
                if (major == null)
                {
                    return false;
                }
            }
            //db.Update<Student>(sDb);
            db.Students.Update(sDb);
            db.SaveChanges();
            return true;
        }
        public bool DeleteStudent(Student dS)
        {
            var db = new AppEfDbContext();
            var sDb = GetStudent(dS.Id);
            if (sDb == null)
            {
                return false;
            }
            db.Students.Remove(sDb);
            db.SaveChanges();
            return true;
        }
        public bool InsertStudent(Student s){
            var db = new AppEfDbContext();
            s.Id = 0;
            if (s.MajorId != null){
                var major = db.Majors.Find(s.MajorId);
                if (major == null){
                    return false;
                }
            }
            db.Students.Add(s);
            db.SaveChanges();
            return true;
        }
    }
}

