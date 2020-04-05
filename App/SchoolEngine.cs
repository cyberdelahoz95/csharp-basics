using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entities;

namespace CoreEscuela {
    public class SchoolEngine {
        public SchoolEngine (School mySchool) {
            this.MySchool = mySchool;
        }
        public School MySchool { get; set; }

        public SchoolEngine () {

        }
        public void Init () {
            MySchool = new School (
                "Platzi Academy",
                2012,
                TypesOfSchool.Elementary,
                pais: "Argentina",
                city: "Buenos Aires"
            );

            LoadCourses ();
            LoadSubjects ();
            LoadTests ();
        }

        private void LoadTests () {
            throw new NotImplementedException ();
        }

        private void LoadSubjects () {
            foreach (var course in MySchool.CoursesList) {
                List<Subject> subjectList = new List<Subject> () {
                    new Subject { Name = "Matemáticas" },
                    new Subject { Name = "Educación Física" },
                    new Subject { Name = "Castellano" },
                    new Subject { Name = "Ciencias Naturales" }
                };
                course.Subjects = subjectList;
            }
        }

        private List<Student> GenerateStudentsRandomly (int size) {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var studentsList = from n1 in name1
            from n2 in name2
            from ln1 in lastName1
            select new Student { Name = $"{n1} {n2} {ln1}" };
            return studentsList.OrderBy ((student) => student.UniqueId).Take (size).ToList ();
        }

        private void LoadCourses () {
            MySchool.CoursesList = new List<Course> () {
                new Course () { Name = "101" },
                new Course () { Name = "102" },
                new Course () { Name = "103" }
            };

            Random rnd = new Random ();
            int randomNumber = 0;
            foreach (var course in MySchool.CoursesList) {
                randomNumber = rnd.Next (5, 20);
                course.Students = GenerateStudentsRandomly (randomNumber);
            }
        }
    }
}