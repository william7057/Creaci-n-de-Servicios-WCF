using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Data
{
    public class CourseDataService
    {
        private List<Course> Courses { get; set; }
        string route = @"C:\proyectos\tmp\course.dat";


        public CourseDataService()
        {

            if (File.Exists(route))
            {
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(route, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    Courses = (List<Course>)formatter.Deserialize(stream); //deserializa archivo para convertir en lista
                }
            }
            else
            {
                Courses = new List<Course>();
                CreateCourses();
            }
        }
        //Crea Obejto curso para utilizarlos en las pruebas

        private void CreateCourses() {
            this.Courses.Add(new Course()
            {
                CourseId = 1,
                Name = "Introduccion a servicios web con .Net",
                Duration = 10800,
                InstrctorName = "Noemi Leon"

            });
            this.Courses.Add(new Course()
            {
                CourseId = 2,
                Name = "Introduccion a React",
                Duration = 16000,
                InstrctorName = "Uriel Hermandez"

            });

            Save();
        }
        //guarda cursos de la lista course en archivo serializado
        private void Save() {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(route, FileMode.Create, FileAccess.Write))
            {
               formatter.Serialize(stream, Courses); 
            }
        }
        //obtiene lista de alumnos
        public Course[] GetCourses() {
            return Courses.ToArray();
        }
        //Obtiene Curso por Id
        public Course GetCourseById(int id) {

            return Courses.SingleOrDefault(p => p.CourseId == id);
        }

        //Agrega un Curso
        public void AddCourse(Course course) {
            var LastCourseId = Courses.Max(c => c.CourseId);
            course.CourseId = LastCourseId + 1;
            Courses.Add(course);
            Save();
        
        }
        //elimina un Curso

        public void DeleteCourse(int id) {
            var course = Courses.SingleOrDefault(c => c.CourseId == id);
            Courses.Remove(course);
            Save();
        
        }
    }

}
