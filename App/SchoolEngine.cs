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

        #region Loading Methods
        private void LoadTests () {
            foreach (var curso in MySchool.CoursesList) {
                foreach (var asignatura in curso.Subjects) {
                    foreach (var alumno in curso.Students) {
                        var rnd = new Random (System.Environment.TickCount);

                        for (int i = 0; i < 5; i++) {
                            var ev = new Tests {
                                ItsSubject = asignatura,
                                Name = $"{asignatura.Name} Ev#{i + 1}",
                                grade = (float) (5 * rnd.NextDouble ()),
                                By = alumno
                            };
                            alumno.Surveys.Add (ev);
                        }
                    }
                }
            }
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

        #endregion
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

        public List<BaseObject> GetBaseInstances (
            out int counterStudents,
            out int counterSurveys,
            out int counterSubjects,
            out int counterCourses,
            bool includesSurveys = true,
            bool includesStudents = true,
            bool includesSubjects = true,
            bool includesCourses = true) {
            var listaObj = new List<BaseObject> ();
            listaObj.Add (MySchool);
            listaObj.AddRange (MySchool.CoursesList);
            counterCourses = counterSurveys = counterSubjects = counterStudents = 0;
            if (includesCourses) {
                counterCourses = MySchool.CoursesList.Count;
                foreach (var curso in MySchool.CoursesList) {
                    if (includesSubjects) {
                        listaObj.AddRange (curso.Subjects);
                        counterSubjects += curso.Subjects.Count;
                    }

                    if (includesStudents) {
                        listaObj.AddRange (curso.Students);
                        counterStudents += curso.Students.Count;
                    }
                    if (includesSurveys) {
                        foreach (var alumno in curso.Students) {
                            counterSurveys += alumno.Surveys.Count;
                            listaObj.AddRange (alumno.Surveys);
                        }
                    }
                }
            }

            return listaObj;
        }
        public List<BaseObject> GetBaseInstances () {
            var listaObj = new List<BaseObject> ();
            listaObj.Add (MySchool);
            listaObj.AddRange (MySchool.CoursesList);

            foreach (var curso in MySchool.CoursesList) {
                listaObj.AddRange (curso.Subjects);
                listaObj.AddRange (curso.Students);

                foreach (var alumno in curso.Students) {
                    listaObj.AddRange (alumno.Surveys);
                }
            }

            return listaObj;
        }

        public (List<BaseObject>, int) GetBaseInstances (
            bool includesSurveys = true,
            bool includesStudents = true,
            bool includesSubjects = true,
            bool includesCourses = true) {
            var listaObj = new List<BaseObject> ();
            listaObj.Add (MySchool);
            listaObj.AddRange (MySchool.CoursesList);
            int counterSurvers = 0;
            if (includesCourses) {
                foreach (var curso in MySchool.CoursesList) {
                    if (includesSubjects)
                        listaObj.AddRange (curso.Subjects);
                    if (includesStudents)
                        listaObj.AddRange (curso.Students);
                    if (includesSurveys) {
                        foreach (var alumno in curso.Students) {
                            counterSurvers++;
                            listaObj.AddRange (alumno.Surveys);
                        }
                    }
                }
            }

            return (listaObj, counterSurvers);
        }
    }
}