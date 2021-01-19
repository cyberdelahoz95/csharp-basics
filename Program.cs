using System;
using CoreEscuela.Entities;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Util;

namespace CoreEscuela {
    class Program {
        static void Main (string[] args) {
            var engine = new SchoolEngine ();
            engine.Init ();
            printSchoolCourses (engine.MySchool);

            var objectsList = engine.GetBaseInstances (out int counterStudents,
                out int counterSurveys,
                out int dummy,
                out dummy);
            //var IVenueList = from obj in objectsList where obj is IVenue select (IVenue) obj;

            engine.MySchool.ClenAddress ();

            /*miEscuela.Courses = new Course[] {
                new Course () { Name = "101" },
                new Course () { Name = "102" },
                new Course () { Name = "103" }
            };

            var anotherCoursesList = new List<Course> () {
                new Course () { Name = "104" },
                new Course () { Name = "105" },
                new Course () { Name = "106" }
            };

            miEscuela.CoursesList.AddRange (anotherCoursesList);

            Course tempCourse = new Course () { Name = "Temp" };

            miEscuela.CoursesList.Add (new Course () { Name = "201" });
            miEscuela.CoursesList.Add (tempCourse);

            printSchoolCourses (miEscuela);

            Predicate<Course> myEvaluator = PredicateForRemoving;
            miEscuela.CoursesList.RemoveAll (myEvaluator);
            miEscuela.CoursesList.Remove (tempCourse);
            miEscuela.CoursesList.RemoveAll(delegate (Course currentCourse) {return currentCourse.Name == "Temp";});
            miEscuela.CoursesList.RemoveAll((currentCourse) => currentCourse.Name == "Temp");


            printSchoolCourses (miEscuela);

            anotherCoursesList.Clear ();

            miEscuela.Country = "Colombia";
            miEscuela.City = "Bogotá";
            miEscuela.Type = TypesOfSchool.Elementary;
            Course[] coursesArray = {
                new Course () {
                    Name = "101"
                }, new Course () {
                    Name = "102"
                }, new Course () {
                    Name = "103"
                }
            };
            var coursesArray = new Course[] {
                new Course () {
                    Name = "101"
                }, new Course () {
                    Name = "102"
                }, new Course () {
                    Name = "103"
                }
            };

                var coursesArray = new Course[3] {
                new Course () {
                    Name = "101"
                }, new Course () {
                    Name = "102"
                }, new Course () {
                    Name = "103"
                }
            };
            PrintCoursesWhile (coursesArray); */
        }

        /*private static bool PredicateForRemoving (Course currentCourse) {
            return (currentCourse.Name == "Temp");
        }*/

        private static void printSchoolCourses (School school) {
            if (school?.CoursesList != null) // previous expresiion is equal to (school!= null && school.Courses != null)
            {
                foreach (var course in school.CoursesList) {
                    Console.WriteLine (course.Name);
                }
            }
        }

        private static void PrintCoursesWhile (Course[] coursesArray) {
            int count = 0;
            while (count < coursesArray.Length) {
                WriteLine ($"{coursesArray[count].Name}");
                count++;
            }
        }

        private static void PrintCoursesDoWhile (Course[] coursesArray) {
            int count = 0;
            do {
                WriteLine ($"{coursesArray[count].Name}");
                count++;
            } while (count < coursesArray.Length);
        }

        private static void PrintCoursesFor (Course[] coursesArray) {
            for (int i = 0; i < coursesArray.Length; i++) {
                WriteLine ($"{coursesArray[i].Name}");
            }
        }

        private static void PrintCoursesForEach (Course[] coursesArray) {
            foreach (var course in coursesArray) {
                WriteLine ($"{course.Name}");
            }
        }
    }
}